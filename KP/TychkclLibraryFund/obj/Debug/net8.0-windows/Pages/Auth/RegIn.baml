   M S B A M L   `   `   `  ����M  ITychkclLibraryFund, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TychkclLibraryFund.Pages.AuthTychkclLibraryFund.Pages.Auth  5      )    #TychkclLibraryFund.Pages.Auth.RegIn   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      7local+clr-namespace:TychkclLibraryFund.Pages.Auth  5        N� Title$  RegIn��5	      $��	15 5 15 0q�6   .��5
      � .+�5   
   �� .+�5   
   �� -   5         ��Name$	 fio��5   3      TextBox#��[  6   
 � Tag$ ФИО��6@   �� 5   
   -   5        $ phone��5   3   #��[  6   $ Телефон��6B   �� 5      $-��'Пароль с повторением:��6     ItemTextLabel#��[ 64     	LightBack#��[ 6[   $��16(�6�   G� 5      -   5         G�Name$
 pass��5   ?     PasswordBox#��[ 6   $ Пароль��6M    G� PasswordChar$ *��6Z    G� 
CaretBrush
 �   �6k   G� 5      -   5        $ dpass��5   ?   #��[ 6   $ Пароль��6N   $ *��6[   
 �   �6l   5      >� 5   
   -   5         >�Name$ logbtn��5        USStyle#��[ 5      $��40��67   $��40��6B   $
��Left=�5      $��Bottom=�6!   $��	0 0 0 8.5q�5      .��5      �� -   5         � ToolTip$ 
Войти��5   %     FontAwesome.WPF.Awesome   Content$
 user=�65     
ItemButton#��[ 6O   5      >� 5   
   #��[ 6   $��40��67   $��40��6B   $��Right=�5      $��Bottom=�6*   $��	0 0 0 8.5q�5      .��5      �� -   5        $ Применить��5   #   $ Check=�67   #��[ 6R   5      5      5      