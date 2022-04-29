using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Nexos.Api.Domain
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public String Tittle { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public int NumberPages { get; set; }
        [Required]
        public int EditorialId { get; set; }        
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Editorial Editorial { get; set; }

    }
}
