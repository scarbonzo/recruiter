using System;

public class Question
{
    public Guid Id { get; set; }
    public Guid PositionId { get; set; }

    public string Text { get; set; }
    public bool Active { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
