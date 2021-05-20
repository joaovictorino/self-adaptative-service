USE [Experimento]
GO

/****** Object:  Table [dbo].[FilaRequisicao]    Script Date: 04/04/2014 21:06:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FilaRequisicao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Conteudo] [varchar](5000) NOT NULL,
	[Situacao] [int] NOT NULL,
	[Area] [varchar](10) NOT NULL,
 CONSTRAINT [PK_FilaRequisicao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


