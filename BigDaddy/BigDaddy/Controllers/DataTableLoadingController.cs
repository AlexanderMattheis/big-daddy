using BigDaddy.Core;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using static BigDaddy.Core.MainStatusBarViewModel;

namespace BigDaddy
{
    internal class DataTableLoadingController
    {
        private OpenExpanderViewModel openExpanderViewModel;

        private BackgroundWorker fileLoadWorker;

        internal void StartOpenFileDialog(OpenExpanderViewModel openExpanderViewModel)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                StoreViewModel(openExpanderViewModel);
                openExpanderViewModel.LastLoadedFileName = openFileDialog.FileName;
                OpenFile(openFileDialog.FileName, null);
            }
        }

        internal void OpenLastFile(int? numberOfNewRows)
        {
            OpenFile(openExpanderViewModel.LastLoadedFileName, numberOfNewRows);
        }

        internal void Cancel()
        {
            fileLoadWorker.CancelAsync();
        }

        private void OpenFile(string filePath, int? numberOfNewRows)
        {
            fileLoadWorker = new BackgroundWorker();

            fileLoadWorker.DoWork += LoadFile; // '+=' subscribe and '-=' unscribe
            fileLoadWorker.WorkerSupportsCancellation = true;
            fileLoadWorker.RunWorkerAsync(new ImportParameters(
                filePath,
                openExpanderViewModel.LowerBoundValue,
                openExpanderViewModel.UpperBoundValue,
                openExpanderViewModel.SeparatorValue,
                new ImportOptions(openExpanderViewModel.DetermineTotalNumberOfLinesValue),
                numberOfNewRows));

            fileLoadWorker.RunWorkerCompleted += FinishLoading;
        }

        private void StoreViewModel(OpenExpanderViewModel openExpanderViewModel)
        {
            this.openExpanderViewModel = openExpanderViewModel;
            openExpanderViewModel.IsImporting = true;
        }

        private void LoadFile(object sender, DoWorkEventArgs e)
        {
            var importParameters = (ImportParameters) e.Argument;

            if (!File.Exists(importParameters.FilePath))
            {
                return;
            }

            using (StreamReader streamReader = new StreamReader(importParameters.FilePath))
            {
                DataGridViewModel dataGridViewModel = null;

                Application.Current.Dispatcher.Invoke(() => {
                    ((MainWindowViewModel)Application.Current.MainWindow.DataContext).IsLoading = true;

                    var mainStatusBarViewModel = ((MainWindow)Application.Current.MainWindow).StatusBarModel;
                    mainStatusBarViewModel.IsWorking = true;
                    mainStatusBarViewModel.ProgressBarValue = 0;
                    mainStatusBarViewModel.ProgressBarStatus = LoadingStatus.Loading;
                    dataGridViewModel = ((MainWindow)Application.Current.MainWindow).TableModel;
                });

                LoadData data;

                try
                {
                    data = importParameters.NumberOfNewRows.HasValue
                        ? GetData(streamReader, dataGridViewModel.ImportData.Lines, dataGridViewModel.ImportData.StartRowNumber, dataGridViewModel.ImportData.EndRowNumber, importParameters.NumberOfNewRows.Value)
                        : GetData(streamReader, importParameters.LowerBound, importParameters.UpperBound, importParameters.ImportOptions.IsDetermineTotalNumberOfLinesActive);
                }
                catch (OutOfMemoryException)
                {
                    data = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    data = new LoadData(new ObservableCollection<string>(), 0, 0);
                    MessageBox.Show(
                        Strings.Error_NotEnoughMemoryToLoadAllLinesText,
                        Strings.Error_NotEnoughMemoryToLoadAllLinesCaption,
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (fileLoadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        dataGridViewModel.ImportData = new CsvImportData()
                        {
                            Lines = data.Lines,
                            StartRowNumber = importParameters.LowerBound,
                            EndRowNumber = importParameters.UpperBound,
                            Separators = new string[] { importParameters.Separator }
                        };
                    }

                    ((MainWindowViewModel)Application.Current.MainWindow.DataContext).IsLoading = false;
                    var mainStatusBarViewModel = ((MainWindow)Application.Current.MainWindow).StatusBarModel;

                    mainStatusBarViewModel.LinesValue = data.NumberOfLoadedLines;
                    mainStatusBarViewModel.TotalLinesValue = data.TotalNumberOfLines ?? mainStatusBarViewModel.TotalLinesValue;
                    mainStatusBarViewModel.IsWorking = false;
                    mainStatusBarViewModel.ProgressBarValue = 100;
                    mainStatusBarViewModel.ProgressBarStatus = LoadingStatus.Finished;
                });
            }
        }

        private LoadData GetData(StreamReader streamReader, ObservableCollection<string> lines, int _startRowNumber, int endRowNumber, int numberOfNewRows)
        {
            var newLines = new ObservableCollection<string>();

            string line;
            var currentNumberOfLines = 0;
            var numberOfLinesUntilPause = Config.Get<int>("MainStatusBar.NumberOfLinesUntilPause");

            while ((line = streamReader.ReadLine()) != null)
            {
                if (fileLoadWorker.CancellationPending)
                {
                    break;
                }

                if (endRowNumber <= currentNumberOfLines && currentNumberOfLines <= endRowNumber + numberOfNewRows)
                {
                    newLines.Add(line);
                }

                if (numberOfLinesUntilPause <= 0)
                {
                    numberOfLinesUntilPause = Config.Get<int>("MainStatusBar.NumberOfLinesUntilPause");
                    System.Threading.Thread.Sleep(1);
                }

                numberOfLinesUntilPause--;
                currentNumberOfLines++;
            }

            var finalLines = (ObservableCollection<string>) lines.Union(newLines);
            return new LoadData(finalLines, finalLines.Count - 1, null);
        }

        private LoadData GetData(StreamReader streamReader, int lowerBound, int upperBound, bool determineTotalNumberOfLines)
        {
            ObservableCollection<string> lines = new ObservableCollection<string>();

            string line;

            var currentNumberOfLines = 0;
            var numberOfLinesUntilPause = Config.Get<int>("MainStatusBar.NumberOfLinesUntilPause");

            while ((line = streamReader.ReadLine()) != null)
            {
                if (fileLoadWorker.CancellationPending)
                {
                    break;
                }

                if (currentNumberOfLines == 0) // always read the header
                {
                    lines.Add(line);
                    currentNumberOfLines++;
                    continue; // to read the header only once
                }

                if (lowerBound <= currentNumberOfLines && currentNumberOfLines <= upperBound)
                {
                    lines.Add(line);
                }

                if (!determineTotalNumberOfLines && currentNumberOfLines >= upperBound)
                {
                    break;
                }

                if (numberOfLinesUntilPause <= 0)
                {
                    numberOfLinesUntilPause = Config.Get<int>("MainStatusBar.NumberOfLinesUntilPause");
                    System.Threading.Thread.Sleep(1);
                }

                numberOfLinesUntilPause--;
                currentNumberOfLines++;
            }

            int totalLinesCount = determineTotalNumberOfLines ? currentNumberOfLines - 1 : -1;
            return new LoadData(lines, lines.Count - 1, totalLinesCount); // '-1' since the header is not counted
        }

        private void FinishLoading(object sender, RunWorkerCompletedEventArgs e)
        {
            openExpanderViewModel.IsImporting = false;
        }

        internal class ImportParameters
        {
            internal string FilePath { get; }

            internal int LowerBound { get; }

            internal int UpperBound { get; }

            internal string Separator { get; }

            internal ImportOptions ImportOptions { get; }

            internal int? NumberOfNewRows { get; }

            internal ImportParameters(string filePath, int lowerBound, int upperBound, string separator, ImportOptions importOptions, int? numberOfNewRows)
            {
                FilePath = filePath;
                LowerBound = lowerBound;
                UpperBound = upperBound;
                Separator = separator;
                ImportOptions = importOptions;
                NumberOfNewRows = numberOfNewRows;
            }
        }

        internal class ImportOptions
        {
            internal bool IsDetermineTotalNumberOfLinesActive { get; }

            internal ImportOptions(bool? determineTotalNumberOfLines)
            {
                IsDetermineTotalNumberOfLinesActive = determineTotalNumberOfLines ?? false;
            }
        }

        internal class LoadData
        {
            internal ObservableCollection<string> Lines { get; }

            internal int NumberOfLoadedLines { get; }

            internal int? TotalNumberOfLines { get; }

            internal LoadData(ObservableCollection<string> lines, int numberOfLoadedLines, int? totalNumberOfLines)
            {
                Lines = lines;
                NumberOfLoadedLines = numberOfLoadedLines;
                TotalNumberOfLines = totalNumberOfLines;
            }
        }
    }
}
