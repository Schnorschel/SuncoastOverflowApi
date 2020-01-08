using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuncoastOverflowApi.Models
{
  public class Answer
  {
    public int Id { get; set; }
    [Required]
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public int VoteValue { get; set; } = 0;
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public Question Question { get; set; }
  }
}