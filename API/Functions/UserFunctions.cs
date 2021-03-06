﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Functions
{
    public class UserFunctions
    {              
        internal int GetUserIdByLogin(string username, string passsword)
        {
            using (UserTweetContext db = new UserTweetContext())
            {
                int userId = db.Users.Where(x => x.Username == username && x.Password == passsword)
                    .Select(s => s.Id).SingleOrDefault();
                return userId;
            }
        }
    }
}