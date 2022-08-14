namespace Guestbook
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //All of API endpoint mapping
            app.MapGet(pattern:"/Comments", ReadComments);
            app.MapGet(pattern:"/Comments/{id}", ReadComment);
            app.MapPost(pattern: "/Comments", WriteComment);
            app.MapPut(pattern: "/Comments", EditComment);
            app.MapDelete(pattern: "/Comments", DeleteComment);

        }

        private static async Task<IResult> ReadComments(IGuestbookData data)
        {
            try
            {
                return Results.Ok(await data.ReadComments());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> ReadComment(int id, IGuestbookData data)
        {
            try
            {
                var results = await data.ReadComment(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> WriteComment(GuestbookModel guestbook, IGuestbookData data)
        {
            try
            {
                await data.WriteComment(guestbook);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> EditComment(GuestbookModel guestbook, IGuestbookData data)
        {
            try
            {
                await data.EditComment(guestbook);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteComment(int id, IGuestbookData data)
        {
            try
            {
                await data.DeleteComment(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
