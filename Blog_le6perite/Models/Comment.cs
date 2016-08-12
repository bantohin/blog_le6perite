using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_le6perite.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
        
        public int PostId { get; set;}

        public virtual Post Post { get; set; }
    }
}