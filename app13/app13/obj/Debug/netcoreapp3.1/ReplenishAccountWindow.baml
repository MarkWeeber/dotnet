   M S B A M L   `   `   `  ����@  <app13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:app13app13  5   	   "    app13.ReplenishAccountWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:app13     5   	     � Title$  Replenish Account��5   	   $	��240��6#   $	��220��60   $	��400��6@   $	��350��6L   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��5      $��0��5      $	��ID:��5         NormalLabelStyle#��[  5      $��Center=�5      $	��Top=�5      $��0 5 0 0q�5      �� 5   
   -   5         ��Name$ RA_AccountId��5!      $��0��5      $��0��5       $��XXXXX��5"      $��Center=�5#      $��Bottom=�5$      $��0 0 0 5q�5%      �� 5'   
   $��0��5(      $��1��5)      $��NUMBER:��5*      #��[  5+      $��Center=�5,      $	��Top=�5-      $��0 5 0 0q�5.      �� 50   
   -   5        $ RA_AccountNumber��53      $��0��51      $��1��52      $��XXXXX��54      $��Center=�55      $��Bottom=�56      $��0 0 0 5q�57      �� 59   
   $��0��5:      $��2��5;      $��	CURRENCY:��5<      #��[  5=      $��Center=�5>      $	��Top=�5?      $��0 5 0 0q�5@      �� 5B   
   -   5        $ RA_AccountCurrency��5E      $��0��5C      $��2��5D      $��XXXXX��5F      $��Center=�5G      $��Bottom=�5H      $��0 0 0 5q�5I      �� 5K   
   $��1��5L      $��0��5M      $��CURRENT BALANCE:��5N      $
��Wrap=�5O      #��[  5P      $��Center=�5Q      $��Center=�5R      �� 5T   
   -   5        $ RA_AccountBalance��5W      $��1��5U      $��1��5V      $��XXXXX��5X      $��Center=�5Y      $��Center=�5Z      �� 5\   
   $��2��5]      $��0��5^      $��REPLENISH AMOUNT:��5_      $
��Wrap=�5`      #��[  5a      $��Center=�5b      $��Center=�5c      �� 5e   
   -   5         ��Name$ RA_TextBoxReplenishAmount��5h      $��2��5f      $��1��5g      $��5q�5i      $��25��5j      6   �� 5m   
   -   5         ��Name$ RA_ButtonReplenish��5p      $��3��5n      $��1��5o        NormalButtonStyle#��[ 5q      $��5q�5r      $��	REPLENISH��5s      6!   �� 5u   
   -   5        $ RA_ButtonCancel��5x      $��3��5v      $��2��5w        CancelButtonStyle#��[ 5y      $��5q�5z      $��CANCEL��5{      6   5}      5~      