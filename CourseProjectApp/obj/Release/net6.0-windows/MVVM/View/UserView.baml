   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practic_App.MVVM.ViewPractic_App.MVVM.View  $    Practic_App.MVVM.View.UserView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:Practic_App.MVVM.View       � 	Resources   �� MergedDictionaries �� Source��  �� $$ ../../styles/ProductTheme.xaml?��� $" ../../styles/InputTheme.xaml?��� $# ../../styles/ButtonTheme.xaml?�%    .��� .+���  � DataContext �� *SelectedUser+.+��� 
�������$��0 5 0 0q�$��Логин:���� 
�������$��19(�$��SemiBold"�$��0 2 0 0q����� *
UserName+�� 
�������$��0 5 0 0q�$��Эл. почта:���� 
�������$��16(�$��SemiBold"�$��0 2 0 0q����� *Email+�� 
�������$��0 5 0 0q�$��Телефон:���� 
�������$��16(�$��0 2 0 0q����� *Phone+�� 
�������$��0 5 0 0q�$��Биография:���� 
�������$��16(�$��0 2 0 0q����� *	Biography+� $��0 15 0 0q�$
��50px�� � ColumnDefinitions �� �� $
��50px ��� .+��� $��0��$A��;Удалить пользователя с вакансии������ *RejectUserFromVacancyCommand+�� $��2��$@��:Отменить удаление пользователя������ *$"CancelRejectUserFromVacancyCommand+