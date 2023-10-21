using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._10_ASP_CLASSLIBRARY.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Note()
        {
            Id = 0;
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
