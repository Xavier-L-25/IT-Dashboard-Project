import Ticket from "./Ticket";

function Tickets() {
  return (
    <div className="flex-1 m-2 p-2 card">
      <h1>Tickets</h1>
      <label htmlFor="priority">Filter by Priority:</label>
      <select
        id="priority"
        className="mx-2 p-1 card-light shadow-sm rounded-lg"
      >
        <option>Critical</option>
        <option>High</option>
        <option>Medium</option>
        <option>Low</option>
      </select>
      <Ticket />
    </div>
  );
}

export default Tickets;
