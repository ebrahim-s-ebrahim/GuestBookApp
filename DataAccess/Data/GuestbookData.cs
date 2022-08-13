using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class GuestbookData : IGuestbookData
    {
        private readonly ISqlDataAccess _db;

        public GuestbookData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<GuestbookModel>> ReadComments() =>
            _db.LoadData<GuestbookModel, dynamic>(storedProcedure: "dbo.spGuestbook_GetAll", new { });

        public async Task<GuestbookModel?> ReadComment(int id)
        {
            var results = await _db.LoadData<GuestbookModel, dynamic>(
                storedProcedure: "dbo.spGuestbook_Get",
                new { PostID = id });
            return results.FirstOrDefault();
        }

        public Task WriteComment(GuestbookModel guestbook) =>
            _db.SaveData(storedProcedure: "dbo.spGuestbook_Insert", new
            {
                guestbook.Name,
                guestbook.Email,
                guestbook.Comment,
                guestbook.DateTime
            });

        public Task EditComment(GuestbookModel guestbook) =>
            _db.SaveData(storedProcedure: "dbo.spGuestbook_Update", guestbook);

        public Task DeleteComment(int id) =>
            _db.SaveData(storedProcedure: "dbo.spGuestbook_Delete", new { PostId = id });
    }
}
