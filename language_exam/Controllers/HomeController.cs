using HtmlAgilityPack;
using language_exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace language_exam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            var titles = new List<HtmlAgilityPack.HtmlNode>();

            var html = @"https://www.wired.com/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//div/div/main/div/div/section/div/div/div/div/div/div/div/a/h2")/*.First().InnerText*/.ToList();

            var node2 = htmlDoc.DocumentNode.SelectNodes("//div/div/main/div/div/section/div/div/div/div/div/div/div/a");
            List<match> match = new List<match>();

            foreach (var i in node)
            {
                titles.Add(i);
            }

            foreach (var item in node2)
            {
                foreach (var i in titles)
                {
                    if (item.OuterHtml.Contains(i.InnerHtml))
                    {
                        var exist_matches = db.Matches.ToList();
                        var last_match = exist_matches.LastOrDefault();

                        match m = new match();
                        var href_url = item.SelectSingleNode(".").Attributes["href"].Value;
                        //the below website for an example
                        var actual_url = "https://www.wired.com" + href_url;


                        m.outerHtml_href_for_link = actual_url;
                        m.title = i.InnerHtml;
                        m.creator = User.Identity.Name;

                        if (m.outerHtml_href_for_link != null)
                        {
                            HtmlWeb web2 = new HtmlWeb();
                            var htmlDoc2 = web2.Load(actual_url);
                            var node3 = htmlDoc2.DocumentNode.SelectNodes("//div/div/main/article/div/div/div/div/div/div/div/p");
                            if (node3 != null)
                            {
                                foreach (var t in node3)
                                {
                                    m.context = m.context + " \n " + t.InnerText;
                                }
                            }

                        }
                        match.Add(m);
                        try
                        {
                            db.Matches.Add(m);
                            //the below code must be in comment if website doesn't allows when you have to do scraping. I keep it open for an example
                            db.SaveChanges();

                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
            }
            return View(match);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Exams exam)
        {
            Exams question_for_fill = new Exams();
            question_for_fill.match = exam.match;
            question_for_fill.Id = exam.Id;
            question_for_fill.question_1_text = exam.question_1_text;
            question_for_fill.question_2_text = exam.question_2_text;
            question_for_fill.question_3_text = exam.question_3_text;
            question_for_fill.question_4_text = exam.question_4_text;
            question_for_fill.correct_1_answer = exam.correct_1_answer;
            question_for_fill.correct_2_answer = exam.correct_2_answer;
            question_for_fill.correct_3_answer = exam.correct_3_answer;
            question_for_fill.correct_4_answer = exam.correct_4_answer;
            question_for_fill.creator = User.Identity.Name;
            question_for_fill.answer_1_a_text = exam.answer_1_a_text;
            question_for_fill.answer_1_b_text = exam.answer_1_b_text;
            question_for_fill.answer_1_c_text = exam.answer_1_c_text;
            question_for_fill.answer_1_d_text = exam.answer_1_d_text;
            question_for_fill.answer_2_a_text = exam.answer_2_a_text;
            question_for_fill.answer_2_b_text = exam.answer_2_b_text;
            question_for_fill.answer_2_c_text = exam.answer_2_c_text;
            question_for_fill.answer_2_d_text = exam.answer_2_d_text;
            question_for_fill.answer_3_a_text = exam.answer_3_a_text;
            question_for_fill.answer_3_b_text = exam.answer_3_b_text;
            question_for_fill.answer_3_c_text = exam.answer_3_c_text;
            question_for_fill.answer_3_d_text = exam.answer_3_d_text;
            question_for_fill.answer_4_a_text = exam.answer_4_a_text;
            question_for_fill.answer_4_b_text = exam.answer_4_b_text;
            question_for_fill.answer_4_c_text = exam.answer_4_c_text;
            question_for_fill.answer_4_d_text = exam.answer_4_d_text;
            question_for_fill.matchId = exam.matchId;
            question_for_fill.created_date = DateTime.Now;
            db.Exams.Add(question_for_fill);
            db.SaveChanges();
            return RedirectToAction("examslist");

        }

        [HttpGet]
        public ActionResult ExamsList()
        {
            var user_name = User.Identity.Name;
            var exams_list = db.Exams.Where(x => x.creator == user_name).ToList();

            return View(exams_list);
        }
        //this is hard deletion and it is not acceptable normally. Because logging is important for our project always.
        //isActive, update_date, created_date, update_user, created_user datas important.
        //we create isActive field in table to show isActive=1 datas at other methods and when we delete data isActive must be 0.
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromBody] int Id)
        {
            var deletion = db.Exams.Find(Id);
            if (deletion == null)
            {
                return RedirectToAction("examslist");

            }
            db.Exams.Remove(deletion);
            db.SaveChanges();
            return RedirectToAction("examslist");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
