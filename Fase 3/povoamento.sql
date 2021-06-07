USE [FireSafe]
GO

-- Clear database before populating --
DELETE FROM [dbo].[Favorito];
DELETE FROM [dbo].[Incendio];
DELETE FROM [dbo].[Utilizador];
DELETE FROM [dbo].[Localizacao];
DELETE FROM [dbo].[Meteorologia];

DBCC CHECKIDENT ('[dbo].[Incendio]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Utilizador]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Localizacao]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Meteorologia]', RESEED, 0);
GO

INSERT INTO [dbo].[Utilizador]
           ([Nome]
           ,[Password]
           ,[Email]
           ,[Telemovel])
    VALUES
        ('Pedro Barbosa','nacho154','nachao@li4.pt','912345678'),
        ('Luís Sousa','123macacochines','hefner@li4.pt','969696969'),
        ('Bruno Dias','touretxiboy','bruninho@li4.pt','999111222')

GO

INSERT INTO [dbo].[Localizacao]
           ([Distrito]
           ,[Concelho]
           ,[Freguesia])
    VALUES
        ('Viana do Castelo','Melgaço','Cousso'),
        ('Braga','Amares','Ferreiros, Prozelo e Besteiros')
GO

INSERT INTO [dbo].[Meteorologia]
           ([Temp_atual]
           ,[Temp_min]
           ,[Temp_max]
           ,[Vento_vel]
           ,[Vento_dir]
           ,[Humidade]
           ,[Pressao_atm]
           ,[Estado])
    VALUES
        (25.0, 20.0, 27.0, 17.0, 'NO', 23, 1020, 'céu limpo'),
        (25.0, 22.0, 30.0, 24.0, 'O', 14, 1040, 'céu limpo')
GO

INSERT INTO [dbo].[Incendio]
           ([Meteorologia_Id]
           ,[Localizacao_Id]
           ,[Meios_humanos]
           ,[Meios_terrestres]
           ,[Meios_aereos]
           ,[Latitude]
           ,[Longitude]
           ,[Estado]
           ,[Inicio]
           ,[Fim])
     VALUES
           (1,1,45,7,1,42.064973,-8.317543,2,convert(smalldatetime,'2021-06-05 07:30:00',20),convert(smalldatetime,'2021-06-05 14:00:00',20)),           
           (2,2,32,4,0,41.644726,-8.368616,1,convert(smalldatetime,'2021-06-05 13:00:00',20),NULL)
GO

INSERT INTO [dbo].[Favorito]
           ([Utilizador_Id]
           ,[Localizacao_Id])
     VALUES
           (1,1),
           (1,2),
           (2,1),
           (2,2),
           (3,1)
GO
