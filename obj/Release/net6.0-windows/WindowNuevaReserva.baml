   M S B A M L   `   `   `  ���� e  aDI07_Tarea_Fernandez_Chacon_EnriqueOctavio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:DI07_Tarea_Fernandez_Chacon_EnriqueOctavio*DI07_Tarea_Fernandez_Chacon_EnriqueOctavio  C    =DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.WindowNuevaReserva   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Jlocal8clr-namespace:DI07_Tarea_Fernandez_Chacon_EnriqueOctavio     :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     -     � Title$  Nueva Reserva��$	��320��$	��470��.��� -   .+�(  "System.Windows.Controls.DatePicker  -     Name$ dpFecha�� � ToolTip$ Seleccione la fecha��$
��Left=�$��	82,46,0,0q�$	��Top=�   SelectedDate ��  �� Path$ Fecha��� -    ��Name$ tbHora��$ Hora de la fecha��$
��Left=�$��
287,49,0,0q� �� TextWrapping$
 Wrap=�$��00��$	��Top=�$��21���� -   $ 	tbMinutos��$ Minutos de la fecha��$
��Left=�$��
313,49,0,0q�$
 Wrap=�$��00��$	��Top=�$��21���� -    ��Name$ 
cbClientes��$ Seleccione el cliente��$
��Left=�$��	82,89,0,0q�$	��Top=�$	��252�� �� SelectedItem �� $ Cliente��� -   	 ��Name$	 btNuevoCLiente��$ Crear un nuevo cliente��$��Nuevo Cliente��$
��Left=�$��
352,89,0,0q�$	��Top=�
 J� RenderTransformOrigin$
 -0.52,-0.17&��� -   $ cbMotivo��$  Seleccione el tipo de cita��$
��Left=�$��
82,130,0,0q�$	��Top=�$	��252�� �� $ TipoCita�	� -	    	�Name$
 rbSi�� 	� 	GroupName$ seguro��$ No poseé seguro privado��$��Si��$
��Left=�$��154,173,0,0q�$	��Top=�	� -
   $
 rbNo��$ seguro��$ Poseé seguro privado��$��No�� d� 	IsChecked$
 TrueY�$
��Left=�$��199,173,0,0q�$	��Top=��� -   $	 
btReservar��$ Crear nueva reserva��$��Reservar��$
��Left=�$��119,243,0,0q�$	��Top=��� -   $	 
btCancelar��$ Cancelar y Salir��$��Cancelar��$
��Left=�$��273,243,0,0q�$	��Top=�$
 1.356,2.933&��� -    ��Name$ lTitulo��$��Nueva Reserva��$��Center=�$��0,10,0,0q�$	��Top=��� $��Hora:��$
��Left=�$��
241,45,0,0q�$	��Top=��� $��Seguro Privado:��$
��Left=�$��
10,167,0,0q�$	��Top=��� $��Motivo:��$
��Left=�$��
10,128,0,0q�$	��Top=��� $��Cliente:��$
��Left=�$��	10,87,0,0q�$	��Top=��� $��Fecha:��$
��Left=�$��	10,44,0,0q�$	��Top=�