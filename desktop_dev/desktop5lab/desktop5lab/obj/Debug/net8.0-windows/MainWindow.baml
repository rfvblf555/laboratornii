   M S B A M L   `   `   `  ����F  Bdesktop5lab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:desktop5labdesktop5lab  5   	       desktop5lab.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:desktop5lab     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ShowGridLines$ False��6   
����ح� � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��1��6   $��0��6$   $��Авторизация��61   $��25(�6D    �� TextAlignment$ Center=�6R   $��Center=�6i   �� 5   
   -   5        $��1��5      $��3��6!   $��Вход��6.   $	��100��6=   $��25��6I   $��0 0 0 30q�6U   6g   �� 5   
   -   5        $��1��5      $��3��6!   $��Регистрация��6.   $	��100��6D   $��25��6P   $��0 30 0 0q�6\   6n   �� 5   
   $��1��6   $��3��6!   $��
Выход��6.   $	��100��6>   $��25��6J   $��0 90 0 0q�6V   �� 5   
   $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6f   $��0 0 0 30q�6�   .+�5      �� $��
Логин��6   $��0 0 10 0q�6%   �� 5      -   5         ��Name$ LoginTB��5      $	��150��6'   $��25��63   $
��Left=�6?   5      �� 5   
   $��1��6   $��1��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6f   $��0 30 0 0q�6�   .+�5      �� $��Пароль��6   $��0 0 2 0q�6&   G� 5       -   5         G�Name$ 
PasswordPB��5       $	��150��6.   $��25��6:   $
��Left=�6F   5!      5"      5#      