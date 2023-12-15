import logo from './logo.svg';
import './App.css';
import styled from 'styled-components';
import { useState , useEffect} from 'react';

function App() {


  //declare state for data
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
  };

  useEffect(() => {
    // Fetch data when the component mounts
    fetchData();
  }, []); // Empty dependency array ensures the effect runs once when the component mounts


  return (
    <MainWindow>

      <h1>GradingSystem</h1>
          {/* Button to fetch data */}
          <button onClick={fetchData}>Fetch Data</button>
            {/* Display data from API */}
              <select onChange={handleSelectChange} value={selectedCohort}>
                <option value="" disabled>Select a Cohort</option>
                  {data && data.map((item) => (
                    <option key={item.cohortId} value={item.cohortId}>
                      {item.name}
                    </option>
                ))}
              </select>
            {/* Optionally display the selected cohort */}
        {selectedCohort && <p>Selected Cohort: {selectedCohort}</p>}

    </MainWindow>
  );

}

const MainWindow = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;`

export default App;
