USE [dienchan]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountClaim]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountLogin]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AccountLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountProperty]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountProperty](
	[AccountID] [int] NOT NULL,
	[Property] [nchar](64) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountRoles]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountRoles](
	[AccountId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AccountRoles] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeID] [int] NOT NULL,
	[AddressTypeName] [nchar](200) NULL,
	[Value1] [nvarchar](max) NULL,
	[Value2] [nvarchar](max) NULL,
	[Value3] [nvarchar](max) NULL,
	[Language] [nchar](5) NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ads]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ads](
	[AdID] [int] IDENTITY(1,1) NOT NULL,
	[AdName] [nvarchar](100) NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[ImageUrl] [varchar](100) NOT NULL,
	[Counter] [int] NOT NULL,
	[AdKey] [varchar](10) NOT NULL,
	[Status] [int] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Author] [int] NOT NULL,
	[ModifiedUser] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ThumImage] [varchar](100) NULL,
	[ThumTitle] [nvarchar](250) NULL,
	[Language] [nvarchar](12) NULL,
	[Description] [nvarchar](max) NULL,
	[PositionContent] [int] NULL,
 CONSTRAINT [PK_Ads] PRIMARY KEY CLUSTERED 
(
	[AdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdsDistribution]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdsDistribution](
	[AdID] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[DayNo] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Language] [nvarchar](12) NULL,
 CONSTRAINT [PK_AdsDistribution] PRIMARY KEY CLUSTERED 
(
	[AdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[QuizID] [int] NOT NULL,
	[Answer] [nvarchar](255) NOT NULL,
	[IsRight] [bit] NOT NULL,
	[Author] [int] NOT NULL,
	[ModifiedUser] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplyTo]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplyTo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CandidateID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Creationdate] [datetime] NOT NULL,
	[Value1] [nvarchar](max) NULL,
	[Value2] [nvarchar](max) NULL,
	[Value3] [nvarchar](max) NULL,
	[Value4] [nvarchar](max) NULL,
	[RecruitmentID] [int] NOT NULL,
 CONSTRAINT [PK__APPLYTO__3214EC271F98B2C1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppProperty]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppProperty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Property] [nvarchar](64) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AppProperty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Area]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value1] [nvarchar](max) NULL,
	[Value2] [nvarchar](max) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttachedType]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachedType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK__ATTACHED__3214EC27367C1819] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Content]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Content](
	[ContentID] [int] IDENTITY(1,1) NOT NULL,
	[Version] [int] NOT NULL,
	[Protected] [int] NOT NULL,
	[Language] [varchar](5) NOT NULL,
	[Headline] [nvarchar](max) NOT NULL,
	[Source] [nvarchar](max) NOT NULL,
	[Author] [int] NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[TagLine] [nvarchar](max) NULL,
	[PictureUrl] [nvarchar](max) NULL,
	[PictureNote] [nvarchar](max) NULL,
	[Value1] [nvarchar](max) NULL,
	[Value2] [nvarchar](max) NULL,
	[Value3] [nvarchar](max) NULL,
	[Value4] [nvarchar](max) NULL,
	[Value5] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Editor] [int] NOT NULL,
	[Approver] [int] NOT NULL,
	[ModifiedUser] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Counter] [int] NOT NULL,
	[Allowcomment] [int] NULL,
	[AllowcommentFB] [int] NULL,
	[LayoutStyle] [int] NULL,
	[BannerImages] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[CustomizeTitle] [nvarchar](max) NULL,
	[CustomizeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC,
	[Version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentLayout]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentLayout](
	[ContentLayoutID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ContentLayout] PRIMARY KEY CLUSTERED 
(
	[ContentLayoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentNotes]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentNotes](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[ContentID] [int] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Author] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ContentNotes] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentProperty]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentProperty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContentID] [int] NOT NULL,
	[ContentPropertyNameID] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentPropertyNameID]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentPropertyNameID](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentRank]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentRank](
	[RankID] [int] NOT NULL,
	[Rank] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_ContentRank] PRIMARY KEY CLUSTERED 
(
	[RankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cure]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cure](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Directory]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directory](
	[DirectoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Trademark] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Province] [nvarchar](max) NOT NULL,
	[Tel] [nvarchar](max) NOT NULL,
	[Fax] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[ActionField] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Directory] PRIMARY KEY CLUSTERED 
(
	[DirectoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Distribution]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Distribution](
	[ContentID] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[Language] [varchar](5) NOT NULL,
	[Ranking] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Distribution] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC,
	[Version] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[District]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nvarchar](64) NOT NULL,
	[CityID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Download]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Download](
	[DownloadID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[ContentID] [int] NOT NULL,
	[Counter] [int] NOT NULL,
	[Author] [int] NOT NULL,
	[ModifiedUser] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Download] PRIMARY KEY CLUSTERED 
(
	[DownloadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dtproperties]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dtproperties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[objectid] [int] NULL,
	[property] [varchar](64) NOT NULL,
	[value] [varchar](255) NULL,
	[uvalue] [nvarchar](255) NULL,
	[lvalue] [image] NULL,
	[version] [int] NOT NULL,
 CONSTRAINT [pk_dtproperties] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[property] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailAds]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[EmailAds](
	[Email] [varchar](255) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamResult]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResult](
	[ExamResultID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[QuizTestID] [int] NOT NULL,
	[Score] [float] NOT NULL,
	[CreationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExamResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamResultDetail]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResultDetail](
	[ExamResultDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ExamResultID] [int] NOT NULL,
	[QuizID] [int] NOT NULL,
	[CheckedAnswerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExamResultDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Group]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Protected] [int] NOT NULL,
	[Language] [varchar](5) NOT NULL,
	[Title] [nvarchar](64) NOT NULL,
	[Abbreviation] [varchar](32) NULL,
	[ImageUrl] [varchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[GroupType] [int] NOT NULL,
	[GroupParentID] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Layout] [int] NULL,
	[Level] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[ShowOnTopMenu] [int] NULL,
	[ShowOnBottomMenu] [int] NULL,
	[ShowOnArea] [int] NULL,
	[BannerUrl] [varchar](250) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupLayout]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupLayout](
	[GroupLayoutID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_GroupLayout] PRIMARY KEY CLUSTERED 
(
	[GroupLayoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mail]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mail](
	[MailID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NULL,
	[SenderID] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[CreationDate] [datetime] NULL,
	[OriginalMailID] [int] NULL,
	[ReplyMailID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalCure]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCure](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MedicalID] [int] NULL,
	[TypeID] [int] NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalRecord]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Headline] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[ParentMenuID] [int] NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](50) NULL,
	[Authorizations] [nvarchar](50) NULL,
	[NormalCss] [nvarchar](30) NULL,
	[SelectedCss] [nvarchar](30) NULL,
	[MenuOrder] [int] NULL,
	[Language] [varchar](5) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[National]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[National](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Options]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[OptionID] [int] NOT NULL,
	[EditionIsPassed] [int] NOT NULL,
	[ApprovalIsPassed] [int] NULL,
	[RowsPerPage] [int] NOT NULL,
	[HeadRankNo] [int] NOT NULL,
	[HighRankNo] [int] NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Province]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Province](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Coords] [varchar](20) NULL,
	[CityName] [nvarchar](max) NULL,
	[Area] [int] NULL,
	[Tax0] [float] NULL,
	[Tax1] [float] NULL,
	[Tax2] [float] NULL,
	[Tax3] [float] NULL,
	[Tax4] [float] NULL,
	[Tax5] [float] NULL,
	[NationalID] [int] NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](64) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Routing]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Routing](
	[RoutingId] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyUrl] [varchar](128) NOT NULL,
	[Controller] [varchar](128) NOT NULL,
	[Action] [varchar](128) NOT NULL,
	[EntityId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SendMailDetail]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendMailDetail](
	[SendMailDetailID] [int] IDENTITY(1,1) NOT NULL,
	[MailID] [int] NOT NULL,
	[ReceiverID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SendMailDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Site]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Site](
	[SiteID] [int] NOT NULL,
	[SiteName] [nvarchar](100) NOT NULL,
	[Abbreviation] [varchar](32) NULL,
	[Language] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysPara]    Script Date: 22/12/2016 9:42:38 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysPara](
	[ID] [int] NOT NULL,
	[ParaName] [nvarchar](80) NOT NULL,
	[ParaValue] [nvarchar](2000) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_SysPara] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_Priority]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[Site] ADD  CONSTRAINT [DF_Site_Language]  DEFAULT ('vi') FOR [Language]
GO
