using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
public class QuestionsController : ControllerBase
{
    private readonly RecruiterSqlContext _repository;

    public QuestionsController(RecruiterSqlContext repository)
    {
        _repository = repository;
    }

    // Get all Questions, supports paging
    [HttpGet]
    [Route("api/v1/[controller]")]
    public ActionResult GetAll(int take = 25, int skip = 0)
    {
        var query = _repository.Questions
            .Take(take)
            .Skip(skip);

        var results = query.ToList();

        return Ok(results);
    }

    // Get one Question from id
    [HttpGet]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult GetOne(Guid id)
    {
        var result = _repository.Questions
            .Find(id);

        if (result != null)
            return Ok(result);
        else
            return NotFound("Question does not exist!");
    }

    // Get Questions for position
    [HttpGet]
    [Route("api/v1/[controller]/position/{positionId}")]
    public ActionResult GetPositionQuestions(Guid positionId)
    {
        var query = _repository.Questions
            .Where(q => q.PositionId == positionId);

        var results = query.ToList();

        return Ok(results);
    }

    // Create a Question
    [HttpPost]
    [Route("api/v1/[controller]")]
    public ActionResult Create([FromBody] Question question)
    {
        var result = _repository.Questions
            .Find(question.Id);

        if (result == null)
        {
            _repository.Add(question);
            _repository.SaveChanges();
            return Ok(question.Id);
        }
        else
        {
            return BadRequest("Question already exists");
        }
    }

    // Update a Question
    [HttpPut]
    [Route("api/v1/[controller]")]
    public ActionResult Update([FromBody] Question question)
    {
        if (_repository.Questions.Contains(question))
        {
            question.Updated = DateTime.Now;
            _repository.Update(question);
            _repository.SaveChanges();
            return Ok(question.Id);
        }
        else
        {
            return BadRequest("Question does not exist");
        }
    }

    // Delete a Question from id
    [HttpDelete]
    [Route("api/v1/[controller]/{id}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Questions
            .Find(id);

        if (result != null)
        {
            _repository.Remove(result);
            _repository.SaveChanges();
            return Ok(result.Id);
        }
        else
        {
            return NotFound("Question does not exist!");
        }
    }

    // TESTING
    [HttpGet]
    [Route("api/v1/[controller]/create")]
    public ActionResult CreateQuestion()
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            PositionId = Guid.Parse("fca8ecef-89ed-4cb0-8084-b5aae15b30c4"),
            Text = "Network Administration Experience",
            Active = true,
            Created = DateTime.Now,
            Updated = null
        };

        try
        {
            _repository.Questions.Add(question);

            _repository.SaveChanges();

            return Created("Created Question: ", question.Id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }
}
