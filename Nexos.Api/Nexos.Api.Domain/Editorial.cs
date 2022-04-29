using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Nexos.Api.Domain
{
    public class Editorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public String Name { get; set; }
        [Required]
        public String AddressCorrespondence { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [DefaultValue(-1)]
        public int MaximumBook  { get; set; } = -1;
        public ICollection<Book> Books { get; set; }

    }
}
