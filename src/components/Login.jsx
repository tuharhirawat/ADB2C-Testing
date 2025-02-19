// import React from "react";
// import { useMsal } from "@azure/msal-react";
// import { loginRequest } from "../authConfig";
// import styled from "styled-components";

// const Login = () => {
//   const { instance } = useMsal();

//   const handleLogin = async () => {
//     try {
//       await instance.loginRedirect(loginRequest);
//     } catch (error) {
//       if (error instanceof Error) {
//         console.error("Login failed:", error.message);
//       } else {
//         console.error("Unknown error during login:", error);
//       }
//     }
//   };

//   return (
//     <LoginBtn onClick={handleLogin}>Login with Azure AD B2C</LoginBtn>
//   );
// };

// const LoginBtn = styled.button`
//   background-color: #0078d4;
//   color: #fff;
//   padding: 10px 20px;
//   border-radius: 5px;
//   cursor: pointer;
//   font-size: 1rem;
//   margin-top: 20px;
// `;

// export default Login;













import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig";
import styled from "styled-components";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const { instance } = useMsal();
  const Navigate= useNavigate();

  const handleLogin = async () => {
    try {
      // Redirect-based login
      const response = await instance.loginPopup(loginRequest);
      console.log("Login Successful:", response);
      Navigate("/directworkorder");


      // Set the active account
      instance.setActiveAccount(response.account);

      // Fetch the access token
      await getAccessToken();
    } catch (error) {
      console.error("Login failed:", error);
    }
  };

  // const getAccessToken = async () => {
  //   try {
  //     const response = await instance.acquireTokenSilent(loginRequest);
  //     console.log("Access Token:", response.accessToken);
      
  //     if (!response.accessToken) {
  //       throw new Error("Access token is empty");
  //     }

  //     return response.accessToken;
  //   } catch (error) {
  //     console.error("Silent token acquisition failed, trying interactive login", error);
      
  //     try {
  //       const popupResponse = await instance.acquireTokenPopup(loginRequest);
  //       console.log("Access Token (Popup):", popupResponse.accessToken);
  //       return popupResponse.accessToken;
  //     } catch (popupError) {
  //       console.error("Popup login failed", popupError);
  //       return null;
  //     }
  //   }
  // };

  const getAccessToken = async () => {
    try {
      const response = await instance.acquireTokenSilent(loginRequest);
      console.log("Access Token:", response.accessToken);
      
      if (!response.accessToken) {
        throw new Error("Access token is empty");
      }
  
      return response.accessToken;
    } catch (error) {
      console.error("Silent token acquisition failed, trying interactive login", error);
  
      try {
        const popupResponse = await instance.acquireTokenPopup(loginRequest);
        console.log("Access Token (Popup):", popupResponse.accessToken);
        return popupResponse.accessToken;
      } catch (popupError) {
        console.error("Popup login failed", popupError);
        return null;
      }
    }
  };
  

  return <LoginBtn onClick={handleLogin}>Login with Azure AD B2C</LoginBtn>;
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
