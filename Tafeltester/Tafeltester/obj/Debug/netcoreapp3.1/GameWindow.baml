   M S B A M L   `   `   `  ����F  BTafeltester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TafeltesterTafeltester  5   	       Tafeltester.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Tafeltester     5   	     � Title$  Game Window��5      $
��1080��6   $
��1920��6'    � WindowStyle$
 None=�64    � WindowState$ 	Maximized=�6G   .��5	      � .+�5
   
   �� -   5         ��Name$ 
Background��5
      $
��1920��6$   $
��1080��61    J� Opacity$	 0.8Q�6?   $��/classroom.jpg��6M   �� 5   
   -   5        $��x��5      $
��Left=�6   $��	88,34,0,0q�68   $	��Top=�6K   $��60��6c   $��60��6o   $��Montserrat SemiBold)�6�   $��38(�6�   ��6z   Z� ��6�   Z� 6�   �� 5   
   -   5         ��Name$ somLabel��5      $��Label��6"   $
��Left=�62   $��446,392,0,0q�6M   $	��Top=�6b   $	��167��6z   $
��1047��6�   $��Center=�6�   $��Center=�6�   
�������$
��Bold"�6�   $��56(�6�   $��Normal$�6  $��Normal&�6   �� 5   
   -   5        $ labels1��5      $
��Som:��6!   $
��Left=�60   $��643,378,0,0q�6K   $	��Top=�6`   $��88��6x   $	��653��6�   $��Center=�6�   $��Center=�6�   
�������$��DemiBold"�6�   $��36(�6�   $��Normal$�6  $��Normal&�6   �� 5   
   -   5        $ labels2��5      $��Vul het antwoord in��6!   $
��Left=�6?   $��643,481,0,0q�6Z   $	��Top=�6o   $��88��6�   $	��653��6�   $��Center=�6�   $��Center=�6�   
�������$��DemiBold"�6�   $��36(�6  $��Normal$�6  $��Normal&�6/  �� 5   
   -   5         ��Name$ 	awnserbox��5      $
��Left=�6%   $��302,625,0,0q�6d   $��Antwoord��6y    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $
��1336��6�   $��48��6�   $��Center=�6�   $��Center=�6�   ���	#72FFFFFF
���   �$��36(�6?  $
��Bold"�6M   �� SelectionBrush
 �����	 �� TextDecorations	 6_  Z� 6�  �� 5   
   -   5        
 ��Name$
 
nextButton��5      $��Volgende��6%   $
��Left=�68   $��854,748,0,0q�6S   $	��Top=�6h   $��96��6�   $	��230��6�   $��Center=�6�   $��Center=�6�   ���	#BFFFFFFF
���   �$��36(�6	  $
��Bold"�6  6)  �� 5   
   -   5        $ 
scorelabel��5      $��Score: 0��6$   $
��Left=�67   $��642,256,0,0q�6R   $	��Top=�6g   $��88��6   $	��654��6�   $��Center=�6�   $��Center=�6�   
�������$��DemiBold"�6�   $��36(�6  $��Normal$�6  $��Normal&�6'  5      5      