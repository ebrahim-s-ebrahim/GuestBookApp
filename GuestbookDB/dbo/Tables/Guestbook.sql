CREATE TABLE [dbo].[Guestbook]
(
	[postId] INT NOT NULL IDENTITY, 
    [name] NCHAR(50) NOT NULL, 
    [email] NCHAR(50) NOT NULL, 
    [password] NCHAR(50) NOT NULL, 
    [comment] NCHAR(255) NOT NULL, 
    [datetime] DATETIME2 NOT NULL,
    PRIMARY KEY (postId, email)
)
