   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWFPAppSalesWFPApp  5          SalesWFPApp.App   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:SalesWFPApp     5      ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        �� 	Resources  5      ,   &SalesWFPApp.NullToEmptyStringConverter   NullToEmptyStringConverter4   .SalesWFPApp.MultipleValueToVisibilityConverter  MultipleToVis  ErrorTemplate&   Xceed.Wpf.Toolkit.DateTimePicker �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource	 �� Path
 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers �� 
TargetName  
mainButton��%  &	        &	      &	 &     '  �     '�� p    'G�     &	 	      5   
   6+     5	   
   63   �� 5   
   .R�5      ]� $
��True��6   .+�5      �� 
���  ��$��1q�6+   ._�5      �� 5      5      5      �� 5   
   "  6    5      P� 5       �@=�HasError$
 true��69   . �5      ��  �@�ToolTip 60   �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   " ��6    5      P� 5        �@=�HasError$
 true��69   . �5!      ��  �@�ToolTip 60   �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5$      .�5'      ��  � �� �#7070706+   �� 5(       � ��$ 1q�60   �� 5)       � ��$ 13(�6)   �� 5*       � ��$ Center=�62   �� 5+       � ��$	 0 5q�6'   �� 5,       � �� 5-      �� 5.      "
 ��6&   .R�5/      �� $ border��6!   $ 3��61   #��z��6B   #��z��50   !   #��z��6U   $
 True��51   !   ._�52      �� $ PART_ContentHost��6+   $|�False��6E   $��Hidden=�6W   $��Hidden=�53   +   54       55      P� 56       �@J�IsMouseOver$
 True��6=   . �57   "   �� $ border��6P    � �� �#3AA9AD58      P� 59       �@J�IsKeyboardFocused$
 True��6C   . �5:   "   �� $ border��6P    � �� �#3AA9AD5;      5=      5?      5@      �� 5A   
   " G�6    5B      P� 5C       �@=�HasError$
 true��69   . �5D      ��  �@�ToolTip 60   �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5G      .�5J      ��  � ��
 ���� 6+   �� 5K       � �� �#7070706+   �� 5L       � ��$ 1q�60   �� 5M       � ��$ 13(�6)   �� 5N       � ��$ 31 3 0 3q�6(   �� 5O       � ��$ Center=�62   �� 5P       � ��$	 0 5q�6'   �� 5Q       � �� 5R      �� 5S      "
 G�6&   .R�5T      �� $ border��6!   $ 3��61   #��z��6B   #��z��5U   !   #��z��6U   $
 True��5V   !   ._�5W      �� $ PART_ContentHost��6+   $|�False��6E   $��Hidden=�6W   $��Hidden=�5X   +   5Y       5Z      P� 5[       �@J�IsMouseOver$
 True��6=   . �5\   "   �� $ border��6P    � �� �#3AA9AD5]      P� 5^       �@J�IsKeyboardFocused$
 True��6C   . �5_   "   �� $ border��6P    � �� �#3AA9AD5`      5b      5d      5e      �� 5g   
   " ��6#   .�5h      ��  � ��
 ���� 6+   �� 5i       � �� �#5a5a5a6+   �� 5j       � ��$ 40��6'   �� 5k       �@�FocusVisualStyle 61   Z� �� 5l       � ��
 ���� 6,   �� 5m       � ��$ SemiBold"�6+   �� 5n       � �� 5o      �� 5p      "
 ��6&   .R�5q      �� #��z��6!   $ 15��6K   $��1q�6]   #��z��5r   !   ._�5s      �� $��Center=�6/   $��Center=�6J   5t      5u      5w       5x      P� 5y       �@J�IsMouseOver$
 True��61   . �5z      ��  � �� �#3AA9AD63   �� 5{       � �� �#FFFFFF63   �� 5|       � �� �#3AA9AD63   5}      5      5�      5�      