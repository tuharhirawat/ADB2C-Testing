import { useEffect, useState } from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig";
import styled from "styled-components";
import Login from "../Components/Login";
import Logout from "../Components/Logout";

const Login_Logout = () => {
  const { instance, accounts } = useMsal();
  const [accessToken, setAccessToken] = useState("");

  useEffect(() => {
    if (accounts.length > 0) {
      instance.setActiveAccount(accounts[0]);

      instance
        .acquireTokenSilent({
          ...loginRequest,
          account: accounts[0],
        })
        .then((response) => {
          console.log("Access Token Response:", response);
          setAccessToken(response.accessToken);
          console.log("Scopes Granted:", response.scopes);
        })
        .catch((error) => {
          console.error("Error acquiring token:", error);
        });
    }
  }, [accounts, instance]);

  return (
    <Container>
      <Heading>Azure AD B2C Authentication</Heading>
      {accounts.length > 0 ? (
        <UserInfo>
          <h2>Welcome, {accounts[0].username}</h2>
          <h4>Access Token:</h4>
          <TokenTextArea readOnly value={accessToken} rows="4" cols="50" />
          <Logout />
        </UserInfo>
      ) : (
        <Login />
      )}
    </Container>
  );
};

const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background-color: #121212;
  color: #fff;
  font-family: Arial, sans-serif;
`;

const TokenTextArea = styled.textarea`
  width: 90%;
  max-width: 500px;
  background-color: #333;
  color: #fff;
  border: 1px solid #555;
  padding: 10px;
  border-radius: 5px;
`;

const Heading = styled.h1`
  font-size: 2rem;
  margin-bottom: 20px;
`;

const UserInfo = styled.div`
  text-align: center;
  margin-top: 20px;
  padding: 20px;
  background: #1e1e1e;
  border-radius: 10px;
  box-shadow: 0px 4px 10px rgba(255, 255, 255, 0.1);
`;

export default Login_Logout;
