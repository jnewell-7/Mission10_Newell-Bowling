import { useEffect, useState } from 'react';
import { bowler } from './types/bowler';
import { team } from './types/team';

function BowlingList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);
  const [teams, setTeams] = useState<team[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const [bowlersResponse, teamsResponse] = await Promise.all([
        fetch('https://localhost:5000/BowlingLeague'),
        fetch('https://localhost:5000/Teams'),
      ]);

      const bowlersData = await bowlersResponse.json();
      const teamsData = await teamsResponse.json();

      setBowlers(bowlersData);
      setTeams(teamsData);
    };

    fetchData();
  }, []);

  const getTeamName = (teamid?: number) => {
    if (!teamid) return 'Unknown Team';
    return teams.find((t) => t.teamId === teamid)?.teamName || 'Unknown Team';
  };

  return (
    <>

      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}{' '}
              </td>
              <td>{getTeamName(b.teamId)}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlingList;
