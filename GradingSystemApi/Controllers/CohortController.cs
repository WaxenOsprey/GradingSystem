using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;

[Route("api/cohorts")]
[ApiController]
public class CohortController : ControllerBase
{
    private readonly GradingSystemContext _context;

    public CohortController(GradingSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cohort>> Get() => Ok(_context.Cohorts.ToList());

    [HttpGet("{id}")]
    public ActionResult<Cohort> Get(int id)
    {
        var cohort = _context.Cohorts.Find(id);
        return cohort != null ? Ok(cohort) : NotFound();
    }
    
    [HttpPost]
    public ActionResult<Cohort> Post([FromBody] Cohort cohort)
    {
        _context.Cohorts.Add(cohort);
        _context.SaveChanges();
        return Ok(cohort);
    }

[HttpPut("{id}")]
public ActionResult<Cohort> Put(int id, [FromBody] Cohort updatedCohort)
{
    if (id != updatedCohort.cohortId)
    {
        return BadRequest("ID in the route does not match the ID in the request body");
    }

    var existingCohort = _context.Cohorts.Find(id);
    if (existingCohort == null)
    {
        return NotFound();
    }

    existingCohort.name = updatedCohort.name;
    _context.Entry(existingCohort).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(existingCohort);
}


    [HttpDelete("{id}")]
    public ActionResult<Cohort> Delete(int id)
    {
        var cohort = _context.Cohorts.Find(id);
        if (cohort == null) return NotFound();

        _context.Cohorts.Remove(cohort);
        _context.SaveChanges();
        return Ok(cohort);
    }
}
