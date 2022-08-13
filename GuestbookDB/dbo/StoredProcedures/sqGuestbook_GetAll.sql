CREATE PROCEDURE [dbo].[sqGuestbook_GetAll]
AS
begin
	select *
	from dbo.Guestbook;
end
