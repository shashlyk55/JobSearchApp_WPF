   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practic_App.MVVM.ViewPractic_App.MVVM.View  '    !Practic_App.MVVM.View.VacancyView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /local#clr-namespace:Practic_App.MVVM.View    � 	Resources   �� MergedDictionaries �� Source��  �� $$ ../../styles/ProductTheme.xaml?��� $" ../../styles/InputTheme.xaml?��� $# ../../styles/ButtonTheme.xaml?�%    .��� .+��� $
��15 0q�����  �� 
TargetType" ��.���  �� Property � y� �� Value$ Visible=� �� Triggers ��  �� Binding �� *MainViewModel.IsAdmin+ �� Value	 False.a���  � y�$ 	Collapsed=�.+��� 	 � DataContext	 �� *SelectedVacancy+.+��� 
�������$��0 5 0 0q�$(��"Название вакансии:���� $��0 2 0 0q����� *Title+�� 
�������$��0 5 0 0q�$(��"Название компании:���� $��0 2 0 0q����� *CompanyName+�� 
�������$��0 5 0 0q�$��Описание:���� $��0 2 0 0q����� *Description+�� 
�������$��0 5 0 0q�$��Зарплата:���� $��0 2 0 0q����� *Salary+�� 
�������$��0 5 0 0q�$��Адрес офиса:���� $��0 2 0 0q����� *
Location+�� 
�������$��0 5 0 0q�$��Отрасль:���� $��0 2 0 0q�
 �� SelectedItem
 �� *
Industry+.@��� $
��ИТ���� $��Общепит���� $��Медицина���� $��Транспорт���� $��0 15 0 0q�$��Сохранить������ *SaveVacancyCommand+���� *SelectedVacancy+�� 
�������$��0 15 0 5q�$a��[Пользователи, откликнувшиеся на данную вакансию: ��$��16(��� $��	15 0 15 0q�$��0q�
������ $��3������ *ResponsedUsers+
 �� *SelectedUser+     ProductStyle �� BasedOn��%   '��       7   �� " ��8   ���� .R��  � ColumnDefinitions �� �� .+��� $��0�� �� Orientation$ Vertical=�.+��� $��18(�����  �� Path$ UserName��� ���� $ Email��� ���� $ Phone�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *SelectUserCommand+   CommandParameter �� *SelectedUser+�� 
�������$��0 15 0 5q�$B��<Пользователи, которым дан отказ: ��$��16(��� $��	15 0 15 0q�$��0q�
������ $��3������ *RejectedUsers+
 �� *SelectedUser+  ��%?   '��       7   �� " ��8   .���  �@J�Opacity$	 0.7Q����� .R��  �� �� .+��� $��0��$ Vertical=�.+��� $��18(����� $ UserName��� ���� $ Email��� ���� $ Phone�   $ MouseDoubleClick��.    �� *SelectUserCommand+ �� *SelectedUser+�� $
��15 0q����� " ��.���  � y�$ Visible=� ��  �� *MainViewModel.IsAdmin+ True.a���  � y�$ 	Collapsed=�.+��� 	 �� *SelectedVacancy+.+��� 
�������$��0 5 0 0q�$(��"Название вакансии:���� 
�������$��19(�$��SemiBold"�$��0 2 0 0q����� *Title+�� 
�������$��0 5 0 0q�$(��"Название компании:���� 
�������$��16(�$��SemiBold"�$��0 2 0 0q����� *CompanyName+�� 
�������$��0 5 0 0q�$��Описание:���� 
�������$��16(�$��0 2 0 0q����� *Description+�� 
�������$��0 5 0 0q�$��Зарплата:���� 
�������$��19(�$��SemiBold"�$��0 2 0 0q����� *Salary+ �� StringFormat$ ${0:F2}���� 
�������$��0 5 0 0q�$��Адрес офиса:���� 
�������$��16(�$��0 2 0 0q����� *
Location+�� 
�������$��0 5 0 0q�$$��Дата добавления:���� 
�������$��16(�$��0 2 0 0q����� *	DataAdded+$&  Добавлен: {0:MM/dd/yyyy}��� $��0 15 0 0q� �� �� $
��50px ���  � RowDefinitions �� �� .+��� $��0��$��0��$4��.Откликнуться на вакансию������ *RespondToVacancyCommand+�� $��2��$��0��$#��Отменить отклик������ *CancelRespondCommand+