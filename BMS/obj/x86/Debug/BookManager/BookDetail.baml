   M S B A M L   `   `   `  ����>  :BMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BMS.MyControlBMS.MyControl  5           BMS.BookManager.BookDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      1BMSclr-namespace:BMS.MyControl     	 
  5      $��Stretch=�5      $��Stretch=�66   .��5
      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5
          IsBusy  .  .��5   
   ]� $��Bottom=�6   $��	0 -30 0 0q�6,   $��Stretch=�6?   $��Stretch=�6]   .+�5      � $��50 0 0 0q�6   $��LeftToRight=�6*   $	��600��6F   $	��800��6S   $��Stretch=�6_   $��Stretch=�6}   .+�5      �� $��	10 20 0 0q�6    �� Orientation$ 
Horizontal=�61   .+�5      �� $��书名:��6    $��50��6+   68   �� 5      -   5        $��bookName��5       $	��300��60   $
��Bold"�6<   $��23��6N   6\   5      �� 5      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5      �� $��作者:��6    $��50��6+   68   �� 5      -   5        $��author��5       $	��300��6.   $��23��6:   6H   5      �� 5      $ 
Horizontal=�6   $��	10 20 0 0q�68   $��Stretch=�6L   $��Stretch=�6j   .+�5      �� $��
位置号:��6    $��50��6,   69   �� 5      -   5        $��position��5       $	��300��60   $��23��6<   6J   5      �� 5      $��	10 20 0 0q�6   $ 
Horizontal=�61   $��Stretch=�6L   $��Stretch=�6j   .+�5      �� $��
序列号:��6    $��50��6,   69   �� 5      -   5        $��	serialNum��5       $	��300��61   $��23��6=   6K   5      �� 5       $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5!      �� $��类型:��6    $��50��6+   68   �� 5"      -   5        $
��type��5"   !   $	��300��6-   $��23��69   6I   5#      �� 5$      $��	10 20 0 0q�6   $ 
Horizontal=�60   .+�5%      �� $��价格:��6    $��50��6+   68   �� 5&      -   5        $��price��5&       $	��300��6-   $��23��6:   5'      �� 5(      $��	10 20 0 0q�6   $ 
Horizontal=�60   .+�5)      �� $��状态:��6    $��50��6+   68   �� 5*      -   5        $��state��5*       $	��300��6-   $
��Bold"�69   $��23��6K   5+      �� 5-      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5.      �� $��概要:��6    $��50��6+   68   �� 5/      -	   5        $��outline��5/      $	��660��6-   $	��250��69    �� AcceptsReturn .  �� 
IsReadOnly . $
��Auto=�6n   $
��Auto=�6�   
�������6�   50      �� 53      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�54      �� $��
出版社:��6    $��50��6,   69   �� 55      -
   5        $��	publisher��55       $	��300��61   $��23��6=   6K   56      �� 57      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�58      �� $��出版日期:��6    $��50��6-   6:   �� 59      -   5         ��Name$ pubDate��59   ?   $��25��6!   $��10 0 0 0q�6-   $	��300��6P   5:      �� 5<      $��	10 20 0 0q�6   $ 
Horizontal=�61   .+�5=      �� $��
借贷人:��6    $��50��6,   69      BMS.MyControl.MyComboBox  5>      -   5          Name$ users��5>   %   $	��150��64   6B   5?      �� 5A      $��	50 20 0 0q�6   $ 
Horizontal=�61   .+�5B      (  "Telerik.Windows.Controls.RadButton  -   5        $��borow��5B   9      CornerRadius$ 3��6(   $��10 0 0 0q�6F   $��借  书��6X   $��80��6{   $��25��6�   5C      �� 5D      $��	50 20 0 0q�6   $ 
Horizontal=�61   .+�5E        -   5        $��Return��5E   9   $ 3��6(   $��10 0 0 0q�6G   $��还  书��6Y   $��80��6}   $��25��6�   5F      5G      5I      5J      5L      