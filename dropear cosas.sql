DROP TRIGGER LA_QUERY_DE_PAPEL.deleteRol
DROP TRIGGER LA_QUERY_DE_PAPEL.insertUsuarios
DROP TRIGGER LA_QUERY_DE_PAPEL.deleteUsuarios
DROP TRIGGER LA_QUERY_DE_PAPEL.updateUsuarios
DROP TRIGGER LA_QUERY_DE_PAPEL.deletePersonas
DROP TRIGGER LA_QUERY_DE_PAPEL.insertClientes
DROP TRIGGER LA_QUERY_DE_PAPEL.deleteClientes
--DROP TRIGGER LA_QUERY_DE_PAPEL.deleteRegimenxHotel

DROP TABLE [LA_QUERY_DE_PAPEL].[FuncionalidadxRol]
DROP TABLE [LA_QUERY_DE_PAPEL].[Funcionalidad]
DROP TABLE [LA_QUERY_DE_PAPEL].[Item]
DROP TABLE [LA_QUERY_DE_PAPEL].[Item_Conflicto_Migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[MedioPago]
DROP TABLE [LA_QUERY_DE_PAPEL].[Factura]
DROP TABLE [LA_QUERY_DE_PAPEL].[Factura_Conflicto_Migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Consumible]
DROP TABLE [LA_QUERY_DE_PAPEL].[UsuarioxHotel]
DROP TABLE [LA_QUERY_DE_PAPEL].[Historial_Reserva]
DROP TABLE [LA_QUERY_DE_PAPEL].[ReservaxHabitacion]
DROP TABLE [LA_QUERY_DE_PAPEL].[ReservaxHabitacion_Conflicto_Migracion] 
DROP TABLE [LA_QUERY_DE_PAPEL].[RegimenxHotel]
DROP TABLE [LA_QUERY_DE_PAPEL].[Estadia]
DROP TABLE [LA_QUERY_DE_PAPEL].[Estadia_conflicto_migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Reserva]
DROP TABLE [LA_QUERY_DE_PAPEL].[Reserva_Conflicto_Migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Habitacion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Tipo_Habitacion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Hotel_Baja]
DROP TABLE [LA_QUERY_DE_PAPEL].[Hotel]
DROP TABLE [LA_QUERY_DE_PAPEL].[Cliente]
DROP TABLE [LA_QUERY_DE_PAPEL].[Cliente_Conflicto_Migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Usuario]
DROP TABLE [LA_QUERY_DE_PAPEL].[Persona]
DROP TABLE [LA_QUERY_DE_PAPEL].[Persona_conflicto_migracion]
DROP TABLE [LA_QUERY_DE_PAPEL].[Rol]
DROP TABLE [LA_QUERY_DE_PAPEL].[Regimen]


DROP VIEW LA_QUERY_DE_PAPEL.usuarios
DROP VIEW LA_QUERY_DE_PAPEL.clientes
DROP VIEW LA_QUERY_DE_PAPEL.reservas_sin_cancelar

DROP PROCEDURE LA_QUERY_DE_PAPEL.procedure_update_cliente
DROP PROCEDURE LA_QUERY_DE_PAPEL.procedure_alta_habitacion
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_regimen
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_baja_hotel
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_activa
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_modificable
DROP PROCEDURE LA_QUERY_DE_PAPEL.actualizar_reserva
DROP PROCEDURE LA_QUERY_DE_PAPEL.cancelar_reserva
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_para_ingreso
DROP PROCEDURE LA_QUERY_DE_PAPEL.registrar_ingreso
DROP PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_para_egreso
DROP PROCEDURE LA_QUERY_DE_PAPEL.procedure_login
DROP PROCEDURE LA_QUERY_DE_PAPEL.Cargar_personas
DROP PROCEDURE LA_QUERY_DE_PAPEL.Cargar_reservas
DROP PROCEDURE LA_QUERY_DE_PAPEL.Cargar_Estadias
DROP PROCEDURE LA_QUERY_DE_PAPEL.generar_factura 

DROP FUNCTION LA_QUERY_DE_PAPEL.habitaciones_disponibles_para_reserva
DROP FUNCTION LA_QUERY_DE_PAPEL.habitaciones_libres
DROP FUNCTION LA_QUERY_DE_PAPEL.habitaciones_de_reserva
DROP FUNCTION LA_QUERY_DE_PAPEL.HotelesMayoresCancelaciones
DROP FUNCTION LA_QUERY_DE_PAPEL.HotelesMayoresConsumibles 
DROP FUNCTION LA_QUERY_DE_PAPEL.HotelesMasDiasFueraDeServicio
DROP FUNCTION [LA_QUERY_DE_PAPEL].[habitacionesMasOcupadas]
DROP FUNCTION LA_QUERY_DE_PAPEL.ClientesConMasPuntos
