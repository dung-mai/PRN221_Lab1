   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	       SalesWFPApp.ProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SalesWFPApp.View     5   	     � Title$  Product Management��5   	   $	��640��6$   $	��800��61   .��5	      �� .+�5
   
      SalesWFPApp.View.MenuBar  � 5   
   .+�5      ]� $	��Top=�6   $��10q�60   .+�5      �  � RowDefinitions 5      �� 5      $	��300 �6(   �� 5      $��* �6(   �� 5      $��4* �6(   �� 5      $��* �6(   .+�5      � 
����ح�$
��Left=�62   $	��420��6M   $��0,0,0,0q�6Y    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� m     �� 5      " ��6$   .�5   "   ��  � ��$	 200��6:   �� 5   "    � ��$ 25��6;   5      �� 5      " ��6$   .�5   "   ��  � ��$	 200��6:   �� 5   "    � ��$ 25��6;   �� 5   "    � ��$
 Left=�6H   5       5!       5"      �� 5#      $��40 �6,   �� 5$      $��* �6,   �� 5%      $��* �6,   �� 5&      $��* �6,   �� 5'      $��* �6,   �� 5(      $��* �6,   �� 5)      $��* �6,   .+�5,      �� -   5        $��lbTitle��5,   $   
���  ��$��DemiBold"�6D   $��20(�6Z   $��Product Information��6h   $��0��6�   �� 5-      -   5        $��lbProductId��5-       $��
Product Id��63   $��1��6H   $��0,6,0,12q�6V   $	��200��6h   �� 5.      -   5        $��txtProductId��5.   "   $��25��66   $��1��6B      ErrorTemplate =� ErrorTemplate# [  52       �� 
IsReadOnly$
 True��6S   ��5/      �� *	ProductId+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�  NullToEmptyStringConverter
 �� 	Converter#
 [  �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True�� �� ValidatesOnExceptions$
 True��52   S   �� 54      -   5        $��lbCategoryId��54       $��Category Id��64   $��2��6J   $��0,7,0,12q�6W   �� 55      -   5        $��txtCategoryId��55   "   $��25��67   $��2��6C   # [  59      ��56      �� *
CategoryId+$ TwoWay=�$	 PropertyChanged=�#
 [ $
 True��$
 True��$
 True��59      �� 5;      -   5        $��lbProductName��5;       $��Product Name��65   $��3��6L   �� 5<      -   5        $��txtProductName��5<   "   $��3��68   # [  5?      ��5=      �� *ProductName+$ TwoWay=�$	 PropertyChanged=�$
 True��$
 True��$
 True��5?      �� 5A      -   5        $��lbWeight��5A       $��Weight��60   $��4��6A   $��4,7,0,11q�6N   $	��200��6`   �� 5B      -	   5        $��	txtWeight��5B   "   $��4��63   # [  5F      ��5C      �� *Weight+$ TwoWay=�#
 [ $
 True��$
 True��$
 True��5F      �� 5H      -
   5        $��lbUnitPrice��5H       $��	UnitPrice��63   $��5��6G   $��1,9,0,10q�6U   $	��200��6g   �� 5I      -   5        $��txtUnitPrice��5I   "   $��5��67   # [  5M      ��5J      �� *	UnitPrice+$ TwoWay=�$	 PropertyChanged=�#
 [ $
 True��$
 True��$
 True��5M      �� 5O      -   5        $��lbUnitsInStock��5O       $��Units In Stock��66   $��6��6O   $��1,6,0,12q�6\   $	��200��6n   �� 5P      -   5        $��txtUnitsInStock��5P   "   $��6��69   # [  5T      $��Center=�6W   $��110,0,110,0q�6r   ��5Q      �� *UnitsInStock+$ TwoWay=�$	 PropertyChanged=�#
 [ $
 True��$
 True��$
 True��5T   r   5U      �� 5X      $��1��6!    �� Orientation$ 
Horizontal=�6.   $
��Left=�6G   .+�5Y      �� -   5         ��Name$ 	btnInsert��5Y   !   $��10q�6�   $��80��6�   $��Insert��6�   ��64   �� *AddProductCommand+��6Z   �� *
CurProduct+6�   �� 5Z      -   5        $ 	btnUpdate��5Z   !   $��10q�6�   $��80��6�   $��Update��6�   ��64   �� *UpdateProductCommand+��6]   �� *
CurProduct+6�   �� 5[      -   5        $ 	btnDelete��5[   !   $��10q�6�   $��80��6�   $��Delete��6�   ��64   �� *DeleteProductCommand+��6]   �� *
CurProduct+6�   �� 5\      -   5        $ btnReset��5\   !   $��10q�6T   $��80��6`   $��Reset��6k   ��63   �� *ResetCommand+6k   5]      �� 5`      $
��Auto=�6#   $��2��6F   .��5a      �� -   5        $��
lvProducts��5a   $   $
��Auto��66   $	��235��6C   ��5b      �� *
Products+$ TwoWay=�$	 Explicit=� �� SelectedItem 5c      �� *
CurProduct+$ TwoWay=�$	 PropertyChanged=� �� View 5d      �� 5e   "   .P�5f   &   �� $��
Product ID��65    �� Width$	 100��6I    �� DisplayMemberBinding 6U   �� *	ProductId+�� 5g   &   $��Category ID��65   $	 100��6J    6V   �� *
CategoryId+�� 5h   &   $��Product Name��65   $	 200��6K    6W   �� *ProductName+�� 5i   &   $��Weight��65   $	 100��6E    6Q   �� *Weight+�� 5j   &   $��Price��65   $	 100��6D    6P   �� *	UnitPrice+ �� StringFormat$ {0:N3}���� 5k   &   $��Units In Stock��65   $	 100��6M    6Y   �� *UnitsInStock+5l   #   5n      5o      5r      5s      5t      5u      5v      