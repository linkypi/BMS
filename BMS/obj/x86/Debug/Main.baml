   M S B A M L   `   `   `  ����>  :BMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BMS.Common
BMS.Common  5          BMS.Main   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (BMSclr-namespace:BMS.Common     5      k gTelerik.Windows.Controls.Input, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      Ktoolkit9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      -   5          � WindowStyle$
  None=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency .  � Title$
 Main��5      ��5	   
   Z�  � 	Resources 5         CloseButton �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime R� Value  System.Windows.Visibility g� Duration	 �� To A�Name F�Name  	AddButton) 
 #Telerik.Windows.Controls.RadTabItem �� Orientation"   BMS.Common.RoutedEventHelper   EnableRoutedClick ^� ToolTip��%6  &	        &	 7    '  n    �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � 
������ $��14��68   $��14��6C   	 5        5   "   CommonStates��.
 5   &     
Normal��62     5   &   	MouseOver��. 5   *   �� .��5   .   T� $ (UIElement.Visibility)�5      $ FocusEllipse��5      ..�5   2   i� $ 0��6I    5   6    5   :   Visible=�6N   5   3   5    /   �� 5!   .   $ 0D�6=   $ 	#FFDC3030X�6J   $* $(Shape.Fill).(SolidColorBrush.Color)�5"      $ FocusEllipse��5#      �� 5$   .   $ 0D�6=   $ WhiteX�6J   $, &(Shape.Stroke).(SolidColorBrush.Color)�5%      $
 path��5&      5'   +   5(   '     5)   &   Pressed��. 5*   *   �� .��5+   .   T� $ (UIElement.Visibility)�5,      $ FocusEllipse��5-      ..�5.   2   i� $ 0��6I    5/   6    50   :   Visible=�6N   52   3   53   /   �� 54   .   $ 0D�6=   $ BlackX�6J   $* $(Shape.Fill).(SolidColorBrush.Color)�55      $ FocusEllipse��56      �� 57   .   $ 0D�6=   $ WhiteX�6J   $, &(Shape.Stroke).(SolidColorBrush.Color)�58      $
 path��59      5:   +   5;   '     5<   &   Disabled��62   5=   #     5>   "   FocusStates��.
 5?   &     Focused��62     5@   &   	Unfocused��62   5A   #   .+�5C      A� $ FocusEllipse��6&   ���	#FFF13535$y�	Collapsed=�6M   F� 5E      $
 path��6#   +����        р�[ ��[ Ѐ�[     �    ��[ 	���	#FF898888$��Center=�5F   
   $��Center=�6'   $��1��5G   
   5H      5I      5K      5L      �� 5M   
   " ��6"   .�5N      ��  � �� 5O      �� 5P      " ��6&   .R�5Q      � 
������ $��14��68   $��14��6C   	 5R        5S   "   CommonStates��.
 5T   &     
Normal��62     5U   &   	MouseOver��. 5V   *   �� .��5W   .   T� $ (UIElement.Visibility)�5X      $ FocusEllipse��5Y      ..�5Z   2   i� $ 0��6I    5[   6    5\   :   Visible=�6N   5^   3   5_   /   �� 5`   .   $ 0D�6=   $ 	#FF1CC81FX�6J   $* $(Shape.Fill).(SolidColorBrush.Color)�5a      $ FocusEllipse��5b      �� 5c   .   $ 0D�6=   $ WhiteX�6J   $, &(Shape.Stroke).(SolidColorBrush.Color)�5d      $
 path��5e      5f   +   5g   '     5h   &   Pressed��. 5i   *   �� .��5j   .   T� $ (UIElement.Visibility)�5k      $ FocusEllipse��5l      ..�5m   2   i� $ 0��6I    5n   6    5o   :   Visible=�6N   5q   3   5r   /   �� 5s   .   $ 0D�6=   $ BlackX�6J   $* $(Shape.Fill).(SolidColorBrush.Color)�5t      $ FocusEllipse��5u      �� 5v   .   $ 0D�6=   $ WhiteX�6J   $, &(Shape.Stroke).(SolidColorBrush.Color)�5w      $
 path��5x      5y   +   5z   '     5{   &   Disabled��62   5|   #     5}   "   FocusStates��.
 5~   &     Focused��62     5   &   	Unfocused��62   5�   #   .+�5�      A� $ FocusEllipse��6&   ���	#FFF13535$y�	Collapsed=�6M   F� 5�      $
 path��6#   +���� 	=     � 	=  z �     	= � z  	= 	���	#FF898888$��Center=�5�   
   $��Center=�6'   $��1��5�   
   5�      5�      5�      5�      �� 5�   
   "  6   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5�      �� $��5,5,0,0q�6:   ��6(   �� 6:   �� 5�       . $��16��5�       $��16��6+   
������ 
������ $��5,5,0,0q�5�      $ Remove item��6#   ��5�   "   �� 5�   &   $'��!/BMS;component/Image/close_16.png��6,   5�      5�      5�      5�      5�      5�      .��5�      /  )Telerik.Windows.Controls.RadBusyIndicator  -   5        $
��busy��5�       .��5�   
   ��  �� CornerRadius$ 10,10,10,10��6   
����ح�$
��Auto��6E   
����� �$��1q�6f   ._�5�   
   ]� $��LeftToRight=�6   .+�5�      ]� $	��Top=�6   $��25��6-   $��0 3 0 0q�69   $��Stretch=�6K   $��Stretch=�6i   .+�5�      �� -   5        $��Right=�5�      $�� 0 0 5 0q�64   
������ ��5�      �� 5�      $��Image/2.png��6%   $��20��6:   $��20��6E   6S   5�      ) 
 #Telerik.Windows.Controls.RadToolBar  5�      $��0 0 25 0q�6)   
����ح�$	��120��6S   $��25��6`   $��Right=�6l   $��Stretch=�6�   $��Stretch=�6�      OverflowButtonVisibility$ 	Collapsed=�6�   .@�5�      (	  "Telerik.Windows.Controls.RadButton	  -   5         	 Name$ Louout��5�   >   $��退出系统��6,   6N   	  5�      -   5        $��SetPassWord��5�   ;   $��修改密码��6,   $��Right=�6Q   6m   5�        5�      
����ح�$	��120��6A   $��25��6M   $��Right=�6[   $��Stretch=�6|   $��Stretch=�6�   $ 	Collapsed=�6�   .@�5�      �� $��当前用户：��6!   $��0q�6/   6<   �� 5�      -   5         ��Name$ CurrentUser��5�   !   
�������$��0q�6K   6X   5�      &
 
  Telerik.Windows.Controls.RadMenu
  5�      -   5        $
��menu��5�   `   
����ح�$��25��6>   $
��Left=�6J   5�      5�      , 
 &Telerik.Windows.Controls.RadTabControl  5�      -   5        $��tabcontrols��5�   M   
����ح�$��3 0 3 5q�6;   $��1q�6b   
������ $��Stretch=�5�      $��Stretch=�6-   ; 
 5Telerik.Windows.Controls.TabControl.RadTabControlBase   HeaderBackground
 ��ح�5�      5�      5�      5�      5�      