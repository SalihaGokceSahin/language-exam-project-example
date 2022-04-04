using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace language_exam.Models
{
    public class Exams
    {
        [Key]
        public int Id { get; set; }
        public int matchId { get; set; }
        public match match { get; set; }
        public string creator { get; set; }

        public string question_1_text { get; set; }
        public string answer_1_a_text { get; set; }
        public string answer_1_b_text { get; set; }
        public string answer_1_c_text { get; set; }
        public string answer_1_d_text { get; set; }
        public string correct_1_answer { get; set; }

        public string question_2_text { get; set; }
        public string answer_2_a_text { get; set; }
        public string answer_2_b_text { get; set; }
        public string answer_2_c_text { get; set; }
        public string answer_2_d_text { get; set; }
        public string correct_2_answer { get; set; }

        public string question_3_text { get; set; }
        public string answer_3_a_text { get; set; }
        public string answer_3_b_text { get; set; }
        public string answer_3_c_text { get; set; }
        public string answer_3_d_text { get; set; }
        public string correct_3_answer { get; set; }

        public string question_4_text { get; set; }
        public string answer_4_a_text { get; set; }
        public string answer_4_b_text { get; set; }
        public string answer_4_c_text { get; set; }
        public string answer_4_d_text { get; set; }
        public string correct_4_answer { get; set; }
        public DateTime created_date { get; set; }
    }
}
