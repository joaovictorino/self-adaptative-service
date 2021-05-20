USE [Experimento]
GO

/****** Object:  Table [dbo].[RequisicaoEntrada]    Script Date: 04/04/2014 21:04:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RequisicaoEntrada](
	[ID] [char](36) NOT NULL,
	[ContainerName] [varchar](10) NOT NULL,
	[DataHoraInicio] [datetime] NOT NULL,
	[Area] [varchar](10) NOT NULL,
 CONSTRAINT [PK_RequisicaoEntrada] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


