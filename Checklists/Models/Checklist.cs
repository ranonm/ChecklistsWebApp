using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class Checklist
    {
        public Checklist()
        {
            DateAdded = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public bool IsDeleted { get; private set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}