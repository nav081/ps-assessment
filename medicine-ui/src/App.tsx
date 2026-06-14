import React, { useState } from "react";
import MedicineList from "./components/MedicineList";
import AddMedicine from "./components/AddMedicine";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const App: React.FC = () => {
  const [reload, setReload] = useState(false);

  return (
    <>
      <h1 style={{ textAlign: "center" }}>ABC Pharmacy</h1>

      <AddMedicine onSuccess={() => setReload(!reload)} />
      <MedicineList reload={reload} />

      <ToastContainer position="top-right" />
    </>
  );
};

export default App;