   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	   (    "SalesWFPApp.View.OrderDetailWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   *localclr-namespace:SalesWFPApp.View  5   	     � Title$  OrderDetailWindow��5	   	   $	��450��6#   $	��870��60   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��400 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Order ID��6   $
��Left=�6#   $��	10,30,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5        $��
txtOrderId��5      $��Center=�6$   $
��Left=�6F   $��	88,30,0,0q�6a    �� TextWrapping$
 Wrap=�5      $	��Top=�6&   $	��169��6>   $��26��6J    �� 
IsReadOnly$
 True��6V      ErrorTemplate =� ErrorTemplate# [  5      ��5      ��  �� Path$ OrderId� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  NullToEmptyStringConverter	 �� 	Converter#	 [ 
 �� ValidatesOnDataErrors$

 True�� �� NotifyOnValidationError$
 True�� �� ValidatesOnExceptions$
 True��5      �� 5   
   $��
Order Date��6   $
��Left=�6%   $��	10,67,0,0q�6@   $	��Top=�6S   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��txtOrderDate��5      $��Center=�63   $
��Left=�6U   $��	88,67,0,0q�6p   $	��Top=�5      $	��169��6%   $��26��61   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5    !      FormatString$ dd/MM/yyyy HH:mm:ss��61   # [  5$   %   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 5!      �� $ 	OrderDate�$ TwoWay=�$ PropertyChanged=�#	 [ $

 True��$
 True��$
 True��5$   %   �� 5'   
   $��MemberId��6   $
��Left=�6#   $��
10,104,0,0q�6>   $	��Top=�6R   �� 5(   
   -   5         ��Name$ 	txtMember��5(      $��Center=�6%   $
��Left=�6G   $��
88,104,0,0q�6b   $
 Wrap=�5)      $	��Top=�6!   $	��169��69   $��26��6E   $
 True��5*      ��6#   �� *CurOrder.Member.MemberId+�� 5,   
   $��Required Date��6   $
��Left=�6(   $��
286,30,0,0q�6C   $	��Top=�6W   $��86��6o     5-   
   -   5        $��txtRequiredDate��5-      $��Center=�65   $
��Left=�6W   $��
388,30,0,0q�6r   $	��Top=�5.      $	��152��6&   $��26��62   $ Custom=�5/   !   $ dd/MM/yyyy HH:mm:ss��61   # [  53   %    50      �� $ RequiredDate�$ TwoWay=�$ PropertyChanged=�#	 [ $

 True��$
 True��$
 True��53   %   �� 55   
   $��Shipped Date��6   $
��Left=�6'   $��
285,67,0,0q�6B   $	��Top=�6V   $��83��6n     57   
   -   5        $��txtShippedDate��57      $��Center=�64   $	��Top=�6V   $	��152��58      $��26��6*   $
��Left=�66   $��
388,67,0,0q�6Q   $ Custom=�59   !   $ dd/MM/yyyy HH:mm:ss��61   # [  5=   %    5:      �� $ ShippedDate�$ TwoWay=�$ PropertyChanged=�#	 [ $

 True��$
 True��$
 True��5=   %   �� 5?   
   $��Freight��6   $
��Left=�6"   $��285,104,0,0q�6=   $	��Top=�6R   $��48��6j   �� 5@   
   -   5        $ 
txtFreight��5@      $��Center=�6&   $
��Left=�6H   $��388,104,0,0q�6c   $
 Wrap=�5A      $	��Top=�6!   $	��152��69   $��26��6E   # [  5D      ��5B      �� $ Freight� �� StringFormat$	 #,0��$ TwoWay=�$ PropertyChanged=�$

 True��$
 True��$
 True��5D      �� 5F   
   $��Email��6   $
��Left=�6    $��
583,26,0,0q�6;   $	��Top=�6O   $��93��6g   �� 5G   
   -   5        $ txtEmail��5G      $��Center=�6$   $
��Left=�6F   $��
680,26,0,0q�6a   $
 Wrap=�5H      $	��Top=�6!   $	��170��69   $��26��6E   $
 True��5I      $��2��6K   ��6$   �� *CurOrder.Member.Email+6K   �� 5K   
   $��CompanyName��6   $
��Left=�6&   $��583,67,0,37q�6A   $��93��6V   �� 5L   
   -   5        $ txtCompanyName��5L      $��Center=�6*   $
��Left=�6L   $��
680,67,0,0q�6g   $
 Wrap=�5M      $	��Top=�6!   $	��170��69   $��26��6E   $
 True��5N      $��2��6Q   ��6$   �� *CurOrder.Member.CompanyName+6Q   �� 5P   
   $��Address��6   $
��Left=�6"   $��583,104,0,0q�6=   $	��Top=�6R   $��93��6j   �� 5Q   
   -	   5        $ 
txtAddress��5Q      $��Center=�6&   $
��Left=�6H   $��680,104,0,0q�6c   $
 Wrap=�5R      $	��Top=�6!   $	��170��69   $��26��6E   $
 True��5S      $��2��6=   ��6$   �� *	Address+6=   � 5U   
   $��1��6   .+�5V      �� $��Total: ��6   $��20(�6'   $��
15,5,263,0q�65   �� 5W      $��20(�6   $��
79,5,103,0q�6L   ��6'   �� *CurOrder.TotalMoney+6L   5X      �� 5Z   
   -
   5        $��	listItems��5Z      $��2��6%   $��0��62   $	��570��6B   $
��Left=�6N   $	��250��5[      $��	10 10 0 0q�5\      $	��Top=�6&   ��5]      �� *CurOrder.OrderDetails+$ TwoWay=�$ Explicit=� �� SelectedItem 5^      �� *	CurItem+$ TwoWay=�$ PropertyChanged=� �� View 5_      �� 5`      .P�5a      �� $��
Product ID��6%    �� Width$ 60��6d    �� DisplayMemberBinding 69   �� *	ProductId+6d   �� 5b      $��
Unit Price��6%   $	 140��6x    69   �� *	UnitPrice+$	 #,0��6x   �� 5c      $��Quantity��6%   $	 100��6a    67   �� *
Quantity+6a   �� 5d      $��Discount��6%   $	 140��6a    67   �� *
Discount+6a   �� 5e      $��Total��6%   $	 130��6[    64   �� *Total+6[   5f      5h      � 5k   
   $��2��6   $��1��6   $��	0,0,277,0q�6,   $��2��6?    5l      �� 5m      $��* �6    �� 5n      $��* �6    �� 5o      $��* �6    .+�5q      �� -   5        $��	btnUpdate��5r       �� 	IsDefault$
 True��5q      $��0��6'   $��30��64   $	��100��5r   '   $
��Left=�5s      ��5r   3   �� *UpdateOrderCommand+.��5s   2   Update6:   �� 5u      -   5        $��btnBack��5v      $
 True��5u      $��1��6&   $��30��63   $	��100��5v   $   $
��Left=�5w      ��5v   0   �� *BackCommand+.��5w   1   Back67   �� 5y      -   5         ��Name$ btnAdd��5z      $
 True��5y      $��2��6'   $��30��64   $	��100��5z   !   $
��Left=�5{      $	��Add��6,   5}      5~      5      