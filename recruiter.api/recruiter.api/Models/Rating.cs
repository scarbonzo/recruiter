using System;

public class Rating
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public int Score { get; set; }
    public string Notes { get; set; }
}
