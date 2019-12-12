using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAppFinal.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Heading { get; set; }

        public string Content { get; set; }

        public int categoryId { get; set; }

        public int? userId { get; set; }
    }
}
