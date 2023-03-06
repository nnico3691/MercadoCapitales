import "./App.css";
import AppRouter from "./router/AppRouter";
import { LoginProvider } from "./Context/LoginContext";

function App() {
  return (
    <div className="App">
      <LoginProvider>
        <AppRouter></AppRouter>
      </LoginProvider>
    </div>
  );
}

export default App;
