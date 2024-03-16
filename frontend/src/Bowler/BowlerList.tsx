// This component renders a list of bowlers fetched from a backend API.

// Import React hooks and types
import { useEffect, useState } from "react";
import { Bowler } from "../types/Bowler";

// Define the BowlerList component
function BowlerList() {
  // Define state to hold bowler data
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  // Fetch bowler data from the backend API on component mount
  useEffect(() => {
    const fetchBowlerData = async () => {
      const rsp = await fetch("http://localhost:5045/bowler");
      const f = await rsp.json();
      setBowlerData(f);
    };

    fetchBowlerData();
  }, []);

  // Render the component
  return (
    <>
      {/* Heading */}
      <div className="row">
        <h3 className="text-center">IS Core Bowling League Participants</h3>
      </div>
      {/* Table to display bowler information */}
      <table className="table table-bordered">
        {/* Table header */}
        <thead>
          <tr>
            <th>First Name</th>
            <th>Middle Initial</th>
            <th>Last Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zipcode</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        {/* Table body */}
        <tbody>
          {/* Map over bowler data and render each row */}
          {bowlerData.map((f) => (
            <tr key={f.bowlerId}>
              <td>{f.bowlerFirstName}</td>
              <td>{f.bowlerLastName}</td>
              <td>{f.bowlerMiddleInit}</td>
              <td>{f.teamName}</td>
              <td>{f.bowlerAddress}</td>
              <td>{f.bowlerCity}</td>
              <td>{f.bowlerState}</td>
              <td>{f.bowlerZip}</td>
              <td>{f.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

// Export the BowlerList component
export default BowlerList;
