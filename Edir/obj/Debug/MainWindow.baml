   M S B A M L   `   `   `  ����?  ;Edir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EdirEdir  5   	       Edir.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Edir     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullY UMaterialDesignThemes.MahApps, Version=0.1.0.325, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   $��28(�5        � Icon$  assets/logoDark.png��6(   
��� ��� � WindowStartupLocation$ CenterScreen=�5	       � Title$ 
MainWindow��5
      $	��700��6   $
��1024��6#    � 
ResizeMode$ NoResize=�60    � 	Resources 5         Storyboard1 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value<  6System.Windows.Media.Animation.EasingThicknessKeyFrame	 p� KeyTime
 p� Value  Storyboard2��%�  &	        &	 �    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ grid1��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.6��6'   $	 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ stackPanel1��6�   .\�5        $ 0:0:0.6��6E   $	 252Q�6W   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ stackPanel1��6�   .\�5        $ 0:0:0.6��6'   $ 9Q�69   5      r� 5      $ (FrameworkElement.Margin)�6/   $ listViewItem��6e   .	�5        $	 0��6*   $
 
-250,0,0,0q�66     5      $	 0:0:0.6��6*   $
 0q�6<     5      $	 0:0:1��6K   $
 0q�6[   5      r� 5       $ (FrameworkElement.Margin)�6/   $ listViewItem1��6e   .	�5!        $	 0��6*   $
 
-250,0,0,0q�66     5"      $	 0:0:0.8��6*   $
 0q�6<   5#      r� 5$      $ (FrameworkElement.Margin)�6/   $ listViewItem2��6e   .	�5%        $	 0��6*   $
 
-250,0,0,0q�66     5&      $	 0:0:1.0��6*   $
 0q�6<   5'      r� 5(      $ (FrameworkElement.Margin)�6/   $ listViewItem3��6e   .	�5)        $	 0��6*   $
 
-250,0,0,0q�66     5*      $	 0:0:1.2��6*   $
 0q�6<   5+      r� 5,      $ (FrameworkElement.Margin)�6/   $ listViewItem4��6e   .	�5-        $	 0��6*   $
 
-250,0,0,0q�66     5.      $	 0:0:1.4��6*   $
 0q�6<   5/      r� 50      $ (FrameworkElement.Margin)�6/   $ listViewItem5��6e   .	�51        $	 0��6*   $
 
-250,0,0,0q�66     52      $	 0:0:1.6��6*   $
 0q�6<   53      54      �� 55   
   .��56      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ grid1��6�   .\�57        $ 0��6'   $	 250Q�63     58      $ 0:0:0.6��6'   $ 0Q�69   59      U� 5>      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ stackPanel1��6�   .\�5?        $ 0:0:0.6��6'   $ 0Q�69   5@      5A      5B       � Triggers 5C      :� 5D   
    :� 
SourceName$ menuDrawerOpen��6    :� RoutedEvent$ Button.Click��63   .[�5F      �� #��[  6   5H      :� 5I   
   $ menuDrawerClose��6   $ Button.Click��64   .[�5K      �� #��[ 6   5M      .��5O      � -   5         �Name$ MainGridView��5O      ���#181818$
��1024��66   .+�5Q   
   �� -   5         ��Name$ stackPanel1��5Q      $	��250��6*   $��
-250 0 0 0q�66   $
��Left=�6J   $��0��6e   $��4��6u   ���#181818 J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5R      V� 5S      .~�5T      �� �� 5U      �� 5V      T� 5W      5X      .+�5Z      �� -   5        $ 
stackPanel��5Z       �� Orientation$ 
Horizontal=�6-   .+�5[      �� -   5         ��Name$ SettingsButton��5[      
��� ���$
��15 0q�6c    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6q   $
��Left=�6�   $��0q�6�   $	��Top=�6�   $��49��6  $��50��6  ��6�   Z� ��6%  Z� .��5\      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Settings=�6.   $��25��6>   $��25��6I   5]      �� 5_      -   5        $ notificationButton��5_      
��� ���$	��3 0q�6j   #��[ 6w   $
��Left=�6�   $��0q�6�   $	��Top=�6�   $��49��6  $��50��6!  ��6�   Z� ��6,  Z� .��5`        $
 Bell=�6.   $��25��6:   $��25��6E   5a      �� 5b      -   5        $ ReportButton��5b      
��� ���$	��3 0q�6^   #��[ 6k   $
��Left=�6�   $��0q�6�   $	��Top=�6�   $��49��6  $��50��6  ��6�   Z� ��6   Z� .��5c        $ Report=�6.   $��25��6<   $��25��6G   5d      5e      �� 5f      $
��0 80q�6   
��� ���$	��550��69   .@�5g      �� -   5         ��Name$ listViewItem��5g   J   .��5i      �� $ 
Horizontal=�6!   $	��200��6:   $��60��6F   .+�5k        $
 Home=�62   $��50��6>   $��	20 10 0 0q�6I   $��40��6\   �� 5l      $��16(�6$   $��Center=�62   $��20q�6M   �� 6[   $
�Home��6_   6n   5m      5n      �� 5p      -   5        $ listViewItem1��5p   L   .��5q      �� $ 
Horizontal=�6!   $	��200��6:   .+�5r        $ People=�62   $��50��6@   $��	20 10 0 0q�6K   $��35��6^   �� 5s      $��18(�6$   $��Center=�62   $��20q�6M   �� 6Z   $�Members��6^   6p   5u      5v      �� 5w      -	   5        $ listViewItem2��5w   J   .��5x      �� $ 
Horizontal=�6!   $	��200��6:   .+�5y        $ Event=�62   $��50��6?   $��	20 10 0 0q�6J   $��35��6]   �� 5z      $��16(�6$   $��Center=�62   $��20q�6M   �� 6Z   $�Events��6^   6o   5{      5|      �� 5}      -
   5        $ listViewItem3��5}   I   .��5~      �� $ 
Horizontal=�6!   $	��200��6:   .+�5        $ Store=�62   $��50��6?   $��	20 10 0 0q�6J   $��35��6]   �� 5�      $��16(�6$   $��Center=�63   $��20q�6N   �� 6[   $�Store��6_   6o   5�      5�      �� 5�      -   5        $ listViewItem4��5�   J   .��5�      �� $ 
Horizontal=�6!   $	��200��6:   .+�5�        $ FileDocument=�62   $��50��6F   $��	20 10 0 0q�6Q   $��35��6d   �� 5�      $��16(�6$   $��Center=�62   $��20q�6M   �� 6Z   $�Rules��6^   6n   5�      5�      �� 5�      -   5        $ listViewItem5��5�       .��5�      �� $ 
Horizontal=�6!   $	��200��6:   .+�5�        $ Payment=�62   $��50��6A   $��	20 10 0 0q�6L   $��35��6_   �� 5�      $��16(�6$   $��Center=�62   $��20q�6M   �� 6[   $�Payment��6_   6q   5�      5�      5�      5�      � 5�   
   -   5        $
 grid��5�      $
��1024��6    � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $	��250 �6#   .+�5�      � -   5        $ grid1��5�      $��0��6"   ���#272727$ 0.5,0.5&�6G   $��2��6g   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $	��250 �6'    � RowDefinitions 5�      �� 5�      $��40 �6$   �� 5�      $��* �6$   �� 5�      $��* �6$   �� 5�      $��* �6$   .+�5�      �� -   5        $ menuDrawerClose��5�   X   
��� ���$��0��6K   $
��Left=�6q   $	��Top=�6�   #��[ 6�   $ 0.363,0.444&�6  ��6�   Z� ��6  Z� .��5�        $
 Menu=�6.   $��45��6:   $��40��6E   5�      �� 5�      -   5        $ menuDrawerOpen��5�   W   
��� ���$��0��6J   $
��Left=�6o   $	��Top=�6�   #��[ 6�   $ 0.363,0.444&�6  ��6�   Z� ��6   Z� .��5�        $
 Menu=�6.   $��45��6:   $��40��6E   5�      � 5�      -   5        $ named��5�      $��	30 0 0 0 q�6&   $��0��69   $��4��6I   $��1��6^   $��3��6l   5�      � 5�      $	��250��6   $��20q�6    $��0��6,   $��2��6<   $��5��6M   $��1��6a   $	��Top=�6n    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      � -   5        $ 	dashbord1��5�      $��0��6*   $��20q�6;   5�      � 5�      -   5        $ 	dashbord2��5�      $��1��6*   $��20q�6;   5�      � 5�      -   5        $ 	dashbord3��5�      $��2��6*   $��20q�6;   5�      5�      � 5�      $	��250��6   $��20q�6$   $��0��60   $��2��6@   $��5��6Q   $��2��6e   $��Center=�6r    5�      �� 5�      $��* �6'   .+�5�      � -   5        $��Upcoming��5�   '   $��0��6   $	��500��68   $
��40 0q�6D   5�      5�      5�      5�      5�      5�      