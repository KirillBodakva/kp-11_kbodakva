   M S B A M L   `   `   `  ����@  <Lab 4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_4Lab_4  5   	       Lab_4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_4     5   	     � Title$e  _Головне вікно інформаційної системи виставки собак��5   	   $	��500��6D   $	��840��6Q    � 
ResizeMode$ NoResize=�6]    � Cursor$ Arrow��6s   .��5	      �  J� OpacityMask �	#FFACA9A9$ Arrow��6#   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dt��5      $
��Left=�6   $	��671��5      $��
24,44,0,37q�6   $��Segoe UI)�63   $ Cross��6I   5      �� 5   
   -   5         ��Name$ cb��5      $
��Left=�6   $��40��6:   $��
713,95,0,0q�6F   $	��Top=�5      $��93��6+   $��Center=�66   $��Center=�5      $
 Hand��67   .@�5      �� $��Breeds��6   �� 5      $
��Dogs��6   �� 5      $��Experts��6   �� 5      $��Clubs��6   �� 5      $��Medals��6   �� 5      $��Vystupy��6   �� 5      $��Owners��6   �� 5      $��DogClub��6   �� 5      $��OwnerDog��6   5      �� 5   
   -   5         ��Name$ b1��5      $
��Open��6   $
��Left=�6,   $��713,152,0,0q�6G   $��40��5      $��93��6   $	��Top=�6(   $
 Hand��6Q   5       �� 5"   
   -   5        $ b2��5"      $
��Exit��6   $
��Left=�6,   $��713,382,0,0q�6G   $��93��5#      $
 Hand��6-   $��40��6;   $	��Top=�6G   5$      �� 5&   
   -   5        $ b3��5&      $
��Edit��6   $
��Left=�6,   $��713,209,0,0q�6G   $��40��5'      $��93��6   $	��Top=�6$   $
 Hand��6M   �� 5(   
   -   5        $ b4��5(      $��Certificate��6   $
��Left=�63   $��713,266,0,0q�6N   $��40��5)      $��93��6   $	��Top=�6$   $
 Hand��6M   �� 5*   
   $
��Left=�6   $��29��6/   $��	24,10,0,0q�6;   $
��Wrap=�6N   $����Перегляд даних з вибраної таблиці.                          Для редагування оберіть зі списку необхідну таблицю та нажміть Edit.��6b   $	��Top=�6�   $	��671��6  �� 5+   
   -   5        $ b5��5+      $��Query��6   $
��Left=�6-   $��713,323,0,0q�6H   $��40��5,      $��93��6   $	��Top=�6$   $
 Hand��6M   �� 5-   
   $
��Left=�6   $��35��6/   $��
730,44,0,0q�6;   $
��Wrap=�6O   $$��Оберіть таблицю:��6c   $	��Top=�6{   $��76��6�   5.      5/      