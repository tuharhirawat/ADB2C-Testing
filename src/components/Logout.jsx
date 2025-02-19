import React from "react";
import { useMsal } from "@azure/msal-react";
import styled from "styled-components";

const Logout = () => {
  const { instance } = useMsal();

  const handleLogout = () => {
    instance.logoutRedirect();
  };

  return <LogoutBtn onClick={handleLogout}>Logout</LogoutBtn>;
};

const LogoutBtn = styled.button`
  background-color: #ff0000;
  color: #fff;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
  margin-top: 20px;
`;

export default Logout;

