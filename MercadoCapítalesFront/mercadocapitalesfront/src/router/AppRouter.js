import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import SignIn from "../components/Login/Login";
import Dashboard from "../components/Dashboard/Dashboard";
import Wallet from "../components/Wallet/Wallet";
import Orders from "../components/Orders/Orders";
import Movements from "../components/Movements/Movements";

const AppRouter = () => {
  return (
    <BrowserRouter>
      <div className="App">
        <div>
          <Routes>
            <Route path="/*" element={<SignIn></SignIn>} />
            <Route path="/SignIn" element={<SignIn></SignIn>} />
            <Route path="/Dashboard" element={<Dashboard></Dashboard>} />
            <Route path="/Wallet" element={<Wallet></Wallet>} />
            <Route path="/Orders" element={<Orders></Orders>} />
            <Route path="/Movements" element={<Movements></Movements>} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  );
};

export default AppRouter;
