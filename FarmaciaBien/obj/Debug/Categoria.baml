   M S B A M L   `   `   `  ����G  CFarmaciaBien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FarmaciaBienFarmaciaBien  5   	       FarmaciaBien.Categoria   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FarmaciaBien     5   	     � Title$  Farmacia��5   	   $	��500��6   $	��500��6'   ��5	      �� 5
   
    �� ImageSource$ Imagenes/fondo1.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��Center=�6   $��24(�6-   $��0��6;   $��0��6K   
�������$��Italic$�6k   $
��Bold"�6~   $��Lucida Calligraphy)�6�   .��6�   	Categoria6�   � 5   
   $��0��6   $��1��6$   $��10q�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��100��6   ���	#FFF0E1E1$��Arial)�6;   $��14(�6N   .��6\   Nombre6d   �� 5      -   5         ��Name$ 	txbNombre��5      $	��180��6-   $��2q�69   6F   5      5      � 5   
   $��Center=�6   $��0��61   $��2��6A   $��4q�6O   .+�5      �� -   5         ��Name$ btnNuevo��5      $��4q�6>   $��80��6I   ���	#FF3E2929���	#FFDCC4C4.��5       �� $ 
Horizontal=�6   .+�5!      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6^   Nuevo6e   �� 5"      $!��/Imagenes/textfield_add.png��6   $��16��6A   6N   5#      5$      �� 5%      -   5        $ 
btnGuardar��5%      $��4q�6B   $��80��6N   ���	#FF3E2929���	#FFDCC4C4.��5&      �� $ 
Horizontal=�6   .+�5'      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6]   	Guardar6f   �� 5(      $��/Imagenes/page_save.png��6   $��16��6=   6J   5)      5*      �� 5+      -   5        $ 	btnEditar��5+      $��4q�6@   $��80��6L   ���	#FF3E2929���	#FFDCC4C4.��5,      �� $ 
Horizontal=�6   .+�5-      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6]   Editar6e   �� 5.      $��/Imagenes/cart_edit.png��6   $��16��6=   6J   5/      50      �� 51      -   5        $ btnEliminar��51      $��4q�6D   $��80��6P   ���	#FF3E2929���	#FFDCC4C4.��52      �� $ 
Horizontal=�6   .+�53      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6]   
Eliminar6g   �� 54      $$��/Imagenes/textfield_delete.png��6   $��16��6D   6Q   55      56      �� 57      -   5        $ btnCancelar��57      $��4q�6D   $��80��6P   ���	#FF3E2929���	#FFDCC4C4.��58      �� $ 
Horizontal=�6   .+�59      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6]   
Cancelar6g   �� 5:      $��/Imagenes/cancel.png��6   $��16��6:   6G   5;      5<      5=      &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dtgCategoria��5>         
IsReadOnly . $��0��6;   $��3��6K   $��10q�6X   $��2��6d   6z   � 5?   
   $��0��6   $��4��6$   $��2q�61   $��Right=�6<   .+�5@      �� -   5        $ btnRegresar��5@      $��4q�6D   $	��130��6P   ���	#FF3E2929���	#FFDCC4C4.��5A      �� $ 
Horizontal=�6   .+�5B      �� 
�������$��Segoe UI Semilight)�6/   $��14(�6O   .��6]   
Regresar6g   �� 5C      $&�� /Imagenes/text_indent_remove.png��6   $��16��6F   6S   5D      5E      5H      5I      5J      