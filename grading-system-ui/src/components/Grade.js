import React, { useState } from "react";
import styled from "styled-components";
import { CircularProgressbar, buildStyles } from "react-circular-progressbar";
import "react-circular-progressbar/dist/styles.css";

const GradeDisplay = ({ grade }) => {
  const [displayMode, setDisplayMode] = useState("number");

  const toggleDisplayMode = () => {
    setDisplayMode((prevMode) => (prevMode === "number" ? "letter" : "number"));
  };

  const getTextValue = () => {
    return displayMode === "number" ? `${grade.numberGrade}%` : grade.letterGrade;
  };

  const getColor = (letterGrade) => {
    switch (letterGrade) {
      case 'A':
        return 'blue';
      case 'B':
        return 'green';
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
    <GradeContainer onClick={toggleDisplayMode}>
      <CircularProgressBarContainer>
        <CircularProgressbar
          value={grade.numberGrade}
          text={getTextValue()}
          styles={buildStyles({
            textColor: getColor(grade.letterGrade),
            pathColor: getColor(grade.letterGrade),
          })}
        />
      </CircularProgressBarContainer>
    </GradeContainer>
  );
};

const GradeContainer = styled.div`
  display: flex;
  align-items: start; 
  margin: 10px;
  padding: 10px;
  cursor: pointer;
`;

const CircularProgressBarContainer = styled.div`
    width: 50px;
`;

export default GradeDisplay;
