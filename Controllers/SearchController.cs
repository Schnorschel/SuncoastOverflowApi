using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncoastOverflowApi.Models;

namespace SuncoastOverflowApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class SearchController : ControllerBase
  {
    [HttpGet("{searchFor}")]
    public ActionResult GetSearchResults(string searchFor)
    {
      var db = new DatabaseContext();
      // return Ok(new { searchTerm = $"{searchFor}" });
      // var searchResults = db.Questions.Include(q => q.Answers) // .OrderByDescending(q => q.LastModifiedDateTime) // , q => q.Answers.AnswerText.ToLower().Contains(searchFor.ToLower())
      // .Where(q => q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
      //             q.QuestionText.ToLower().Contains(searchFor.ToLower())
      // //   || q.Answers.AnswerText.ToLower().Contains(searchFor.ToLower())
      // );

      // var searchResults = (from q in db.Questions
      //                      join a in db.Answers on q.Id equals a.QuestionId
      //                      where q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
      //                            q.QuestionText.ToLower().Contains(searchFor.ToLower()) ||
      //                            a.AnswerText.ToLower().Contains(searchFor.ToLower())
      //                      select q).Distinct().Include(q => q.Answers);

      // var searchResults = (from q in db.Questions
      //                      join a in db.Answers on q.Id equals a.QuestionId
      //                      where q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
      //                            q.QuestionText.ToLower().Contains(searchFor.ToLower()) ||
      //                            a.AnswerText.ToLower().Contains(searchFor.ToLower())
      //                      select q); //.Distinct();


      // var searchResults = (from q in db.Questions.Include(i => i.Answers)
      //                      where q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
      //                            q.QuestionText.ToLower().Contains(searchFor.ToLower()) ||
      //                            q.Answers.Any(a => a.AnswerText.ToLower().Contains(searchFor.ToLower()))
      //                      select new { Title = q.QuestionTitle, Id = q.Id, NumberOfAnswers = q.Answers.Count }); //.Distinct();

      var searchResults = (from q in db.Questions.Include(i => i.Answers)
                           where q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
                                 q.QuestionText.ToLower().Contains(searchFor.ToLower()) ||
<<<<<<< HEAD
                                 a.AnswerText.ToLower().Contains(searchFor.ToLower())
                           select q).Distinct(); //why do we need to put distinct to prevent duplicate results ?
=======
                                 q.Answers.Any(a => a.AnswerText.ToLower().Contains(searchFor.ToLower()))
                           select q); //.Distinct();
>>>>>>> 4700f751cd462a8818b2739a24fd64609e0aeddd


      return Ok(searchResults);
    }
  }
}