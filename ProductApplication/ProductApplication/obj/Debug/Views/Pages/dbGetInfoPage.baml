   M S B A M L   `   `   `  ����M  IProductApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProductApplication.Views.PagesProductApplication.Views.Pages  5      2    ,ProductApplication.Views.Pages.dbGetInfoPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ProductApplication.Views.Pages     5      -   5          N� Title$  dbGetInfoPage��5	      .��5
      � .+�5   
   �� $��Stretch=�6   $��Stretch=�5      .+�5      �� $��/Images/bg1.jpg��6   5      � 5       � RowDefinitions 5   
   �� 5      $	��55* �6   �� 5      $
��331* �6   �� 5      $	��64* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��Center=�5      $��20 0 0 0q�5      .+�5      �� -   5         ��Name$ btnBack��5      $	��100��5      $��
Назад��5      $��30��5       5"      5#      � 5%   
   $��1��6   .+�5&      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dbGetInfo��5&         AutoGenerateColumns .     
IsReadOnly . $��20q�5)         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5*         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Код��6-   
   Width$

 0.4* 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *ID+6Q     5-      $)	 #Название материала��6-   $
 1* 6s    6I   �� *Material.NameMaterial+6s     5.      $	 Тип��6-   $
 1* 6d    6:   �� *Material.TypeMaterial+6d     5/      $'	 !Единица измерения��6-   $
 1* 6w    6H   �� *Material.UnitOfMeasurement+6w     50      $"	 Цена за единицу��6-   $
 1* 6m    6F   �� *Material.PriceUnit+6m     51      $ 	 Использование��6-   $
 1* 6i    6D   �� *Material.NoteUse+6i     52      $	 Количество��6-   $
 1* 6t    6A   �� * Specification.QuantityMaterial+6t     53      $!	 Дата установки��6-   $
 1* 6�    6E   �� *(&Specification.DateInstallSpecification+ �� StringFormat$  {0: dd MMMM yyyy}��6�     54      $	 Дата отмены��6-   $
 1* 6�    6B   �� *Specification.DateCancel+$  {0: dd MMMM yyyy}��6�   56      57      � 59   
   $��2��6   5;      5>      5@      5A      