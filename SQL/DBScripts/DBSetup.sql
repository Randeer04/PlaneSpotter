/****** Object:  Database [PlaneSpotter]    Script Date: 05/29/2021 10:36:49 PM ******/
CREATE DATABASE [PlaneSpotter]

ALTER DATABASE [PlaneSpotter] SET QUERY_STORE = OFF
GO
USE [PlaneSpotter]
GO
/****** Object:  Table [dbo].[Sighting]    Script Date: 05/29/2021 10:36:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sighting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](128) NOT NULL,
	[Model] [varchar](128) NOT NULL,
	[Registration] [varchar](8) NOT NULL,
	[Location] [nvarchar](255) NOT NULL,
	[SightingDate] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](50) NOT NULL,
	[LastUpdatedDateTime] [datetime] NOT NULL,
	[LastUpdatedUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sighting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [PlaneSpotter] SET  READ_WRITE 
GO
