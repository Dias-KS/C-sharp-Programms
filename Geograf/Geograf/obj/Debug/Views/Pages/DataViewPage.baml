   M S B A M L   `   `   `  ����B  >Geograf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Geograf.Views.PagesGeograf.Views.Pages  5      &     Geograf.Views.Pages.DataViewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Geograf.Views.Pages     5      -   5          N� FontSize$  16(�5       N� Title$ DataViewPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $��* �6   �� 5      $
��0.4* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Center=�5      .+�5      �� $��Поиск: ��6   �� 5      -   5         ��Name$ 	txbSearch��5      $��10,0,0,0q�5      5      �� 5      $%��ВЫбрать гос. язык��6   $��10,0,0,0q�5      �� 5      -   5        $��cmbSelectedLanguage��5      $��10,0,0,0q�5      5       5!      5"      � 5$   
   $��1��6   .+�5%      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dbViewData��5%      $��10q�5&         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6#      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width$
 0.3* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *ID+6L     5+      $
 Наименование��6)    6?   �� *Title+  5,      $
 Регион��6)    69   �� *Region+  5-      $
 Столица��6)    6:   �� *	Capital+  5.      $
 Площадь��6)    6:   �� *Square+  5/      $
 Население��6)    6<   �� *Population.Count+  50      $
 
Нация��6)    68   �� *Ethnic.Natinolity.Ttile+  51      $
 Язык��6)    67   �� *Ethnic.Language.Title+53      54      � 56   
   $��2��6   .+�57      �� $ 
Horizontal=�6   $��Center=�58      $��Center=�59      .+�5:      �� -   5        $��btnAdd��5;      $��Добавить��5:      5<      �� 5=      -   5        $��btnEdit��5>      $ ��Редактировать��5=      $
��10,0q�5?      5@      �� 5A      -   5        $��	btnDelete��5B      $��Удалить��5A      5C      5D      5E      5F      5G      