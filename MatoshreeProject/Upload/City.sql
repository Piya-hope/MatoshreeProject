USE [MatoshreePortal]
GO
SET IDENTITY_INSERT [dbo].[Tbl_City] ON 

INSERT [dbo].[Tbl_City] ([ID], [City], [State_ID], [District_ID], [Create_date], [Updated_date], [created_by], [Status]) VALUES (1, N'Shirdi', 12, 312, CAST(N'2023-09-14T23:25:09.387' AS DateTime), CAST(N'2023-09-15T00:11:45.453' AS DateTime), N'PriyankaD', 1)
INSERT [dbo].[Tbl_City] ([ID], [City], [State_ID], [District_ID], [Create_date], [Updated_date], [created_by], [Status]) VALUES (2, N'Sangamner ', 12, 312, CAST(N'2023-09-15T00:14:17.957' AS DateTime), NULL, N'PriyankaD', 1)
INSERT [dbo].[Tbl_City] ([ID], [City], [State_ID], [District_ID], [Create_date], [Updated_date], [created_by], [Status]) VALUES (3, N'Kopargaon ', 12, 312, CAST(N'2023-09-15T00:17:45.547' AS DateTime), NULL, N'PriyankaD', 1)
SET IDENTITY_INSERT [dbo].[Tbl_City] OFF
GO
