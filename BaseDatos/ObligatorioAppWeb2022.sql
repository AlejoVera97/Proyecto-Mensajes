use master
go

if exists (select * from SysDataBases Where name='OBLIGATORIOBASEDATOSAW_2022')
	BEGIN
		DROP DATABASE OBLIGATORIOBASEDATOSAW_2022
	END
	GO


CREATE DATABASE OBLIGATORIOBASEDATOSAW_2022
GO

USE OBLIGATORIOBASEDATOSAW_2022
GO

Create Table USUARIO
(
	NOMBREUSUARIO VARCHAR (10) PRIMARY KEY,
	CEDULA BIGINT NOT NULL UNIQUE,
	NOMBRECOMPLETO VARCHAR (50) NOT NULL
)
GO

CREATE TABLE TIPOMSJ
(
	CODINT VARCHAR (3) PRIMARY KEY,
	NOMBRECOD VARCHAR (20) NOT NULL
)
GO

CREATE TABLE MENSAJE
(
	NUMINT INT PRIMARY KEY IDENTITY (1, 1),
	FECHAHORA DATETIME NOT NULL,
	ASUNTO VARCHAR (50) NOT NULL,
	TEXTO VARCHAR (200) NOT NULL,
	NOMUSUENVIA VARCHAR (10) NOT NULL FOREIGN KEY REFERENCES USUARIO(NOMBREUSUARIO),
	NOMUSURECIBE VARCHAR (10) NOT NULL FOREIGN KEY REFERENCES USUARIO(NOMBREUSUARIO)
)
GO

CREATE TABLE MSJPRIVADO
(
	NUMINT INT NOT NULL FOREIGN KEY REFERENCES MENSAJE(NUMINT),
	FECHACAD DATETIME NOT NULL,
	PRIMARY KEY (NUMINT)
)
GO

CREATE TABLE MSJCOMUN
(
	NUMINT INT NOT NULL FOREIGN KEY REFERENCES MENSAJE(NUMINT),
	CODINT VARCHAR (3) NOT NULL FOREIGN KEY REFERENCES TIPOMSJ(CODINT),
	PRIMARY KEY (NUMINT)
)
GO

CREATE PROCEDURE SP_ALTAUSUARIO
@NombreUsu varchar(10),
@cedula bigint,
@NombreCompl varchar (50)
as
begin
	if (exists (select NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO=@NombreUsu))
		RETURN -1;
	INSERT INTO USUARIO (NOMBREUSUARIO, CEDULA, NOMBRECOMPLETO) VALUES (@NombreUsu, @cedula, @NombreCompl);
		IF (@@ERROR =0)
			RETURN 1;
		ELSE
			RETURN -2;
	END
GO

CREATE PROC SP_MODIFICARUSUARIO
@NombreUsu varchar (10),
@cedula bigint,
@NombreCompl varchar(50)
as
begin
	if (NOT exists (select NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO=@NombreUsu))
	RETURN -1;

	UPDATE USUARIO SET CEDULA=@cedula, NOMBRECOMPLETO=@NombreCompl WHERE NOMBREUSUARIO=@NombreUsu;
	RETURN 1;
END
GO

CREATE PROC SP_ELIMINARUSUARIO
@NombreUsu varchar (10),
@cedula bigint,
@NombreCompl varchar (50)
as 
begin
	if (not exists (select NOMBREUSUARIO from USUARIO where NOMBREUSUARIO=@NombreUsu))
	return -1;
	if exists (select NOMUSUENVIA from MENSAJE where NOMUSUENVIA=@NombreUsu) or exists (select nomusurecibe from MENSAJE where NOMUSURECIBE=@NombreUsu)
	return -2;
	
	delete USUARIO where NOMBREUSUARIO=@NombreUsu
	
	if (@@Error=0)
	return 1;
	else
	return -3;
	
end
go

create proc SP_BUSCARUSUARIO
@NombreUsu varchar (10)
as
begin
	select CEDULA, NOMBREUSUARIO
	FROM USUARIO
	WHERE NOMBREUSUARIO=@NombreUsu;
END
GO

CREATE PROC SP_LISTARUSUARIOS
AS
BEGIN
SELECT NOMBREUSUARIO, CEDULA, NOMBRECOMPLETO
FROM USUARIO
END
GO

CREATE PROC SP_ALTATIPOMSJ
@CodInt varchar (3),
@NombreCod varchar (20)
as
begin
if (exists (select CODINT from TIPOMSJ where CODINT=@CodInt))
return -1;
insert into TIPOMSJ (CODINT, NOMBRECOD) values (@CodInt, @NombreCod)
end
go

CREATE PROC SP_MODIFTIPOMSJ
@CodInt Varchar (3),
@NombreCod Varchar (20)
as
begin
	if (not exists (select CODINT FROM TIPOMSJ WHERE CODINT=@CodInt))
	RETURN -1
	
	UPDATE TIPOMSJ SET NOMBRECOD = @NombreCod WHERE CODINT=@CodInt;
	RETURN 1;
END
GO

CREATE PROC SP_ELIMINARTIPOMSJ
@CodInt varchar (3)
as
begin
	if (not exists (select CODINT FROM TIPOMSJ WHERE CODINT=@CodInt))
	RETURN -1
	if (exists (select CODINT FROM MSJCOMUN WHERE CODINT=@CodInt))
	RETURN -2
	DELETE TIPOMSJ WHERE CODINT=@CodInt
	RETURN 2;
END
GO

CREATE PROC SP_LISTARTIPOMSJ
AS
BEGIN
SELECT CODINT, NOMBRECOD
FROM TIPOMSJ
END
GO

create proc SP_BUSCATIPOMSJ
@CodInt varchar (3)
as
begin
	select CODINT, NOMBRECOD
	FROM TIPOMSJ
	WHERE CODINT=@CodInt;
END
GO

CREATE PROC SP_ALTAMSJPRIVADO
@ASUNTO VARCHAR (50),
@TEXTO VARCHAR (200),
@USUARIOENVIA VARCHAR (10),
@USUARIORECIBE VARCHAR (10),
@FECHACAD DATETIME
AS
BEGIN
	IF NOT EXISTS (SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO = @USUARIOENVIA)
		RETURN -1 -- USUARIO QUE ENVIA NO EXISTE.
	IF NOT EXISTS (SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO= @USUARIORECIBE)
		RETURN -2 -- USUARIO QUE RECIBE NO EXISTE
		BEGIN TRAN
		INSERT MENSAJE VALUES (GETDATE(), @ASUNTO ,@TEXTO, @USUARIOENVIA, @USUARIORECIBE)
			IF (@@ERROR != 0)
			BEGIN
				ROLLBACK TRAN
				RETURN -3
			END
		INSERT MSJPRIVADO VALUES (IDENT_CURRENT('MENSAJE'), @FECHACAD)
			IF (@@ERROR !=0)
			BEGIN
				ROLLBACK TRAN
				RETURN -3
			END
			COMMIT TRAN
			RETURN (IDENT_CURRENT('MENSAJE'))
END
GO

CREATE PROC LISTAMSJRECUSU
AS
BEGIN
	SELECT MENSAJE.*, MSJPRIVADO.FECHACAD
	FROM MENSAJE JOIN MSJPRIVADO ON MENSAJE.NUMINT = MSJPRIVADO.NUMINT
	WHERE FECHACAD >= GETDATE()
END
GO



CREATE PROCEDURE SP_AGREGARMSJCOMUN
@ASUNTO VARCHAR (50),
@TEXTO VARCHAR (200),
@USUARIOENVIA VARCHAR (10),
@USUARIORECIBE VARCHAR (10),
@TIPOMSJ VARCHAR (3)
AS
BEGIN
	IF NOT EXISTS (SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO = @USUARIOENVIA)
		RETURN -1 -- USUARIO QUE ENVIA NO EXISTE.
	IF NOT EXISTS (SELECT NOMBREUSUARIO FROM USUARIO WHERE NOMBREUSUARIO= @USUARIORECIBE)
		RETURN -2 -- USUARIO QUE RECIBE NO EXISTE
	IF NOT EXISTS (SELECT CODINT FROM TIPOMSJ WHERE CODINT = @TIPOMSJ)
		RETURN -3 -- EL C�DIGO INTERNO NO EXISTE.
		BEGIN TRAN
		INSERT MENSAJE VALUES (GETDATE(), @ASUNTO ,@TEXTO, @USUARIOENVIA, @USUARIORECIBE)
			IF (@@ERROR != 0)
			BEGIN
				ROLLBACK TRAN
				RETURN -4
			END
		INSERT MSJCOMUN VALUES (IDENT_CURRENT('MENSAJE'), @TIPOMSJ)
			IF (@@ERROR != 0)
			BEGIN 
				ROLLBACK TRAN
				RETURN -4
			END
			COMMIT TRAN
			RETURN (IDENT_CURRENT('MENSAJE'))
END
GO
