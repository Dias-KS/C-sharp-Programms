   M S B A M L   `   `   `  ����L  HSelhozApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SelhozApplication.Views.Pages.Admin#SelhozApplication.Views.Pages.Admin  5      ;    5SelhozApplication.Views.Pages.Admin.AdminGgetInfoPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:SelhozApplication.Views.Pages.Admin     5      -   5          N� Title$  AdminGgetInfoPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $
��128* �6   �� 5      $	��50* �6   .+�5   
   � $��0��6   
�������.+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��Center=�5      .+�5      �� -   5         ��Name$ btnBack��5      $	��100��5      $��
Назад��5      $��10 0 0 0q�5      $��30��5      5      5       � 5"   
   $��1��6   
�������.+�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dbGetInfo��5%      $��10q�5$         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5'         
IsReadOnly .    Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6)   
   Width$

 0.4* 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	Supply.ID+6S     5,      $'	 !Название продукта��6)   $

 1.1* 6m    6D   �� *Products.NameProduct+6m     5-      $'	 !Единица измерения��6)   $

 1.1* 6t    6D   �� *Products.UnitOfMeasurement+6t     5.      $#	 Закупочная цена��6)   $

 1.1* 6m    6B   �� *Products.PurchasePrice+6m     5/      $	 Дата поставки��6)   $

 1.1* 6�    6@   �� *Supply.DateOfSupply+ �� StringFormat$ {0:dd MMMM yyyy}��6�     50      $	 
Обьем��6)   $

 1.1* 6Z    68   �� *Supply.Volume+6Z     51      $5	 /Себестоимость поставщика��6)   $

 1.2* 6y    6K   �� *Supply.SuppliersCostPrice+6y   54      55      � 57   
   $��2��6   
�������5:      5=      5?      