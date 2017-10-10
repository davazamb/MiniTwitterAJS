using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class UserTweet
    {
        public int TweetId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ParentId { get; set; }   
        public string Username { get; set; }   
        public string Password { get; set; }     
        public string FirstName { get; set; }   
        public string LastName { get; set; }
    }
}
