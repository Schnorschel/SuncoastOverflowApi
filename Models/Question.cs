using System.Collections.Generic;
using System;

namespace SuncoastOverflowApi.Models
{
  public class Question
  {
    public int Id { get; set; }
    public string QuestionTitle { get; set; }
    public string QuestionText { get; set; }
    public int VoteValue { get; set; } = 0;
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;

    public List<Answer> Answers { get; set; } = new List<Answer>();

  }
}