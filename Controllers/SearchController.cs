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

      var searchResults = (from q in db.Questions
                           join a in db.Answers on q.Id equals a.QuestionId
                           where q.QuestionTitle.ToLower().Contains(searchFor.ToLower()) ||
                                 q.QuestionText.ToLower().Contains(searchFor.ToLower()) ||
                                 a.AnswerText.ToLower().Contains(searchFor.ToLower())
                           select q).Distinct(); //why do we need to put distinct to prevent duplicate results ?


      return Ok(searchResults);
    }
  }
}