import logo from './logo.svg';
import './App.css';
import CohortOverview from './components/CohortOverview';
import styled from 'styled-components';
import { useState , useEffect} from 'react';

function App() {

  const [data, setData] = useState(null);
  const [selectedCohort, setSelectedCohort] = useState(null);

  const fetchData = async () => {
    const response = await fetch('http://localhost:5122/api/cohorts');
    const data = await response.json();
    setData(data);
    console.log(data);
  }

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setSelectedCohort(selectedValue);
    console.log(selectedValue);
  };

  useEffect(() => {
    
    fetchData();
  }, []); 


  return (
    <MainWindow>
      <h1>GradingSystem (NO MORE CODING UNTIL LEARN ABOUT CODE AND INHERITANCE ETC.)</h1>
              <select onChange={handleSelectChange} value={selectedCohort}>
                <option value="" disabled>Select a Cohort</option>
                  {data && data.map((item) => (
                    <option key={item.cohortId} value={item.cohortId}>
                      {item.name}
                    </option>
                ))}
              </select>
        {selectedCohort && <p>Selected Cohort: {selectedCohort}</p>}

        <CohortOverview selectedCohort={selectedCohort}/>



    </MainWindow>
  );

}

// const CohortOverview = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   justify-content: center;
//   border: solid 1px black;
//   border-radius: 5px;
//   width: 50%;
//   margin: 10px;
//   padding: 10px;
// `


const MainWindow = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  border: solid 5px red;
`

export default App;
