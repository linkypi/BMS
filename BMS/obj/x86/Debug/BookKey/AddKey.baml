   M S B A M L   `   `   `  ����  BMS    BMS.BookKey.AddKey   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      $��Stretch=�5      $��Stretch=�6"     N� Title$  AddKey��5   	   .��5      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5      .��5	   
   ]� .+�5
      & 
  Telerik.Windows.Controls.RadMenu  -   5          Name$ radMenu��5
   6   
����ح�$	��Top=�6G   ' 
 !Telerik.Windows.Controls.MenuBase   ClickToOpen .  $��12(�6x   .@�5      * 
 $Telerik.Windows.Controls.RadMenuItem  -   5          Name$
 Save��5   *   $��保存关键字��68   6G     5      -   5        $	��del��5   *   $��删除关键字��65   6X   5      ]� 5      $	��Top=�6   .+�5      � 
�������$��LeftToRight=�61   $	��Top=�6M   $��0 2 0 2q�6b   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	10 5 50 5q�67   .+�5      �� $��
位置号:��6    $��50��6,   69   �� 5      -   5        $��sc_position��5      $	��120��61   $��23��6=   6K   5      �� 5      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5      �� $��
序列号:��6    $��50��6,   69   �� 5      -   5        $��sc_serialNum��5      $	��120��62   $��23��6>   6L   5      �� 5      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5      �� $��书名:��6    $��50��6+   68   �� 5      -   5        $��sc_bookName��5      $	��120��61   $��23��6=   6K   5      �� 5       $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5!      �� $��作者:��6    $��50��6+   68   �� 5"      -   5        $��	sc_author��5"      $	��120��6/   $��23��6;   6I   5#      �� 5$      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5%      �� $��类型:��6    $��50��6+   68   �� 5&      -	   5        $��sc_type��5&       �� DisplayMemberPath$ 	BTypeName��6.    �� SelectedValuePath$ TypeID��6L   $	��120��6g   $��23��6s   6�   5'      �� 5)      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5*      �� $��
关键字:��6    $��50��6,   69   �� 5+      -
   5        $��sc_bkey��5+      $	��120��6-   $��23��69   6G   5,      �� 52      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�53      �� $��
出版社:��6    $��50��6,   69   �� 54      -   5        $��sc_publisher��54      $	��120��62   $��23��6>   6L   55      �� 56      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�57      �� $��出版日期:��6    $��50��6-   6:   ,  &Telerik.Windows.Controls.RadDatePicker  58      -   5        $��
sc_pubDate��58   ]   0  *Telerik.Windows.Controls.RadDateTimePicker   DateSelectionMode$ Month=�6,      DisplayFormat$ Short=�6F   $	��120��6o   $��23��6{   59      �� 5:      $ 
Horizontal=�6   $��	10 5 50 5q�66   .+�5;      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5;   (   	   CornerRadius$	 3��66   $��查询��6G   $��80��6T   $��23��6_   5=      5?      5A      5B      ]� 5D      $	��Top=�6   .+�5E      ]� -   5        
 ]�Name$
 panel��5E      $��Bottom=�6)   $��Stretch=�6I   .+�5G      /  )Telerik.Windows.Controls.RadNumericUpDown  -   5          Name$ pagesize��5G   C   $��Right=�6+   +	  %Telerik.Windows.Controls.RadRangeBase 	  Minimum$ 1Q�6U    	  Value$ 30X�6a   $��50��6m      NumberDecimalDigits$ 0��6x   +
  %Telerik.Windows.Controls.RadDataPager
  5H      -   5         
 Name$
 page��5H   (   $
��Left=�68    
  PageSize$ 30��5I       
  AutoEllipsisMode$
 Both=�6$    
  DisplayMode$	 All=�6=    
  NumericButtonCount$ 10��6O   $��30��6h   5J      * 	 $Telerik.Windows.Controls.RadGridView  5K      -   5          Name$ GridList��5K   "   ; 	 5Telerik.Windows.Controls.GridView.GridViewDataControl   GridLinesVisibility$
 Both=�6d   $	��Top=�6�      ShowColumnHeaders .    CanUserInsertRows .  $	��150��5L      $	��200��6$      ShowGroupPanel .     RowIndicatorVisibility$ 	Collapsed=�6P      IsFilteringAllowed .    CanUserFreezeColumns .     
IsReadOnly .    AutoGenerateColumns .     IsBusy .     SelectionMode$ Extended=�5N   =       CanUserSortColumns  .  !   CanUserReorderColumns! .  "   Columns" 5O      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  5P      1 	 +Telerik.Windows.Controls.GridViewDataColumn  5Q      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase#   Header$# 	位置号��6h   - 	 'Telerik.Windows.Controls.GridViewColumn$   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
$ auto 6u   %   
IsReadOnly% . &   HeaderTextAlignment$& Center=�6�   '   IsGroupable' .  (   IsFilterable( .  )   DataMemberBinding) 61   �� *
SMPosition+* �� Mode$* OneWay=�6�     5R      $# 	序列号��6g   $
$ auto 6t   % . $& Center=�6�   ' .  ( .  ) 61   �� *	SerialNum+$* OneWay=�6�     5S      $# 书名��6f   $
$ auto 6r   % . $& Center=�6�   ' .  ( .  ) 61   �� *
BookName+$* OneWay=�6�     5T      $# 作者��6e   $
$ auto 6q   % . $& Center=�6�   ' .  ( .  ) 61   �� *	BAuthor+$* OneWay=�6�     5V      $# 类别��6g   $
$ auto 6s   % . $& Center=�6�   ' .  ( .  ) 61   �� *	BTypeName+$* OneWay=�6�     5X      $# 价格��6d   $
$ auto 6p   % . $& Center=�6�   ' .  ( .  ) 61   �� *BPrice+$* OneWay=�6�     5Y      $# 	出版社��6g   $
$ auto 6t   % . $& Center=�6�   ' .  ( .  ) 61   �� *	Publisher+$* OneWay=�6�     5Z      $# 出版日期��6e   $
$ auto 6s   % . $& Center=�6�   ' .  ( .  ) 61   �� *	PubDate+$* OneWay=�6�   5]      5^      ]� 5`      $��Bottom=�6   .+�5b      ]� $��Right=�6   .+�5c        -   5        $	 3��5c   (   $��Bottom=�6:   $��23��6R   $
��200 ��6^   $��添加关键字��6l   6|   �� 5d      -   5        $
��keys��5d   3   $	��Top=�6   + �� AcceptsReturn+ . $	��160��6U   ", �� VerticalScrollBarVisibility$
, Auto=�6e   $- �� HorizontalScrollBarVisibility$
- Auto=�6�   6�   5f      ]� 5h      $
��Left=�6   .+�5j      ]� -   5        $
 panel2��5j   !   $��Bottom=�61   $��30��6J   $��Stretch=�6V   .+�5l        -   5        $ 	pagesize2��5l   W   $��Right=�63   $��30��6J   $ 1Q�6j   $ 30X�6v   $��50��6�   $ 0��6�   
  5m      -   5        $ page2��5m   0   $
��Left=�6A   $ 30��5n      $
 Both=�6(   $	 All=�6A   $ 10��6S   $��30��6l   5o        5q      -   5        $ GridKey��5q   *   $
 Both=�6>   $	��Top=�6Z    .  .  $	��150��5r      $	��400��6$    .  $ 	Collapsed=�6J    .  .   .  .   .  $ Extended=�5t   =     .  ! .  " 5u        5v        5w      $# 	关键字��6j   $
$ auto 6w   % . $& Center=�6�   ' .  ( .  ) 69   �� *BKey+$* OneWay=�6�   5z      5|      ]� 5~      $
��Left=�6   .+�5      ]� $	��Top=�6    .+�5�      �� $
��Left=�6#   $��23��69   $
��auto��6E   $��关键字预览：��6R   $��0 3 0 0q�6`   6s     5�      -   5        $��Right=�5�   ,   $��80��6C   $��23��6N   $��清空��6Z   $	 3��6�   6�     5�      -   5        $��Right=�5�   ,   $��80��6C   $��23��6N   $��删除��6Z   $	 3��6g   6�   5�        5�      -   5        $ GridScan��5�   *   $
 Both=�6?   $��Bottom=�6[    .  .  $	��150��5�      $	��150��6%    .  $ 	Collapsed=�6O    .  .   .  .   .  $ Extended=�5�   =     .  ! .  " 5�        5�        5�      $# 	关键字��6f   $
$ auto 6s   % . $& Center=�6�   ' .  ( .  ) 65   �� *BKey+$* OneWay=�6�   5�      5�      5�      5�      5�      5�      