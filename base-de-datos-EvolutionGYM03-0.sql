create database EvolutionGYM;

use EvolutionGYM;

create table Usuarios
(
	tipo varchar(20) not null,
    usuario varchar(15) primary key,
    contraseña varchar(40) not null,
    nombres varchar(30) not null,
    apellidos varchar(40) not null
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
    codigo_proveedor varchar(6),
    producto varchar(30),
    marca varchar(30),
    categoria varchar(30),
    detalles text,
    precio_compra double,
    precio_venta_menudeo double,
    precio_venta_mayoreo double,
    precio_venta_instructor double,
    bodega int,
    foreign key (codigo_proveedor) references Proveedores(codigo)
);

create table Ventas
(
	folio int primary key,
	usuario varchar(15),
    fecha datetime,
    cantidad int,
    total double,
    utilidad double,
    foreign key (usuario) references usuarios(usuario)
);

create table compras
(
	folio int primary key,
    usuario varchar(15),
    fecha datetime,
    cantidad int,
    total double,
    foreign key (usuario) references usuarios(usuario)
);

create table detalle_compra
(
	codigo_compra int,
    codigo_producto varchar(15),
    producto varchar(50),
    cantidad int,
    precio_compra double,
    subtotal double,
    foreign key (codigo_compra) references compras(folio),
    foreign key (codigo_producto) references productos(codigo),
    constraint primary key(codigo_compra,codigo_producto)
);

create table detalle_ventas
(
	codigo_venta int,
    codigo_producto varchar(15),
    producto varchar(50),
    cantidad int,
    precio_venta double,
    subtotal double,
    foreign key (codigo_venta) references ventas(folio),
    foreign key (codigo_producto) references productos(codigo),
    constraint primary key(codigo_venta,codigo_producto)
);