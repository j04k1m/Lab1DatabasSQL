   M S B A M L   `   `   `  ����L  HWpfAppDatabasLab1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfAppDatabasLab1WpfAppDatabasLab1  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    WpfAppDatabasLab1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfAppDatabasLab1     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5	   	   $��553.982��6   $��697.771��6-   
���   �.��5
      � $	��417��6   $	��Top=�6    � RowDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��17* �6   .+�5   
   �� -   5         ��Name$% ListBoxInformationTableCustomer��5      $
��Left=�6;   $	��228��6V   $��	61,92,0,0q�6c   $	��Top=�6v   $	��130��6�   $��2��6�   6�   �� 5   
   -   5        $" ListBoxInformationTableOrder��5      $
��Left=�68   $	��228��6S   $��
383,92,0,0q�6`   $	��Top=�6t   $	��130��6�   $��2��6�   6�   �� 5   
   -   5         ��Name$% TextBoxInfoCustomer_Customer_Id��5      $
��Left=�6;   $��28��6V   $��208,124,0,0q�6b    �� TextWrapping$
 Wrap=�6w   $
��Info��6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $  TextBoxInfoOrder_Orders_Id��5      $
��Left=�66   $��28��6Q   $��532,114,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $	��120��6�   $
��Info��6�   �� 5   
   -   5         ��Name$ ButtonUpdateTableCustomer��5      $��SAVE Customer��64   $
��Left=�6L   $��
61,134,0,0q�6g   $	��Top=�6{   $	��130��6�    J� RenderTransformOrigin$ 
0.81,0.427&�6�   $��28��6�   $��1��6�   {�.  6  �� 5   
   -   5        $ ButtonAddTableCustomer��5      $��ADD Customer��61   $
��Left=�6H   $��
61,181,0,0q�6c   $	��Top=�6w   $	��130��6�   $ 0.189,0.548&�6�   $��28��6�   $��1��6�   �� 5   
   -   5        $ ButtonDeleteTableCustomer��5      $��DELETE Customer��64   $
��Left=�6N   $��61,232,0,-50q�6i   $	��Top=�6   $	��130��6�   $��40��6�   $��1��6�   ���	#FFFF2C2C{�.  6�   �� 5   
   -   5        $# TextBoxInfoCustomer_Firstname��5      $
��Left=�69   $��28��6T   $��	208,4,0,0q�6`   $
 Wrap=�6s   $��Info ��6�   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5   
   -	   5        $" TextBoxInfoCustomer_Lastname��5      $
��Left=�68   $��208,79,0,115q�6S   $
 Wrap=�6i   $
��Info��6}   $	��120��6�   $��1��6�   �� 5   
   -
   5        $" TextBoxInfoOrder_Customer_Id��5      $
��Left=�68   $��28��6S   $��532,185,0,0q�6_   $
 Wrap=�6t   $
��Info��6�   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5        $ TextBoxInfoOrder_Date��5      $
��Left=�61   $��28��6L   $��
532,61,0,0q�6X   $
 Wrap=�6l   $
��Info��6�   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5    
   -   5        $ ButtonAddTableOrder��5       $��ADD Table B��6.   $
��Left=�6D   $��383,181,0,0q�6_   $	��Top=�6t   $	��130��6�   $ 0.189,0.548&�6�   $��1��6�   $��28��6�   �� 5"   
   -   5        $&  TextBoxInfoCustomer_SelectedItem��5"      $
��Left=�6<   $��28��6W   $��560,257,0,-63q�6c   $
 Wrap=�6z   $��Selected Customer��6�   $	��Top=�6�   $	��120��6�   {�.  $��1��6�   �� 5#   
   -   5        $# TextBoxInfoOrder_SelectedItem��5#      $
��Left=�69   $��28��6T   $��560,290,0,-96q�6`   $
 Wrap=�6w   $��Selected Order��6�   $	��Top=�6�   $	��120��6�   $��1��6�   {�.  6�   �� 5$   
   -   5        $# TextBoxInfoOrder_Total_Amount��5$      $
��Left=�69   $��28��6T   $��532,135,0,0q�6`   $
 Wrap=�6u   $
��Info��6�   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5&   
   -   5        $ ButtonUpdateTableOrder��5&      $��
SAVE Order��61   $
��Left=�6F   $��383,135,0,0q�6a   $	��Top=�6v   $	��130��6�   $ 0.189,0.548&�6�   $��1��6�   $��28��6�   {�.  6�   �� 5'   
   -   5        $ ButtonDeleteTableOrder��5'      $��DELETE Order��61   $
��Left=�6H   $��383,232,0,-50q�6c   $	��Top=�6z   $	��130��6�   $ 0.189,0.548&�6�   $��1��6�   $��40��6�   ���	#FFFF2C2C{�.  6  �� 5)   
   -   5         ��Name$ LabelCustomerTitle��5)      $��          Customers��6,   $
��Left=�6J   $��	61,66,0,0q�6e   $	��Top=�6x   $	��130��6�   ���	#FFCDCDCD6�   �� 5*   
   -   5        $ LabelOrderTitle��5*      $��            Orders��6)   $
��Left=�6F   $��
383,66,0,0q�6a   $	��Top=�6u   $	��130��6�   ���	#FFCDCDCD6�   �� 5+   
   -   5        $ LabelCustomerLastname��5+      $��Customer Lastname��6/   $
��Left=�6K   $��28��6f   $��
208,51,0,0q�6r   $��1��6�   $	��Top=�6�   $	��120��6�   ���	#FFCDCDCD6�   �� 5,   
   -   5        $ LabelCustomerFirstname��5,      $��Customer Firstname��60   $
��Left=�6M   $��28��6h   $��208,171,0,0q�6t   $	��Top=�6�   $	��120��6�   ���	#FFCDCDCD$��2��6�   �� 5-   
   -   5        $ LabelCustomer_Id��5-      $��Customer ID��6*   $
��Left=�6@   $��28��6[   $��
208,96,0,0q�6g   $	��Top=�6{   $	��120��6�   ���	#FFCDCDCD6�   �� 5.   
   -   5        $ LabelOrderTotalAmount��5.      $��Order Total Price��6/   $
��Left=�6K   $��28��6f   $��532,107,0,0q�6r   $��1��6�   $	��Top=�6�   $	��120��6�   ���	#FFCDCDCD6�   �� 5/   
   -   5        $ LabelOrder_Customer_Id��5/      $��Customer ID��60   $
��Left=�6F   $��28��6a   $��532,157,0,0q�6m   $	��Top=�6�   $	��120��6�   ���	#FFCDCDCD6�   �� 50   
   -   5        $ LabelOrder_Id��50      $��Order ID��6'   $
��Left=�6:   $��28��6U   $��
532,86,0,0q�6a   $	��Top=�6u   $	��120��6�   ���	#FFCDCDCD6�   �� 51   
   -   5        $ LabelOrderDate��51      $��
Order Date��6(   $
��Left=�6=   $��28��6X   $��
532,33,0,0q�6d   $��1��6x   $	��Top=�6�   $	��120��6�   ���	#FFCDCDCD6�   53      54      