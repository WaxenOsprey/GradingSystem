import styled from "styled-components";
import { useState, useEffect } from "react";
const StudentOverview = ({selectedStudent}) => {

    return ( 
        <>
        <StudentOverviewContainer>
        
            {selectedStudent ? (
                <>
                    <h1>{selectedStudent.name}</h1>
                    <p>Student ID: {selectedStudent.studentId}</p>
                    <p>Cohort ID: {selectedStudent.CohortId}</p>
                </>
            ) : (
                <p>No student selected</p>
            )}
        </StudentOverviewContainer>
        </>
     );
}

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

 
export default StudentOverview;