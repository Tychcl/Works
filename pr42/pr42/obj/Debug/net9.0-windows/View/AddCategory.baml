   M S B A M L   `   `   `  ����?  ;pr42, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:pr42.View	pr42.View  5          pr42.View.AddCategory   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:pr42.View     5        N� Title$	  Add��5	      $��10q�5
       N� 
FontFamily$ Century Gothic)�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � �� �	#FF4FC3186+   �� 5       � �� �	#FF4FC3186,   �� 5       � ��
 �����6+   5      5      .��5      � 
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 270Q�6      
BlurRadius$ 5Q�6/   	   ShadowDepth$	 2Q�6>   
   Opacity$	
 0.5Q�6N   .+�5   
   �� $��50��6   $��50��6   $��/Images/item.png��6'   $	��Top=�6A   $
��Left=�6Y   $��10q�6t   � 5   
   $��65,0,0,0q�6   .+�5      �� $��Название:��6   $	��Top=�6(   $��
10,10,10,0q�6@   �� 5      $��26��65   $	��Top=�6A   $��
10,36,10,0q�6Y   $��Center=�5       ��5      �� *category.Name+5       �� 5#      $��Сохранить��6   $	��100��6)   $��25��65   $��	0,0,10,10q�6A   $��Bottom=�5$      $��Right=�60   $��1��6L   ��5%      �� *category.OnSave+ 5&        5'      $	 270Q�6'   $ 5Q�67   $	 2Q�6F   $	
 0.5Q�6V   5)      5*      5+      5,      