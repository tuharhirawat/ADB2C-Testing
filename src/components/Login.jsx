// src/components/Login.jsx
import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig";
import styled from "styled-components";

const Login = () => {
  const { instance } = useMsal();

  const handleLogin = async () => {
    try {
      await instance.loginRedirect(loginRequest);
    } catch (error) {
      if (error instanceof Error) {
        console.error("Login failed:", error.message);
      } else {
        console.error("Unknown error during login:", error);
      }
    }
  };

  return (
    <LoginBtn onClick={handleLogin}>Login with Azure AD B2C</LoginBtn>
  );
};

const LoginBtn = styled.button`
  background-color: #0078d4;
  color: #fff;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
  margin-top: 20px;
`;

export default Login;