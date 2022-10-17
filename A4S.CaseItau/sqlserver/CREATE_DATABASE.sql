USE master;
GO

CREATE DATABASE case_itau_twitter_db;
GO

USE case_itau_twitter_db
GO

CREATE TABLE usuarios (
	id BIGINT NOT NULL,
	guid UNIQUEIDENTIFIER,
	data_cadastro DATETIME,
	seguidores int,
	seguindo int,
	nome NVARCHAR(255),
	username NVARCHAR(255),
    CONSTRAINT PK_USUARIOS PRIMARY KEY (id)
);
GO

CREATE TABLE postagens (
	id BIGINT NOT NULL,
	guid UNIQUEIDENTIFIER,
	data_cadastro DATETIME,
	data_postagem DATETIME,
	id_author BIGINT,
	text NVARCHAR(MAX),
	idioma NVARCHAR(4),
    CONSTRAINT PK_POSTAGENS PRIMARY KEY (id),
	CONSTRAINT FK_POSTAGENS_USUARIOS FOREIGN KEY (id_author) REFERENCES usuarios(id)
);
GO

CREATE DATABASE case_itau_cat_db;
GO

USE case_itau_cat_db
GO

CREATE TABLE imagens (
	id BIGINT NOT NULL IDENTITY(1,1),
	guid UNIQUEIDENTIFIER,
	data_cadastro DATETIME,
	id_imagem NVARCHAR(30),
	id_raca NVARCHAR(20),
	categoria NVARCHAR(100),
	largura NVARCHAR(5),
	altura NVARCHAR(5),
	url NVARCHAR(MAX),
    CONSTRAINT PK_IMAGENS PRIMARY KEY (id),
	CONSTRAINT FK_IMAGENS_RACAS FOREIGN KEY (id_raca) REFERENCES racas(id)
);
GO

CREATE TABLE racas (
	id NVARCHAR(20) NOT NULL,
	guid UNIQUEIDENTIFIER,
	data_cadastro DATETIME,
	nome NVARCHAR(50),
	origem NVARCHAR(50),
	temperamento NVARCHAR(500),
	descricao NVARCHAR(MAX),
    CONSTRAINT PK_RACAS PRIMARY KEY (id)
);
GO