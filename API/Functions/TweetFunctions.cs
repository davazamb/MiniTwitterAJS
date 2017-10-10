using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Functions
{
    public class TweetFunctions
    {
        private UserTweetContext db = new UserTweetContext();

        public IQueryable<UserTweet> GetAllTweets()
        {
            //Se hace join para integrar datos para dar uso a esta viewmodel
            var data = from t in db.Tweets
                       join
                 u in db.Users on t.UserId equals u.Id
                       select new UserTweet
                       {
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Content = t.Content,
                           CreateDate = t.CreateDate,
                           ParentId = t.ParentId,
                           Password = u.Password,
                           TweetId = t.Id,
                           Type = t.Type,
                           UpdateDate = t.UpdateDate,
                           UserId = t.UserId,
                           Username = u.Username,                               

                       };
            return data;
        }
    }
}