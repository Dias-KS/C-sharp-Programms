   M S B A M L   `   `   `  ����H  DWpfAuthSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfAuthSystem.Views.PagesWpfAuthSystem.Views.Pages  5      (    "WpfAuthSystem.Views.Pages.AuthPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WpfAuthSystem.Views.Pages     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  AuthPage��5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper N� 
Background# �  5        MaterialDesignFont N� 
FontFamily# �  5      .��5      � .+�5   
    � -   5          �Name$ AdminViewFrame��5        � NavigationUIVisibility$ Visible=�6(    � 5   
   -   5        $ UserViewFrame��5      $ Visible=�6'   �� 5   
   $��Stretch=�6   $��Stretch=�5      .+�5      �� $��/Images/bgForAuth.jpg��6   5       �� 5"   
   $��Center=�6    �� Orientation$ 
Horizontal=�5#      $	��Top=�5$      .+�5&      �� $%��Окно авторизации��6   $��20(�5'      5*      �� 5.   
   $��Center=�6   $��Center=�5/      $ 
Horizontal=�50      $��0 5 0 0q�51      .+�53      �� -   5         ��Name$ btnADD��53      $	��100��54      $��
Войти��55      $��0 0 5 0q�56      	 �� 	IsDefault	 . $��12(�58      $��30��59      �� 5<      -   5        $ 	btnDelete��5<      $	��100��5=      $��Очистить��5>      $��12(�5?      $��30��5@      5B      �� 5D   
   $��Center=�6   $��Center=�5E      $ 
Horizontal=�5F      $��0 5 0 0q�5G      .+�5I      �� -   5        $ btnExit��5I      $	��205��5J      $��
Выйти��5K      $��0 75 0 0q�5L      
 �� IsCancel
 . $��12(�5N      $��30��5O      5Q      �� 5X   
   $��Center=�6   $��Center=�5Y      $ Vertical=�5Z      $��
0 0 270 80q�5[      .+�5_      �� $��Логин: ��6   $��	15 0 0 15q�5`      $��50��5a      
�������5b      �� 5e      $��Пароль: ��6   
�������$��50��5g      $��0 0 0 20q�5h      5j      �� 5o   
   $��Center=�6   $��Center=�5p      $ Vertical=�5q      $��	0 0 0 100q�5r      .+�5t      �� -   5         ��Name$ txtLogin��5t      $	��205��5u      $��0 0 0 5q�5v      
�������5w      G� 5y      -   5         G�Name$ pswPassword��5y      $	��205��5z      
�������5{      5}      5~      5      