import React, { useState, useEffect } from "react";
import styled from 'styled-components';
import Student from './Student';

const CohortOverview = ({ selectedCohort, setSelectedStudent }) => {
  const [cohort, setCohort] = useState(null);

  const fetchCohort = async () => {
    try {
      const cohortResponse = await fetch(`http://localhost:5122/api/cohorts/${selectedCohort}`);
      const cohortData = await cohortResponse.json();

      const studentsResponse = await fetch(`http://localhost:5122/api/students/byCohort/${selectedCohort}`);
      const studentsData = await studentsResponse.json();

      const combinedData = {
        ...cohortData,
        students: studentsData
      };
      setCohort(combinedData);
    } catch (error) {
      console.error("Error fetching cohort:", error);
    }
  }

  const handleStudentClick = (selectedStudent) => {
    setSelectedStudent(selectedStudent);
  };

  useEffect(() => {
    fetchCohort();
  }, [selectedCohort]);

  return (
    <CohortOverviewContainer>
      {cohort ? (
        <>
          <h1>Students in {cohort && cohort.name}</h1>
          <div>
            {Array.isArray(cohort.students) ? (
              cohort.students.map((item) => (
                <Student key={item.studentId} student={item} onClick={handleStudentClick}/>
              ))
            ) : (
              <p>No students data available</p>
            )}
          </div>
        </>
      ) : (
        <p>No cohort selected</p>
      )}
    </CohortOverviewContainer>
  );
};

const CohortOverviewContainer = styled.div`
  display: flex;
  flex-direction: column;
  border: 1px solid green;
  margin: 10px;
  padding: 10px;
  width: 50%;
  align-items: center;
  justify-content: center;
`;

export default CohortOverview;
