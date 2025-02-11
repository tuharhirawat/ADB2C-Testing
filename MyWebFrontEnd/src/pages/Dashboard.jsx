// import React from "react";
// import styled from "styled-components";

// const Container = styled.div`
//   text-align: center;
//   padding: 50px;
// `;

// function Dashboard() {
//   return (
//     <Container>
//       <h1>Dashboard</h1>
//       <p>Welcome! You are logged in.</p>
//     </Container>
//   );
// }

// export default Dashboard;






import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";

const Container = styled.div`
  text-align: center;
  padding: 50px;
`;

const Button = styled.button`
  padding: 10px;
  background: #dc3545;
  color: white;
  border: none;
  cursor: pointer;
  margin-top: 20px;
`;

function Dashboard() {
  const navigate = useNavigate();

  // useEffect(() => {
  //   const token = localStorage.getItem("token");
  //   if (!token) {
  //     alert("Please login first.");
  //     navigate("/login");
  //   }
  // }, [navigate]);


  useEffect(() => {
    const isAuthenticated = localStorage.getItem("isAuthenticated");
    if (!isAuthenticated) {
      alert("Please login first.");
      navigate("/login");
    }
  }, [navigate]);
  
  const handleLogout = () => {
    localStorage.removeItem("isAuthenticated"); // Remove authentication flag
    navigate("/login");
  };
  
  return (
    <Container>
      <h1>Dashboard</h1>
      <p>Welcome! You are logged in.</p>
      <Button onClick={handleLogout}>Logout</Button>
    </Container>
  );
}

export default Dashboard;
