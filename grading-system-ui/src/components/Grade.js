import React from "react";
import styled from "styled-components";

const GradeDisplay = ({ grade }) => {
  const getColor = (letterGrade) => {
    switch (letterGrade) {
      case 'A':
        return 'green';
      case 'B':
        return 'blue';
      case 'C':
        return 'yellow';
      case 'D':
        return 'orange';
      case 'F':
        return 'red';
      default:
        return 'gray';
    }
  };

  return (
    <GradeContainer>
      <GradeInfo>
        <p>{grade.numberGrade}%</p>
        <p><span style={{ color: getColor(grade.letterGrade) }}>{grade.letterGrade}</span></p>
      </GradeInfo>
      <PercentageBar style={{ width: `${grade.numberGrade}%`, backgroundColor: getColor(grade.letterGrade) }}></PercentageBar>
    </GradeContainer>
  );
};

const GradeContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: start;
  border: 1px solid black;
  margin: 10px;
  padding: 10px; 
  width: 500px;
`;

const PercentageBar = styled.div`
  height: 20px;
  border-radius: 5px;
  margin-bottom: 10px;

`;

const GradeInfo = styled.div`
  text-align: center;

  p {
    margin: 0;
  }

  span {
    font-weight: bold;
  }
`;

export default GradeDisplay;
