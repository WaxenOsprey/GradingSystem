import React, { useState, useEffect } from "react";
import styled from "styled-components";
import Grade from "./Grade";

const GradesOverview = ({ selectedStudent }) => {
    const [student, setStudent] = useState(null);
  
    const fetchStudentGrades = async () => {
      try {
        const response = await fetch(`http://localhost:5122/api/grades/byStudent/${selectedStudent.studentId}`);
        const data = await response.json();
  
        const combinedData = {
          ...selectedStudent,
          grades: data,
        };
        setStudent(combinedData);
  
      } catch (error) {
        console.error("Error fetching student:", error);
      }
    }
  
    useEffect(() => {
      fetchStudentGrades();
    }, [selectedStudent]);
  
    return (
      <>
        <GradesOverviewContainer>
  
          <h2>Grades:</h2>
          {student && student.grades && student.grades.length > 0 ? (
            <ul>
              {student.grades.map((grade) => (
                <Grade key={grade.gradeId} grade={grade}></Grade>
              ))}
            </ul>
          ) : (
            <p>No grades available</p>
          )}
  
        </GradesOverviewContainer>
      </>
    );
  }
  
    const GradesOverviewContainer = styled.div`
        display: flex;
        flex-direction: column;
        border: 1px solid purple;
        margin: 10px;
        padding: 10px;
        width: 100%;
        align-items: center;
        justify-content: center;
    `;

export default GradesOverview;