   M S B A M L   `   `   `  ����   TodoList    TodoList.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
To-do List��$	��450��$
��1256��.��� 
�������$��0,0,74,0q� � RowDefinitions �� $
��Auto ��� .+���  �� Orientation$ 
Horizontal=�$��
10,10,10,0q�.+��� -    ��Name$ txtTitle��$	��200��$��10q�$��Title��$��14(��� -   $ txtDescription��$	��200��$��10q�$��Description��$��14(�(  "System.Windows.Controls.DatePicker  -     Name$ 	dpDueDate��$��10q��� -    ��Name$ 
btnAddTask��$��Add Task��$��10q�
������$��14(��� -   $ btnEditTask��$��	Edit Task��$��10q�
����ح�$��14(��� -   $ btnDeleteTask��$��Delete Task��$��10q�
�������$��14(��� -   $ btnMarkAsComplete��$��Mark As Complete��$��10q�
�������$��14(��� -    ��Name$ lvTasks��$��1��$��10,10,-76,10q����� *Tasks+����  �� 
TargetType" ��.���  �� Property � ��	 �� Value
	 �   �
 �� Triggers
 ��  �� Binding �� *	Completed+ �� Value True.a���  � ��
	 � � ���  �� *	IsOverdue+ True.a���  � ��
	 �  �� �� View �� .P��� $��Title�� �� DisplayMemberBinding �� *Title+�� $��Description�� �� *Description+�� $��Due Date�� �� *	DueDate+�� $ 
Horizontal=�$��Right=�$��10q�.+��� $��Filter:��$��Center=��� -	    ��Name$ 	cmbFilter��$	��142��$��10q�.@��� $	��All�� �� 
IsSelected$
 True���� $��	Completed���� $��
Incomplete��