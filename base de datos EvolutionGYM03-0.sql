create database EvolutionGYM;

use EvolutionGYM;

create table Usuarios
(
	tipo varchar(20) not null,
    usuario varchar(15) primary key,
    contraseña varchar(25) not null,
    nombres varchar(25) not null,
    apellidos varchar(25) not null
);

create table Proveedores
(
	codigo varchar(6) primary key,
    nombre_empresa varchar(50),
    telefono_empresa char(16),
    correo_empresa varchar(60),
    nombre_contacto varchar(60),
    apellidos_contacto varchar(60),
    observaciones text
);

create table Productos
(
	codigo varchar(15) primary key,
    producto varchar(30),
    marca varchar(30),
    categoria varchar(30),
    detalles text,
    precio_compra double,
    precio_venta_menudeo double,
    precio_venta_mayoreo double,
    precio_venta_instructor double,
    bodega int,
    imagen blob
);

create table Ventas
(
	usuario varchar(15),
    fecha datetime,
    folio int primary key,
    codigo_producto varchar(15),
    precio double,
    cantidad int,
    total double,
    utilidad double,
    foreign key (usuario) references usuarios(usuario)
);

create table compras
(
	codigo int primary key,
    codigo_producto varchar(15),
    codigo_proveedor varchar(6),
    cantidad int,
    fecha datetime,
    foreign key (codigo_proveedor) references proveedores
    (codigo)
);

create table detalle_compra
(
	codigo_compra int,
    codigo_producto varchar(15),
    cantidad int,
    precio_compra double,
    foreign key (codigo_compra) references compras(codigo),
    foreign key (codigo_producto) references productos(codigo)
);

create table detalle_ventas
(
	codigo_venta int,
    codigo_producto varchar(15),
    cantidad int,
    precio_venta double,
    foreign key (codigo_venta) references ventas(folio),
    foreign key (codigo_producto) references productos(codigo)
);