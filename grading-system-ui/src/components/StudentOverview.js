import styled from "styled-components";
import { useState, useEffect } from "react";

const StudentOverview = ({ selectedStudent, setRefresh }) => {
  const [newGrade, setNewGrade] = useState(0);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewGrade(name === 'numberGrade' ? parseInt(value, 10) : value);
  };

  const handleAddGrade = async (e) => {
    e.preventDefault();
    console.log(newGrade);
    try {
      const response = await fetch(
        `http://localhost:5122/api/grades/?studentId=${selectedStudent.studentId}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            numberGrade: newGrade,
            letterGrade: "",
          }),
        });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      // Set the newGrade to 0 after successfully adding a grade
      setNewGrade(0);
        // Refresh the data after creating a new grade
        setRefresh((prev) => !prev);
    } catch (error) {
      console.error("Error adding grade:", error.message);
    }
  };

  return (
    <>
      <StudentOverviewContainer>
        {selectedStudent ? (
          <>
            <h1>{selectedStudent.name}</h1>
            <p>Student ID: {selectedStudent.studentId}</p>
            <p>Cohort ID: {selectedStudent.CohortId}</p>
            <GradeForm
              newGrade={newGrade}
              handleInputChange={handleInputChange}
              handleAddGrade={handleAddGrade}
            />
          </>
        ) : (
          <p>No student selected</p>
        )}
      </StudentOverviewContainer>
    </>
  );
};

const StudentOverviewContainer = styled.div`
  display: flex;
  flex-direction: column;
  border: 1px solid blue;
  margin: 10px;
  padding: 10px;
  width: 50%;
  align-items: center;
  justify-content: center;
`;

const GradeForm = ({ newGrade, handleInputChange, handleAddGrade }) => {
  return (
    <form onSubmit={handleAddGrade}>
      <label>
        Number Grade:
        <input
          type="number"
          name="numberGrade"
          value={newGrade}
          onChange={handleInputChange}
          required
        />
      </label>
      {/* Omit the studentId input since it's now part of the URL */}
      <button type="submit">Add Grade</button>
    </form>
  );
};

export default StudentOverview;
