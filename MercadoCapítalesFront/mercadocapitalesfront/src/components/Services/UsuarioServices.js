import axios from "./axiosServices";

export function registrar(usuario) {
  return axios.post("Usuario/", usuario);
}

export function login(usuario) {
  return axios.post("/Login", usuario, {
    headers: {
      "Content-Type": "application/json",
    },
  });
}
