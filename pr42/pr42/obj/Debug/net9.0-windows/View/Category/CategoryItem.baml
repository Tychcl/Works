   M S B A M L   `   `   `  ����?  ;pr42, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:pr42.View.Categorypr42.View.Category  5      %    pr42.View.Category.CategoryItem   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:pr42.View.Category     5      $��Stretch=�5      $��5q�6=     � 	Resources  5	       �� 
TargetType 
  Update �� Property �� Value 
 Delete��%X  &	        &	 �     �� 5
   
   " ��6   .�5      ��  � �� �	#FF4FC3186+   �� 5       � �� �	#FF4FC3186,   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � �� �	#FFC34E186+   �� 5       � �� �	#FFC34E186,   �� 5       � ��
 �����6+   5      5      .��5      � 
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 270Q�6      
BlurRadius$ 5Q�6/      ShadowDepth$ 2Q�6>      Opacity$	 0.5Q�6N   .+�5   
   �� $��50��6   $��50��6   $��/Images/item.png��6'   $	��Top=�6A   $
��Left=�6Y   $��10q�6t   �� 5   
   #��[  6   $��25��61   $��Update��6=   $	��Top=�6N   $
��Left=�5      $��	10,72,0,0q�6,   $��55��6?   $��10(�6J   ��6X   �� *OnEdit+ 5        5       $	 270Q�6#   $ 5Q�63   $ 2Q�6B   $	 0.5Q�6R   5"      �� 5$   
   #��[ 6   $��25��61   $��Delete��6=   $	��Top=�6N   $
��Left=�5%      $��
10,102,0,0q�6,   $��55��6@   $��10(�6K   ��6Y   �� *
OnDelete+ 5&        5'      $	 270Q�6#   $ 5Q�63   $ 2Q�6B   $	 0.5Q�6R   5)      � 5+   
   $��65,0,0,0q�6   	 � ColumnDefinitions	 5,      �� 5-      $��1* �6#   �� 5.      $��1* �6#   .+�51      �� $��Category name:��6   $	��Top=�6-   $��
10,10,10,0q�6E   �� 52      $��26��6,   $	��Top=�68   $��
10,36,10,0q�6P   $��Center=�53      ${�False��68   ��52      �� *Name+53   8   54      55      56      