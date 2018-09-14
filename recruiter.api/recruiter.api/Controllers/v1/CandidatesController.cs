using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Produces("application/json")]
public class CandidatesController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public CandidatesController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("api/v1/[controller]/create")]
    public ActionResult CreateCandidate()
    {
        var candidate = new Candidate
        {
            Id = Guid.NewGuid(),
            FirstName = "Richard",
            MiddleName = "T.",
            LastName = "Eodice",
            Email = "reodice@lsnj.org",
            Phone = "7329215276",
            Salary = "Make me an offer I can't refuse...",
            Notes = "Just an average guy who does God-like things.",
            Available = true,
            Created = DateTime.Now
        };

        try
        {
            _repository.Candidates.Add(candidate);

            _repository.SaveChanges();

            return Created("Created Candidate: ", candidate.Id);
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }

    }

    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult Get(int take = 25, int skip = 0)
    {
        var query = _repository.Candidates
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }
}
