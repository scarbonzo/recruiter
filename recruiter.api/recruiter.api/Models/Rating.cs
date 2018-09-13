using System;
using System.ComponentModel.DataAnnotations;

public class Rating
{
    [Key]
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public int Score { get; set; }
    public string Notes { get; set; }
}
