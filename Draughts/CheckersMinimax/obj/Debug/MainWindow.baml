   M S B A M L   `   `   `  ����J  FCheckersMinimax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CheckersMinimaxCheckersMinimax  5   	        CheckersMinimax.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CheckersMinimax     5   	     � Title$  
MainWindow��5   	   $	��680��6   $	��820��6)    � 
ResizeMode$ CanMinimize=�65    � 	Resources 5	         CheckerButtonTemplate �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� ContentStringFormat �� ContentStringFormat	 �� Triggers
 P� Property P� Value �� 
TargetName �� Value �� Property  DataTemplate_Level1  DataTemplate_Level2 �� Orientation��%L  &	        &	 �    �� 5   
   " ��68   .R�5      �� $ border��6   #��z��6%   #��z��6Q   #��z��6�    . ._�5      �� $ contentPresenter��6#   #��z��6=   #��z��6q   # z 6�   |�.  #��z��6�   #��z��6&  ��. # z 6d  #��z��6�  5      	 5      P� 5      
 �@��IsDefaulted . . �5      �� $ border��64   # � ��6H    � ��5      P� 5      
 �@J�IsMouseOver . . �5      �� $ border��64    � �� �#EB00096H   5      P� 5      
 � �� . . �5      �� $ border��64    � �� �#00EB156H   5      P� 5      
 �@d�	IsChecked$
 TrueY�6<   . �5      �� $ border��63    � �� �#05FF046G   �� 5       $ border��64    � �� �	#FF245A836H   5!      P� 5"      
 � {� .  . �5#      �� $ border��63    � ��
 ���� 6G   �� 5$      $ border��64    � ��
 ���� 6H   5&      5(      �� 5*   
   .R�5+      �� #���  63   ��6   �� ��5-      �� 5.      .R�5/      �� $ 
Horizontal=�6%   50      52      53      55      .��56      �  � ColumnDefinitions 57   
   �� 58      $
��471* �6   �� 59      $
��175* �6   �� 5:      $
��174* �6   .+�5?   
   o�  o� 
IsMainMenu . $��20��6!   $	��245��6-   $��0 0 0 0q�69   $	��Top=�6J   $��3��6c   .@�5A      m� -   5        $��	_New Game��5A      6*   m� 5B      -   5        $��Developer Information��5B      66   m� 5C      -   5        $
��Quit��5C      6%   5E      �� 5H   
   -   5         ��Name$	 lst��5H      #���  6$   $��20,20,20,20q�6Y   $��3��6n   �� 5I   
   $��28(�6   $��2��6"   $��0,0,2,2q�62   �� 6D   �� 6J   �� 6P   �� 6\   �� 6b   �� 6n   �� 6t   �� 6z   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�   �� 6�    � Language$ en-in�6�   $	�   ��6  �� 6  .�6  �� $�Welcome ��6  6+  �� 61  �� 6=  $ en-in�6A  $�        ��6R  �� 6d  .�6j  �� $�to��6n  6{  �� 6�  �� 6�  $� ��6�  �� 6�  $ en-in�6�  $�  ��6�  �� 6�  .�6�  �� $�Draughts��6�  6�  6�  5L      5M      