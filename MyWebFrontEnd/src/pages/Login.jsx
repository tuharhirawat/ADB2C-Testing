// import React, { useState } from "react";
// import styled from "styled-components";
// import axios from "axios";
// import { useNavigate } from "react-router-dom";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   padding: 50px;
// `;

// const Form = styled.form`
//   display: flex;
//   flex-direction: column;
//   gap: 10px;
//   width: 300px;
// `;

// const Input = styled.input`
//   padding: 8px;
//   border: 1px solid #ccc;
//   border-radius: 5px;
// `;

// const Button = styled.button`
//   padding: 10px;
//   background: #28a745;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Login() {
//   const [user, setUser] = useState({ email: "", password: "" });
//   const navigate = useNavigate();

//   const handleChange = (e) => {
//     setUser({ ...user, [e.target.name]: e.target.value });
//   };

//   const handleSubmit = async (e) => {
//     e.preventDefault();

//     try {
//       const res = await axios.get(`http://localhost:5247/api/Users/GetByEmail`, {
//         params: { email: user.email } // Use user input
//       });

//       if (res.data) {
//         if (res.data.passwordHash === user.password) {
//           alert("Login successful!");
//           navigate("/dashboard");
//         } else {
//           alert("Invalid password!");
//         }
//       } else {
//         alert("User not found!");
//       }
//     } catch (error) {
//       console.error("Error:", error.response?.data || error.message);
//       alert("Login failed! Please check your credentials.");
//     }
//   };

//   return (
//     <Container>
//       <h2>Login</h2>
//       <Form onSubmit={handleSubmit}>
//         <Input
//           type="email"
//           name="email"
//           placeholder="Email"
//           value={user.email}
//           onChange={handleChange}
//           required
//         />
//         <Input
//           type="password"
//           name="password"
//           placeholder="Password"
//           value={user.password}
//           onChange={handleChange}
//           required
//         />
//         <Button type="submit">Login</Button>
//       </Form>
//     </Container>
//   );
// }

// export default Login;










// import React, { useState } from "react";
// import styled from "styled-components";
// import axios from "axios";
// import { useNavigate } from "react-router-dom";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   padding: 50px;
// `;

// const Form = styled.form`
//   display: flex;
//   flex-direction: column;
//   gap: 10px;
//   width: 300px;
// `;

// const Input = styled.input`
//   padding: 8px;
//   border: 1px solid #ccc;
//   border-radius: 5px;
// `;

// const Button = styled.button`
//   padding: 10px;
//   background: #28a745;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Login() {
//   const [credentials, setCredentials] = useState({
//     email: "",
//     passwordHash: "", // Match backend field
//   });

//   const navigate = useNavigate();

//   const handleChange = (e) => {
//     setCredentials({ ...credentials, [e.target.name]: e.target.value });
//   };


//   const handleSubmit = async (e) => {
//     e.preventDefault();
  
//     const loginData = {
//       email: credentials.email,
//       passwordHash: credentials.passwordHash,
//     };
  
//     try {
//       const res = await axios.post("http://localhost:5247/api/Users/login", loginData, {
//         headers: { "Content-Type": "application/json" },
//       });
  
//       console.log("Response received:", res.data);
  
//       if (res.data.message === "Login successful!") {
//         localStorage.setItem("isAuthenticated", "true"); // Store authentication flag
//         alert("Login successful!");
//         navigate("/dashboard");
//       } else {
//         alert("Invalid credentials!");
//       }
//     } catch (error) {
//       console.error("Login Error:", error.response?.data || error.message);
//       alert(error.response?.data?.message || "Login failed! Please check your credentials.");
//     }
//   };
  

//   // const handleSubmit = async (e) => {
//   //   e.preventDefault();
  
//   //   const loginData = {
//   //     email: credentials.email,
//   //     passwordHash: credentials.passwordHash,
//   //   };
  
//   //   try {
//   //     const res = await axios.post(
//   //       "http://localhost:5247/api/Users/login",
//   //       loginData,
//   //       {
//   //         headers: { "Content-Type": "application/json" },
//   //       }
//   //     );
  
//   //     console.log("Response received:", res.data);
      
//   //     // Check for login success based on the response message
//   //     if (res.data.message === "Login successful!") {
//   //       alert("Login successful!");
//   //       navigate("/dashboard");
//   //     } else {
//   //       alert("Invalid credentials!");
//   //     }
//   //   } catch (error) {
//   //     console.error("Login Error:", error.response?.data || error.message);
//   //     alert(
//   //       error.response?.data?.message || "Login failed! Please check your credentials."
//   //     );
//   //   }
//   // };
  
  


//   return (
//     <Container>
//       <h2>Login</h2>
//       <Form onSubmit={handleSubmit}>
//         <Input
//           type="email"
//           name="email"
//           placeholder="Email"
//           value={credentials.email}
//           onChange={handleChange}
//           required
//         />
//         <Input
//           type="password"
//           name="passwordHash"
//           placeholder="Password"
//           value={credentials.passwordHash}
//           onChange={handleChange}
//           required
//         />
//         <Button type="submit">Login</Button>
//       </Form>
//     </Container>
//   );
// }

// export default Login;











// import React from "react";
// import styled from "styled-components";
// import { useMsal } from "@azure/msal-react";
// import { InteractionType } from "@azure/msal-browser";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   padding: 50px;
// `;

// const Button = styled.button`
//   padding: 10px;
//   background: #28a745;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Login() {
//   const { instance } = useMsal();

//   const handleLogin = () => {
//     instance
//       .loginPopup({
//         scopes: ["openid", "profile", "email"],
//       })
//       .then((response) => {
//         localStorage.setItem("isAuthenticated", "true");
//         localStorage.setItem("idToken", response.idToken);
//         alert("Login successful!");
//         window.location.href = "/dashboard";
//       })
//       .catch((error) => {
//         console.error("Login Error:", error);
//         alert("Login failed!");
//       });
//   };

//   return (
//     <Container>
//       <h2>Login</h2>
//       <Button onClick={handleLogin}>Login with Azure AD B2C</Button>
//     </Container>
//   );
// }

// export default Login;





// import React, { useEffect } from "react";
// import styled from "styled-components";
// import { useMsal } from "@azure/msal-react";
// import { InteractionType } from "@azure/msal-browser";
// import { useNavigate } from "react-router-dom";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   padding: 50px;
// `;

// const Button = styled.button`
//   padding: 10px;
//   background: #28a745;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Login() {
//   const { instance } = useMsal();
//   const navigate = useNavigate();

//   useEffect(() => {
//     const urlParams = new URLSearchParams(window.location.search);
//     const code = urlParams.get("code");

//     if (code) {
//       exchangeCodeForToken(code);
//     }
//   }, []);

//   const handleLogin = () => {
//     instance
//       .loginRedirect({
//         scopes: ["openid", "profile", "email"],
//       })
//       .catch((error) => {
//         console.error("Login Error:", error);
//         alert("Login failed!");
//       });
//   };

//   const exchangeCodeForToken = async (code) => {
//     const tokenEndpoint = `${process.env.REACT_APP_B2C_INSTANCE}/${process.env.REACT_APP_B2C_TENANT}/oauth2/v2.0/token`;

//     const params = new URLSearchParams({
//       client_id: process.env.REACT_APP_B2C_CLIENT_ID,
//       grant_type: "authorization_code",
//       scope: "openid offline_access",
//       code: code,
//       redirect_uri: process.env.REACT_APP_B2C_REDIRECT_URI,
//       client_secret: process.env.REACT_APP_B2C_CLIENT_SECRET, // Required for confidential client apps
//     });

//     try {
//       const response = await fetch(tokenEndpoint, {
//         method: "POST",
//         headers: { "Content-Type": "application/x-www-form-urlencoded" },
//         body: params,
//       });

//       const data = await response.json();
//       console.log("Access Token:", data.access_token);
//       localStorage.setItem("access_token", data.access_token);
//       localStorage.setItem("isAuthenticated", "true");
//       alert("Login successful!");
//       navigate("/dashboard");
//     } catch (error) {
//       console.error("Error fetching access token:", error);
//       alert("Token exchange failed!");
//     }
//   };

//   return (
//     <Container>
//       <h2>Login</h2>
//       <Button onClick={handleLogin}>Login with Azure AD B2C</Button>
//     </Container>
//   );
// }

// export default Login;







// import React from "react";
// import styled from "styled-components";
// import { useMsal } from "@azure/msal-react";
// import { InteractionType } from "@azure/msal-browser";

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
//   padding: 50px;
// `;

// const Button = styled.button`
//   padding: 10px;
//   background: #28a745;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Login() {
//   const { instance } = useMsal();

//   const handleLogin = async () => {
//     try {
//       const response = await instance.loginPopup({
//         scopes: [
//           "openid",
//           "profile",
//           "email",
//           "https://TusharAzureTestingADB2C.onmicrosoft.com/user_impersonation/access_api"
//         ],
//       });

//       console.log("Login Successful:", response);

//       // Store tokens securely
//       localStorage.setItem("isAuthenticated", "true");
//       localStorage.setItem("idToken", response.idToken);
//       localStorage.setItem("accessToken", response.accessToken);

//       // Redirect to dashboard
//       window.location.href = "/dashboard";
//     } catch (error) {
//       console.error("Login Error:", error);
//       alert("Login failed!");
//     }
//   };

//   return (
//     <Container>
//       <h2>Login</h2>
//       <Button onClick={handleLogin}>Login with Azure AD B2C</Button>
//     </Container>
//   );
// }

// export default Login;
























import React from "react";
import styled from "styled-components";
import { useMsal } from "@azure/msal-react";

const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 50px;
`;

const Button = styled.button`
  padding: 10px;
  background: #28a745;
  color: white;
  border: none;
  cursor: pointer;
`;

function Login() {
  const { instance } = useMsal();

  const handleLogin = () => {
    instance.loginRedirect({
      scopes: [
        "openid",
        "profile",
        "email",
        "https://TusharAzureTestingADB2C.onmicrosoft.com/user_impersonation/access_api"
      ],
    });
  };

  return (
    <Container>
      <h2>Login</h2>
      <Button onClick={handleLogin}>Login with Azure AD B2C</Button>
    </Container>
  );
}

export default Login;
