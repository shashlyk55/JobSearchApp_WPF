   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practic_App.MVVM.ViewPractic_App.MVVM.View  $    Practic_App.MVVM.View.UserView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:Practic_App.MVVM.View       � 	Resources   �� MergedDictionaries �� Source��  �� $$ ../../styles/ProductTheme.xaml?��� $" ../../styles/InputTheme.xaml?��� $# ../../styles/ButtonTheme.xaml?�%    .���� $��
10 0 20 20q�.+���  � DataContext �� *SelectedUser+.+��� 
�������$��0 5 0 0q�$��Логин:���� 
�������$��19(�$��SemiBold"�$��0 2 0 0q����� *
UserName+�� 
�������$��0 5 0 0q�$��Эл. почта:���� 
�������$��16(�$��SemiBold"�$��0 2 0 0q����� *Email+�� 
�������$��0 5 0 0q�$��Телефон:���� 
�������$��16(�$��0 2 0 0q����� *Phone+�� 
�������$��0 5 0 0q�$��Биография:���� 
�������$
��Wrap=�$��16(�$��0 2 0 0q� � Cursor$
 Hand������ *	Biography+� $��0 15 0 0q�$
��50px�� � ColumnDefinitions �� $��100px ��� $
��10px ��� �� $
��10px ��� �� $
��10px ��� .+��� $��0��$��
Назад��$��80������ *BackCommand+�� $��2��$��
Отказ��$	��190������ *RejectUserFromVacancyCommand+�� $��4��$��Одобрить��$	��190������ *AcceptUserOnVacancyCommand+�� $��6��$��Отмена��$	��190������ *$"CancelRejectUserFromVacancyCommand+