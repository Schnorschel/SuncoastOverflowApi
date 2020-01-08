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
        return Ok(answer);
      }
    }

    // [HttpPost]
    // public ActionResult CreateAnswer(Answer answer)
    // {
    //   var db = new DatabaseContext();
    //   answer.Id = 0;
    //   db.Answers.Add(answer);
    //   db.SaveChanges();
    //   return Ok(answer);
    // }

    [HttpPost]
    public ActionResult CreateAnswer(NewAnswer newAnswer)
    {
      var db = new DatabaseContext();
      var prevQuestion = db.Questions.FirstOrDefault(q => q.Id == newAnswer.QuestionId);
      if (prevQuestion == null)
      {
        return NotFound(new { error = "No question with QuestionId " + newAnswer.QuestionId + " found." });
      }
      var answer = new Answer
      {
        QuestionId = newAnswer.QuestionId,
        AnswerText = newAnswer.AnswerText,
        VoteValue = newAnswer.VoteValue
      };
      db.Answers.Add(answer);
      db.SaveChanges();
      return Ok(answer);
    }

    // [HttpPut("{id}")]
    // public ActionResult UpdateAnswer(Answer answer)
    // {
    //   var db = new DatabaseContext();
    //   var prevAnswer = db.Answers.FirstOrDefault(a => a.Id == answer.Id);
    //   {
    //     if (prevAnswer == null)
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       prevAnswer.QuestionId = answer.QuestionId;
    //       prevAnswer.AnswerText = answer.AnswerText;
    //       prevAnswer.VoteValue = answer.VoteValue;
    //       prevAnswer.LastModifiedDateTime = DateTime.UtcNow;
    //       db.SaveChanges();
    //       return Ok(prevAnswer);
    //     }
    //   }
    // }

    [HttpPut("{id}")]
    public ActionResult UpdateAnswer(int id, UpdateAnswer updateAnswer)
    {
      var db = new DatabaseContext();
      var prevAnswer = db.Answers.FirstOrDefault(a => a.Id == updateAnswer.Id);
      if (prevAnswer == null)
      {
        return NotFound(new { error = "No answer with Id" + updateAnswer.Id + " found." });
      }
      else
      if (db.Questions.FirstOrDefault(q => q.Id == updateAnswer.QuestionId) == null)
      {
        return NotFound(new { error = "No question with QuestionId " + updateAnswer.QuestionId + " found." });
      }
      else

        if (updateAnswer.Id != id)
      {
        return NotFound(new { error = $"Endpoint Id ({id}) and object Id ({updateAnswer.Id}) differ." });
      }

      else
      {
        prevAnswer.QuestionId = updateAnswer.QuestionId;
        prevAnswer.AnswerText = updateAnswer.AnswerText;
        prevAnswer.VoteValue = updateAnswer.VoteValue;
        prevAnswer.LastModifiedDateTime = DateTime.UtcNow;
        db.SaveChanges();
        return Ok(prevAnswer);
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