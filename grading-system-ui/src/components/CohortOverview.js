import React, { useState, useEffect } from "react";
const CohortOverview = ({selectedCohort}) => {

    const [data, setData] = useState(null);

    const fetchData = async () => {
      const response = await fetch(`http://localhost:5122/api/students/byCohort/${selectedCohort}`);
      const data = await response.json();
      setData(data);
      // console.log("in CohortOverview" + data);
    }

    useEffect(() => {
      fetchData();
    }, [selectedCohort]); 

    return ( 
      <>
      <h1>Students</h1>
      <div>
        {data && data.map((item) => (
          <p key={item.studentId}>{item.name}</p>
        ))} 
      </div>
      </>
    );
}
 
export default CohortOverview;