using System;
using System.ComponentModel.DataAnnotations;

namespace SuncoastOverflowApi.Models
{
  public class NewAnswer
  {
    [Required]
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public int VoteValue { get; set; } = 0;
  }
}