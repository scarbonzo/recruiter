using System;
using System.ComponentModel.DataAnnotations;

public class Reviewer
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public int Active { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
