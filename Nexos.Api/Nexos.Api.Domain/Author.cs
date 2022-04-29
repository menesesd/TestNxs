using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexos.Api.Domain
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public String FullName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public String CityOrigin { get; set; }
        [Required]
        public String Email { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
