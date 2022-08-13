CREATE PROCEDURE [dbo].[spGuestbook_Delete]
	@id int
AS
begin
	delete
	from dbo.Guestbook
	where postId = @id;
end
