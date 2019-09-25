using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class UserBook
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
