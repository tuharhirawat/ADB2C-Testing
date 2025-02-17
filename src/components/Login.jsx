// src/components/Login.jsx
import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig";

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
    <button onClick={handleLogin}>Login with Azure AD B2C</button>
  );
};

export default Login;