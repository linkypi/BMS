   M S B A M L   `   `   `  ����  BMS    BMS.Sys.UpdateRole   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5        N� Title$  
UpdateRole��5      .��5
      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5
       .��5   
   ]� .+�5      ]� $	��Top=�6   .+�5      & 
  Telerik.Windows.Controls.RadMenu  -   5          Name$ radMenu��5   "   
����ح�$	��Top=�6L   ' 
 !Telerik.Windows.Controls.MenuBase   ClickToOpen .  $��12(�6u   .@�5      * 
 $Telerik.Windows.Controls.RadMenuItem  -   5          Name$
 Save��5   *   $��保存��6K     5      -   5        $ Delete��5   *   $��删除��6L   5      5      ]� 5      $	��Top=�6   $��26��6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��3,2q�66   .+�5      �� $��80��6    $��角色名称��6+   69   �� 5      -   5         ��Name$ roleName��5   *   $	��120��6   6>   5      �� 5      $ 
Horizontal=�6   $	��3,2q�66   .+�5      �� $��80��6    $��备注��6+   67   �� 5      -   5        $
 note��5   *   $	��120��6   6:   5      �� 5      $ 
Horizontal=�6   $	��3,2q�66   .+�5      (  "Telerik.Windows.Controls.RadButton  -   5        $��search��5   D      CornerRadius$ 3��6(   $��60��69   $��查  询��6g   6x   5      5       ]� 5!      $	��Top=�6   .+�5"      ]� -   5         ]�Name$ panel��5"      $��Bottom=�6,   $��Stretch=�6D   $��LeftToRight=�6b   .+�5#      /  )Telerik.Windows.Controls.RadNumericUpDown  -	   5          Name$ pagesize��5#   0   $��Right=�6B   +  %Telerik.Windows.Controls.RadRangeBase	   Minimum$	 1Q�6~   
   Value$
 30X�6�   $��40��6�      NumberDecimalDigits$ 0��6�   +  %Telerik.Windows.Controls.RadDataPager  5$      -
   5          Name$
 page��5$   ,   $
��Left=�6<      PageSize$ 30��5%         AutoEllipsisMode$
 Both=�6$      DisplayMode$	 All=�6=      NumericButtonCount$ 10��6O   $��30��6h   5'      *	 	 $Telerik.Windows.Controls.RadGridView	  5(      -   5         	 Name$ GridList��5(   &   ;
 	 5Telerik.Windows.Controls.GridView.GridViewDataControl 
  GridLinesVisibility$
 Both=�69   $	��Top=�6U    
  ShowColumnHeaders .  
  CanUserInsertRows .   
  ShowGroupPanel .   
  RowIndicatorVisibility$ 	Collapsed=�5)   U    
  IsFilteringAllowed . $	��100��5*      $	��150��6"    
  CanUserFreezeColumns .   
  
IsReadOnly .  
  AutoGenerateColumns .   
  IsBusy .   
  SelectionMode$ Extended=�5+   =    
  CanUserSortColumns .   
  CanUserReorderColumns .   
  Columns 5-      3 	 -Telerik.Windows.Controls.GridViewSelectColumn  5.      1 	 +Telerik.Windows.Controls.GridViewDataColumn  5/      6 	 0Telerik.Windows.Controls.GridViewBoundColumnBase    Header$  角色名称��6j   - 	 'Telerik.Windows.Controls.GridViewColumn!   Width? 	 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
! auto 6x   "   
IsReadOnly" . #   HeaderTextAlignment$# Center=�6�   $   IsGroupable$ .  %   IsFilterable% .  &   DataMemberBinding& 65   �� *
RoleName+' �� Mode$' OneWay=�6�     50      $  备注��6f   $
! auto 6r   " . $# Center=�6�   $ .  % .  & 65   �� *Note+$' OneWay=�6�   53      54      ]� 55      $	��Top=�6   $��26��6-   .+�56      �� $ 
Horizontal=�6   $	��3,2q�66   .+�57      �� $��80��6    $��角色名称��6+   69   �� 58      -   5        $ updroleName��58   *   $	��120��6   6A   59      �� 5:      $ 
Horizontal=�6   $	��3,2q�66   .+�5;      �� $��80��6    $��备注��6+   67   �� 5<      -   5        $ updnote��5<   *   $	��120��6   6=   5=      5>      ]� 5?      $��Bottom=�6   .+�5A      ]� $��Bottom=�6   .+�5B        -   5        (  Name$( 	SelectAll��5B   �   $ 3��6)   $��全 选��6:   $��80��6H   $��23��6S   $	��5,0q�6_   $
��Left=�6l   6�     5C      -   5        $ 3��5C   )   $��反 选��6<   $��80��6J   $��23��6U   $	��5,0q�6a   $
��Left=�6o   6�   5D      * 
 $Telerik.Windows.Controls.RadTreeView  5F      -   5        )  Name$) RadTreeView1��5H   #   $	��Top=�5F   &   
�������*   SelectionMode$* Single=�6P   +   IsLineEnabled+ . ,   ItemsOptionListType$, 	CheckList=�5G   	   -   IsOptionElementsEnabled- . .   IsRootLinesEnabled. . /   IsTriStateMode/ . 5H   9   5J      5K      5L      5M      