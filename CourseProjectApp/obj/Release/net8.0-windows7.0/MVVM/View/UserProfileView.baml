   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practic_App.MVVM.ViewPractic_App.MVVM.View  +    %Practic_App.MVVM.View.UserProfileView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /local#clr-namespace:Practic_App.MVVM.View    � 	Resources   �� MergedDictionaries �� Source��  �� $$ ../../styles/ProductTheme.xaml?��� $" ../../styles/InputTheme.xaml?��� $# ../../styles/ButtonTheme.xaml?�%    .��� .+��� $��Hidden=�$��
0 0 10px 0q�.���� $��15q�.+���  � DataContext �� *ProfileOwner+.+��� 
�������$��0 5 0 0q�$��Логин:���� $��0 2 0 0q����� *Login+�� 
�������$��0 5 0 0q�$��Имя:���� $��0 2 0 0q����� *
UserName+�� 
�������$��0 5 0 0q�$��Эл. почта:���� $��0 2 0 0q����� *Email+�� 
�������$��0 5 0 0q�$��Телефон:���� $��0 2 0 0q����� *Phone+�� 
�������$��0 5 0 0q�$��Биография:����  �� TextWrapping$
 Wrap=�$
��Auto=�$	��100��$��0 2 0 0q����� *	Biography+�� $��0 15 0 0q�$��Сохранить������ *SaveUserDataCommand+���� *ProfileOwner+�� 
�������$��0 15 0 5q�$D��>Вакансии, на котрые вы дали ответ: ��$��16(��� $��	15 0 15 0q�$��0q�
������ $��3������ *ResponsedVacancies+ �� SelectedItem �� *SelectedVacancy+   �� 
TargetType   ProductStyle �� BasedOn��%   '��       7   �� " ��8   ���� .R��  � ColumnDefinitions �� �� .+��� $��0��	 �� Orientation$	 Vertical=�.+��� $��18(����� 
 �� Path$
 Title��� ���� $
 CompanyName��� ���� $
 Location��� $��1��$	 Vertical=�$��Right=�.+��� ���� $
 Salary� �� StringFormat$ ${0:F2}���� ���� $
 	DataAdded�$&  Добавлен: {0:MM.dd.yyyy}��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *SelectVacancyCommand+   CommandParameter �� *SelectedVacancy+�� 
�������$��0 15 0 5q�$F��@Вакансии, на котрые вам дали отказ: ��$��16(��� $��	15 0 15 0q�$��0q�
������ $��3������ *CanceledVacancies+ �� *SelectedVacancy+   �� Property �� Value��%=   '��       7   �� " ��8   .���  �@J�Opacity$ 1Q����� .R��  �� �� �� .+��� $��0��$	 Vertical=�.+��� $��18(����� $
 Title��� ���� $
 CompanyName��� ���� $
 Location��� $��1��$��10q�$��20(�
���  ��$��Отказано!���� $��2��$	 Vertical=�$��Right=�.+��� ���� $
 Salary�$ ${0:F2}���� ���� $
 	DataAdded�$&  Добавлен: {0:MM.dd.yyyy}��   $ MouseDoubleClick��.    �� *SelectVacancyCommand+ �� *SelectedVacancy+�� 
�������$��0 15 0 5q�$-��'Одобренные вакансии: ��$��16(��� $��	15 0 15 0q�$��0q�
������ $��3������ *AcceptedVacancies+ �� *SelectedVacancy+  ��%=   '��       7   �� " ��8   .���  �@J�Opacity$ 1Q����� .R��  �� �� �� .+��� $��0��$	 Vertical=�.+��� $��18(����� $
 Title��� ���� $
 CompanyName��� ���� $
 Location��� $��1��$��10q�$��20(�
���"�"�$��Одобрено!���� $��2��$	 Vertical=�$��Right=�.+��� ���� $
 Salary�$ ${0:F2}���� ���� $
 	DataAdded�$&  Добавлен: {0:MM.dd.yyyy}��   $ MouseDoubleClick��.    �� *SelectVacancyCommand+ �� *SelectedVacancy+