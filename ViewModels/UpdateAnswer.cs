using System;
using System.ComponentModel.DataAnnotations;

namespace SuncoastOverflowApi.Models
{
  public class UpdateAnswer
  {
    public int Id { get; set; }
    [Required]
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public int VoteValue { get; set; } = 0;
  }
}