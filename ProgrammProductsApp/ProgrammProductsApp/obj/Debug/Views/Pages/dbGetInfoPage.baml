   M S B A M L   `   `   `  ����N  JProgrammProductsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProgrammProductsApp.Views.PagesProgrammProductsApp.Views.Pages  5      3    -ProgrammProductsApp.Views.Pages.dbGetInfoPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ProgrammProductsApp.Views.Pages     5      -   5          N� Title$  dbGetInfoPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $
��159* �6   �� 5      $	��35* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��Center=�5      $��10 0 0 0q�5      .+�5      �� -   5         ��Name$ btnBack��5      $	��100��5      $��
Назад��5      5      5      5      � 5    
   $��1��6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dbGetInfo��5!      $��10q�5"         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)   	   Width$
	 0.2* 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *ID+6L     5(      $/ )Название пользователя��6)   $
	 1.2* 6j   
 6H   �� *User.NameUser+6j     5)      $ Регион��6)   $
	 0.4* 6Y   
 69   �� *User.Region+6Y     5*      $% Сфера применения��6)   $	 1* 6o   
 6C   �� *User.ScopeOfApplication+6o     5+      $- 'Стоимость инсталяции��6)   $
	 1.3* 6v   
 6G   �� *Service.CostOfInstallation+6v     5,      $# Дата инсталяции��6)   $	 1* 6�   
 6B   �� *Service.DateOfInstallation+ �� StringFormat$ {0: dd MMMM yyyy}��6�     5-      $' !Дата деинсталяции��6)   $	 1* 6�   
 6D   �� *Service.DateOfDeinstallation+$ {0: dd MMMM yyyy}��6�     5.      $" Кол-во лицензий��6)   $	 1* 6n   
 6B   �� *Service.QuantityLicense+6n   51      52      � 54   
   $��2��6   56      58      59      