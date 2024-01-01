import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import styled from 'styled-components';



const Student = ({student, onClick, selectedStudent}) => {
    const handleClick = () => {
        onClick(student);
    }
    return (
        <>
        <StyledIcon icon={faUser} onClick={handleClick} isSelected={selectedStudent === student} />
        <p>{student.name}</p>
      </>
     );
}

const StyledIcon = styled(FontAwesomeIcon)`
    color: ${props => props.isSelected ? "blue" : "green"};
    margin: 10px;
    padding: 10px;
    font-size: 4rem;
    cursor: pointer;

`;
 
export default Student;