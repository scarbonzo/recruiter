using System;

public class Reviewer
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public bool Active { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
