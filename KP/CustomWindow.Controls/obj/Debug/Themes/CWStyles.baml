   M S B A M L   `   `   `  ����P  LCustomWindow.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CustomWindow.ControlsCustomWindow.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466  �� 
TargetType   WindowButtonStyle �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat �� Triggers	 P� Property
 P� Value �� BasedOn  WindowButtonStyleRed$    CustomWindow.Controls.CWWindow  CWWindowStyle �Name J� OpacityMask �� CornerRadius 
� GradientOrigin 
� Center 
� RadiusX 
� RadiusY � Color � Offset � RowDefinitions � ColumnDefinitions K� ZIndex � Title �� TextAlignment �� Padding � IsActive ��Name  FontAwesome.WPF.Awesome   Content ��Name'  !System.Windows.Shell.WindowChrome   GlassFrameThickness    ResizeBorderThickness!   CaptionHeight�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      -fa$http://schemas.fontawesome.io/icons/  5      -local#clr-namespace:CustomWindow.Controls  5      %   &	        &	 �    7   &	     7   7   7   7  �� 5      "  ��6   .�5   
   ��  � �� 6'   Z� �� 5   
    � ��$ Webdings)�6'   �� 5	   
    � ��$ 13.333(�6%   �� 5
   
    � �� �#E3CB536'   �� 5   
    � ��$ 2q�6$   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ Chrome��5      #��z��5      $��0q�5      #��z��5       . ._�5      �� #��z��5   !   #��z��5   !   # z 5   !   #��z��5   !   #��z��5   !   ��. # z 5   !   #��z��5   !   5      5      5!       5"   
   P� 5#      	 �@J�IsMouseOver
 . . �5$      ��  � ��
 �����6/   5%      5'      �� 5)      "  ��6   8    5*   
   P� 5+      	 �@J�IsMouseOver
 . . �5,      ��  � ��
 �  ��6/   5-      5/      �� 51      "    6   .�52   
   ��  � �� 6'   Z� �� 53   
    � �� 6(   Z� �� 54   
    � ��$	 320��6&   �� 55   
    � ��$	 500��6%   �� 56   
    �@��BitmapScalingMode$ HighQuality=�6<   �� 57   
    �@�Title 6"   �� *Title+�� 58   
    �@�AllowsTransparency . 6/   �� 59   
    �@�WindowStyle$
 None=�6(   �� 5;   
    � �� 5<      �� 5=      "   6"   .R�5@      � $ 
WindowRoot��64   
������  6H   Z� .+�5A      �� $ 15��6!   $��0q�63   ��5B      
� 5C   "   $	 1,0&�66   $	 1,0&�6K   $	 0.9Q�6X   $	 0.9Q�6f   .��5D   &   � $ #553743��63   $ 0Q�6C   � 5E   &   $ #140033��63   $ 1Q�6C   5F   #   ._�5H      � $ 
LayoutRoot��6#   #��z��5I       5J   "   �� 5K   &   $��30 �64   �� 5L   &   $��* �64   .+�5P   "   � $ PART_HeaderBar��6'    5Q   &   �� 5R   *   $
��Auto �6;   �� 5S   *   $��* �6;   �� 5T   *   $
��Auto �6;   .+�5W   &   �� $��0��60   $��3��5X   )   $��Stretch=�5Y   )   $
��Auto��5Z   )   $��Center=�5[   )   $ 1��5\   )   ��5]   )   Z� �� 5_   &   $��0��6-   $��3��6=   $
��Left=�5`   -   $��Center=�6H   ���#632D47$ 15,0,0,0��5a   B   $��57��6Z   $��0q�5b   -   ._�5c   *   �� #��z 64   $��CharacterEllipsis=�5d   ,   $��13(�5e   ,   $ Center=�5f   ,   $��Segoe Script)�5g   ,   $
��Bold"�5h   ,   $ 10q�5i   ,   $��Center=�5j   ,   $
��Auto��5k   ,   ���#E3CB53$ 0��5m   ,   #{�z 5n   ,   $��Center=�5o   ,   5p   '   � 5r   &   $ WindowControlsGrid��6+   $��2��6G   $ 2��6m   $��0 5 5 0q�6~   ��6W   Z�  5s   *   �� 5t   .   $��30 �6?   �� 5u   .   $��30 �6?   �� 5v   .   $��30 �6?   .+�5y   *   �� $ MinimizeButton��61   8��  $ WindowMinimize=�5z   -   $C��=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)�5{   -   $��10(�5|   -   $��Center=�5}   -   $��0��5~   -   �� 5�   *   $ MaximizeButton��61   8�� $ WindowMaximize=�5�   -   $C��=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)�5�   -   $��10(�5�   -   $��Center=�5�   -   $��1��5�   -   �� 5�   *   $ RestoreButton��61   8�� $ WindowRestore=�5�   -   $y�	Collapsed=�5�   -   $C��=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)�5�   -   $��10(�5�   -   $��Center=�5�   -   $��1��5�   -   �� 5�   *   $ CloseButton��61   8�� $ Times=�5�   -   $C��=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)�5�   -   $��15(�5�   -   $��Center=�5�   -   $��2��5�   -   5�   '   5�   #   � 5�   "   $ PART_MainContentGrid��6'   $��1��5�   #   $ 10��5�   #   .+�5�   &   �� $ PART_MainContentPresenter��67   $��1��6Z   5�   #   5�      5�      5�      5�      5�      �� 5�   
    �@ WindowChrome 5�        5�      $ 2q�6   $  8q�5�      $! 0Q�5�      5�      5�      5�      