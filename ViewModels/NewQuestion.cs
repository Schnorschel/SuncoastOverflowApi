using System;

namespace SuncoastOverflowApi.ViewModels
{
  public class NewQuestion
  {
    public string QuestionTitle { get; set; }
    public string QuestionText { get; set; }
    public int VoteValue { get; set; }
  }
}