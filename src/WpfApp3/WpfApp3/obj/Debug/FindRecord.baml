   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5          WpfApp3.FindRecord   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp3     5        N� Title$  
FindRecord��5	      .��5      � $��
10,0,10,10q�6    � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��35��6.    �� Padding$ 5q�6:   ���#4E87D4._�5      �� $��Center=�6   
�������.��6B   借书记录查询6J   5      �� 5   
   $��	卡号：��6   $��0��6   $��1��6/   $��	10,20,0,0q�6<   �� 5   
   -   5        $��CardID��5      $��0��6    $��1��60   $��	80,20,0,0q�6=   $
��Left=�5      $��24��6-    �� TextWrapping$
 Wrap=�69   $	��Top=�6M   $	��200��6e   �� 5   
   -   5        $��0��5      $��1��6!   $��
380,20,0,0q�6.   $	��100��6B   $��25��6N   $
��Left=�6Z   .��6�   查询6�   �� 5    
   $��尚未归还：��6   $��0��6!   $��2��61   $��	10,15,0,0q�6>   &   System.Windows.Controls.DataGrid  5!   
   -   5        $��NotReturned��5!      $��0��6&   $��3��66   $��Center=�5"      $	��106��60   $��	40,5,40,0q�6=   $��Center=�5#      $	��700��6.   �� 5$   
   $��已经归还：��6   $��0��6!   $��5��61   $��	10,15,0,0q�6>     5%   
   -   5        $��HaveReturned��5%      $��0��6'   $��6��67   $��Center=�5&      $	��106��60   $��40,5,40,100q�6=   $��Center=�5'      $	��700��6.   5)      5*      