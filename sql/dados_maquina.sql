USE [Experimento]
GO

/****** Object:  Table [dbo].[DadosMaquina]    Script Date: 04/04/2014 21:06:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DadosMaquina](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CPU] [float] NOT NULL,
	[Memoria] [float] NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_DadosMaquina] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


