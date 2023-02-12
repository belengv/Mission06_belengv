using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_belengv.Models
{
    //Creating our variables
    public class ApplicationResponse
    {

        [Key] //This is the primary key
        [Required]
        public int EntryId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ushort Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; } //Not required
        public bool Edited { get; set; } //Not required
        public string LentTo { get; set; } //Not required
        [MaxLength (25)]
        public string Notes { get; set; } //Max 25 characteres

    }
}
