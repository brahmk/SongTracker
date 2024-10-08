USE [MusicDB]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 10/3/2024 11:13:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LookupName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 10/3/2024 11:13:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ArtistId] [int] NULL,
	[LinkUrl] [nvarchar](max) NULL,
	[Artist] [nvarchar](max) NOT NULL,
	[ArtistLookup] [nvarchar](max) NOT NULL,
	[TitleLookup] [nvarchar](max) NOT NULL,
	[DateAdded] [datetime2](7) NULL,
	[DateModified] [datetime2](7) NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFriends]    Script Date: 10/3/2024 11:13:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFriends](
	[FriendId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserFriends] PRIMARY KEY CLUSTERED 
(
	[FriendId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/3/2024 11:13:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSongLikes]    Script Date: 10/3/2024 11:13:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSongLikes](
	[SongId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserSongLikes] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (2, N'Where Eagles Dare', NULL, N'https://youtu.be/7ON8zNL3e7c?si=lH6SSC3qWdzZZsI-', N'Misfits', N'misfits', N'whereeaglesdare', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), NULL)
INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (3, N'July Unending', NULL, N'https://open.spotify.com/track/4MGTb8sIDrIOkwECcO1gAy?si=98162af5dd3e4b05', N'Balmora', N'balmora', N'julyunending', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), NULL)
INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (6, N'Ghost Town', NULL, N'https://open.spotify.com/track/6ewN9MaFbi78oDLT9wYDgn?si=d94ff7d654414acb', N'The Specials', N'thespecials', N'ghosttown', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), CAST(N'2024-10-03T21:48:52.2215308' AS DateTime2))
INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (7, N'In Between Days', NULL, N'https://www.youtube.com/watch?v=scif2vfg1ug', N'The Cure', N'thecure', N'inbetweendays', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), NULL)
INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (8, N'Dreaming', NULL, N'https://open.spotify.com/track/2Rn7bVL1FVYboc4c55RUdg?si=bb4157c6aada4052', N'Blondie', N'blondie', N'dreaming', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), NULL)
INSERT [dbo].[Songs] ([SongId], [Title], [ArtistId], [LinkUrl], [Artist], [ArtistLookup], [TitleLookup], [DateAdded], [DateModified]) VALUES (9, N'XOXO', NULL, N'https://gelhc.bandcamp.com/track/xoxo', N'Gel', N'gel', N'xoxo', CAST(N'2024-10-03T21:40:31.2900000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Songs] OFF
GO
INSERT [dbo].[UserFriends] ([FriendId], [UserId]) VALUES (2, 1)
INSERT [dbo].[UserFriends] ([FriendId], [UserId]) VALUES (1, 2)
INSERT [dbo].[UserFriends] ([FriendId], [UserId]) VALUES (3, 2)
INSERT [dbo].[UserFriends] ([FriendId], [UserId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName]) VALUES (1, N'Brahm')
INSERT [dbo].[Users] ([UserId], [UserName]) VALUES (2, N'Zjolie')
INSERT [dbo].[Users] ([UserId], [UserName]) VALUES (3, N'Bill')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (2, 1)
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (7, 1)
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (8, 1)
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (9, 1)
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (6, 2)
INSERT [dbo].[UserSongLikes] ([SongId], [UserId]) VALUES (7, 2)
GO
ALTER TABLE [dbo].[Artists] ADD  DEFAULT (N'') FOR [LookupName]
GO
ALTER TABLE [dbo].[Songs] ADD  DEFAULT (N'') FOR [Artist]
GO
ALTER TABLE [dbo].[Songs] ADD  DEFAULT (N'') FOR [ArtistLookup]
GO
ALTER TABLE [dbo].[Songs] ADD  DEFAULT (N'') FOR [TitleLookup]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Artists_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Artists_ArtistId]
GO
ALTER TABLE [dbo].[UserFriends]  WITH CHECK ADD  CONSTRAINT [FK_UserFriends_Users_FriendId] FOREIGN KEY([FriendId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFriends] CHECK CONSTRAINT [FK_UserFriends_Users_FriendId]
GO
ALTER TABLE [dbo].[UserFriends]  WITH CHECK ADD  CONSTRAINT [FK_UserFriends_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserFriends] CHECK CONSTRAINT [FK_UserFriends_Users_UserId]
GO
ALTER TABLE [dbo].[UserSongLikes]  WITH CHECK ADD  CONSTRAINT [FK_UserSongLikes_Songs_SongId] FOREIGN KEY([SongId])
REFERENCES [dbo].[Songs] ([SongId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSongLikes] CHECK CONSTRAINT [FK_UserSongLikes_Songs_SongId]
GO
ALTER TABLE [dbo].[UserSongLikes]  WITH CHECK ADD  CONSTRAINT [FK_UserSongLikes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSongLikes] CHECK CONSTRAINT [FK_UserSongLikes_Users_UserId]
GO
