   M S B A M L   `   `   `  ����?  ;Edir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Edir.forms
Edir.forms  5      &     Edir.forms.childRegistrationForm   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Edir.forms     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullY UMaterialDesignThemes.MahApps, Version=0.1.0.325, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   
�������.��5   
   �� .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	ChildGrid��5   $   $��1��6       AutoGenerateColumns  .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        IDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5   7      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Id+  5      -   5        
NameColumn��$ 
First Name��5   9   $	 120 6M    6Y   �� *Name+  5      -   5        PhoneColumn��$ 
First Name��5   :   $	 120 6N    6Z   �� *Phone+5      �� 5   
   $��0��6   .+�5   
   �� 
��� ���$��10q�6$   $ ��Children Registration Form��60   $��17(�6V   $��Center=�6d   $��Center=�6�   �� 5   
   $��20q�6   $��Center=�6"    �� Orientation$ 
Horizontal=�6?   .+�5      �� -   5         ��Name$ 	ChildName��5      $
��10 0q�6-   $
��200 ��6<   $��11(�6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Name��6W   �� 5      -   5        $ Phone��5      $
��200 ��6+   $��11(�68   $  Phone��6F   5      �� 5#   
   $ 
Horizontal=�6   $��10q�6.   $��Center=�6:   .+�5$      �� -   5        $��AddBtn��5$         MaterialDesignRaisedButton#��[  5%      $��60��5&      $	��5 0q�6    � ToolTip$5 /Resource name: MaterialDesignRaisedAccentButton��5'      .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]	   Kind$		 Add=�6.   5*      �� 5+      -   5        $��EditBtn��5-      #��[  5,      $��60��5-      $
��25 0q�6   $5 /Resource name: MaterialDesignRaisedAccentButton��5.      .��5/        $
	 Edit=�62   50      �� 51      -	   5        $��	DeleteBtn��51      #��[  52      $��60��53      $5 /Resource name: MaterialDesignRaisedAccentButton��54      .��55        $	 Delete=�62   56      57      59      5:      5>      