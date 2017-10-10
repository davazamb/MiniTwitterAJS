using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model.Models;
using API.Functions;

namespace API.Controllers
{
    public class TweetsController : ApiController
    {
        private TweetFunctions _tweet = new TweetFunctions();

        // GET: api/Tweets
        [HttpGet]
        [Route("api/tweets")]
        public IQueryable<UserTweet> GetMainTweets()
        {
            return _tweet.GetAllMainTweets();
        }

        [HttpGet]
        [Route("api/tweets/comments/{id}")]
        public IHttpActionResult GetComments(int id)
        {
            var tweets = _tweet.GetAllComments(id);
            if(tweets.Count() == 0)
            {
                return NotFound();
            }
            return Ok(tweets);
        }

        // GET: api/Tweets/5
        [HttpGet]
        [Route("api/tweets/{id}")]
        public IHttpActionResult GetTweet(int id)
        {
            var tweet = _tweet.GetTweetById(id);
            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        [HttpPost]
        [Route("api/tweets/create")]
        public HttpResponseMessage Create(Tweet tweet)
        {
            if(string.IsNullOrWhiteSpace(tweet.Content))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Tweet cannot be empty");
            }
            else
            {
                try
                {
                    var tweetFunction = new TweetFunctions();
                    tweetFunction.CreateTweet(tweet);
                    var mesg = Request.CreateResponse(HttpStatusCode.Created);
                    mesg.Headers.Location = new Uri(Request.RequestUri + tweet.Id.ToString());

                    return mesg;
                }
                catch (Exception)
                {                                 
                    throw new Exception("Error!!");
                }
            }                   

        }

        [HttpPost]
        [Route("api/tweets/edit/{id}")]
         public IHttpActionResult Edit(int id, Tweet tweet)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != tweet.Id)
            {
                return BadRequest();
            }

            tweet.UpdateDate = DateTime.Now;
            var tweetUpdate = new TweetFunctions();
            var result = tweetUpdate.EditTweet(tweet);

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int tweetId, int userId)
        {
            var tweet = _tweet.GetTweetById(tweetId);
            if(tweet == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _tweet.DeleteTweet(tweetId, userId);
                    return Ok(tweet);

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            

        }

        //// PUT: api/Tweets/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTweet(int id, Tweet tweet)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tweet.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tweet).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TweetExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Tweets
        //[ResponseType(typeof(Tweet))]
        //public IHttpActionResult PostTweet(Tweet tweet)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tweets.Add(tweet);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tweet.Id }, tweet);
        //}

        //// DELETE: api/Tweets/5
        //[ResponseType(typeof(Tweet))]
        //public IHttpActionResult DeleteTweet(int id)
        //{
        //    Tweet tweet = db.Tweets.Find(id);
        //    if (tweet == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Tweets.Remove(tweet);
        //    db.SaveChanges();

        //    return Ok(tweet);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TweetExists(int id)
        //{
        //    return db.Tweets.Count(e => e.Id == id) > 0;
        //}
    }
}