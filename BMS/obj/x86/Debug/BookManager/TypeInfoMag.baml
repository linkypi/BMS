   M S B A M L   `   `   `  ����  BMS!    BMS.BookManager.TypeInfoMag   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5   
   Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	        N� ShowsNavigationUI  .  $��Stretch=�5
   
   $��Stretch=�6(    N� Title$ TypeInfoMag��5      .��5      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5       .��5   
   ]� $��LeftToRight=�6   $��Stretch=�60   $��Stretch=�6N   .+�5      ]� $	��Top=�6   .+�5      & 
  Telerik.Windows.Controls.RadMenu  -   5          Name$ radMenu��5   "   
����ح�$	��Top=�6L   ' 
 !Telerik.Windows.Controls.MenuBase   ClickToOpen .  $��12(�6}   .@�5      * 
 $Telerik.Windows.Controls.RadMenuItem  -   5          Name$ delete��5   *   $��删除��6:   6F   5      5      ]� 5      $	��Top=�6   .+�5      � 
�������$��LeftToRight=�63   $	��Top=�6O   $��0 2 0 2q�6d   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5      �� $��图书类别:��6$   $��50��61   6>   �� 5      -   5        $��sc_typeName��5   "   $	��120��65   $��23��6A   $��10 0 0 0q�6M   6a   5      �� 5      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5   T   $��80��6,   $��23��67      CornerRadius$ 3��6C   $��查  询��6b   6�   5      5       5!      ]� 5#      $	��Top=�6   $��Stretch=�6-   $��Stretch=�6K   .+�5$      ]� -   5         ]�Name$ panel��5$      $��Bottom=�6,   $��Stretch=�6L   $��LeftToRight=�6j   .+�5%      /  )Telerik.Windows.Controls.RadNumericUpDown  -   5          Name$ pagesize��5%   0   $��Right=�6B   +  %Telerik.Windows.Controls.RadRangeBase	   Minimum$	 1Q�6~   
   Value$
 30X�6�   $��40��6�      NumberDecimalDigits$ 0��6�   +  %Telerik.Windows.Controls.RadDataPager  5&      -   5          Name$
 page��5&   ,   $
��Left=�6<      PageSize$ 30��5'         AutoEllipsisMode$
 Both=�6$      DisplayMode$	 All=�6=      NumericButtonCount$ 10��6O   $��30��6h   5)      *	 	 $Telerik.Windows.Controls.RadGridView	  5,      -	   5         	 Name$ GridList��5,   &   $	��500��68   ;
 	 5Telerik.Windows.Controls.GridView.GridViewDataControl 
  GridLinesVisibility$
 Both=�6x   $	��Top=�6�    
  ShowColumnHeaders .  
  CanUserInsertRows .   
  ShowGroupPanel .   
  RowIndicatorVisibility$ 	Collapsed=�5-   .    
  IsFilteringAllowed .  
  CanUserFreezeColumns .   
  
IsReadOnly .  
  AutoGenerateColumns .   
  IsBusy .   
  SelectionMode$ Extended=�5/   =    
  CanUserSortColumns .   
  CanUserReorderColumns .   
  Columns 50      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  51      1 	 +Telerik.Windows.Controls.GridViewDataColumn  52      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase    Header$  类别��6^   - 	 'Telerik.Windows.Controls.GridViewColumn!   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
! auto 6j   "   
IsReadOnly" . #   HeaderTextAlignment$# Center=�6�   $   IsGroupable$ .  %   IsFilterable% .  &   DataMemberBinding& 65   �� *	BTypeName+6�   55      56      ]� 58      $��Bottom=�6   $��LeftToRight=�60   .+�59      � 
�������$��LeftToRight=�63   $��Right=�6O   $��0 2 0 2q�6f   .+�5:      �� $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5;      �� $��图书类别：��6$   63   �� 5<      -
   5        $
��type��5<   "   $��23��6.   $	��120��6:   6H   5=      �� 5>      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5?        -   5        $��80��5?   ,   $��23��67   $ 3��6C   $��添  加��6T   6}   5@      5A      � 5B      
�������$��LeftToRight=�63   $
��Left=�6O   $��0 2 0 2q�6e   .+�5C      �� $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5D      �� $��图书类别：��6$   63   �� 5E      -   5        $��updtype��5E   "   $��23��61   $	��120��6=   6K   5F      �� 5G      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5H        -   5        $��80��5H   ,   $��23��67   $ 3��6C   $��修  改��6T   6   5I      5J      5K      5M      5N      5O      