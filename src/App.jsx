
import React from "react";
import Login from "./components/Login";
import Logout from "./components/Logout";
import { useMsal } from "@azure/msal-react";

const App = () => {
  const { accounts } = useMsal();
  console.log(accounts)

  return (
    <div>
      <h1>Azure AD B2C Authentication</h1>
      {accounts.length > 0 ? (
        <>
        {/* console.log(accounts) */}
          <h2>Welcome, {accounts[0].name}</h2>
          <h4>{accounts[0].username}</h4>
          <Logout />
        </>
      ) : (
        <Login />
      )}
    </div>
  );
};

export default App;
