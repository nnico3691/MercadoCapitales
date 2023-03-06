import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import SignIn from "../components/Login/Login";
import Dashboard from "../components/Dashboard/Dashboard";

const AppRouter = () => {
  return (
    <BrowserRouter>
      <div className="App">
        <div>
          <Routes>
            <Route path="/*" element={<SignIn></SignIn>} />
            <Route path="/SignIn" element={<SignIn></SignIn>} />
            <Route path="/Dashboard" element={<Dashboard></Dashboard>} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  );
};

export default AppRouter;
