import {useState} from 'react'

const StudentAverage = ({selectedStudent}) => {

    const [average, setAverage] = useState(0);

    const fetchStudentAverage = async () => {
        try {
            const response = await fetch(`http://localhost:5122/api/students/average/${selectedStudent.studentId}`);
            const data = await response.json();
            setAverage(data);
        } catch (error) {
            console.error('Error fetching student average:', error);
        }
    }

    fetchStudentAverage();

    return ( 
        <>
            <h2>Average:</h2>
            <p>{average}</p>
        </>
     );
}
 
export default StudentAverage;