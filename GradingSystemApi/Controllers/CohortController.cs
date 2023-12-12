using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;
using System.Collections.Generic;
using System.Linq;

[Route("api/[cohorts]")]
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
    public ActionResult<Cohort> Put(int id, [FromBody] Cohort cohort)
    {
        if (id != cohort.cohortId) return BadRequest();

        _context.Entry(cohort).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(cohort);
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
