import './App.css';
import CohortOverview from './components/CohortOverview';
import styled from 'styled-components';
import { useState, useEffect } from 'react';
import StudentOverview from './components/StudentOverview';
import GradesOverview from './components/GradesOverview';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUsers, faPlus } from '@fortawesome/free-solid-svg-icons';

function App() {
  const [data, setData] = useState(null);
  const [selectedCohort, setSelectedCohort] = useState(null);
  const [selectedStudent, setSelectedStudent] = useState(null);
  const [newCohortName, setNewCohortName] = useState('');
  const [refresh, setRefresh] = useState(false);
  const [showInput, setShowInput] = useState(false);


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
  }, [refresh]);

  return (
    <>
           <MainWindow>
        <h1>GradingSystem</h1>
        <CohortsContainer>
          {data &&
            data.map((item) => (
              <CohortItem key={item.cohortId} onClick={() => setSelectedCohort(item.cohortId)}>
                <StyledIcon icon={faUsers} isSelected={selectedCohort === item.cohortId} />
                <p>{item.name}</p>
              </CohortItem>
            ))}
          {/* Toggle input box */}
          <CohortItem onClick={() => setShowInput(!showInput)}>
            <StyledIcon icon={faPlus} isSelected={showInput} />
            <p>Add Cohort</p>
          </CohortItem>
        </CohortsContainer>

        {/* New Cohort Form */}
        {showInput && (
          <form onSubmit={handleNewCohortSubmit}>
            <label>
              <input
                type="text"
                value={newCohortName}
                onChange={(e) => setNewCohortName(e.target.value)}
                required
              />
            </label>
            <button type="submit">Create Cohort</button>
          </form>
        )}
      </MainWindow>
      <SecondRankContainer>
        <CohortOverview selectedCohort={selectedCohort} setSelectedStudent={setSelectedStudent} selectedStudent={selectedStudent} />
      </SecondRankContainer>
      <StudentOverview selectedStudent={selectedStudent} setRefresh={setRefresh} refresh={refresh} />
    </>
  );
}

const MainWindow = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

const CohortsContainer = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
`;

const SecondRankContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-around;
`;

const CohortItem = styled.div`
  display: flex;
  align-items: center;
  cursor: pointer;

  &:hover {
    background-color: lightgray;
  }

  p {
    margin: 0;
  }
`;

const StyledIcon = styled(FontAwesomeIcon)`
  color: ${(props) => (props.isSelected ? 'blue' : 'green')};
  margin-right: 10px;
  font-size: 4rem;
  margin-left: 10px;
  padding: 10px;
`;

export default App;
