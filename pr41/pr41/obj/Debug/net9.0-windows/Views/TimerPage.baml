   M S B A M L   `   `   `  ����?  ;pr41, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pr41.Views
pr41.Views  5          pr41.Views.TimerPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:pr41.Views     5        N� Title$  	TimerPage��5      .��5
      �� 
���   � � DataContext 6$   �� *Timer+.+�5   
   �� -   5        $��Секундомер��5      $��25��6&   
�������$��5q�6E   6P   �� 5   
   $��5 0 5 5q�6   .+�5      �� $��Секунд��6   
�������6&   �� 5      ��6   �� *InitialTime+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   
�������$��48(�6#   $��Center=�61   $��5 0 5 5q�6u   ��6U   �� *TimeDisplay+6u   �� 5   
   .+�5      �� $��5 0 5 5q�6�   
���������6   �� *
TextButton+��64   �� *DataContext.StartCommand+ �� RelativeSource ��  �� AncestorType Page6�   �� 5      $��Обратно��6   $��5 0 5 5q�6�   
���������6'   �� *DataContext.ResetCommand+ ��  Page6�   5      5      5      