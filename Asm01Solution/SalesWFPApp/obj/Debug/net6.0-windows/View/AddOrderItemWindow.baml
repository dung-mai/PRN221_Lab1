   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	   )    #SalesWFPApp.View.AddOrderItemWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SalesWFPApp.View     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  AddOrderItemWindow��5	   	   $	��640��6$   $	��800��61   .��5
      �� .+�5   
      SalesWFPApp.View.MenuBar  � 5   
   .+�5      ]� $	��Top=�6   $��10q�60   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� -   5        $��lbTitle��5       
���  ��$��DemiBold"�6@   $��20(�6V   $��Find Product��6d   $��0��6x   � 5      $��1��6   $	��200��6(    � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      � $��0��6   $��2��6/   $��	0,0,498,0q�6C    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� m     �� 5    "   " ��6(   .�5!   &   ��  � ��$	 150��6>   �� 5"   &    � ��$ 25��6?   5#   #   �� 5$   "   " ��6(   .�5%   &   ��  � ��$	 200��6>   �� 5&   &    � ��$ 25��6?   �� 5'   &    � ��$
 Left=�6L   5(   #   5)       5*      �� 5+   "   $��* �60   �� 5,   "   $��* �60   �� 5-   "   $��* �60   �� 5.   "   $��* �60   .+�50      �� -   5        $��lbProductId��50   $   $��
Product ID��67   $��0��6L   $��0,6,0,12q�6Z   $	��200��6l   �� 51      -   5        $��txtProductId��51   &   $��25��6:   $��0��6F   $��20,0,0,0q�6S   ��52   !   �� *	ProductId+ �� Mode$ TwoWay=�   NullToEmptyStringConverter �� 	Converter# [  	 �� UpdateSourceTrigger$	 PropertyChanged=��� 54      -   5        $��lbCategoryId��54   $   $��Category ID��68   $��1��6N   $��0,7,0,12q�6[   �� 55      -   5        $��txtCategoryId��55   &   $��25��6;   $��1��6G   $��20,0,0,0q�6T   ��56   !   �� *
CategoryId+$ TwoWay=�# [  $	 PropertyChanged=��� 58      -   5        $��lbProductName��58   $   $
��Name��69   $��2��6H   �� 59      -   5        
 ��Name$
 txtProductName��59   &   $��2��6>   $��20,0,0,0q�6K   ��5:   !   �� *ProductName+$ TwoWay=�$	 PropertyChanged=��� 5<      -   5        $��	btnSearch��5<   %   $��3��66   $
��Left=�6C   $��10,5,0,0q�6^     
mainButton#��[ 5=   %   $��30��6I   $��90��6U   ���#3AA9AD���#3AA9AD���#FFFFFF��5?   %   �� *SearchProductCommand+.��6N   Search5A      �� 5B      -	   5        $��btnReset��5B   %   $��3��65   #��[ 5C   %   $��30��6I   $��90��6U   $��60,5,0,0q�6`   ���#3AA9AD���#FFFFFF���#3AA9AD��5E   %   �� *ResetCommand+.��6F   Reset5G      �� 5H      -
   5        $��btnAddToCart��5H   %   $��0��69   $��20��6F   $��20��6Q   $��0q�6]   $��
250 0 0 0 q�6j   
������ 
������ 
������ ��5J   %   �� *AddItemCommand+��6H   �� *SelectedItem+ �� ElementName$ 
lvProducts��.��5K   "   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ PlusBoxOutline=�68   $��20��6N   ���#3AA9AD$��0q�6n   5L      5M      �� 5O      $
��Auto=�6'   $��1��6J   $	��495��6Z   $��Right=�6f   .��5P      �� -   5        $��
lvProducts��5P   (   $	��495��6:   $	��180��6F   $��Right=�6S   ��5Q   #   �� *
Products+$ TwoWay=�$	 Explicit=� �� SelectedItem 5R   #   �� *
CurProduct+$ TwoWay=�$	 PropertyChanged=� �� View 5S   "   �� 5T   &   .P�5U   *   �� $��ID��69    �� Width$ 40��6E    �� DisplayMemberBinding 6P   �� *	ProductId+�� 5V   *   $��Category ID��69   $ 90��6N    6Y   �� *
CategoryId+�� 5W   *   $
��Name��69   $	 160��6G    6S   �� *ProductName+�� 5X   *   $��Weight��69   $	 100��6I    6U   �� *Weight+�� 5Y   *   $��Price��69   $	 100��6H    6T   �� *	UnitPrice+ �� StringFormat$	 #,0��5Z   '   5\      5]      5^      �� 5_      -   5        $��lbSecondTitle��5_       
���**��$��	10 20 5 0q�6H   $��DemiBold"�6[   $��20(�6q   $��	Cart List��6   $��2��6�   �� 5`      $
��Auto=�6#   $��3��6F   $	��270��6S   $	��700��6`   $
��Left=�6l   .��5a      &   System.Windows.Controls.DataGrid  -   5          Name$ dgItems��5a   #      AutoGenerateColumns$ False��64      CanUserAddRows$ False��6P   $��
10 10 5 10q�6h      SelectionMode$ Single=�5d      ��5b      �� *	CartItems+$ TwoWay=�$	 Explicit=� 5c      �� *	CurItem+$ TwoWay=�$	 PropertyChanged=�   Columns 5e      0  *System.Windows.Controls.DataGridTextColumn  5f   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��65      
IsReadOnly$
 True��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   �� *	ProductId+6y     5g   "   $
 Name��65   $
 True��6C   $	 150 6}    6U   �� *Product.ProductName+6}     5h   "   $ 
Unit Price��65   $
 True��6I   $	 100 6�    6[   �� *	UnitPrice+$	 #,0��6�     5i   "   $ Quantity��65   $ False��6G   $	 100 6w    6Z   �� *
Quantity+6w     5j   "   $ Discount��65   $ False��6G   $	 140 6w    6Z   �� *
Discount+6w     5k   "   $ Total��65   $
 True��6D   $	 130 6p    6V   �� *Total+6p   5m      5n      �� 5o      -   5        $��btnRemoveItemCart��5o      $��0q�66   $��3��6B   $��680,13,0,79q�6O   $��25��6e   $��25��6p   $	��Top=�5p      
������ 
������ 
������ ��5r   %   �� *RemoveItemCommand+��6K   �� *SelectedItem+$ dgItems��.��5s        $ TrashCan=�60   $��25��6@   
���\\��$��25��6b   $��Center=�6n   5t      �� 5v       �� Orientation$ 
Horizontal=�6!   $��4��6:   .+�5w      �� -   5        $��btnNext��5w   !   $
��Left=�60   $��10,5,0,0q�6K   #��[ 5x   %   $��30��6I   $��90��6U   ���#3AA9AD���#3AA9AD���#FFFFFF��5z   %   �� *NextCommand+.��6E   
Continue5|      �� 5}      -   5        $��	btnCancel��5}   !   #��[ 5~   %   $��30��6I   $��90��6U   $��50,5,0,0q�6`   ���#3AA9AD���#FFFFFF���#3AA9AD��5�   %   �� *BackCommand+.��6E   Back5�      5�      5�      5�      5�      5�      5�      