   M S B A M L   `   `   `  ����@  <app14, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:app14app14  5   	       app14.AddNewAccount   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:app14     5   	     � Title$  AddNewAccount��5   	   $	��200��6   $	��350��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��5      $��Account Type:��5         NormalLabelStyle#��[  5      $
��Left=�5      $��Center=�5      $��20 0 0 0q�5      	� 5   
   -   5         	�Name$! ANC_RadioDepositTypeChecker��5      $��0��5      $��Deposit��5       	� 	GroupName$ AccountType��5      $
��Left=�5      $��Center=�5      $��	120 0 0 0q�5       d� 	IsChecked$
 TrueY�5      	� 5    
   -   5        $$ ANC_RadioNonDepositTypeChecker��5!      $��Non-Deposit��5"      $ AccountType��5#      $
��Left=�5$      $��	200 0 0 0q�5%      $��Center=�5&      �� 5(   
   $��1��5)      $��	Currency:��5*      #��[  5+      $
��Left=�5,      $��Center=�5-      $��20 0 0 0q�5.      �� 5/   
   -   5         ��Name$  ANC_ComboBoxCurrencyPicker��51      $��1��50      $
��Left=�52      $��Center=�53      $��	120 0 0 0q�54      $��20��55      $	��120��56      6   � 58   
   $��2��6    � ColumnDefinitions 59      �� 5:      �� 5;      .+�5=      �� -   5         ��Name$ ANC_ButtonAdd��5?      $��0��5>        NormalButtonStyle#��[ 5@      $��7q�5A      $��ADD NEW ACCOUNT��5B      6+   �� 5D      -   5        $ ANC_ButtonCancel��5F      $��1��5E        CancelButtonStyle#��[ 5G      $��7q�5H      $��CANCEL��5I      6"   5K      5L      5M      