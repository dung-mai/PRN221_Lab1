   M S B A M L   `   `   `  ����N  JSalesWFPAppAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SalesWFPApp.ViewSalesWFPApp.View  5   	   #    SalesWFPApp.View.MemberWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SalesWFPApp.View     5   	     � Title$  Member Management��5   	   $	��450��6#   $	��800��60   .��5	      �� .+�5
   
      SalesWFPApp.View.MenuBar  � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��	Member ID��6   $
��Left=�6(   $��	10,30,0,0q�6C   $	��Top=�6V   �� 5      -   5         ��Name$ txtMemberId��5      $��Center=�6+   $
��Left=�6M   $��
118,30,0,0q�6h    �� TextWrapping$
 Wrap=�5      $	��Top=�6&   $	��184��6>   $��26��6J    �� 
IsReadOnly$
 True��6V      ErrorTemplate =� ErrorTemplate# [  5      ��5      �� *
MemberId+  NullToEmptyStringConverter �� 	Converter# [  �� Mode$ TwoWay=� �� NotifyOnValidationError$
 True��	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� ValidatesOnDataErrors$

 True�� �� ValidatesOnExceptions$
 True��5      �� 5      $��Email��6   $
��Left=�6$   $��	10,67,0,0q�6?   $	��Top=�6R   �� 5      -   5        $ txtEmail��5      $��Center=�6(   $
��Left=�6J   $��
118,67,0,0q�6e   $
 Wrap=�5      $	��Top=�6!   $	��184��69   $��26��6E   # [  5      ��5      �� *Email+# [ $ TwoWay=�$
 True��$	 PropertyChanged=�$

 True��$
 True��5      �� 5      $��Company Name��6   $
��Left=�6+   $��
10,104,0,0q�6F   $	��Top=�6Z   �� 5      -   5        $ 
txtCompany��5      $��Center=�6*   $
��Left=�6L   $��118,104,0,0q�6g   $
 Wrap=�5      $	��Top=�6!   $	��184��69   $��26��6E   # [  5       ��5      �� *CompanyName+# [ $ TwoWay=�$
 True��$	 PropertyChanged=�$

 True��$
 True��5       �� 5"      $��Password��6   $
��Left=�6'   $��
324,30,0,0q�6B   $	��Top=�6V   �� 5#      -   5        $ txtPassword��5#      $��Center=�6+   $
��Left=�6M   $��
432,30,0,0q�6h   $	��Top=�5$      $	��184��6&   $��26��62   # [  5&      ��5%      �� *
Password+# [ $ TwoWay=�$
 True��$	 PropertyChanged=�$

 True��$
 True��5&      �� 5(      $
��City��6   $
��Left=�6#   $��
327,67,0,0q�6>   $	��Top=�6R   �� 5)      -   5        $ txtCity��5)      $��Center=�6'   $
��Left=�6I   $��
432,67,0,0q�6d   $
 Wrap=�5*      $	��Top=�6!   $	��184��69   $��26��6E   # [  5,      ��5+      �� *City+# [ $ TwoWay=�$
 True��$	 PropertyChanged=�$

 True��$
 True��5,      �� 5.      $��Country��6   $
��Left=�6&   $��324,104,0,0q�6A   $	��Top=�6V   �� 5/      -   5        $ 
txtCountry��5/      $��Center=�6*   $
��Left=�6L   $��432,104,0,0q�6g   $
 Wrap=�50      $	��Top=�6!   $	��184��69   $��26��6E   # [  52      ��51      �� *	Country+# [ $ TwoWay=�$
 True��$	 PropertyChanged=�$

 True��$
 True��52      �� 54      -   5         ��Name$ btnNew��54   #   $	��New��6   $
��Left=�6X   $��
58,161,0,0q�6s   $	��Top=�6�   $	��118��6�   $��25��6�   ��63   �� *AddMemberCommand+6�   �� 55      -   5        $ 	btnUpdate��55   &   $��Update��6   $
��Left=�6�   $��195,161,0,0q�6�   $	��Top=�6�   $	��118��6�   $��25��6�   ��69   �� *UpdateMemberCommand+��6a   �� *	CurMember+6�   �� 56      -	   5        $ 	btnDelete��56   &   $��Delete��6   $
��Left=�6�   $��327,161,0,0q�6�   $	��Top=�6�   $	��118��6�   $��25��6�   ��69   �� *DeleteMemberCommand+��6a   �� *	CurMember+6�   �� 57      -
   5        $ btnReset��57   %   $��Reset��6   $
��Left=�6X   $��465,161,0,0q�6s   $	��Top=�6�   $	��118��6�   $��25��6�   ��67   �� *ResetCommand+6�   �� 59      -   5         ��Name$ listMembers��59      $
��Left=�6,   $	��267��6G   $��	10,20,0,0q�5:      $	��Top=�6&   $	��606��6>   $��1��6J   ��5;      �� *	Members+$ TwoWay=�$	 Explicit=� �� SelectedItem 5<      �� *	CurMember+$ TwoWay=�$	 PropertyChanged=� �� View 5=      �� 5>      .P�5?      �� $��	Member ID��6)    �� Width$ 75��6f    �� DisplayMemberBinding 6<   �� *
MemberId+6f   �� 5@      $��Email��6)   $	 150��6_    68   �� *Email+6_   �� 5A      $��Company Name��6)   $	 100��6l    6?   �� *CompanyName+6l   �� 5B      $
��City��6)   $	 100��6]    67   �� *City+6]   �� 5C      $��Country��6)   $ 75��6c    6:   �� *	Country+6c   �� 5D      $��Password��6)   $	 100��6e    6;   �� *
Password+6e   5E      5G      5I      5J      5K      