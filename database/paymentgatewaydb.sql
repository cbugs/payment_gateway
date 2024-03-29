USE [PaymentGatewayDB]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 6/25/2019 12:50:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[MerchantId] [uniqueidentifier] NOT NULL,
	[PaymentDetails] [nvarchar](max) NULL,
	[PaymentAmount] [float] NOT NULL,
	[PaymentStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/25/2019 12:50:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[UserEmail] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users_UserId]
GO
