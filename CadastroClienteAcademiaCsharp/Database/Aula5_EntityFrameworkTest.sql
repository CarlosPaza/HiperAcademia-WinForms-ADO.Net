use master
GO

drop database if exists AulaBancoDeDados_Teste1;
GO

create database AulaBancoDeDados_Teste1

GO

use AulaBancoDeDados_Teste1

GO

CREATE TABLE PessoaFisica
(  
	 Id int NOT NULL IDENTITY(1, 1) primary key,
	 Nome nvarchar(50) NOT NULL,
	 Sobrenome nvarchar(50) NOT NULL,
	 Cpf nvarchar(30) NULL,
	 Rg nvarchar(20) NULL
)
GO

CREATE TABLE PedidoDeVenda
(
	Id int NOT NULL IDENTITY(1, 1) primary key,
	PessoaFisicaId INT NULL,
	Observacao NVARCHAR(200) NULL,
	CONSTRAINT FK_PessoaFisica FOREIGN KEY (PessoaFisicaId) REFERENCES PessoaFisica(Id)
)
GO
