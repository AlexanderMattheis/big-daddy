   M S B A M L   `   `   `  ����C  ?BigDaddy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BigDaddyBigDaddy  5      H DBigDaddy.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:BigDaddy.Core;assembly=BigDaddy.CoreBigDaddy.Core 5          BigDaddy.OpenExpander   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:BigDaddy     5      Ccore2clr-namespace:BigDaddy.Core;assembly=BigDaddy.Core     5        9� 
IsExpanded  . ��5	      �� *Name+.��5      �� .+�5   
   ]� .+�5      �� $��80��6   ��6   �� *LowerBoundName+�� 5      -   5         ��Name$ LowerBoundTextBox��5      $��5q�61   .��6=   ��5      �� 5       �� Path$ LowerBoundValue�6    �� UpdateSourceTrigger$ PropertyChanged=�65    �� ValidationRules 5         BigDaddy.MinRule  5      
   Min$ 1��6,   5      .��5       5      5      ]� 5   
   .+�5      �� $��80��6   ��6   �� *UpperBoundName+�� 5      -   5        $ UpperBoundTextBox��5      $��5q�61   .��6<   ��5      �� 5      $ UpperBoundValue�6   $ PropertyChanged=�65    5         5!      $ 1��6,   5#      .��5$       5%      5&      ]� 5(   
   .+�5)      �� $��80��6   ��6   �� *SeparatorName+�� 5*      $��5q�6   ��6!   �� *SeparatorValue+5+      �� 5-   
   $��5q�6    d� 	IsChecked 6   �� *" DetermineTotalNumberOfLinesValue+.��5.      �� $
��Wrap=�6   ��6,   �� *!DetermineTotalNumberOfLinesName+5/      �� 51   
   -   5         ��Name$ ReimportButton��51      $��5q�6)    ^� ShowOnDisabled . ��64   �� *ReimportName+��52      �� 53      	 �� 
TargetType"	 ��6   .�54      �� 
 �� Property
 �@�ToolTip �� Value 60   �� *ValidationErrorTooltip+�� 55      
 � {� .  62    �� Triggers 56      ^� 57       ^� 
Conditions 58      �� 59   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ LowerBoundTextBox�� �� Value	 False6z   �� 5:   "    6,   �� *LastLoadedFileName+ �� 	Converter '  !BigDaddy.ObjectExistenceConverter   True6   �� 5;   "    6,   �� $ (Validation.HasError)�$ UpperBoundTextBox��	 False6z   .0�5=      �� 
 � {� . 6:   �� 5>      
 �@�ToolTip 68   Z� 5?      5A      5C         BigDaddy.LoadingButton  5E   
      BigDaddy.LoadingButton   Click$ ImportButton_Click��6H   $��5q�6    . ��6)   �� *
ImportName+��5F      �� 5G      "	 ��6   .�5H      �� 
 �@�ToolTip 60   �� *ValidationErrorTooltip+�� 5I      
 � {� .  62    5J      ^� 5K       5L      �� 5M   "    6,   �� $ (Validation.HasError)�$ LowerBoundTextBox��	 False6z   �� 5N   "    6,   �� $ (Validation.HasError)�$ UpperBoundTextBox��	 False6z   .0�5P      �� 
 � {� . 6:   �� 5Q      
 �@�ToolTip 68   Z� 5R      5T      5V      5W      5Y      