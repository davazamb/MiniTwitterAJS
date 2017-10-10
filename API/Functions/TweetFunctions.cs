using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace API.Functions
{
    public class TweetFunctions
    {
        private UserTweetContext db = new UserTweetContext();

        public IQueryable<UserTweet> GetAllMainTweets()
        {
            //Se hace join para integrar datos para dar uso a esta viewmodel
            var data = from t in db.Tweets
                       join u in db.Users on t.UserId equals u.Id
                       where t.ParentId == null
                       select new UserTweet
                       {
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Content = t.Content,
                           CreateDate = t.CreateDate,
                           TweetId = t.Id,
                           Type = t.Type,
                           UpdateDate = t.UpdateDate,
                           UserId = t.UserId,
                           Username = u.Username,                               

                       };
            return data;
        }

        public IQueryable<UserTweet> GetAllComments(int id)
        {
            //Se hace join para integrar datos para dar uso a esta viewmodel
            var data = from t in db.Tweets
                       join u in db.Users on t.UserId equals u.Id
                       where t.ParentId == id
                       select new UserTweet
                       {
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Content = t.Content,
                           CreateDate = t.CreateDate,
                           TweetId = t.Id,
                           Type = t.Type,
                           UpdateDate = t.UpdateDate,
                           UserId = t.UserId,
                           Username = u.Username,

                       };
            return data;
        }

        public void CreateTweet(Tweet tweet)
        {
            if(tweet == null)
            {
                throw new NotImplementedException("Tweet not initializaed");

            }
            else
            {
                tweet.CreateDate = DateTime.Now;
                db.Tweets.Add(tweet);
                db.SaveChanges();
            }
        }

        public UserTweet GetTweetById(int id)
        {
            //Se hace join para integrar datos para dar uso a esta viewmodel
            var data = from t in db.Tweets
                       join u in db.Users on t.UserId equals u.Id
                       where t.ParentId == null && t.Id == id
                       select new UserTweet
                       {
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Content = t.Content,
                           CreateDate = t.CreateDate,
                           TweetId = t.Id,
                           Type = t.Type,
                           UpdateDate = t.UpdateDate,
                           UserId = t.UserId,
                           Username = u.Username,

                       };
            return data.SingleOrDefault();
        }

        public void DeleteTweet(int tweetId, int userId)
        {
            var tweetComments = db.Tweets.Where(t => t.ParentId == tweetId).ToList();
            if(tweetComments.Count > 0)
            {
                for (int i = 0; i < tweetComments.Count; i++)
                {
                    db.Tweets.Remove(tweetComments[i]);
                }
                db.SaveChanges();
                 //Borrar 2 id de  la tabla
                var tweetEntity = db.Tweets.Where(t => t.Id == tweetId && t.UserId == userId).SingleOrDefault();
                db.Tweets.Remove(tweetEntity);
                db.SaveChanges();
            }
        }

        public bool EditTweet(Tweet tweet)
        {
            db.Entry(tweet).State = EntityState.Modified; 
            db.SaveChanges();
            return true;
            
        }
    }
}