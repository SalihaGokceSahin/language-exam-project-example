using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace language_exam.Models
{
    public class match
    {
        [Key]
        public int Id { get; set; }
        public string outerHtml_href_for_link { get; set; }
        public string title { get; set; }
        public string context { get; set; }
        public string creator { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Exams> Exams { get; set; }

    }
}
