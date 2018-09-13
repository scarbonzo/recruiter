using System;
using System.ComponentModel.DataAnnotations;

public class Position
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; }
    public string Project { get; set; }
    public string Notes { get; set; }
    public int Active { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime Closed { get; set; }
}
