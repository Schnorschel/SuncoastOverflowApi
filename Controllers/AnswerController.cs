using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncoastOverflowApi.Models;

namespace SuncoastOverflowApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class AnswerController : ControllerBase
  {
    [HttpGet("{id}")]
    public ActionResult GetOneAnswer(int id)
    {
      var db = new DatabaseContext();
      var answer = db.Answers.FirstOrDefault(a => a.Id == id);
      if (answer == null)
      {
        return NotFound();
      }
      else
      {
        return Ok();
      }
    }

    [HttpPost]
    public ActionResult CreateAnswer(Answer answer)
    {
      var db = new DatabaseContext();
      answer.Id = 0;
      db.Answers.Add(answer);
      db.SaveChanges();
      return Ok(answer);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateAnswer(Answer answer)
    {
      var db = new DatabaseContext();
      var prevAnswer = db.Answers.FirstOrDefault(a => a.Id == answer.Id);
      {
        if (prevAnswer == null)
        {
          return NotFound();
        }
        else
        {
          prevAnswer.QuestionId = answer.QuestionId;
          prevAnswer.AnswerText = answer.AnswerText;
          prevAnswer.VoteValue = answer.VoteValue;
          prevAnswer.LastModifiedDateTime = DateTime.UtcNow;
          db.SaveChanges();
          return Ok(prevAnswer);
        }
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnswer(int id)
    {
      var db = new DatabaseContext();
      var answer = db.Answers.FirstOrDefault(a => a.Id == id);
      if (answer == null)
      {
        return NotFound();
      }
      else
      {
        db.Answers.Remove(answer);
        db.SaveChanges();
        return Ok();
      }
    }
  }

}