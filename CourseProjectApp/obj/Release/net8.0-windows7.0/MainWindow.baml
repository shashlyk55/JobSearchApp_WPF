   M S B A M L   `   `   `  ���� F  BPractic-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Practic_AppPractic_App  G(clr-namespace:Practic_App.MVVM.ViewModelPractic_App.MVVM.ViewModel      Practic_App.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Practic_App     >	viewModel(clr-namespace:Practic_App.MVVM.ViewModel       � Title$  
MainWindow��$	��650��$	��900��   WindowStyle#���    � DataContext .   (Practic_App.MVVM.ViewModel.MainViewModel   � 	Resources  �� MergedDictionaries �� Source��  �� $ ./styles/MainStyles.xaml?��� $ ./styles/InputTheme.xaml?��� $$ ./styles/RadioButtonTheme.xaml?��� $ ./styles/ButtonTheme.xaml?�%    .����   ContainerStyle#��[ ._��  � RowDefinitions �� $��32 ��� $��80 ���  � ColumnDefinitions �� $	��150 ��� .+��� $��2��  WindowNavbar#��[ ._��  ��  �� �� $	��120 �.+���  	 Title#��[ $��Searching job app��$��0��$��0���� $��Right=� �� Orientation$ 
Horizontal=�$��0��$��1��.+���   	NavButton#��[ ���� *MinimizeApplicationCommand+���� $��20��$!��./assets/icons/minimize.png���� #��[ ���� *CloseApplicationCommand+���� $��20��$��./assets/icons/close.png��� $��1��$��2�� �� �� $	��130 � �� .+��� $��1��$��70��$��0 0 15 0q����� *LoginWindowCommand+����  �� 
TargetType" ��	 �� BasedOn#	 [B��.��� 
 �� Property
 � y� �� Value$ Visible=��� 
 � ��$ 15 5 0 5q��� 
 � �� �#ffbb13�� 
 � ��$ 16(��� 
 �@�Cursor$
 Hand���� 
 � ��$ 60���� 
 � �� ��  �� 
TargetType" ��.R���  �� CornerRadius$ 10��$��60��#��z��._��� #��z��$��Center=�$��Center=����#fff �� Triggers ��  �� Binding �� *
IsLoggedIn+ �� Value True.a��� 
 � y�$ 	Collapsed=�.���� $��./assets/icons/login.png���� $��1��$��70��$��0 0 15 0q����� *LogOutCommand+���� " ��#	 [B��.��� 
 � y�$ 	Collapsed=��� 
 � ��$ 15 5 0 5q��� 
 � �� �#ffbb13�� 
 � ��$ 16(��� 
 �@�Cursor$
 Hand���� 
 � ��$ 60���� 
 � �� �� " ��.R��� $ 10��$��60��#��z��._��� #��z��$��Center=�$��Center=����#fff ��  �� *
IsLoggedIn+ True.a��� 
 � y�$ Visible=�.���� $��./assets/icons/exit.png���� $��2��$��0������ " ��.��� 
 � y�$ 	Collapsed=� ��  �� *	IsAdmin+ True.a��� 
 � y�$ Visible=�.+�	� $��Вакансии�� d� 	IsChecked$
 TrueY�$��10q����� *VacancyListCommand+	� $��Добавить��$��10q����� *AddVacancyCommand+	� $��Удалить��$��10q����� *DeleteVacancyCommand+�� $��2��$��0������ " ��.��� 
 � y�$ 	Collapsed=� ��  �� *	IsAdmin+	 False.a��� 
 � y�$ Visible=���  �� *
IsLoggedIn+	 False.a��� 
 � y�$ Visible=���  �� *
IsLoggedIn+ True.a��� 
 � y�$ 	Collapsed=�.+�	� $��Вакансии��$
 TrueY�$��10q����� *VacancyListCommand+�� $��1��$��0��$��2������ " ��.��� 
 � y�$ 	Collapsed=� ��  �� *	IsAdmin+	 False.a��� 
 � y�$ Visible=���  �� *
IsLoggedIn+	 False.a��� 
 � y�$ 	Collapsed=�.+�	� $��1��$��0��$ FalseY�$��10q����� *OpenUserProfileCommand+���� " 	�.��� 
 � ��$ 15 5 0 5q��� 
 � �� �#ffbb13�� 
 � ��$ 16(��� 
 �@�Cursor$
 Hand���� 
 � ��$ 60���� 
 � �� �� " 	�.R��� $ 10��$��60��#��z��._��� #��z��$��Center=�$��Center=����#fff P�  P� Property �@d�	IsChecked P� Value$
 TrueY�. ��� 
 � �� �#ff9100P�  �@J�IsMouseOver$
 True��. ��� 
 � �� �#ff9100.���� $ ��./assets/icons/profile.png��	� $��Вакансии��$
 TrueY�$��10q����� *VacancyListCommand+�� $��2��$��1��$��
0 0 0 10pxq����� *CurrentView+