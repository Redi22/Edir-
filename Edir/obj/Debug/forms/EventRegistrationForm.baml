   M S B A M L   `   `   `  ����?  ;Edir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Edir.forms
Edir.forms  5      &     Edir.forms.EventRegistrationForm   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Edir.forms     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullY UMaterialDesignThemes.MahApps, Version=0.1.0.325, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   
�������.��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $	��250 �6   .+�5   
   �� $��1��6   ���#181818.��5      � $	��800��6   $��20 0 0 0q�6!    � RowDefinitions 5      �� 5      $	��100 �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��70 �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5       $��* �6$   �� 5!      $��* �6$   �� 5"      $	��100 �6$   .+�5$      �� 
��� ���$��Event Registration Form��6,   $��0��6N   $��19(�6[   $��Center=�6i   $��Center=�6�   �� 5&      -   5        $��	EventName��5&   5   $��1��6   $��12(�6'   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Event Name��5'       %  !MaterialDesignFloatingHintTextBox#��[  5(      (  "System.Windows.Controls.DatePicker  5*      -   5        $��	EventDate��5*   8   $��2��6   $��12(�6*   $	��200��5+      $ 
Event Date��5,       ( $MaterialDesignFloatingHintDatePicker#��[ 5-      �� 5.      -   5        $��
EventPlace��5.   5   $��3��6   $��12(�6'   $ Place��5/      #��[  50      )  #MaterialDesignThemes.Wpf.TimePicker  51      -   5        $��	EventTime��51   ,   $	��200��52      $��4��6   $��12(�6    ( $MaterialDesignFloatingHintTimePicker#��[ 53      $ 
Event Time��54      �� 55      -   5        $��EventFin��55   5   $��5��6   $��12(�6'   $
  Fin��56      #��[  57      �� 58      -   5        $��Description��58       * &MaterialDesignOutlinedTextFieldTextBox#��[ 59      $��6��5:      $��2��6   $��12(�6#   $	��Top=�5;      $	��100��5<       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5>      " �� VerticalScrollBarVisibility$
 Auto=�5?      $ Event Description��5@      �� 5C       �� Orientation$ 
Horizontal=�6   $��10��66   .+�5D      �� -   5        $��AddBtn��5D      $
��11 0q�6A    � ToolTip$ One with custom opacity��5E      ��5F      '  !MaterialDesignThemes.Wpf.PackIcon  5G      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�66   5I      �� 5J      -   5        $��EditBtn��5J      $
��11 0q�6D   $	 Two��5K      ��5L        5M      $
 Edit=�66   5O      �� 5P      -	   5        $��	DeleteBtn��5P      $
��11 0q�6G   $ Three��6U   ��5Q        5R      $ Delete=�66   5T      5U      5X      5Y      �� 5Z   
   .+�5[      �� $ 
Horizontal=�6   $��30q�62   .+�5\      �� $��Events��6   $��Center=�6*   $
��30 0q�6E   
��� ���$��22(�6l   �� 5]      -
   5        $��Search��5]      $	��200��6=   $��12(�6I   #��[  5^      .��6?    5_      �� 5`      $ 
Horizontal=�6%   .+�5a        $ Search=�66   $��40��6D   $��30��6P   �� 5b      $��Search��6(   $��Center=�66   5c      .��5d   6   5e      �� 5f      -   5        $��
refreshBtn��5f   I   
��� ������#222222$��
30 30 0 0 q�6�   ��6   Z� .��5h        $ Refresh=�5i      $��24��5j      $��24��5k      5l      5m      &   System.Windows.Controls.DataGrid  5o      -   5        	  Name$	 	EventGrid��5o   C   $��0��6   
   AutoGenerateColumns
 .     
IsReadOnly .    Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      -   5        IDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5q   ;      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 70	 6G   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6R   �� *Id+  5r      -   5        FirstNameColumn��$ 
Event Name��5r   B   $	 120	 6V    6b   �� *Name+  5s      -   5        LastNameColumn��$ Place��5s   A   $	 120	 6P    6\   �� *Place+  5t      -   5        MiddleNameColumn��$
 Date��5t   C   $	 120	 6Q    6]   �� *date+  5u      -   5        MiddNameColumn��$ Description��5u   A   $	 120	 6V    6b   �� *Description+  5v      -   5        MiddlmeColumn��$
 Fine��5v   @   $	 120	 6N    6Z   �� *Fin+5x      �� 5y   
   -   5        $��Details��5y      $
��Left=�66    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5z      $��30q�6I   $ See details��5{      ��6   Z� .��5|        $ Details=�5}      {�.  $��24��5~      
���   �$��24��5      5�      �� 5�      .��5�      � -   5        $��AttendanceForm��5�      5�      5�      5�      5�      5�      