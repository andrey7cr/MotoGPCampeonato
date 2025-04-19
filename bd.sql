USE [master]
GO
/****** Object:  Database [MotoGP_DB]    Script Date: 4/18/2025 9:22:34 PM ******/
CREATE DATABASE [MotoGP_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MotoGP_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MotoGP_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MotoGP_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MotoGP_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MotoGP_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MotoGP_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MotoGP_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MotoGP_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MotoGP_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MotoGP_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MotoGP_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MotoGP_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MotoGP_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MotoGP_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MotoGP_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MotoGP_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MotoGP_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MotoGP_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MotoGP_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MotoGP_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MotoGP_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MotoGP_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MotoGP_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MotoGP_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MotoGP_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MotoGP_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MotoGP_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MotoGP_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MotoGP_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MotoGP_DB] SET  MULTI_USER 
GO
ALTER DATABASE [MotoGP_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MotoGP_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MotoGP_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MotoGP_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MotoGP_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MotoGP_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MotoGP_DB] SET QUERY_STORE = OFF
GO
USE [MotoGP_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[CarreraId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Tipo] [int] NOT NULL,
	[GranPremioId] [int] NULL,
 CONSTRAINT [PK_Carreras] PRIMARY KEY CLUSTERED 
(
	[CarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Circuitos]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Circuitos](
	[CircuitoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[PaisId] [int] NOT NULL,
 CONSTRAINT [PK_Circuitos] PRIMARY KEY CLUSTERED 
(
	[CircuitoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[EquipoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Fabricante] [nvarchar](100) NOT NULL,
	[Pais] [nvarchar](50) NOT NULL,
	[Puntos] [int] NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrandesPremios]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrandesPremios](
	[GranPremioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[CircuitoId] [int] NOT NULL,
	[PaisId] [int] NOT NULL,
 CONSTRAINT [PK_GrandesPremios] PRIMARY KEY CLUSTERED 
(
	[GranPremioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JefesDeEquipo]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JefesDeEquipo](
	[JefeDeEquipoId] [int] IDENTITY(1,1) NOT NULL,
	[EquipoId] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_JefesDeEquipo] PRIMARY KEY CLUSTERED 
(
	[JefeDeEquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[PaisId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pilotos]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilotos](
	[PilotoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[EquipoId] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
 CONSTRAINT [PK_Pilotos] PRIMARY KEY CLUSTERED 
(
	[PilotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadosCarrera]    Script Date: 4/18/2025 9:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadosCarrera](
	[ResultadoCarreraId] [int] IDENTITY(1,1) NOT NULL,
	[CarreraId] [int] NOT NULL,
	[PilotoId] [int] NOT NULL,
	[Posicion] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
 CONSTRAINT [PK_ResultadosCarrera] PRIMARY KEY CLUSTERED 
(
	[ResultadoCarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/18/2025 9:22:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Correo] [nvarchar](max) NOT NULL,
	[Contrasena] [nvarchar](max) NOT NULL,
	[Rol] [int] NOT NULL,
	[EquipoId] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250416173613_InitialCreate', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250416183712_AddEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418172757_AddPiloto', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418173906_RemoveEdadFromPiloto', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418183025_AddPuntosToPilotoAndEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418185345_AddCarrerasAndResultados', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418195918_AddNombreCarreraToCarrera', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418200600_AddGranPremioAndCircuito', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418202842_AddPaisToCircuitoAndGranPremio', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250418211805_AddGranPremioToCarrera', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419015410_AddEquipoToUsuario', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419015738_AddJefeDeEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419022000_AddNombreToJefeDeEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419022219_RemoveUsuarioIdFromJefeDeEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419022710_SyncJefeDeEquipoModel', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419023822_RecreateUsuarioIdInJefeDeEquipo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419025742_AddPuntosToResultadoCarrera', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419031419_RecalcularPuntosEnResultados', N'9.0.4')
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (1, CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (2, CAST(N'2025-03-02T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (3, CAST(N'2025-03-15T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (4, CAST(N'2025-03-16T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (5, CAST(N'2025-03-29T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (6, CAST(N'2025-03-30T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (7, CAST(N'2025-04-12T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (8, CAST(N'2025-03-13T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (9, CAST(N'2025-04-27T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (10, CAST(N'2025-04-27T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (11, CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (12, CAST(N'2025-03-02T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (13, CAST(N'2025-03-15T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (14, CAST(N'2025-03-16T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (15, CAST(N'2025-03-29T00:00:00.0000000' AS DateTime2), 0, 3)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (16, CAST(N'2025-03-30T00:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (17, CAST(N'2025-04-12T00:00:00.0000000' AS DateTime2), 0, 4)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (18, CAST(N'2025-04-13T00:00:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (19, CAST(N'2025-04-26T00:00:00.0000000' AS DateTime2), 0, 5)
INSERT [dbo].[Carreras] ([CarreraId], [Fecha], [Tipo], [GranPremioId]) VALUES (20, CAST(N'2025-04-27T00:00:00.0000000' AS DateTime2), 1, 5)
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Circuitos] ON 

INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (1, N'Chang International Circuit', 1)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (2, N'Termas de Río Hondo', 2)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (4, N'Lusail International Circuit', 4)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (5, N'Circuito de Jerez - Ángel Nieto', 5)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (6, N'Le Mans', 6)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (7, N' Silverstone Circuit', 7)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (8, N' MotorLand Aragón', 5)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (9, N'Autodromo Internazionale del Mugello', 8)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (10, N'TT Circuit Assen', 9)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (11, N'Sachsenring', 10)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (12, N'Automotodrom Brno', 11)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (13, N'Red Bull Ring - Spielberg', 12)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (14, N'Balaton Park', 13)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (15, N'Circuit de Barcelona-Catalunya', 5)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (16, N'Misano World Circuit Marco Simoncelli', 8)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (17, N'Mobility Resort Motegi', 14)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (18, N'Pertamina Mandalika Circuit', 15)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (19, N'Phillip Island', 16)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (20, N'Petronas Sepang International Circuit', 17)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (21, N'Autódromo Internacional do Algarve', 18)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (22, N'Circuit Ricardo Tormo', 5)
INSERT [dbo].[Circuitos] ([CircuitoId], [Nombre], [PaisId]) VALUES (23, N'Circuit Of The Americas', 3)
SET IDENTITY_INSERT [dbo].[Circuitos] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (1, N'Aprilia Racing', N'Aprilia', N'Italia', 14)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (2, N'BK8 Gresini Racing MotoGP', N'Ducati', N'Italia', 35)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (3, N'Ducati Lenovo Team', N'Ducati', N'Italia', 53)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (4, N'Honda HRC Castrol', N'Honda', N'Japón', 4)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (5, N'LCR Honda', N'Honda', N'Japón', 14)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (6, N'Monster Energy Yamaha MotoGP', N'Yamaha', N'Japón', 10)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (7, N'Pertamina Enduro VR46 Racing Team', N'Ducati', N'Italia', 19)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (8, N'Prima Pramac Yamaha MotoGP', N'Yamaha', N'Italia', 7)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (9, N'Red Bull KTM Factory Racing', N'KTM', N'Austria', 8)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (10, N'Red Bull KTM Tech3', N'KTM', N'Austria', 14)
INSERT [dbo].[Equipos] ([EquipoId], [Nombre], [Fabricante], [Pais], [Puntos]) VALUES (11, N'Trackhouse MotoGP Team', N'Aprilia', N'Estados Unidos', 11)
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[GrandesPremios] ON 

INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (1, N'PT Grand Prix of Thailand', 1, 1)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (2, N'Gran Premio YPF Energía de Argentina', 2, 2)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (3, N'Red Bull Grand Prix of The Americas', 23, 3)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (4, N'Qatar Airways Grand Prix of Qatar', 4, 4)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (5, N'Gran Premio Estrella Galicia 0,0 de España', 5, 5)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (6, N'Michelin® Grand Prix de France', 6, 6)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (7, N'Tissot British Grand Prix', 7, 7)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (8, N'Gran Premio GoPro de Aragón', 8, 5)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (9, N'Gran Premio d’Italia Brembo', 9, 8)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (10, N'Motul TT Assen', 10, 9)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (11, N'Liqui Moly Motorrad Grand Prix Deutschland', 11, 10)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (12, N'Grand Prix of Czechia', 12, 11)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (13, N'Motorrad Grand Prix von Österreich', 13, 12)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (14, N'Grand Prix of Hungary', 14, 13)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (15, N'Gran Premi Monster Energy de Catalunya', 15, 5)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (16, N'Gran Premio Red Bull di San Marino e della Riviera di Rimini', 16, 8)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (17, N'Motul Grand Prix of Japan', 17, 14)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (18, N'Pertamina Grand Prix of Indonesia', 18, 15)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (19, N'Australian Motorcycle Grand Prix', 19, 16)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (20, N'Petronas Grand Prix of Malaysia', 20, 17)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (21, N'Qatar Airways Grande Prémio de Portugal', 21, 18)
INSERT [dbo].[GrandesPremios] ([GranPremioId], [Nombre], [CircuitoId], [PaisId]) VALUES (22, N'Gran Premio Motul de la Comunitat Valenciana', 22, 5)
SET IDENTITY_INSERT [dbo].[GrandesPremios] OFF
GO
SET IDENTITY_INSERT [dbo].[JefesDeEquipo] ON 

INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (1, 3, N'Luigi Dall''Igna', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (2, 6, N'Massimo Meregalli', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (3, 4, N'Alberto Puig', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (4, 9, N'Francesco Guidotti', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (5, 1, N'Massimo Rivola', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (6, 8, N'Gino Borsoi', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (7, 2, N'Nadia Padovani ', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (8, 5, N'Lucio Cecchinello', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (9, 11, N'Justin Marks ', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (10, 7, N'Alessio Salucci', NULL)
INSERT [dbo].[JefesDeEquipo] ([JefeDeEquipoId], [EquipoId], [Nombre], [UsuarioId]) VALUES (11, 10, N'Alberto Giribuola', NULL)
SET IDENTITY_INSERT [dbo].[JefesDeEquipo] OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (1, N'Tailandia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (2, N'Argentina')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (3, N'Estados Unidos')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (4, N'Qatar')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (5, N'España')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (6, N'Francia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (7, N'Reino Unido')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (8, N'Italia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (9, N'Países Bajos')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (10, N'Alemania')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (11, N'República Checa')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (12, N'Austria')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (13, N'Hungría')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (14, N'Japón')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (15, N'Indonesia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (16, N'Australia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (17, N'Malasia')
INSERT [dbo].[Paises] ([PaisId], [Nombre]) VALUES (18, N'Portugal')
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
SET IDENTITY_INSERT [dbo].[Pilotos] ON 

INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (1, N'Raúl Fernández', 11, 0)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (2, N'Ai Ogura', 11, 11)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (3, N'Jorge Martín', 1, 0)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (4, N'Marco Bezzechi', 1, 14)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (5, N'Fermin Aldeguer', 2, 3)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (6, N'Alex Marquez', 2, 32)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (7, N'Marc Marquez', 3, 37)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (8, N'Francesco Bagnaia', 3, 16)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (9, N'Luca Marini', 4, 4)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (10, N'Joan Mir', 4, 0)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (11, N'Johann Zarco', 5, 14)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (12, N'Somkiat Chantra', 5, 0)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (13, N'Fabio Quartararo', 6, 1)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (14, N'Alex Rins', 6, 9)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (15, N'Franco Morbidelli', 7, 13)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (16, N'Fabio Di Giannantonio', 7, 6)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (17, N'Jack Miller', 8, 5)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (18, N'Miguel Oliveira', 8, 2)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (19, N'Brad Binder', 9, 8)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (20, N'Pedro Acosta', 9, 0)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (21, N'Maverick Viñales', 10, 7)
INSERT [dbo].[Pilotos] ([PilotoId], [Nombre], [EquipoId], [Puntos]) VALUES (22, N'Enea Bastianini', 10, 7)
SET IDENTITY_INSERT [dbo].[Pilotos] OFF
GO
SET IDENTITY_INSERT [dbo].[ResultadosCarrera] ON 

INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (45, 11, 7, 1, 12)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (46, 11, 6, 2, 9)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (47, 11, 8, 3, 7)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (48, 11, 2, 4, 6)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (49, 11, 15, 5, 5)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (50, 11, 20, 6, 4)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (51, 11, 13, 7, 3)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (52, 11, 19, 8, 2)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (53, 11, 10, 9, 1)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (54, 11, 11, 10, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (55, 11, 1, 11, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (56, 11, 4, 12, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (57, 11, 5, 13, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (58, 11, 21, 14, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (59, 11, 9, 15, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (60, 11, 18, 16, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (61, 11, 14, 17, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (62, 11, 22, 18, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (63, 11, 12, 19, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (64, 11, 3, 20, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (65, 11, 16, 21, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (66, 11, 17, 22, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (67, 12, 7, 1, 25)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (68, 12, 6, 2, 20)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (69, 12, 8, 3, 16)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (70, 12, 15, 4, 13)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (71, 12, 2, 5, 11)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (72, 12, 4, 6, 10)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (73, 12, 11, 7, 9)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (74, 12, 19, 8, 8)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (75, 12, 22, 9, 7)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (76, 12, 16, 10, 6)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (77, 12, 17, 11, 5)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (78, 12, 9, 12, 4)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (79, 12, 5, 13, 3)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (80, 12, 18, 14, 2)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (81, 12, 13, 15, 1)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (82, 12, 21, 16, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (83, 12, 14, 17, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (84, 12, 12, 18, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (85, 12, 20, 19, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (86, 12, 3, 20, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (87, 12, 1, 21, 0)
INSERT [dbo].[ResultadosCarrera] ([ResultadoCarreraId], [CarreraId], [PilotoId], [Posicion], [Puntos]) VALUES (88, 12, 10, 22, 0)
SET IDENTITY_INSERT [dbo].[ResultadosCarrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioId], [Nombre], [Correo], [Contrasena], [Rol], [EquipoId]) VALUES (1, N'Andrey', N'andrey@andrey.com', N'$2a$11$Yogh.7lXOqxZaDgvidN4YuT5iDvAIMIuQq5iWdwcSM2n42VPmK9BS', 0, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Carreras_GranPremioId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carreras_GranPremioId] ON [dbo].[Carreras]
(
	[GranPremioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Circuitos_PaisId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Circuitos_PaisId] ON [dbo].[Circuitos]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GrandesPremios_CircuitoId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_GrandesPremios_CircuitoId] ON [dbo].[GrandesPremios]
(
	[CircuitoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GrandesPremios_PaisId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_GrandesPremios_PaisId] ON [dbo].[GrandesPremios]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JefesDeEquipo_EquipoId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_JefesDeEquipo_EquipoId] ON [dbo].[JefesDeEquipo]
(
	[EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pilotos_EquipoId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pilotos_EquipoId] ON [dbo].[Pilotos]
(
	[EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResultadosCarrera_CarreraId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_ResultadosCarrera_CarreraId] ON [dbo].[ResultadosCarrera]
(
	[CarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResultadosCarrera_PilotoId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_ResultadosCarrera_PilotoId] ON [dbo].[ResultadosCarrera]
(
	[PilotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_EquipoId]    Script Date: 4/18/2025 9:22:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_EquipoId] ON [dbo].[Usuarios]
(
	[EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Circuitos] ADD  DEFAULT ((0)) FOR [PaisId]
GO
ALTER TABLE [dbo].[Equipos] ADD  DEFAULT ((0)) FOR [Puntos]
GO
ALTER TABLE [dbo].[GrandesPremios] ADD  DEFAULT ((0)) FOR [PaisId]
GO
ALTER TABLE [dbo].[JefesDeEquipo] ADD  DEFAULT (N'') FOR [Nombre]
GO
ALTER TABLE [dbo].[Pilotos] ADD  DEFAULT ((0)) FOR [Puntos]
GO
ALTER TABLE [dbo].[ResultadosCarrera] ADD  DEFAULT ((0)) FOR [Puntos]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [FK_Carreras_GrandesPremios_GranPremioId] FOREIGN KEY([GranPremioId])
REFERENCES [dbo].[GrandesPremios] ([GranPremioId])
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [FK_Carreras_GrandesPremios_GranPremioId]
GO
ALTER TABLE [dbo].[Circuitos]  WITH CHECK ADD  CONSTRAINT [FK_Circuitos_Paises_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Paises] ([PaisId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Circuitos] CHECK CONSTRAINT [FK_Circuitos_Paises_PaisId]
GO
ALTER TABLE [dbo].[GrandesPremios]  WITH CHECK ADD  CONSTRAINT [FK_GrandesPremios_Circuitos_CircuitoId] FOREIGN KEY([CircuitoId])
REFERENCES [dbo].[Circuitos] ([CircuitoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GrandesPremios] CHECK CONSTRAINT [FK_GrandesPremios_Circuitos_CircuitoId]
GO
ALTER TABLE [dbo].[GrandesPremios]  WITH CHECK ADD  CONSTRAINT [FK_GrandesPremios_Paises_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Paises] ([PaisId])
GO
ALTER TABLE [dbo].[GrandesPremios] CHECK CONSTRAINT [FK_GrandesPremios_Paises_PaisId]
GO
ALTER TABLE [dbo].[JefesDeEquipo]  WITH CHECK ADD  CONSTRAINT [FK_JefesDeEquipo_Equipos_EquipoId] FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipos] ([EquipoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JefesDeEquipo] CHECK CONSTRAINT [FK_JefesDeEquipo_Equipos_EquipoId]
GO
ALTER TABLE [dbo].[JefesDeEquipo]  WITH CHECK ADD  CONSTRAINT [FK_JefesDeEquipo_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[JefesDeEquipo] CHECK CONSTRAINT [FK_JefesDeEquipo_Usuarios_UsuarioId]
GO
ALTER TABLE [dbo].[Pilotos]  WITH CHECK ADD  CONSTRAINT [FK_Pilotos_Equipos_EquipoId] FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipos] ([EquipoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pilotos] CHECK CONSTRAINT [FK_Pilotos_Equipos_EquipoId]
GO
ALTER TABLE [dbo].[ResultadosCarrera]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosCarrera_Carreras_CarreraId] FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ResultadosCarrera] CHECK CONSTRAINT [FK_ResultadosCarrera_Carreras_CarreraId]
GO
ALTER TABLE [dbo].[ResultadosCarrera]  WITH CHECK ADD  CONSTRAINT [FK_ResultadosCarrera_Pilotos_PilotoId] FOREIGN KEY([PilotoId])
REFERENCES [dbo].[Pilotos] ([PilotoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ResultadosCarrera] CHECK CONSTRAINT [FK_ResultadosCarrera_Pilotos_PilotoId]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Equipos_EquipoId] FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipos] ([EquipoId])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Equipos_EquipoId]
GO
USE [master]
GO
ALTER DATABASE [MotoGP_DB] SET  READ_WRITE 
GO
