   M S B A M L   `   `   `  ����>  :BMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BMS.Common
BMS.Common  5      -clr-namespace:BMS.MyControlBMS.MyControl  5
          BMS.BookManager.History   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gsdk9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      (modelclr-namespace:BMS.Common    5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5	      0myclr-namespace:BMS.MyControl     	 
  5
      Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5        N� Title$  History��5       � 	Resources 5      )   #BMS.Common.GridViewRowStyleSelector   SelectorStyle   
GreenStyle �� 
TargetType3 	 -Telerik.Windows.Controls.GridView.GridViewRow �� Property �� Value �� Triggers)  #Telerik.Windows.Controls.RadRowItem P� Property P� Value	   RedStyle��%�  &	          5   
    5      �� 5      "  6   .�5      ��  � ��
 ����67    5      P� 5       �@ 
IsSelected . . �5      ��  � ��
 ����6?   5      5      	 5      �� 5      "  6   .�5      ��  � ��
 �����67    5      P� 5       �@ 
IsSelected . . �5      ��  � ��
 �����6?   5       5"      5$      5%      .��5&      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5&       .��5'   
   ]� .+�5(      ]� $	��Top=�6   .+�5)      � 
�������$��LeftToRight=�63   $	��Top=�6O   $��0 2 0 2q�6d   .+�5/      �� 
 �� Orientation$
 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�50      �� $��
借书人:��6$   $��50��60   6=   �� 51      -   5         ��Name$
 user��51   "   $	��120��61   $��23��6=   52      �� 53      $
 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�54      �� $��状态:��6$   $��50��6/   6<   �� 55      -   5        $��isBorow��55   #   $	��120��63   $��23��6?   .@�56      �� $��全部��6+    �� 
IsSelected . 6L   �� 57      $��已还��6+   6:   �� 58      $��未还��6+   6:   59      5:      �� 5;      $
 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5<      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5<   =      CornerRadius$ 3��6,   $��查询��6K   $��80��6X   $��23��6c   5=      5?      5@      5A      ]� 5B      -   5         ]�Name$ panel��5B      $��Bottom=�6)   $��Stretch=�6I   .+�5D      /  )Telerik.Windows.Controls.RadNumericUpDown  -   5          Name$ pagesize��5D   C   $��Right=�6+   +  %Telerik.Windows.Controls.RadRangeBase   Minimum$ 1Q�6x      Value$ 30X�6�   $��30��6�   $��50��6�      NumberDecimalDigits$ 0��6�   +  %Telerik.Windows.Controls.RadDataPager  5E      -   5          Name$
 page��5E   (   $
��Left=�68      PageSize$ 30��5F         AutoEllipsisMode$
 Both=�6$      DisplayMode$	 All=�6=      NumericButtonCount$ 10��6O   $��30��6h   5G      *	 	 $Telerik.Windows.Controls.RadGridView	  5H      -   5         	 Name$ GridList��5H   "   ;
 	 5Telerik.Windows.Controls.GridView.GridViewDataControl 
  GridLinesVisibility$
 Both=�6a   $	��Top=�6}    
  ShowColumnHeaders .  
  CanUserInsertRows .   
  ShowGroupPanel .   
  RowIndicatorVisibility$ 	Collapsed=�5I   +    
  IsFilteringAllowed .  
  CanUserFreezeColumns .    
  
IsReadOnly  . ! 
  RowStyleSelector#! [  5J   C   " 
  AutoGenerateColumns" .  # 
  IsBusy# .  $ 
  SelectionMode$$ Extended=�5K   =   % 
  CanUserSortColumns% .  & 
  CanUserReorderColumns& .  ' 
  Columns' 5L      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  5M      1 	 +Telerik.Windows.Controls.GridViewDataColumn  5N      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase(   Header$( 书名��6f   - 	 'Telerik.Windows.Controls.GridViewColumn)   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
) auto 6r   *   
IsReadOnly* . +   HeaderTextAlignment$+ Center=�6�   ,   IsGroupable, .  -   IsFilterable- .  .   DataMemberBinding. 61   �� *
BookName+/ �� Mode$/ OneWay=�6�     5Q      $( 类别��6g   $
) auto 6s   * . $+ Center=�6�   , .  - .  . 61   �� *	BTypeName+$/ OneWay=�6�     5S      $( 	借书人��6e   $
) auto 6r   * . $+ Center=�6�   , .  - .  . 61   �� *	Borower+$/ OneWay=�6�     5T      0   DataFormatString$0 {0:yyyy-MM-dd hh:mm:ss}��6g   $( 借书时间��6�   $
) auto 6�   * . $+ Center=�6�   , .  - .  . 61   �� *	BorowDate+$/ OneWay=�6�     5U      $0 {0:yyyy-MM-dd hh:mm:ss}��6i   $( 还书时间��6�   $
) auto 6�   * . $+ Center=�6�   , .  - .  . 61   �� *
ReturnDate+$/ OneWay=�6�   5X      5Z      5[      5\      