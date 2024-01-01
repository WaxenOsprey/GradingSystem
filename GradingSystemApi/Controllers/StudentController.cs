using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;
using GradingSystem.utils;

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

    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get() => Ok(_context.Students.Include(s => s.Cohort).ToList());

 
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

    [HttpGet("average/{studentId}")]
    public ActionResult<double> GetAverage(int studentId)
    {
        var student = _context.Students.Include(s => s.grades).FirstOrDefault(s => s.studentId == studentId);

        if (student == null) return NotFound("Student not found");

        return Ok(Grader.GradeAverage(student.grades));
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
    public ActionResult<Student> Put(int id, [FromBody] Student updatedStudent)
    {
        if (id != updatedStudent.studentId)
        {
            return BadRequest("ID in the route does not match the ID in the request body");
        }

        var existingStudent = _context.Students.Include(s => s.Cohort).FirstOrDefault(s => s.studentId == id);

        if (existingStudent == null)
        {
            return NotFound();
        }

        existingStudent.name = updatedStudent.name;

        existingStudent.CohortId = updatedStudent.CohortId;

        _context.Entry(existingStudent).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(existingStudent);
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
