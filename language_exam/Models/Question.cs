using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace language_exam.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int matchId { get; set; }
        public match match { get; set; }
        public string question_text { get; set; }
        public string answer_a_text { get; set; }
        public string answer_b_text { get; set; }
        public string answer_c_text { get; set; }
        public string answer_d_text { get; set; }
        public string correct_answer { get; set; }
        public string creator { get; set; }

    }
}
