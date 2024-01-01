import './App.css';
import CohortOverview from './components/CohortOverview';
import styled from 'styled-components';
import { useState, useEffect } from 'react';
import StudentOverview from './components/StudentOverview';
import GradesOverview from './components/GradesOverview';

function App() {
  const [data, setData] = useState(null);
  const [selectedCohort, setSelectedCohort] = useState(null);
  const [selectedStudent, setSelectedStudent] = useState(null);
  const [newCohortName, setNewCohortName] = useState('');
  const [refresh, setRefresh] = useState(false);

  const fetchData = async () => {
    try {
      const response = await fetch('http://localhost:5122/api/cohorts');
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      const data = await response.json();
      setData(data);
    } catch (error) {
      console.error('Error fetching data:', error.message);
    }
  };

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setSelectedCohort(selectedValue);
  };

  const handleNewCohortSubmit = async (event) => {
    event.preventDefault();

    try {
      const response = await fetch('http://localhost:5122/api/cohorts', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name: newCohortName,
        }),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      // Refresh the data after creating a new cohort
      fetchData();
    } catch (error) {
      console.error('Error creating new cohort:', error.message);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  useEffect(() => {
    console.log('refreshing data' + refresh);
  } , [refresh]);

  return (
    <>
      <MainWindow>
        <h1>GradingSystem</h1>
        <select onChange={handleSelectChange} value={selectedCohort}>
          <option value="" disabled></option>
          {data &&
            data.map((item) => (
              <option key={item.cohortId} value={item.cohortId}>
                {item.name}
              </option>
            ))}
        </select>
        {selectedCohort && <p>Selected Cohort: {selectedCohort}</p>}
        {selectedStudent && <p>Selected Student: {selectedStudent.name}</p>}

        {/* New Cohort Form */}
        <form onSubmit={handleNewCohortSubmit}>
          <label>
            New Cohort Name:
            <input
              type="text"
              value={newCohortName}
              onChange={(e) => setNewCohortName(e.target.value)}
              required
            />
          </label>
          <button type="submit">Create Cohort</button>
        </form>
      </MainWindow>
      <SecondRankContainer>
        <CohortOverview selectedCohort={selectedCohort} setSelectedStudent={setSelectedStudent} />
        <StudentOverview selectedStudent={selectedStudent} setRefresh={setRefresh} />
      </SecondRankContainer>
      <GradesOverview selectedStudent={selectedStudent} refresh={refresh} />
    </>
  );
}

const MainWindow = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  border: solid 5px red;
`;

const SecondRankContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-around;
`;

export default App;
