using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncoastOverflowApi.Models;
using SuncoastOverflowApi.ViewModels;

namespace SuncoastOverflowApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class QuestionController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllQuestions()
    {
      var db = new DatabaseContext();
      // return Ok(db.Questions.OrderByDescending(q => q.LastModifiedDateTime)); // only show question objects, not associated answer objects
      return Ok(db.Questions.Include(q => q.Answers).OrderByDescending(q => q.LastModifiedDateTime));
    }

    [HttpGet("{id}")]
    public ActionResult GetOneQuestion(int id)
    {
      var db = new DatabaseContext();
      var question = db.Questions.Include(i => i.Answers).FirstOrDefault(q => q.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(question);
      }
    }

    // [HttpPost]
    // public ActionResult CreateQuestion(Question question)
    // {
    //   var db = new DatabaseContext();
    //   question.Id = 0;
    //   db.Questions.Add(question);
    //   db.SaveChanges();
    //   return Ok(question);
    // }

    [HttpPost]
    public ActionResult CreateQuestion(NewQuestion newQuestion)
    {
      var db = new DatabaseContext();
      var question = new Question
      {
        QuestionTitle = newQuestion.QuestionTitle,
        QuestionText = newQuestion.QuestionText,
        VoteValue = newQuestion.VoteValue
      };
      db.Questions.Add(question);
      db.SaveChanges();
      return Ok(question);
    }

    // [HttpPut("{id}")]
    // public ActionResult UpdateQuestion(Question question)
    // {
    //   var db = new DatabaseContext();
    //   var prevQuestion = db.Questions.FirstOrDefault(q => q.Id == question.Id);
    //   if (prevQuestion == null)
    //   {
    //     return NotFound();
    //   }
    //   else
    //   {
    //     prevQuestion.QuestionTitle = question.QuestionTitle;
    //     prevQuestion.QuestionText = question.QuestionText;
    //     prevQuestion.VoteValue = question.VoteValue;
    //     prevQuestion.LastModifiedDateTime = DateTime.UtcNow;
    //     db.SaveChanges();
    //     return Ok(prevQuestion);
    //   }
    // }

    [HttpPut("{id}")]
    public ActionResult UpdateQuestion(int id, UpdateQuestion updateQuestion)
    {
      var db = new DatabaseContext();
      var prevQuestion = db.Questions.FirstOrDefault(q => q.Id == updateQuestion.Id);
      if (prevQuestion == null)
      {
        return NotFound();
      }
      else if (updateQuestion.Id != id)
      {
        return BadRequest(new { error = $"Endpoint Id ({id}) and object Id ({updateQuestion.Id}) differ." });
      }
      else
      {
        prevQuestion.QuestionTitle = updateQuestion.QuestionTitle;
        prevQuestion.QuestionText = updateQuestion.QuestionText;
        prevQuestion.VoteValue = updateQuestion.VoteValue;
        prevQuestion.LastModifiedDateTime = DateTime.UtcNow;
        db.SaveChanges();
        return Ok(prevQuestion);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteQuestion(int id)
    {
      var db = new DatabaseContext();
      var question = db.Questions.FirstOrDefault(q => q.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        db.Answers.RemoveRange(db.Answers.Where(a => a.QuestionId == id));
        db.Questions.Remove(question);
        db.SaveChanges();
        return Ok();
      }

    }
  }
}