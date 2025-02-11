import React from "react";
import styled from "styled-components";

const Container = styled.div`
  text-align: center;
  padding: 50px;
`;

function Home() {
  return (
    <Container>
      <h1>Welcome to My Web App</h1>
      <p>This is the home page of the application.</p>
    </Container>
  );
}

export default Home;
