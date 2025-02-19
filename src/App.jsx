
// import React from "react";
// import styled from "styled-components";
// import Login from "./components/Login";
// import Logout from "./components/Logout";
// import { useMsal } from "@azure/msal-react";
// import SecureData from "./SecureData";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   justify-content: center;
//   height: 100vh;
//   background-color: #121212;
//   color: #fff;
//   font-family: Arial, sans-serif;
// `;

// const Heading = styled.h1`
//   font-size: 2rem;
//   margin-bottom: 20px;
// `;

// const UserInfo = styled.div`
//   text-align: center;
//   margin-top: 20px;
//   padding: 20px;
//   background: #1e1e1e;
//   border-radius: 10px;
//   box-shadow: 0px 4px 10px rgba(255, 255, 255, 0.1);
// `;

// const App = () => {
//   const { accounts } = useMsal();
//   console.log(accounts);

//   return (
//     <Container>
//       <Heading>Azure AD B2C Authentication</Heading>
//       {accounts.length > 0 ? (
//         <UserInfo>
//           <h2>Welcome, {accounts[0].name}</h2>
//           {/* <h4>{accounts[0].username}</h4> */}
//           <h2>{accounts[0].idTokenClaims.family_name}</h2>
//           <h2>{accounts[0].idTokenClaims.given_name}</h2>
//           <Logout />
//           {/* <SecureData /> */}
//         </UserInfo>
//       ) : (
//         <Login />
//       )}
//     </Container>
//   );
// };

// export default App;





// import React, { useEffect, useState } from "react";
// import styled from "styled-components";
// import Login from "./components/Login";
// import Logout from "./components/Logout";
// import { useMsal } from "@azure/msal-react";
// import { loginRequest } from "./authConfig";

// const App = () => {
//   const { instance, accounts } = useMsal();
//   const [accessToken, setAccessToken] = useState("");

//   useEffect(() => {
//     if (accounts.length > 0) {
//       instance
//         .acquireTokenSilent({
//           ...loginRequest,
//           account: accounts[0],
//         })
//         .then((response) => {
//           console.log("Access Token:", response.accessToken);
//           setAccessToken(response.accessToken);
//         })
//         .catch((error) => {
//           console.error("Error acquiring token:", error);
//           if (error.name === "InteractionRequiredAuthError") {
//             instance.acquireTokenRedirect(loginRequest);
//           }
//         });
//     }
//   }, [accounts, instance]);

//   return (
//     <Container>
//       <Heading>Azure AD B2C Authentication</Heading>
//       {accounts.length > 0 ? (
//         <UserInfo>
//           <h2>Welcome, {accounts[0].name}</h2>
//           <h4>Email: {accounts[0].username}</h4>
//           <h4>First Name: {accounts[0].idTokenClaims.given_name}</h4>
//           <h4>Last Name: {accounts[0].idTokenClaims.family_name}</h4>

//           <h4>Access Token:</h4>
//           <TokenTextArea readOnly value={accessToken} rows="6" cols="50" />

//           <Logout />
//         </UserInfo>
//       ) : (
//         <Login />
//       )}
//     </Container>
//   );
// };

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   justify-content: center;
//   height: 100vh;
//   background-color: #121212;
//   color: #fff;
//   font-family: Arial, sans-serif;
// `;

// const Heading = styled.h1`
//   font-size: 2rem;
//   margin-bottom: 20px;
// `;

// const UserInfo = styled.div`
//   text-align: center;
//   margin-top: 20px;
//   padding: 20px;
//   background: #1e1e1e;
//   border-radius: 10px;
//   box-shadow: 0px 4px 10px rgba(255, 255, 255, 0.1);
// `;

// const TokenTextArea = styled.textarea`
//   width: 90%;
//   max-width: 500px;
//   background-color: #333;
//   color: #fff;
//   border: 1px solid #555;
//   padding: 10px;
//   border-radius: 5px;
// `;

// export default App;

















// import React, { useState, useEffect } from "react";
// import styled from "styled-components";
// import Login from "./components/Login";
// import Logout from "./components/Logout";
// import { useMsal } from "@azure/msal-react";
// import { loginRequest } from "./authConfig";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   justify-content: center;
//   height: 100vh;
//   background-color: #121212;
//   color: #fff;
//   font-family: Arial, sans-serif;
// `;

// const Heading = styled.h1`
//   font-size: 2rem;
//   margin-bottom: 20px;
// `;

// const UserInfo = styled.div`
//   text-align: center;
//   margin-top: 20px;
//   padding: 20px;
//   background: #1e1e1e;
//   border-radius: 10px;
//   box-shadow: 0px 4px 10px rgba(255, 255, 255, 0.1);
// `;

// const TokenBox = styled.textarea`
//   width: 80%;
//   height: 100px;
//   margin-top: 20px;
//   background: #222;
//   color: #fff;
//   padding: 10px;
//   border: none;
//   border-radius: 5px;
//   font-size: 0.9rem;
// `;

// const App = () => {
//   const { instance, accounts } = useMsal();
//   const [accessToken, setAccessToken] = useState("");

//   useEffect(() => {

//     if (accounts.length === 0) {
//       console.error("No accounts found. User might not be logged in.");
//       return;
//     }

//     if (accounts.length > 0) {
//       // Set the active account
//       instance.setActiveAccount(accounts[0]);

//       instance
//         .acquireTokenSilent({
//           ...loginRequest,
//           account: accounts[0], // Ensure account is passed
//         })
//         .then((response) => {
//           console.log("Access Token:", response.accessToken);
//           setAccessToken(response.accessToken);
//         })
//         .catch((error) => {
//           console.error("Error acquiring token:", error);
//         });
//     }
//   }, [accounts, instance]);

//   return (
//     <Container>
//       <Heading>Azure AD B2C Authentication</Heading>
//       {accounts.length > 0 ? (
//         <UserInfo>
//           <h2>Welcome, {accounts[0].name}</h2>
//           <h3>{accounts[0].username}</h3>
//           <h3>{accounts[0].idTokenClaims.family_name}</h3>
//           <h3>{accounts[0].idTokenClaims.given_name}</h3>
//           <Logout />
//           <h3>Access Token:</h3>
//           <TokenBox readOnly value={accessToken} />
//         </UserInfo>
//       ) : (
//         <Login />
//       )}
//     </Container>
//   );
// };

// export default App;














import { useEffect, useState } from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";
import styled from "styled-components";
import Login from "./components/Login";
import Logout from "./components/Logout";

const App = () => {
  const { instance, accounts } = useMsal();
  const [accessToken, setAccessToken] = useState("");

  useEffect(() => {
    if (accounts.length > 0) {
      // Set the active account before acquiring token
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

export default App;
