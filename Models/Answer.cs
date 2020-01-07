using System;

namespace SuncoastOverflowApi.Models
{
  public class Answer
  {
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public int VoteValue { get; set; } = 0;
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;

    public Question Question { get; set; }
  }
}