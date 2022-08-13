CREATE PROCEDURE [dbo].[spGuestbook_Insert]
	@name nvarchar(50),
	@email nvarchar(50),
	@comment nvarchar(255),
	@datetime datetime2(7)
AS
begin
	insert into dbo.Guestbook ([name], email, comment, [datetime])
	values (@name, @email, @comment, @datetime);
end