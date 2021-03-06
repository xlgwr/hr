USE [HR_Zip]
GO
/****** Object:  Table [dbo].[user_mstr]    Script Date: 02/06/2015 17:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_mstr](
	[Tid] [bigint] NOT NULL,
	[comp] [nvarchar](50) NOT NULL,
	[userID] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](256) NOT NULL,
	[cc_super] [nvarchar](256) NULL,
	[cc_hr] [nvarchar](256) NULL,
	[u_str1] [nvarchar](50) NULL,
	[u_str2] [nvarchar](50) NULL,
	[u_dec1] [decimal](18, 0) NULL,
	[u_dec2] [decimal](18, 0) NULL,
	[updateDate] [datetime] NULL,
	[createby] [nvarchar](50) NULL,
	[clientIP] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_mstr] PRIMARY KEY CLUSTERED 
(
	[Tid] ASC,
	[comp] ASC,
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hrlog]    Script Date: 02/06/2015 17:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hrlog](
	[logID] [bigint] NOT NULL,
	[logname] [nvarchar](50) NULL,
	[logContent] [nvarchar](50) NULL,
	[u_str1] [nvarchar](50) NULL,
	[u_str2] [nvarchar](50) NULL,
	[u_dec1] [decimal](18, 0) NULL,
	[u_dec2] [decimal](18, 0) NULL,
	[updateDate] [datetime] NOT NULL,
	[createby] [nvarchar](50) NULL,
	[clientIP] [nvarchar](50) NULL,
 CONSTRAINT [PK_hrlog] PRIMARY KEY CLUSTERED 
(
	[logID] DESC,
	[updateDate] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
