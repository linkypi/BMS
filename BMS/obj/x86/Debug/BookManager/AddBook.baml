   M S B A M L   `   `   `  ����  BMS    BMS.BookManager.AddBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5        N� ShowsNavigationUI  .   N� Title$ AddBook��5      .��5      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5         IsBusy .  .��5	   
   ]� $��Bottom=�6   $��Stretch=�6,   $��Stretch=�6J   .+�5
      � $��0 20 0 0q�6   $��LeftToRight=�6*   $	��500��6F   $	��500��6S   $��Stretch=�6_   $��Stretch=�6}   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10 0 0 0q�68   $��Stretch=�6K   $��Stretch=�6i   .+�5      �� $��
位置号:��6    $��50��6,   69   �� 5      -   5        $��position��5      $	��150��6.   $��23��6:   6H   5      �� 5      $��80 0 0 0q�6   $ 
Horizontal=�60   $��Stretch=�6K   $��Stretch=�6i   .+�5      �� $��
序列号:��6    $��50��6,   69   �� 5      -   5        $��	serialNum��5      $	��150��6/   $��23��6;   6I   5      �� 5      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5      �� $��书名:��6    $��50��6+   68   �� 5      -   5        $��bookName��5      $	��150��6.   $��23��6:   6H   5      �� 5      $��	80 20 0 0q�6   $ 
Horizontal=�61   .+�5      �� $��作者:��6    $��50��6+   68   �� 5      -   5        $��author��5      $	��150��6,   $��23��68   6F   5      �� 5      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5      �� $��类型:��6    $��50��6+   68   �� 5      -   5        $
��type��5       $	��150��6,   $��23��68    �� DisplayMemberPath$ 	BTypeName��6D    �� SelectedValuePath$ TypeID��6b   6�   5      �� 5!      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5"      �� $��概要:��6    $��50��6+   68   �� 5#      -   5        $��outline��5#       �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�6B   " �� VerticalScrollBarVisibility$
 Auto=�6h   $	��430��6�   $	��148��6�   6�   5$      �� 5&      $��	10 20 0 0q�6   $ 
Horizontal=�60   .+�5'      �� $��价格:��6    $��50��6+   68   /  )Telerik.Windows.Controls.RadNumericUpDown  5(      -   5        $��price��5(   /   $	��150��6<   $��23��6I   5)      �� 5*      $��	80 20 0 0q�6   $ 
Horizontal=�61   .+�5+      �� $��
出版社:��6    $��50��6,   69   �� 5,      -	   5        $��	publisher��5,      $	��150��6/   $��23��6;   6I   5-      �� 5.      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5/      �� $��出版日期:��6    $��50��6-   6:   ,  &Telerik.Windows.Controls.RadDatePicker  50      -
   5        	  Name$	 pubDate��50   T   0  *Telerik.Windows.Controls.RadDateTimePicker
   DateSelectionMode$
 Month=�6-   $��25��6H   $	��150��6e   51      �� 53      $��	80 20 0 0q�6   $ 
Horizontal=�61   .+�54      (  "Telerik.Windows.Controls.RadButton  -   5        $	��add��54   9      CornerRadius$ 3��6(   $��添加��6D   $��80��6Q   $��25��6\   55      56      57      59      5:      5;      