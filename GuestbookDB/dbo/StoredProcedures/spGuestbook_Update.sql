CREATE PROCEDURE [dbo].[spGuestbook_Update]
	@id int,
	@name nvarchar(50),
	@email nvarchar(50),
	@comment nvarchar(255),
	@datetime datetime2(7)
AS
begin
	update dbo.Guestbook
	set name = @name, email = @email, comment = @comment, [datetime]= @datetime
	where postId = @id
end