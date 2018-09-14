using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
public class CandidatesController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public CandidatesController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    // Get all candidates, supports paging
    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult GetAll(int take = 25, int skip = 0)
    {
        var query = _repository.Candidates
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }

    // Get one candidate from id
    [HttpGet]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult GetOne(Guid id)
    {
        var result = _repository.Candidates
            .Find(id);

        if (result != null)
            return Ok(result);
        else
            return NotFound("Candidate does not exist!");
    }

    
    // Create a candidate
    [HttpPost]
    [Route("api/v1/[controller]")]
    public ActionResult Create([FromBody] Candidate candidate)
    {
        var result = _repository.Candidates
            .Find(candidate.Id);

        if (result == null)
        {
            _repository.Add(candidate);
            _repository.SaveChanges();
            return Ok(candidate.Id);
        }
        else
        {
            return BadRequest("Candidate already exists");
        }
    }

    // Update a candidate
    [HttpPut]
    [Route("api/v1/[controller]")]
    public ActionResult Update([FromBody] Candidate candidate)
    {
        if (_repository.Candidates.Contains(candidate))
        {
            candidate.Updated = DateTime.Now;
            _repository.Update(candidate);
            _repository.SaveChanges();
            return Ok(candidate.Id);
        }
        else
        {
            return BadRequest("Candidate does not exist");
        }
    }

    // Delete a candidate from id
    [HttpDelete]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Candidates
            .Find(id);

        if (result != null)
        {
            _repository.Remove(result);
            _repository.SaveChanges();
            return Ok(result.Id);
        }
        else
        {
            return NotFound("Candidate does not exist!");
        }
    }

    // TESTING
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
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }
}
