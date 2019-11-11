using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Function
{
    public class UserFunction
    {        
        internal int GetUserIdByLogin(string UserName, string Password, DateTime LastLoginTime, int State, DateTime LastUpdateDate, int RecordState, string HType)
        {
            using (UserContext db= new UserContext())
            {
                int UserId = db.Users.Where(x => x.Username == UserName && x.Password == Password && x.LastLoginTime == LastLoginTime && x.State == State && x.LastUpdateTime == LastUpdateDate && x.RecordState == RecordState && x.HType == HType).Select(z => z.CustomerId).SingleOrDefault();
                return UserId;
            }
        }
    }
}