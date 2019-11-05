use master
GO

drop database if exists AulaBancoDeDados;
GO

create database AulaBancoDeDados
GO

use AulaBancoDeDados
GO

CREATE TABLE Cidade
(  
 Id uniqueidentifier DEFAULT NEWID() NOT NULL primary key,
 Nome nvarchar(100) NOT NULL,
 Estado nvarchar(2) NOT NULL,
)
GO

INSERT INTO Cidade (Nome, Estado)
 VALUES ('Brusque', 'SC'), 
	    ('Blumenau', 'SC'),
		('Guabiruba', 'SC'),
		('São Paulo', 'SP'),
		('Rio de Janeiro', 'RJ'),
		('Belo Horizonte', 'MG'),
		('Porto Alegre', 'RS'),
		('Curitiba', 'PR')
GO

CREATE TABLE Cliente
(  
 Id uniqueidentifier DEFAULT NEWID() NOT NULL primary key,
 Codigo int NOT NULL IDENTITY(1, 1),
 Nome nvarchar(100) NOT NULL,
 CidadeId uniqueidentifier NOT NULL,
 Telefone nvarchar(20) NULL,
 DataCadastro datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
 CONSTRAINT FK_Cidade FOREIGN KEY (CidadeId) REFERENCES Cidade(Id)
)
GO


INSERT INTO Cliente (Nome, CidadeId, Telefone)
 VALUES ('João', (SELECT Id FROM Cidade where Nome = 'Brusque'), '4712349876'), 
	    ('Carlos', (SELECT Id FROM Cidade where Nome = 'Brusque'), '4712455876'),
		('Bruna', (SELECT Id FROM Cidade where Nome = 'Rio de Janeiro'), '1245349876'),
		('Rafael', (SELECT Id FROM Cidade where Nome = 'Brusque'), '4712119876'),
		('Pedro', (SELECT Id FROM Cidade where Nome = 'Blumenau'), '4712349876'),
		('Antonio', (SELECT Id FROM Cidade where Nome = 'Brusque'), '4712349876'),
		('Fernanda', (SELECT Id FROM Cidade where Nome = 'Brusque'), NULL),
		('Aline', (SELECT Id FROM Cidade where Nome = 'Belo Horizonte'), '4712349876')
GO