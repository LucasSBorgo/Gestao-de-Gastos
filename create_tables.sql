Create table Usuario
(
	id int identity (1,1),
	nome varchar(100) not null,
	idade int not null,
	email varchar (100) not null,
	Constraint PK_Usuario Primary Key (id)
);

Create table Conta
(
	id int identity (1,1),
	saldo decimal(15,4) not null,
	es_usuario int not null,
	Constraint Pk_Conta Primary Key (id),
	CONSTRAINT FK_Conta_Usuario FOREIGN KEY (es_usuario)
	REFERENCES dbo.Usuario (id)
)

Create table Transacao
(
	id int identity (1,1),
	descricao varchar(200) null,
	data datetime not null,
	valor decimal (15, 4) not null,
	tipo_inclusao varchar (1) not null,
	modalidade int not null,
	es_usuario int not null,
	es_conta int not null,
	constraint Pk_Transacao primary key (id),
	constraint FK_Transacao_Usuario Foreign Key (es_usuario)
	References dbo.Usuario(id),
	constraint FK_Transacao_Conta Foreign key (es_conta)
	References dbo.Conta(id)
)


select * from Conta

select * from Usuario

select * from Transacao
