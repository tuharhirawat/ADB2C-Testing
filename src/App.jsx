
// import React from "react";
// import Login from "./components/Login";
// import Logout from "./components/Logout";
// import { useMsal } from "@azure/msal-react";

// const App = () => {
//   const { accounts } = useMsal();
//   console.log(accounts)

//   return (
//     <div>
//       <h1>Azure AD B2C Authentication</h1>
//       {accounts.length > 0 ? (
//         <>
//         {/* console.log(accounts) */}
//           <h2>Welcome, {accounts[0].name}</h2>
//           <h4>{accounts[0].username}</h4>
//           <Logout />
//         </>
//       ) : (
//         <Login />
//       )}
//     </div>
//   );
// };

// export default App;




import React from "react";
import styled from "styled-components";
import Login from "./components/Login";
import Logout from "./components/Logout";
import { useMsal } from "@azure/msal-react";

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

const App = () => {
  const { accounts } = useMsal();
  console.log(accounts);

  return (
    <Container>
      <Heading>Azure AD B2C Authentication</Heading>
      {accounts.length > 0 ? (
        <UserInfo>
          <h2>Welcome, {accounts[0].name}</h2>
          {/* <h4>{accounts[0].username}</h4> */}
          <h2>{accounts[0].idTokenClaims.family_name}</h2>
          <h2>{accounts[0].idTokenClaims.given_name}</h2>
          <Logout />
        </UserInfo>
      ) : (
        <Login />
      )}
    </Container>
  );
};

export default App;
