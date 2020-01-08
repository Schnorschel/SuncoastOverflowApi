using System;

namespace SuncoastOverflowApi.ViewModels
{
  public class UpdateQuestion
  {
    public int Id { get; set; }
    public string QuestionTitle { get; set; }
    public string QuestionText { get; set; }
    public int VoteValue { get; set; }
  }
}