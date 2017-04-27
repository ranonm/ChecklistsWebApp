using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            DateAdded = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public bool Checked { get; set; }

        public DateTime DateAdded { get; set; }

        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }

        public void Check()
        {
            if (!Checked)
                Checked = true;
        }

        public void Uncheck()
        {
            if (Checked)
                Checked = false;
        }
    }
}