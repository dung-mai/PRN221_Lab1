   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	   *    $SalesWFPApp.View.ProgressOrderWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SalesWFPApp.View     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  ProgressOrderWindow��5	   	   $	��450��6%   $	��870��62   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��400 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Order Date��6   $
��Left=�6%   $��	10,28,0,0q�6@   $	��Top=�6S   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��txtOrderDate��5      $��Center=�63   $
��Left=�6U   $��
102,28,0,0q�6p   $	��Top=�5      $	��169��6%   $��26��61   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5   !      FormatString$ dd/MM/yyyy HH:mm:ss��61      ErrorTemplate =� ErrorTemplate# [  5   %   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 5      ��  �� Path$ 	OrderDate� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�  NullToEmptyStringConverter
 �� 	Converter#
 [  �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True�� �� ValidatesOnExceptions$
 True��5   %   �� 5    
   $��MemberId��6   $
��Left=�6#   $��
301,26,0,0q�6>   $	��Top=�6R   �� 5!   
   -   5         ��Name$ 	txtMember��5!      $��Center=�6%   $
��Left=�6G   $��
369,26,0,0q�6b    �� TextWrapping$
 Wrap=�5"      $	��Top=�6!   $	��169��69   $��26��6E    �� 
IsReadOnly$
 True��5#      ��6#   �� *CurOrder.Member.MemberId+�� 5%   
   $��Required Date��6   $
��Left=�6(   $��8,69,0,0q�6C   $	��Top=�6U   $��86��6m     5&   
   -   5        $��txtRequiredDate��5&      $��Center=�65   $
��Left=�6W   $��
105,69,0,0q�6r   $	��Top=�5'      $	��166��6&   $��26��62   $ Custom=�5(   !   $ dd/MM/yyyy HH:mm:ss��61   # [  5,   %    5)      �� $ RequiredDate�$ TwoWay=�$	 PropertyChanged=�#
 [ $
 True��$
 True��$
 True��5,   %   �� 5.   
   $��Freight��6   $
��Left=�6"   $��
300,67,0,0q�6=   $	��Top=�6Q   $��48��6i   �� 5/   
   -   5        $ 
txtFreight��5/      $��Center=�6&   $
��Left=�6H   $��
369,67,0,0q�6c   $
 Wrap=�50      $	��Top=�6!   $	��169��69   $��26��6E   # [  53      ��51      �� $ Freight� �� StringFormat$	 #,0��$ TwoWay=�$	 PropertyChanged=�$
 True��$
 True��$
 True��53      � 5D   
   $��1��6    5E      �� 5F      $	��89* �6#   �� 5G      $
��249* �6#   .+�5I      �� $��Total: ��6   $��20(�6'   $��
15,5,263,0q�65   $��2��6I   �� 5J      $��20(�6   $��
79,5,103,0q�6L   $��2��6`   ��6'   �� *CurOrder.TotalMoney+6`   5K      �� 5M   
   -   5        $��	listItems��5M      $��2��6%   $��0��62   $	��570��6B   $
��Left=�6N   $	��250��5N      $��	10 10 0 0q�5O      $	��Top=�6&   ��5P      �� *CurOrder.OrderDetails+$ TwoWay=�$	 Explicit=� �� SelectedItem 5Q      �� *	CurItem+$ TwoWay=�$	 PropertyChanged=� �� View 5R      �� 5S      .P�5T      �� $��
Product ID��6%    �� Width$ 60��6d    �� DisplayMemberBinding 69   �� *	ProductId+6d   �� 5U      $��
Unit Price��6%   $	 140��6x    69   �� *	UnitPrice+$	 #,0��6x   �� 5V      $��Quantity��6%   $	 100��6a    67   �� *
Quantity+6a   �� 5W      $��Discount��6%   $	 140��6a    67   �� *
Discount+6a   �� 5X      $��Total��6%   $	 130��6[    64   �� *Total+6[   5Y      5[      � 5^   
   $��2��6   $��1��6   $��	0,0,277,0q�6,   $��2��6?    5_      �� 5`      $��* �6    �� 5a      $��* �6    �� 5b      $��* �6    .+�5e      �� -   5        $��btnBack��5f       �� 	IsDefault$
 True��5e      $��0��6&   $��30��63   ���#3AA9AD���#FFFFFF���#3AA9AD$	��100��5f   $   $
��Left=�5g        
mainButton#��[ 60   $��
13,28,0,28q�6T   ��5f   0   �� *BackCommand+.��5g   h   Back6n   �� 5h      -   5         ��Name$ btnAdd��5i      $
 True��5h      $��1��6'   $��30��64   ���#3AA9AD���#FFFFFF$	��100��5i   !   #��[ 6-   $
��Left=�5j      $��Finish��6,   $��
13,28,0,29q�6=   ��5i   Q   �� *FinishCommand+5j   =   5k      5l      5m      