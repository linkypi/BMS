   M S B A M L   `   `   `  ����>  :BMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BMS.Common
BMS.Common  5          
BMS.Search   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5   
   0modelclr-namespace:BMS.Common     	 
  5      Gsdk9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   
   Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
        N� ShowsNavigationUI  .  $��Stretch=�5   
   $��Stretch=�6(    N� Title$ Search��5       � 	Resources 5      )   #BMS.Common.GridViewRowStyleSelector   SelectorStyle   
GreenStyle �� 
TargetType3 	 -Telerik.Windows.Controls.GridView.GridViewRow �� Property �� Value �� Triggers)  #Telerik.Windows.Controls.RadRowItem P� Property	 P� Value
   RedStyle��%�  &	          5   
    5      �� 5      "  6   .�5      ��  � ��
 ����67    5      P� 5       �@ 
IsSelected	 . . �5      ��  � ��
 ����6?   5      5      
 5      �� 5      "  6   .�5      ��  � ��
 �����67    5      P� 5       �@ 
IsSelected	 . . �5      ��  � ��
 �����6?   5      5!      5#      5$      .��5&      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5&       .��5(   
   ]� $��LeftToRight=�6   $��Stretch=�60   $��Stretch=�6N   .+�52      ]� $	��Top=�6   .+�53      � 
�������$��LeftToRight=�63   $	��Top=�6O   $��0 2 0 2q�6d   .+�54      ��  �� Orientation$ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�55      �� $��书名:��6$   $��50��6/   6<   �� 56      -   5        $��sc_bookName��56   "   $	��120��65   $��23��6A   6O   57      �� 58      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�59      �� $��作者:��6$   $��50��6/   6<   �� 5:      -   5        $��	sc_author��5:   "   $	��120��63   $��23��6?   6M   5;      �� 5<      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5=      �� $��类型:��6$   $��50��6/   6<   �� 5>      -   5        $��sc_type��5>   #    �� DisplayMemberPath$ 	BTypeName��62    �� SelectedValuePath$ TypeID��6P   $	��120��6k   $��23��6w   6�   5?      �� 5A      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5B      �� $��
关键字:��6$   $��50��60   6=   �� 5C      -   5        $��sc_bkey��5C   "   $	��120��61   $��23��6=   6K   5D      �� 5F      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5G      �� $��
出版社:��6$   $��50��60   6=   �� 5H      -   5        $��sc_publisher��5H   "   $	��120��66   $��23��6B   6P   5I      �� 5K      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5L      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5L   =      CornerRadius$ 3��6,   $��查询��6K   $��80��6X   $��23��6c   5M      5O      5Q      5R      ]� 5T      $��Bottom=�6   $��Stretch=�60   $��Stretch=�6N   .+�5U      ]� -   5         ]�Name$ panel��5U      $��Bottom=�6,   $��Stretch=�6L   $��LeftToRight=�6j   .+�5V      /  )Telerik.Windows.Controls.RadNumericUpDown  -	   5          Name$ pagesize��5V   0   $��Right=�6B   +  %Telerik.Windows.Controls.RadRangeBase   Minimum$ 1Q�6~      Value$ 30X�6�   $��40��6�      NumberDecimalDigits$ 0��6�   +  %Telerik.Windows.Controls.RadDataPager  5W      -
   5          Name$
 page��5W   ,   $
��Left=�6<      PageSize$ 30��5X         AutoEllipsisMode$
 Both=�6$      DisplayMode$	 All=�6=      NumericButtonCount$ 10��6O   $��30��6h   5Z      *	 	 $Telerik.Windows.Controls.RadGridView	  5]      -   5         	 Name$ GridList��5]   &   ;
 	 5Telerik.Windows.Controls.GridView.GridViewDataControl 
  GridLinesVisibility$
 Both=�69   $	��Top=�6U    
  ShowColumnHeaders .  
  CanUserInsertRows .   
  RowStyleSelector# [  5^   D    
  ShowGroupPanel .   
  RowIndicatorVisibility$ 	Collapsed=�6�     
  IsFilteringAllowed  . $	��100��5_      ! 
  CanUserFreezeColumns! .  " 
  
IsReadOnly" . # 
  AutoGenerateColumns# .  $ 
  IsBusy$ .  % 
  SelectionMode$% Extended=�5`   =   & 
  CanUserSortColumns& .  ' 
  CanUserReorderColumns' .  ( 
  Columns( 5b      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  5c      1 	 +Telerik.Windows.Controls.GridViewDataColumn  5d      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase)   Header$) 	位置号��6l   - 	 'Telerik.Windows.Controls.GridViewColumn*   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
* auto 6y   +   
IsReadOnly+ . ,   HeaderTextAlignment$, Center=�6�   -   IsGroupable- .  .   IsFilterable. .  /   DataMemberBinding/ 65   �� *
SMPosition+0 �� Mode$0 OneWay=�6�     5e      $) 	序列号��6k   $
* auto 6x   + . $, Center=�6�   - .  . .  / 65   �� *	SerialNum+$0 OneWay=�6�     5f      $) 书名��6j   $
* auto 6v   + . $, Center=�6�   - .  . .  / 65   �� *
BookName+$0 OneWay=�6�     5g      $) 作者��6i   $
* auto 6u   + . $, Center=�6�   - .  . .  / 65   �� *	BAuthor+$0 OneWay=�6�     5i      $) 类别��6k   $
* auto 6w   + . $, Center=�6�   - .  . .  / 65   �� *	BTypeName+$0 OneWay=�6�     5k      $) 价格��6h   $
* auto 6t   + . $, Center=�6�   - .  . .  / 65   �� *BPrice+$0 OneWay=�6�     5l      $) 	出版社��6k   $
* auto 6x   + . $, Center=�6�   - .  . .  / 65   �� *	Publisher+$0 OneWay=�6�     5m      $) 出版日期��6i   $
* auto 6w   + . $, Center=�6�   - .  . .  / 65   �� *	PubDate+$0 OneWay=�6�     5n      $) 状态��6f   $
* auto 6r   + . $, Center=�6�   - .  . .  / 65   �� *Note+$0 OneWay=�6�   5q      5r      5s      5t      5u      