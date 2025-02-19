
// import React from "react";
// import styled from "styled-components";
// import Login from "./components/Login";
// import Logout from "./components/Logout";
// import { useMsal } from "@azure/msal-react";
// import SecureData from "./SecureData";

import AppRouter from "./Routes/AppRouter";

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














const App = () => {
  return (<>
  
  <AppRouter />

  </>);
}

export default App;