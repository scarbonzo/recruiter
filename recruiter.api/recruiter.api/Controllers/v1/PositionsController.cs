using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
public class PositionsController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public PositionsController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    // Get all Positions, supports paging
    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult GetAll(int take = 25, int skip = 0)
    {
        var query = _repository.Positions
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }

    // Get one Position from id
    [HttpGet]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult GetOne(Guid id)
    {
        var result = _repository.Positions
            .Find(id);

        if (result != null)
            return Ok(result);
        else
            return NotFound("Position does not exist!");
    }


    // Create a Position
    [HttpPost]
    [Route("api/v1/[controller]")]
    public ActionResult Create([FromBody] Position position)
    {
        var result = _repository.Positions
            .Find(position.Id);

        if (result == null)
        {
            _repository.Add(position);
            _repository.SaveChanges();
            return Ok(position.Id);
        }
        else
        {
            return BadRequest("Position already exists");
        }
    }

    // Update a Position
    [HttpPut]
    [Route("api/v1/[controller]")]
    public ActionResult Update([FromBody] Position position)
    {
        if (_repository.Positions.Contains(position))
        {
            position.Updated = DateTime.Now;
            _repository.Update(position);
            _repository.SaveChanges();
            return Ok(position.Id);
        }
        else
        {
            return BadRequest("Position does not exist");
        }
    }

    // Delete a Position from id
    [HttpDelete]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Positions
            .Find(id);

        if (result != null)
        {
            _repository.Remove(result);
            _repository.SaveChanges();
            return Ok(result.Id);
        }
        else
        {
            return NotFound("Position does not exist!");
        }
    }

    // TESTING
    [HttpGet]
    [Route("api/v1/[controller]/create")]
    public ActionResult CreatePosition()
    {
        var position = new Position
        {
            Id = Guid.NewGuid(),
            Project = "Tech",
            Title = "Network Administrator",
            Active = true,
            Notes = "Replacing Dharmesh",
            Created = DateTime.Now,
            Updated = null,
            Closed = null
        };

        try
        {
            _repository.Positions.Add(position);

            _repository.SaveChanges();

            return Created("Created Position: ", position.Id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }
}
