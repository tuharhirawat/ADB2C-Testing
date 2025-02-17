// src/components/Logout.jsx
import React from "react";
import { useMsal } from "@azure/msal-react";

const Logout = () => {
  const { instance } = useMsal();

  const handleLogout = () => {
    instance.logoutRedirect();
  };

  return <button onClick={handleLogout}>Logout</button>;
};

export default Logout;