USE [master]
GO

CREATE DATABASE [FilRouge] ON  PRIMARY 
	( 
	NAME = N'FilRouge', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FilRouge.mdf' , 
	SIZE = 8192KB , 
	MAXSIZE = UNLIMITED, 
	FILEGROWTH = 65536KB 
	)
	LOG ON
	( 
	NAME = N'FilRouge_log', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FilRouge_log.ldf' , 
	SIZE = 8192KB , 
	MAXSIZE = 2048GB , 
	FILEGROWTH = 65536KB )
GO
USE [FilRouge]
GO

-- [DemiJournee]
CREATE TABLE [dbo].[DemiJournee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HeureDebut] [time](7) NOT NULL,
	[HeureFin] [time](7) NOT NULL,
	[Module] [bigint] NOT NULL,
 CONSTRAINT [PK_DemiJournee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- [Etablissement]
CREATE TABLE [dbo].[Etablissement](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](50) NOT NULL,
	[Admin] [bigint] NULL,
 CONSTRAINT [PK_Etablissement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- [Module]
CREATE TABLE [dbo].[Module](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](50) NOT NULL,
	[Formateur] [bigint] NULL,
 	[Session] [bigint] NOT NULL,
CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- [Note]
CREATE TABLE [dbo].[Note](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DateNotation] [datetime] NOT NULL,
	[Module] [bigint] NOT NULL,
	[Eleve] [bigint] NOT NULL,
	[Valeur] [tinyint] NOT NULL,
	[Commentaire] [nvarchar](max) NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-- [Session]
CREATE TABLE [dbo].[Session](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](50) NOT NULL,
	[DateDebut] [datetime] NOT NULL,
	[DateFin] [datetime] NOT NULL,
	[Etablissement] [bigint] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- [SessionEleve]
CREATE TABLE [dbo].[SessionEleve](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Eleve] [bigint] NOT NULL,
	[Session] [bigint] NOT NULL,
 CONSTRAINT [PK_SessionEleve] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- [Utilisateur]
CREATE TABLE [dbo].[Utilisateur](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [tinyint] NOT NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Utilisateur] ADD  CONSTRAINT [DF_Utilisateur_Role]  DEFAULT ((0)) FOR [Role]

-- Clés étrangères
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Module] FOREIGN KEY([Module]) REFERENCES [dbo].[Module] ([Id])
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Module]
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Module1] FOREIGN KEY([Module]) REFERENCES [dbo].[Module] ([Id])
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Module1]
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Utilisateur] FOREIGN KEY([Eleve]) REFERENCES [dbo].[Utilisateur] ([Id])
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Utilisateur]

ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Etablissement] FOREIGN KEY([Etablissement]) REFERENCES [dbo].[Etablissement] ([Id])
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Etablissement]

ALTER TABLE [dbo].[SessionEleve]  WITH CHECK ADD  CONSTRAINT [FK_SessionEleve_Session] FOREIGN KEY([Session]) REFERENCES [dbo].[Session] ([Id])
ALTER TABLE [dbo].[SessionEleve] CHECK CONSTRAINT [FK_SessionEleve_Session]
ALTER TABLE [dbo].[SessionEleve]  WITH CHECK ADD  CONSTRAINT [FK_SessionEleve_Utilisateur] FOREIGN KEY([Eleve]) REFERENCES [dbo].[Utilisateur] ([Id])
ALTER TABLE [dbo].[SessionEleve] CHECK CONSTRAINT [FK_SessionEleve_Utilisateur]

ALTER TABLE [dbo].[DemiJournee]  WITH CHECK ADD  CONSTRAINT [FK_DemiJournee_Module] FOREIGN KEY([Module]) REFERENCES [dbo].[Module] ([Id])
ALTER TABLE [dbo].[DemiJournee] CHECK CONSTRAINT [FK_DemiJournee_Module]

ALTER TABLE [dbo].[Etablissement]  WITH CHECK ADD  CONSTRAINT [FK_Etablissement_Utilisateur] FOREIGN KEY([Admin]) REFERENCES [dbo].[Utilisateur] ([Id])
ALTER TABLE [dbo].[Etablissement] CHECK CONSTRAINT [FK_Etablissement_Utilisateur]

ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_Session] FOREIGN KEY([Session]) REFERENCES [dbo].[Session] ([Id])
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_Session]
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_Utilisateur] FOREIGN KEY([Formateur]) REFERENCES [dbo].[Utilisateur] ([Id])
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_Utilisateur]

insert Utilisateur (Nom, [Password], Role) values('Ali', 'P@ssw0rd', 2)
insert Utilisateur (Nom, Password, Role) values('xavier', 'P@ssw0rd', 1)
insert Utilisateur (Nom, Password, Role) values('Chems', 'P@ssw0rd', 1)
insert Utilisateur (Nom, Password, Role) values('Benjamin', 'P@ssw0rd', 1)
insert Utilisateur (Nom, Password, Role) values('Loïc', 'P@ssw0rd', 1)
insert Utilisateur (Nom, [Password], Role) values('Admin', 'P@ssw0rd', 4)
insert Etablissement(Libelle, Admin) values('M2i', 5)
insert [Session] (Libelle, DateDebut, DateFin, Etablissement) values('CDA 2024', '06/03/2024', '24/02/2025', 1)
insert Module (Libelle, Formateur, Session) values('UML', 1, 1)
insert Module (Libelle, Formateur, Session) values('WPF', 1, 1)
insert SessionEleve (Session, Eleve) values (1, 3),	(1, 4),	(1, 5)
Go

select u.Id, u.Nom from SessionEleve se
inner join Utilisateur u on se.Eleve=u.Id
where Role=1 and se.Session = 1

--select * from [Session]
--select * from [SessionEleve]
--select * from [Utilisateur]
--select * from Etablissement
--select * from Utilisateur
--select * from Module

--select u.Id, u.Nom 
--from SessionEleve se
--inner join Utilisateur u on se.Eleve=u.Id
--where Role=1 and se.Session = 1

use master