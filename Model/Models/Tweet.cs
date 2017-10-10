using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int ParentId { get; set; }
        public User User { get; set; }

    }
}
