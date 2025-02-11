import React from "react";
import styled from "styled-components";

const Container = styled.div`
  text-align: center;
  padding: 50px;
`;

function Dashboard() {
  return (
    <Container>
      <h1>Dashboard</h1>
      <p>Welcome! You are logged in.</p>
    </Container>
  );
}

export default Dashboard;
