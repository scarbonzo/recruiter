using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
public class ReviewsController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public ReviewsController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    // Get all Reviews, supports paging
    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult GetAll(int take = 25, int skip = 0)
    {
        var query = _repository.Reviews
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }

    // Get one Review from id
    [HttpGet]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult GetOne(Guid id)
    {
        var result = _repository.Reviews
            .Find(id);

        if (result != null)
            return Ok(result);
        else
            return NotFound("Review does not exist!");
    }

    // Get Reviews for candidate
    [HttpGet]
    [Route("api/v1/[controller]/candidate/{candidateId}")]
    public ActionResult GetCandidateReviews(Guid candidateId)
    {
        var query = _repository.Reviews
            .Where(q => q.CandidateId == candidateId);

        var results = query.ToList();

        return Ok(results);
    }

    // Get Reviews for position
    [HttpGet]
    [Route("api/v1/[controller]/candidate/{positionId}")]
    public ActionResult GetPositionReviews(Guid positionId)
    {
        var query = _repository.Reviews
            .Where(q => q.PositionId == positionId);

        var results = query.ToList();

        return Ok(results);
    }

    // Create a Review
    [HttpPost]
    [Route("api/v1/[controller]")]
    public ActionResult Create([FromBody] Review review)
    {
        var result = _repository.Reviews
            .Find(review.Id);

        if (result == null)
        {
            _repository.Add(review);
            _repository.SaveChanges();
            return Ok(review.Id);
        }
        else
        {
            return BadRequest("Review already exists");
        }
    }

    // Update a Review
    [HttpPut]
    [Route("api/v1/[controller]")]
    public ActionResult Update([FromBody] Review review)
    {
        if (_repository.Reviews.Contains(review))
        {
            review.Updated = DateTime.Now;
            _repository.Update(review);
            _repository.SaveChanges();
            return Ok(review.Id);
        }
        else
        {
            return BadRequest("Review does not exist");
        }
    }

    // Delete a Review from id
    [HttpDelete]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Reviews
            .Find(id);

        if (result != null)
        {
            _repository.Remove(result);
            _repository.SaveChanges();
            return Ok(result.Id);
        }
        else
        {
            return NotFound("Review does not exist!");
        }
    }

    // TESTING
    [HttpGet]
    [Route("api/v1/[controller]/create")]
    public ActionResult CreateReview()
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            PositionId = Guid.Parse("fca8ecef-89ed-4cb0-8084-b5aae15b30c4"),
            
            Created = DateTime.Now,
            Updated = null
        };

        try
        {
            _repository.Reviews.Add(review);

            _repository.SaveChanges();

            return Created("Created Review: ", review.Id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }
}
