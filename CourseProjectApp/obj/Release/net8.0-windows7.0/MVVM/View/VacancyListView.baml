   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practic_App.MVVM.ViewPractic_App.MVVM.View  +    %Practic_App.MVVM.View.VacancyListView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /local#clr-namespace:Practic_App.MVVM.View    � 	Resources   �� MergedDictionaries �� Source��  �� $$ ../../styles/ProductTheme.xaml?��� $" ../../styles/InputTheme.xaml?��� $# ../../styles/ButtonTheme.xaml?�%    .���  � RowDefinitions �� $��70 ���  � ColumnDefinitions �� �� $	��200 �.+���  �� Orientation$ 
Horizontal=�$��0��.+��� $��
15 0 15 15q�$��34��$	��390��$��0������ *SearchQuery+�� $��
Поиск��$	��100��$��
15 0 15 15q����� *SearchVacancyCommand+�� $��20 0 0 0q�$ Vertical=�$��0��$��2��$��1��.+��� 
�������$��0 0 0 20q�$��Фильтрация:��$��20(�$��24���� 
�������$��0 0 0 10q�$��Зарплата:��$��18(�$��22���� $ 
Horizontal=�$��0 0 0 10q�.+��� 
�������$��	Мин:  ��$��16(�$��20���� $��30��$	��100������ *	MinSalary+�� $ 
Horizontal=�$��0 0 0 10q�.+��� 
�������$��
Макс: ��$��16(�$��20���� $��30��$	��100������ *	MaxSalary+�� 
�������$��	0 10 0 10q�$ ��Спецализация: ��$��18(�$��22���� $	��140��$��24��$
��Left=� �� SelectedValue �� *SelectedIndustry+.@��� $��Все���� $
��ИТ���� $��Медицина���� $��Транспорт���� $��Общепит���� $��Фильтровать��$	��120��$��	0 10 0 15q�$
��Left=����� *FilterCommand+�� 
�������$��0 0 0 10q�$#��Сортировать по: ��$��18(�$��22���� $	��140��$��24��$
��Left=� �� SelectedItem �� *SelectedSortOption+.@��� $!��Добавлен(убыв.)���� $!��Добавлен(возр.)���� $!��Зарплата(убыв.)���� $!��Зарплата(возр.)���� $��Название���� $��Сортировать��$	��120��$��0 10 0 0q�$
��Left=����� *SortCommand+�� $��	15 0 15 0q�$��0q�
������ $��3��$��Hidden=����� *	Vacancies+ �� *SelectedVacancy+   �� 
TargetType   ProductStyle	 �� BasedOn��%   '��       7   �� " ��8	   ���� .R��  �� �� .+��� $��0��$ Vertical=�.+��� $��18(����� 
 �� Path$
 Title��� ���� $
 CompanyName��� ���� $
 Location��� $��1��$ Vertical=�$��Right=�.+��� ���� $
 Salary� �� StringFormat$ ${0:F2}���� ���� $
 	DataAdded�$&  Добавлен: {0:MM.dd.yyyy}��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *SelectVacancyCommand+   CommandParameter �� *SelectedVacancy+