   M S B A M L   `   `   `  ����?  ;pr42, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:pr42.View.Itemspr42.View.Items  5          pr42.View.Items.Items   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:pr42.View.Items     5      $��Stretch=�5      $��5q�6=     � 	Resources  5	       �� 
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
   $��65,0,0,0q�6   	 � ColumnDefinitions	 5,      �� 5-      $��1* �6#   �� 5.      $��1* �6#   .+�51      �� $��
Item name:��6   $	��Top=�6)   $��
10,10,10,0q�6A   �� 52      $��26��6,   $	��Top=�68   $��
10,36,10,0q�6P   $��Center=�53      ${�False��68   ��52      �� *Name+53   8   �� 55      $��Price:��6   $	��Top=�6%   $��
10,10,10,0q�6=   $��1��6Q   �� 56      $��25��6-   $	��Top=�69   $��
10,37,10,0q�6Q   $��Center=�57      ${�False��68   $��1��6J   ��56      �� *Price+57   J   �� 59      $��	Category:��6   $	��Top=�6(   $��
10,67,10,0q�6@   $��2��6T   �� 5:      $��25��65   $	��Top=�6A   $��
10,93,10,0q�6Y   $��Center=�5;      ${�False��68   $��2��6J   ��5:      �� *Category.Name+5;   J   �� 5=      $��Description:��6   $	��Top=�6+   $��10,123,10,0q�6C   $��2��6X   �� 5>      $��10,150,10,10q�63   $��Center=�6I   ${�False��5?      $��2��6(   ��5>      �� *Descriprion+5?   (   5@      5A      5B      