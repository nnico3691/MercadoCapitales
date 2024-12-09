import React from "react";
import NavBar from "../components/NavBar/NavBar";
import "animate.css";
import { Routes, Route } from "react-router-dom";
import Login from "./components/Login";

const AuthRoutes = () => {
  return (
    <div className="animate__animated animate__fadeIn animate__faster">
      <NavBar />
      <Routes>
        <Route path="/" element={<Login />} />
      </Routes>
    </div>
  );
};

export default AuthRoutes;
