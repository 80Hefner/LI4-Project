USE [FireSafe]
GO


INSERT INTO [Utilizador]
           ([Id]
           ,[Nome]
           ,[Password]
           ,[Email]
           ,[Telemovel])
    VALUES
        (1,'Pedro Barbosa','nacho154','nachao@li4.pt','912345678'),
        (2,'Luís Sousa','123macacochines','hefner@li4.pt','969696969'),
        (3,'Bruno Dias','touretxiboy','bruninho@li4.pt','999111222')

GO

INSERT INTO [Localizacao]
           ([Id]
           ,[Distrito]
           ,[Concelho]
           ,[Freguesia])
    VALUES
        (1,'Viana do Castelo','Viana do Castelo','Meadela'),
        (2,'Viana do Castelo','Melgaço','Cousso'),
        (3,'Braga','Braga','São Victor'),
        (4,'Braga','Amares','Ferreiros, Prozelo e Besteiros')
GO
	

INSERT INTO [Meteorologia]
           ([Id]
           ,[Temp_atual]
           ,[Temp_min]
           ,[Temp_max]
           ,[Vento_vel]
           ,[Vento_dir]
           ,[Humidade]
           ,[Pressao_atm]
           ,[Estado])
    VALUES
        (1, 25.0, 20.0, 27.0, 17.0, 'NO', 23, 1020, 'céu limpo'),
        (2, 25.0, 22.0, 30.0, 24.0, 'O', 14, 1040, 'céu limpo')
GO

INSERT INTO [Incendio]
           ([Id]
           ,[Meteorologia_Id]
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
           (1,1,2,45,7,1,42.064973,-8.317543,2,convert(smalldatetime,'2021-06-05 07:30:00',20),convert(smalldatetime,'2021-06-05 14:00:00',20)),           
           (1,2,4,32,4,0,41.644726,-8.368616,1,convert(smalldatetime,'2021-06-05 13:00:00',20),NULL)
GO

INSERT INTO [Favorito]
           ([Utilizador_Id]
           ,[Localizacao_Id])
     VALUES
           (1,1),
           (1,3),
           (2,2),
           (2,3),
           (3,4),
           (3,3)
GO
