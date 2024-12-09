import React, { createContext } from "react";

export const LoginContext = createContext();

export const LoginProvider = (props) => {
  const handleLogin = (idUsuario, token) => {
    localStorage.setItem("idUsuario", idUsuario);
    localStorage.setItem("token", token);
  };

  return (
    <LoginContext.Provider value={{ handleLogin }}>
      {props.children}
    </LoginContext.Provider>
  );
};
