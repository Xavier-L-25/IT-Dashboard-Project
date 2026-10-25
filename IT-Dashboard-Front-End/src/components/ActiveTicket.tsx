function ActiveTicket() {
  return (
    <div className="m-2 p-2 card">
      <h1>Active Ticket</h1>
      <div className="my-2 p-2 card-light">
        <p>Priority: Critical</p>
        <p>Status: Closed</p>
        <p>Subject: Wifi down in classroom 12</p>
        <p>
          Description: Lorem, ipsum dolor sit amet consectetur adipisicing elit.
          Aliquam cupiditate in delectus aspernatur voluptas, nam laboriosam,
          quibusdam nobis praesentium facere vero ratione quaerat accusantium
          tempore. Veniam accusamus autem asperiores inventore!
        </p>
        <div className="w-fit mx-auto">
          <button className="m-2 p-2 card-light shadow-sm">Next Step</button>
        </div>
      </div>
    </div>
  );
}

export default ActiveTicket;
