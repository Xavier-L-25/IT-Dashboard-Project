import Dashboard from "./components/Dashboard";
import Tickets from "./components/tickets/Tickets";
import ActiveTicket from "./components/ActiveTicket";
import "./App.css";

function App() {
  return (
    <div className="flex">
      <div className="flex-2">
        <Dashboard />
        <ActiveTicket />
      </div>
      <Tickets />
    </div>
  );
}

export default App;
