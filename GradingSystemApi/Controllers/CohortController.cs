using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;
using GradingSystem.utils;

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
    public ActionResult<IEnumerable<Cohort>> Get()
    {
        var cohortsWithStudentsAndGrades = _context.Cohorts
            .Include(c => c.students)
                .ThenInclude(s => s.grades)  // Include the grades of each student
            .ToList();

        return Ok(cohortsWithStudentsAndGrades);
    }



    [HttpGet("{id}")] 
    public ActionResult<Cohort> Get(int id)
    {
        var cohort = _context.Cohorts.Find(id);
        return cohort != null ? Ok(cohort) : NotFound();
    }

    [HttpGet("average/{id}")]
    public ActionResult<double> GetAverage(int id)
    {
        var cohort = _context.Cohorts
            .Include(c => c.students)
                .ThenInclude(s => s.grades)  // Include the grades of each student
            .FirstOrDefault(c => c.cohortId == id);

        if (cohort == null) return NotFound("Cohort not found");

        return Ok(Grader.CohortAverage(cohort.students));
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
