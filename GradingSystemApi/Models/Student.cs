using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GradingSystem.models;
using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        public string name { get; set; }

        public List<Grade> grades { get; set; } = new List<Grade>();

        public int CohortId { get; set; }
        [JsonIgnore]
        public Cohort? Cohort { get; set; }

        public Student(string name, int CohortId)
        {
            this.name = name;
            this.CohortId = CohortId;
        }



    }
}
