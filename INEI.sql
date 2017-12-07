create database INEI_NOTA;

use INEI_NOTA;

create table BACHILLERATO(
	CODIGO		varchar(10),
	NOMBRE		varchar(50),
	DESCRIPCION	varchar(240),
	ACTIVO		boolean,	
	PRIMARY KEY (CODIGO)
);

insert into BACHILLERATO (codigo,nombre,descripcion,activo) 
values 	('001','Contado','--',true)
		,('002','Secretariado','--',true)
        ,('003','Mecanica','--',true)
        ,('004','General','--',true);

create table MATERIA(
	CODIGO			integer auto_increment,
	NOMBRE			varchar(100),	
	DESCRIPCION 	varchar(240),
	BACHILLERATO	varchar(10),
	ACTIVA			boolean,	
	PRIMARY KEY (CODIGO),
	FOREIGN KEY (BACHILLERATO) REFERENCES BACHILLERATO(CODIGO)
);

create table ALUMNO(
	CARNET			varchar(20),
	NOMBRES			varchar(40),
	APELLIDOS		varchar(40),
	sexo			char(1),
	TURNO			char(1),
	SECCION			varchar(2),
	ACTIVO			boolean,
	PRIMARY KEY (CARNET)
);

create table ALUMNO_MATERIA(
	CORRELATIVO		integer auto_increment,
	ALUMNO			varchar(20),
	MATERIA			integer,
	OBSERVACIONES	varchar(140),
	PRIMARY KEY (CORRELATIVO),
	FOREIGN KEY (ALUMNO) REFERENCES ALUMNO(CARNET),
	FOREIGN KEY (MATERIA) REFERENCES MATERIA(CODIGO)
);

create table ACTIVIDAD(
	ACTIVIDAD		integer auto_increment,
	NOMBRE			varchar(50),
	INDICACIONES	varchar(1000),
	FECHA_ENTREGA	date,
	ACTIVO			boolean,
	MATERIA			integer,
	PRIMARY KEY (ACTIVIDAD),
	FOREIGN KEY (MATERIA) REFERENCES MATERIA(CODIGO)
);

create table NOTAS(
	ACTIVIDAD		integer,
	NOTA			integer,
	ALUMNOMATERIA	integer,
	FOREIGN KEY (ACTIVIDAD) REFERENCES ACTIVIDAD(ACTIVIDAD)
); 