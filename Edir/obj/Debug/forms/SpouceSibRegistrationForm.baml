   M S B A M L   `   `   `  ����?  ;Edir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Edir.forms
Edir.forms  5      *    $Edir.forms.SpouceSibRegistrationForm   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullY UMaterialDesignThemes.MahApps, Version=0.1.0.325, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   &localclr-namespace:Edir.forms   5      
�������.��5
      �� .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��SpouseSibGrid��5          Columns  5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        IDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5   7      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Id+  5      -   5        
NameColumn��$ 
First Name��5   9   $	 120 6M    6Y   �� *Name+  5      -   5        PhoneColumn��$ 
First Name��5   :   $	 120 6N    6Z   �� *Phone+5      �� 5   
   
��� ���$��10q�6$   $&�� Spouse Sibling Registration Form��60   $��17(�6\   $��Center=�6j   $��Center=�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��20q�6/   $��Center=�6;   .+�5      �� -   5         ��Name$ 	ChildName��5      $��0 0 20 0q�6)   $
��150 ��6;   $��11(�6H   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Name��6V    %  !MaterialDesignFloatingHintTextBox#��[  6}   �� 5      -   5        $ Phone��5      $
��10 0q�6&   $
��150 ��64   $��11(�6A   $  Phone��6O   #��[  6w   5      �� 5   
   $ 
Horizontal=�6   $��10q�6.   $��Center=�6:   .+�5      �� -   5        $��AddBtn��5        MaterialDesignRaisedButton#��[ 5       $��60��5!      $	��5 0q�6    � ToolTip$5 /Resource name: MaterialDesignRaisedAccentButton��5"      .��5#      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�6*   5%      �� 5&      -   5        $��EditBtn��5(      #��[ 5'      $��60��5(      $
��25 0q�6   $5 /Resource name: MaterialDesignRaisedAccentButton��5)      .��5*        $
 Edit=�6*   5+      �� 5,      -	   5        $��	DeleteBtn��5,      #��[ 5-      $��60��5.      $5 /Resource name: MaterialDesignRaisedAccentButton��5/      .��50        $ Delete=�6*   51      52      54      55      