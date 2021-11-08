using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePrj.Models
{
    public class Post
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string Id { get; set; }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; } // we save it in Deltas format (subset of JSON, specific for the Quill WYSIWYG editor)

    }
}
