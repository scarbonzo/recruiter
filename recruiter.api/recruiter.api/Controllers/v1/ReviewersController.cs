using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
public class ReviewersController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public ReviewersController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    // Get all Reviewers, supports paging
    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult GetAll(int take = 25, int skip = 0)
    {
        var query = _repository.Reviewers
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }

    // Get one Reviewer from id
    [HttpGet]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult GetOne(Guid id)
    {
        var result = _repository.Reviewers
            .Find(id);

        if (result != null)
            return Ok(result);
        else
            return NotFound("Reviewer does not exist!");
    }


    // Create a Reviewer
    [HttpPost]
    [Route("api/v1/[controller]")]
    public ActionResult Create([FromBody] Reviewer reviewer)
    {
        var result = _repository.Reviewers
            .Find(reviewer.Id);

        if (result == null)
        {
            _repository.Add(reviewer);
            _repository.SaveChanges();
            return Ok(reviewer.Id);
        }
        else
        {
            return BadRequest("Reviewer already exists");
        }
    }

    // Update a Reviewer
    [HttpPut]
    [Route("api/v1/[controller]")]
    public ActionResult Update([FromBody] Reviewer reviewer)
    {
        if (_repository.Reviewers.Contains(reviewer))
        {
            _repository.Update(reviewer);
            _repository.SaveChanges();
            return Ok(reviewer.Id);
        }
        else
        {
            return BadRequest("Reviewer does not exist");
        }
    }

    // Delete a Reviewer from id
    [HttpDelete]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Reviewers
            .Find(id);

        if (result != null)
        {
            _repository.Remove(result);
            _repository.SaveChanges();
            return Ok(result.Id);
        }
        else
        {
            return NotFound("Reviewer does not exist!");
        }
    }

    // TESTING
    [HttpGet]
    [Route("api/v1/[controller]/create")]
    public ActionResult CreateReviewer()
    {
        var reviewer = new Reviewer
        {
            Id = Guid.NewGuid(),
            Active = true,
            Name = "Richard Eodice",
            Created = DateTime.Now,
            Updated = null,
        };

        try
        {
            _repository.Reviewers.Add(reviewer);

            _repository.SaveChanges();

            return Created("Created Reviewer: ", reviewer.Id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }
}
