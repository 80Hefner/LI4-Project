-- -----------------------------------------------------
-- Schema Firesafe
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Firesafe
-- -----------------------------------------------------
IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name='FireSafe')
    CREATE DATABASE [FireSafe]
GO

USE [Firesafe]
GO

DROP TABLE IF EXISTS [dbo].[Favorito];
DROP TABLE IF EXISTS [dbo].[Incendio];
DROP TABLE IF EXISTS [dbo].[Utilizador];
DROP TABLE IF EXISTS [dbo].[Localizacao];
DROP TABLE IF EXISTS [dbo].[Meteorologia];
GO

-- -----------------------------------------------------
-- Table [Firesafe].[dbo].[Utilizador]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Utilizador] (
  [Id] INT IDENTITY(1,1) NOT NULL,
  [Nome] VARCHAR(45) NOT NULL,
  [Password] VARCHAR(45) NOT NULL,
  [Email] VARCHAR(90) NOT NULL,
  [Telemovel] VARCHAR(20) NULL,
  PRIMARY KEY ([Id]));
GO

-- -----------------------------------------------------
-- Table [Firesafe].[dbo].[Localizacao]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Localizacao] (
  [Id] INT IDENTITY(1,1) NOT NULL,
  [Distrito] VARCHAR(45) NOT NULL,
  [Concelho] VARCHAR(45) NOT NULL,
  [Freguesia] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([Id]));
GO

-- -----------------------------------------------------
-- Table [Firesafe].[dbo].[Meteorologia]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Meteorologia] (
  [Id] INT IDENTITY(1,1) NOT NULL,
  [Temp_atual] FLOAT NOT NULL,
  [Temp_min] FLOAT NOT NULL,
  [Temp_max] FLOAT NOT NULL,
  [Vento_vel] FLOAT NOT NULL,
  [Vento_dir] VARCHAR(2) NOT NULL,
  [Humidade] INT NOT NULL,
  [Pressao_atm] INT NOT NULL,
  [Estado] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([Id]));
GO


-- -----------------------------------------------------
-- Table [Firesafe].[dbo].[Incendio]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Incendio] (
  [Id] INT IDENTITY(1,1) NOT NULL,
  [Meteorologia_Id] INT NOT NULL,
  [Localizacao_Id] INT NOT NULL,
  [Meios_humanos] INT NOT NULL,
  [Meios_terrestres] INT NOT NULL,
  [Meios_aereos] INT NOT NULL,
  [Latitude] FLOAT NOT NULL,
  [Longitude] FLOAT NOT NULL,
  [Estado] INT NOT NULL,
  [Inicio] SMALLDATETIME NOT NULL,
  [Fim] SMALLDATETIME,
  PRIMARY KEY ([Id]),
  CONSTRAINT [fk_Incendio_Localizacao1]
    FOREIGN KEY ([Localizacao_Id])
    REFERENCES [Localizacao] ([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Incendio_Meteorologia1]
    FOREIGN KEY ([Meteorologia_Id])
    REFERENCES [Meteorologia] ([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
GO

CREATE INDEX [fk_Incendio_Localizacao1_idx] on [Incendio] ([Localizacao_Id] ASC);
GO

CREATE INDEX [fk_Incendio_Meteorologia1_idx] on [Incendio] ([Meteorologia_Id] ASC);
GO
  

-- -----------------------------------------------------
-- Table [Firesafe].[dbo].[Favorito]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Favorito] (
  [Utilizador_Id] INT NOT NULL,
  [Localizacao_Id] INT NOT NULL,
  PRIMARY KEY ([Utilizador_Id], [Localizacao_Id]),
  CONSTRAINT [fk_Utilizador_has_Localizacao_Utilizador]
    FOREIGN KEY ([Utilizador_Id])
    REFERENCES [Utilizador] ([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Localizacao_Localizacao1]
    FOREIGN KEY ([Localizacao_Id])
    REFERENCES [Localizacao] ([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
GO

CREATE INDEX [fk_Utilizador_has_Localizacao_Localizacao1_idx] on [Favorito] ([Localizacao_Id] ASC);
GO

CREATE INDEX [fk_Utilizador_has_Localizacao_Utilizador_idx] on [Favorito] ([Utilizador_Id] ASC);
GO

