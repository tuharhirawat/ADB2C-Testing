
import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
// import Home from "./pages/Home";
import Signup from "./pages/Signup";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import styled from "styled-components";
import { MsalProvider } from "@azure/msal-react";
import { msalInstance } from "./authConfig";

const Nav = styled.nav`
  background: #282c34;
  padding: 10px;
  display: flex;
  justify-content: space-around;
  a {
    color: white;
    text-decoration: none;
    font-size: 18px;
  }
`;

function App() {
  return (
    <MsalProvider instance={msalInstance}>    
    <Router>
      <Nav>
        <Link to="/">Home</Link>
        <Link to="/signup">Signup</Link>
        <Link to="/login">Login</Link>
        <Link to="/dashboard">Dashboard</Link>
      </Nav>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard" element={<Dashboard />} />
      </Routes>
    </Router>
    </MsalProvider>
  );
}

export default App;
