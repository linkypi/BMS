   M S B A M L   `   `   `  ����  BMS     BMS.BookManager.UpdateBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5   
   Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5        N� ShowsNavigationUI  .  $��Stretch=�5	      $��Stretch=�6"    N� Title$ 
UpdateBook��5
      .��5      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5      .��5   
   ]� $��LeftToRight=�6   $��Stretch=�60   $��Stretch=�6N   .+�5      ]� $	��Top=�6   .+�5      & 
  Telerik.Windows.Controls.RadMenu  -   5          Name$ radMenu��5   :   
����ح�$	��Top=�6K   ' 
 !Telerik.Windows.Controls.MenuBase   ClickToOpen .  $��12(�6|   .@�5      * 
 $Telerik.Windows.Controls.RadMenuItem  -   5          Name$ Sumbit��5   .   $��保存��6>   6J     5      -   5        $��删除��5   .   6V   5      5      ]� 5      $	��Top=�6   .+�5      � 
�������$��LeftToRight=�63   $	��Top=�6O   $��0 2 0 2q�6d   .+�5      ��  �� Orientation$ 
Horizontal=�6"   $��	10 5 50 5q�6;   .+�5      �� $��
位置号:��6$   $��50��60   6=   �� 5      -   5        $��sc_position��5   "   $	��120��65   $��23��6A   6O   5      �� 5      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5      �� $��
序列号:��6$   $��50��60   6=   �� 5      -   5        $��sc_serialNum��5   "   $	��120��66   $��23��6B   6P   5       �� 5!      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5"      �� $��书名:��6$   $��50��6/   6<   �� 5#      -   5        $��sc_bookName��5#   "   $	��120��65   $��23��6A   6O   5$      �� 5%      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5&      �� $��作者:��6$   $��50��6/   6<   �� 5'      -   5        $��	sc_author��5'   "   $	��120��63   $��23��6?   6M   5(      �� 5)      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5*      �� $��类型:��6$   $��50��6/   6<   �� 5+      -	   5        $��sc_type��5+   #    �� DisplayMemberPath$ 	BTypeName��62    �� SelectedValuePath$ TypeID��6P   $	��120��6k   $��23��6w   6�   5,      �� 5.      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5/      �� $��
关键字:��6$   $��50��60   6=   �� 50      -
   5        $��sc_bkey��50   "   $	��120��61   $��23��6=   6K   51      �� 57      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�58      �� $��
出版社:��6$   $��50��60   6=   �� 59      -   5        $��sc_publisher��59   "   $	��120��66   $��23��6B   6P   5:      �� 5;      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5<      �� $��出版日期:��6$   $��50��61   6>   ,  &Telerik.Windows.Controls.RadDatePicker  5=      -   5        $��
sc_pubDate��5=   a   0  *Telerik.Windows.Controls.RadDateTimePicker   DateSelectionMode$ Month=�60   	   DisplayFormat$	 Short=�6J   $	��120��6s   $��23��6   5>      �� 5?      $ 
Horizontal=�6!   $��	10 5 50 5q�6:   .+�5@      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5@   ,   
   CornerRadius$
 3��6:   $��查询��6K   $��80��6X   $��23��6c   5B      5D      5F      5G      ]� 5H      $	��Top=�6   .+�5I      ]� -   5         ]�Name$ panel��5I      $��Bottom=�6-   $��Stretch=�6M   .+�5K      /  )Telerik.Windows.Controls.RadNumericUpDown  -   5          Name$ pagesize��5K   G   $��Right=�6/   +	  %Telerik.Windows.Controls.RadRangeBase 	  Minimum$ 1Q�6Y    	  Value$ 30X�6e   $��50��6q      NumberDecimalDigits$ 0��6|   +
  %Telerik.Windows.Controls.RadDataPager
  5L      -   5         
 Name$
 page��5L   ,   $
��Left=�6<    
  PageSize$ 30��5M       
  AutoEllipsisMode$
 Both=�6$    
  DisplayMode$	 All=�6=    
  NumericButtonCount$ 10��6O   $��30��6h   5N      * 	 $Telerik.Windows.Controls.RadGridView  5O      -   5          Name$ GridList��5O   "   ; 	 5Telerik.Windows.Controls.GridView.GridViewDataControl   GridLinesVisibility$
 Both=�6d   $	��Top=�6�      ShowColumnHeaders .    CanUserInsertRows .  $	��150��5P      $	��200��6$      ShowGroupPanel .     RowIndicatorVisibility$ 	Collapsed=�6P      IsFilteringAllowed .    CanUserFreezeColumns .     
IsReadOnly .    AutoGenerateColumns .     IsBusy .      SelectionMode$  Extended=�5R   =   !   CanUserSortColumns! .  "   CanUserReorderColumns" .  #   Columns# 5S      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  5T      1 	 +Telerik.Windows.Controls.GridViewDataColumn  5U      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase$   Header$$ 	位置号��6l   - 	 'Telerik.Windows.Controls.GridViewColumn%   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
% auto 6y   &   
IsReadOnly& . '   HeaderTextAlignment$' Center=�6�   (   IsGroupable( .  )   IsFilterable) .  *   DataMemberBinding* 65   �� *
SMPosition++ �� Mode$+ OneWay=�6�     5V      $$ 	序列号��6k   $
% auto 6x   & . $' Center=�6�   ( .  ) .  * 65   �� *	SerialNum+$+ OneWay=�6�     5W      $$ 书名��6j   $
% auto 6v   & . $' Center=�6�   ( .  ) .  * 65   �� *
BookName+$+ OneWay=�6�     5X      $$ 作者��6i   $
% auto 6u   & . $' Center=�6�   ( .  ) .  * 65   �� *	BAuthor+$+ OneWay=�6�     5Z      $$ 类别��6k   $
% auto 6w   & . $' Center=�6�   ( .  ) .  * 65   �� *	BTypeName+$+ OneWay=�6�     5\      $$ 价格��6h   $
% auto 6t   & . $' Center=�6�   ( .  ) .  * 65   �� *BPrice+$+ OneWay=�6�     5]      $$ 	出版社��6k   $
% auto 6x   & . $' Center=�6�   ( .  ) .  * 65   �� *	Publisher+$+ OneWay=�6�     5^      $$ 出版日期��6i   $
% auto 6w   & . $' Center=�6�   ( .  ) .  * 65   �� *	PubDate+$+ OneWay=�6�   5a      5b      ]� 5c      $��Bottom=�6   .+�5d      � $��LeftToRight=�6   $��5 20 0 5q�68   .+�5e      �� $ 
Horizontal=�6!   $��	10 5 50 5q�6;   .+�5f      �� $��
位置号:��6$   $��50��60   6=   �� 5g      -   5        $��position��5g   "   $	��120��62   $��23��6>   6L   5h      �� 5i      $ 
Horizontal=�6!   $��	10 5 50 5q�6;   .+�5j      �� $��
序列号:��6$   $��50��60   6=   �� 5k      -   5        $��	serialNum��5k   "   $	��120��63   $��23��6?   6M   5l      �� 5m      $ 
Horizontal=�6!   $��	10 5 50 5q�6;   .+�5n      �� $��书名:��6$   $��50��6/   6<   �� 5o      -   5        $��bookName��5o   "   $	��120��62   $��23��6>   6L   5p      �� 5q      $ 
Horizontal=�6!   $��	10 5 50 5q�6<   .+�5r      �� $��作者:��6$   $��50��6/   6<   �� 5s      -   5        $��author��5s   "   $	��120��60   $��23��6<   6J   5t      �� 5v      $ 
Horizontal=�6!   $��	10 5 50 5q�6<   .+�5w      �� $��类型:��6$   $��50��6/   6<   �� 5x      -   5        $
��type��5x   #   $ 	BTypeName��6/   $ TypeID��6M   $	��120��6h   $��23��6t   6�   5y      �� 5z      $ 
Horizontal=�6!   $��	10 5 50 5q�6<   .+�5{      �� $��价格:��6$   $��50��6/   6<     5|      -   5        $��price��5|   K   $ 2��63   $	��120��6X   $��23��6d   5}      �� 5~      $ 
Horizontal=�6"   $��	10 5 50 5q�6<   .+�5      �� $��
出版社:��6$   $��50��60   6=   �� 5�      -   5        $��	publisher��5�   "   $	��120��63   $��23��6?   6M   5�      �� 5�      $ 
Horizontal=�6!   $��	10 5 50 5q�6<   .+�5�      �� $��出版日期:��6$   $��50��61   6>     5�      -   5        $��pubDate��5�   J   $ Month=�60   $	��120��6Y   $��23��6e   5�      �� 5�      -   5        $	��txt��5�   :   $ 
Horizontal=�6!   $��	10 5 50 5q�6G   .+�5�      �� -   5        $��txtblock��5�   :   $��概要:��6$   $��50��6/   6L   �� 5�      -   5        $��outline��5�   "   $	��820��61   $	��220��6=   , �� AcceptsReturn, . $- �� HorizontalScrollBarVisibility$
- Auto=�6b   ". �� VerticalScrollBarVisibility$
. Auto=�6�   6�   5�      5�      5�      5�      5�      5�      