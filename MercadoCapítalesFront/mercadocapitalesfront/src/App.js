import logo from "./logo.svg";
import "./App.css";
import Login from "./components/Login";
import { LoginProvider } from "./components/Context/LoginContext";

function App() {
  return (
    <div className="App">
      <LoginProvider></LoginProvider>
      <Login></Login>
    </div>
  );
}

export default App;
