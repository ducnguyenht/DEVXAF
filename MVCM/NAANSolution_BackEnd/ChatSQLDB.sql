CREATE TABLE [dbo].[ChatUserDetail](
 [ID] [int] primary key IDENTITY(1,1) NOT NULL,
 [ConnectionId] [nvarchar](100) NULL,
 [UserName] [nvarchar](100) NULL,
 [EmailID] [nvarchar](50) NULL
)

CREATE TABLE [dbo].[ChatMessageDetail](
 [ID] [int] primary key IDENTITY(1,1) NOT NULL,
 [UserName] [nvarchar](100) NULL,
 [Message] [nvarchar](max) NULL,
 [EmailID] [nvarchar](50) NULL
 )

 
CREATE TABLE [dbo].[ChatPrivateMessageDetails](
 [ID] [int] primary key IDENTITY(1,1) NOT NULL,
 [MasterEmailID] [nvarchar](50) NOT NULL,
 [ChatToEmailID] [nvarchar](50) NOT NULL,
 [Message] [nvarchar](max) NULL
)


CREATE TABLE [dbo].[ChatPrivateMessageMaster](
 [ID] [int] primary key IDENTITY(1,1) NOT NULL,
 [UserName] [nvarchar](100) NULL,
 [EmailID] [nvarchar](50) NULL
)