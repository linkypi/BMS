   M S B A M L   `   `   `  ����  BMS    BMS.Sys.AddRole   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5   	     N� Title$  AddRole��5      .��5
      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5
       .��5   
   ]� .+�5      ]� $	��Top=�6   .+�5      & 
  Telerik.Windows.Controls.RadMenu  -   5          Name$ radMenu��5   "   
����ح�$	��Top=�6L   ' 
 !Telerik.Windows.Controls.MenuBase   ClickToOpen .  $��12(�6u   .@�5      * 
 $Telerik.Windows.Controls.RadMenuItem  -   5          Name$
 Save��5   *   $��保存��6K   5      5      ]� 5      $	��Top=�6   $��26��6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��3,2q�66   .+�5      �� $��80��6    $��角色名称��6+   69   �� 5      -   5         ��Name$ roleName��5   *   $	��120��6   6>   5      �� 5      $ 
Horizontal=�6   $	��3,2q�66   .+�5      �� $��80��6    $��备注��6+   67   �� 5      -   5        $
 note��5   *   $	��120��6   6:   5      5      ]� 5      $��Bottom=�6   .+�5      ]� $��Bottom=�6   .+�5       (  "Telerik.Windows.Controls.RadButton  -   5          Name$ 	SelectAll��5    �      CornerRadius$ 3��6)   $��全 选��6:   $��80��6H   $��23��6S   $	��5,0q�6_   $
��Left=�6l   6�     5!      -   5        $ 3��5!   )   $��反 选��6<   $��80��6J   $��23��6U   $	��5,0q�6a   $
��Left=�6o   6�   5"      * 
 $Telerik.Windows.Controls.RadTreeView  5$      -   5          Name$ RadTreeView1��5&   #   $	��Top=�5$   &   
�������	   SelectionMode$	 Single=�6P   
   IsLineEnabled
 .    ItemsOptionListType$ 	CheckList=�5%   	      IsOptionElementsEnabled .    IsRootLinesEnabled .    IsTriStateMode . 5&   9   5(      5)      5*      5+      