CREATE PROCEDURE [dbo].[spGuestbook_Get]
	@id int
AS
begin
	select *
	from dbo.Guestbook
	where postId = @id;
end
