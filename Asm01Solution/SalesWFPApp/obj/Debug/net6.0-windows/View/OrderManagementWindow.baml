   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	   ,    &SalesWFPApp.View.OrderManagementWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   *localclr-namespace:SalesWFPApp.View  5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Order Management Window��5	   	   $	��450��6)   $	��830��66   .��5
      � ���#F2F2F2 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
      SalesWFPApp.View.MenuBar  � 5   
   $��1��6   ���#F2F2F2$
��0,10q�61    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��
10 0 10 10q�6$   ���#FFFFFF��5      �� 5      $��Search��6   $��17(�6-   $��SemiBold"�6;   ���#3AA9AD$��30��6f   .��5      �  5      �� 5      $
��Auto �6(   �� 5       $
��Auto �6(   �� 5!      $
��Auto �6(   .+�5#      �� $��0��6!    �� Orientation$ 
Horizontal=�6.   $��	20,0,10,0q�6G   .+�5$      �� $��Email��6    $
��Left=�60   $��Center=�6K   �� 5%      -   5         ��Name$ txtEmail��5%   "   $��Center=�64   $
��Left=�6V   $��10,0,0,0q�6q    �� TextWrapping$
 Wrap=�5&      $	��Top=�61   $	��170��6I   $��26��6U      ErrorTemplate =� ErrorTemplate# [  5*   )   ��5'   "   �� *Email+  NullToEmptyStringConverter �� 	Converter# [  �� Mode$ TwoWay=�	 �� NotifyOnValidationError$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnDataErrors$
 True�� �� ValidatesOnExceptions$
 True��5*   )   �� 5+      $��
Start Date��6    $��35,0,0,0q�65   $��Center=�6H   &   Xceed.Wpf.Toolkit.DateTimePicker  5,      -   5          Name$ txtStartDate��5,   .   $	��155��5-   !   $��10,0,0,0q�6-   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5.   !      FormatString$ dd/MM/yyyy HH:mm:ss��61   $��Center=�6T   # [  52   )   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 5/   !   �� *	StartDate+$ TwoWay=�$
	 True��$
 PropertyChanged=�$
 True��$
 True��52   )   �� 53      $��35,0,0,0q�6    $��End Date��62   $��Center=�6F     54      -   5        $ 
txtEndDate��54   .   $	��155��55   !   $��10,0,0,0q�6-   $ Custom=�56   !   $ dd/MM/yyyy HH:mm:ss��61   $��Center=�6T   # [  5:   )    57   "   �� *	EndDate+$ TwoWay=�$
	 True��$
 PropertyChanged=�$
 True��$
 True��5:   )   5;      � 5<      $��1��6   $��0,10,0,0q�6(   .+�5=      �  � ColumnDefinitions 5>      �� 5?   "   $
��Auto �63   �� 5@   "   $
��Auto �63   .+�5B      �� -   5        $��	btnSearch��5B   %   $��0��66     
mainButton#��[ 5C   %   $��30��6I   $��90��6U   $��20,5,0,0q�6`   ���#3AA9AD���#3AA9AD���#FFFFFF��5E   %   �� *SearchOrderCommand+.��6L   Search5G      �� 5H      -   5        $��btnReset��5H   %   $��1��65   #��[ 5I   %   $��30��6I   $��90��6U   $��20,5,0,0q�6`   ���#3AA9AD���#FFFFFF���#3AA9AD��5K   %   �� *ResetCommand+.��6F   Reset5M      5N      5O      5P      5Q      �� 5S      $��1��6   $��	0,10,10,0q�6&   ���#FFFFFF.+�5T      �  5U      �� 5V      $��* �6+   �� 5W      $
��Auto �6+   �� 5X      $
��Auto �6+   .+�5Z      �� -   5        $��btnAdd��5Z      ���#3AA9AD���#3AA9AD���#FFFFFF$��1��6k   #��[ 5[      $��30��6@   $��90��6L   $��	10 5 10 0q�6W   $	��Add��6j   ��5\      �� *AddOrderCommand+�� 5]      -   5        $��btnView��5]      $��2��6L   ���#3AA9AD
�������$��0 5 10 0q�5^   G   #��[ 5_      $��30��6A   $��90��6M   $
��View��6Y   ��5]   ,   �� *ViewCommand+5_   Y   �� 5`      $��0��6   $��
Order List��6,   $��20(�6A   $��SemiBold"�6O   ���#3AA9AD$��	10 0 10 0q�6z   5a      &   System.Windows.Controls.DataGrid  5b      -   5          Name$ dgOrders��5b         AutoGenerateColumns$ False��6-      CanUserAddRows$ False��6I      
IsReadOnly$
 True��5c      $��
10 10 5 10q�6-      SelectionMode$ Single=�5f      ��5d      �� *Orders+$ TwoWay=�$
 Explicit=� �� SelectedItem 5e      �� *
CurOrder+$ TwoWay=�$
 PropertyChanged=�   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6U   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 69   �� *	OrderId+6U     5i      $ 
Order Date��6-   $	 138 6_    6A   �� *	OrderDate+6_     5j      $ Member��6-   $	 170 6^    6=   �� *Member.Email+6^     5k      $ Required Date��6-   $	 138 6e    6D   �� *RequiredDate+6e     5l      $ Shipped Date��6-   $	 138 6c    6C   �� *ShippedDate+6c     5m      $ Freight��6-   $ 80 6n    6>   �� *	Freight+ �� StringFormat$	 #,0��6n     5n      $ Total��6-   $ 80 6[    6<   �� *
TotalMoney+6[   5p      �� 5r      $��Center=�6   $��18(�65   $��SemiBold"�5s      ��6.   �� *	EmptyMess+5t      5u      5v      5�      