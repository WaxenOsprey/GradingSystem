using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradingSystem.data;
using GradingSystem.models;
using System.Collections.Generic;
using System.Linq;

[Route("api/grades")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly GradingSystemContext _context;

    public GradeController(GradingSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Grade>> Get() => Ok(_context.Grades.Include(g => g.Student).ToList());

    [HttpGet("{id}")]
    public ActionResult<Grade> Get(int id)
    {
        var grade = _context.Grades.Include(g => g.Student).FirstOrDefault(g => g.gradeId == id);

        return grade != null ? Ok(grade) : NotFound();
    }

    [HttpGet("byStudent/{studentId}")]
    public ActionResult<IEnumerable<Grade>> GetByStudent(int studentId)
    {
        var gradesForStudent = _context.Grades
                                    .Where(grade => grade.StudentId == studentId)
                                    .ToList();
    
        return Ok(gradesForStudent);
    }


    [HttpPost]
    public ActionResult<Grade> Post([FromBody] Grade grade, [FromQuery] int studentId)
    {
        var student = _context.Students.Find(studentId);

        if (student == null) return NotFound("Student not found");

        grade.StudentId = studentId;

        student.grades.Add(grade); 

        _context.Grades.Add(grade);
        _context.SaveChanges();

        return Ok(grade);
    }

    [HttpPut("{id}")]
    public ActionResult<Grade> Put(int id, [FromBody] Grade updatedGrade)
    {
        if (id != updatedGrade.gradeId)
        {
            return BadRequest("ID in the route does not match the ID in the request body");
        }

        var existingGrade = _context.Grades.Find(id);
        if (existingGrade == null)
        {
            return NotFound();
        }

        existingGrade.numberGrade = updatedGrade.numberGrade;
        existingGrade.letterGrade = updatedGrade.letterGrade;
        existingGrade.StudentId = updatedGrade.StudentId;

        _context.Entry(existingGrade).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(existingGrade);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var grade = _context.Grades.Find(id);

        if (grade == null) return NotFound();

        _context.Grades.Remove(grade);
        _context.SaveChanges();

        return NoContent();
    }
}
