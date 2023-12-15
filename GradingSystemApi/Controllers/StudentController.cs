using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;
using System.Collections.Generic;
using System.Linq;

[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly GradingSystemContext _context;

    public StudentController(GradingSystemContext context)
    {
        _context = context;
    }
    // GET: api/students
    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get() => Ok(_context.Students.Include(s => s.Cohort).ToList());

    // GET: api/students/{id}
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = _context.Students.Include(s => s.Cohort).FirstOrDefault(s => s.studentId == id);

        return student != null ? Ok(student) : NotFound();
    }

    [HttpGet("byCohort/{cohortId}")]
    public ActionResult<IEnumerable<Student>> GetByCohort(int cohortId)
    {
        var studentsInCohort = _context.Students
                                    .Where(student => student.CohortId == cohortId)
                                    .ToList();

        return Ok(studentsInCohort);
    }


[HttpPost]
public ActionResult<Student> Post([FromBody] Student student, [FromQuery] int cohortId)
{
    Console.WriteLine($"Cohort ID from query: {cohortId}");
    var cohort = _context.Cohorts.Find(cohortId);

    if (cohort == null) return NotFound("Cohort not found");

    student.CohortId = cohortId;
    
    cohort.students.Add(student);

    _context.Students.Add(student);
    _context.SaveChanges();

    return Ok(student);
}


    [HttpPut("{id}")]
    public ActionResult<Student> Put(int id, [FromBody] Student student)
    {
        if (id != student.studentId) return BadRequest();

        _context.Entry(student).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public ActionResult<Student> Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) return NotFound();

        _context.Students.Remove(student);
        _context.SaveChanges();
        return Ok(student);
    }
}
