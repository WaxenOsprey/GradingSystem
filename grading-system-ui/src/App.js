import './App.css';
import CohortOverview from './components/CohortOverview';
import styled from 'styled-components';
import { useState , useEffect} from 'react';
import Student from './components/Student';
import StudentOverview from './components/StudentOverview';
import GradesOverview from './components/GradesOverview';

function App() {

  const [data, setData] = useState(null);
  const [selectedCohort, setSelectedCohort] = useState(null);
  const [selectedStudent, setSelectedStudent] = useState(null);

  const fetchData = async () => {
    try {
      const response = await fetch('http://localhost:5122/api/cohorts');
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      const data = await response.json();
      setData(data);
      console.log(data);
    } catch (error) {
      console.error('Error fetching data:', error.message);
    }
  };
  

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setSelectedCohort(selectedValue);
    console.log(selectedValue);
  };

  useEffect(() => {
    
    fetchData();
  }, []); 


  return (
    <>
      <MainWindow>
        <h1>GradingSystem</h1>
                <select onChange={handleSelectChange} value={selectedCohort}>
                  <option value="" disabled></option>
                    {data && data.map((item) => (
                      <option key={item.cohortId} value={item.cohortId}>
                        {item.name}
                      </option>
                  ))}
                </select>
          {selectedCohort && <p>Selected Cohort: {selectedCohort}</p>}
          {selectedStudent && <p>Selected Student: {selectedStudent.name}</p>}

          {/* <CohortOverview selectedCohort={selectedCohort}/> */}
      </MainWindow>
      <SecondRankContainer>
        <CohortOverview selectedCohort={selectedCohort} setSelectedStudent={setSelectedStudent}/>
        <StudentOverview selectedStudent={selectedStudent}/>
      </SecondRankContainer>
      <GradesOverview selectedStudent={selectedStudent}/>
    </>
  );

}


const MainWindow = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  border: solid 5px red;
`

const SecondRankContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-around;
`

export default App;
