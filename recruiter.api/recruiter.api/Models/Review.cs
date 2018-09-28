using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Review
{
    [Key]
    public Guid Id { get; set; }
    public Guid PositionId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid ReviewerId { get; set; }

    public bool Callback { get; set; }
    public List<Rating> Ratings { get; set; }
    public string Notes { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
