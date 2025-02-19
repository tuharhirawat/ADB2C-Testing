// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length > 0) {
//         try {
//           // Ensure MSAL is initialized before calling any authentication function
//           await instance.initialize();

//           // Set active account
//           instance.setActiveAccount(accounts[0]);

//           const response = await instance.acquireTokenSilent({
//             account: accounts[0], // Ensure an account is provided
//             scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//           });

//           const token = response.accessToken;

//           const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//             headers: { Authorization: `Bearer ${token}` },
//           });

//           setData(apiResponse.data);
//         } catch (error) {
//           console.error("Error fetching secure data:", error);
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;




// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length === 0) {
//         console.warn("No active accounts found. User might not be logged in.");
//         return;
//       }

//       try {
//         console.log("Ensuring MSAL is initialized...");
//         await instance.initialize(); // Ensure MSAL is ready

//         console.log("Setting active account...");
//         instance.setActiveAccount(accounts[0]);

//         console.log("Fetching token silently...");
//         const response = await instance.acquireTokenSilent({
//             account: accounts[0],
//             scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//           });
          
//           const token = response.accessToken;
//           console.log("Token Acquired:", token); // Log the token
          
//           // Decode and check expiration time
//           const tokenPayload = JSON.parse(atob(token.split(".")[1]));
//           console.log("Token Payload:", tokenPayload);
//           console.log("Token Expiry:", new Date(tokenPayload.exp * 1000));
          
//         // Call Secure API with token
//         const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//           headers: { Authorization: `Bearer ${token}` },
//         });

//         setData(apiResponse.data);
//       } catch (error) {
//         console.error("Error fetching secure data:", error);

//         // If token is expired or invalid, request interactive login
//         if (error.message?.includes("AADB2C90077")) {
//           console.log("Token expired, requesting interactive login...");
//           instance.loginPopup({
//             scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//           })
//             .then(loginResponse => {
//               console.log("New token acquired:", loginResponse.accessToken);
//             })
//             .catch(err => {
//               console.error("Interactive login failed:", err);
//             });
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;







// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length === 0) {
//         console.warn("No active accounts found. User might not be logged in.");
//         return;
//       }

//       try {
//         console.log("Fetching token silently...");
//         const response = await instance.acquireTokenSilent({
//           account: accounts[0],
//           scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//         });

//         const token = response.accessToken;
//         console.log("Token Acquired:", token);

//         // Decode token and validate audience (API Identifier)
//         const tokenPayload = JSON.parse(atob(token.split(".")[1]));
//         console.log("Token Payload:", tokenPayload);
//         console.log("Token Expiry:", new Date(tokenPayload.exp * 1000));

//         if (!tokenPayload.aud.includes("https://tusharazuretestingadb2c.onmicrosoft.com/api")) {
//           console.error("Invalid audience in token. Expected API audience.");
//           return;
//         }

//         // Call Secure API with token
//         const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//           headers: { Authorization: `Bearer ${token}` },
//         });

//         setData(apiResponse.data);
//       } catch (error) {
//         console.error("Error fetching secure data:", error);

//         // If token is expired or unauthorized, force an interactive login
//         if (error.response?.status === 401) {
//           console.log("Token expired or unauthorized. Prompting interactive login...");
//           instance
//             .loginPopup({
//               scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//             })
//             .then(loginResponse => {
//               console.log("New token acquired:", loginResponse.accessToken);
//               fetchData(); // Retry API request with new token
//             })
//             .catch(err => {
//               console.error("Interactive login failed:", err);
//             });
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;





// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";
// import {jwtDecode} from "jwt-decode"; 

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length === 0) {
//         console.warn("No active accounts found. User might not be logged in.");
//         return;
//       }

//       try {
//         console.log("Ensuring MSAL is initialized...");
//         await instance.initialize(); // Ensure MSAL is ready

//         console.log("Setting active account...");
//         instance.setActiveAccount(accounts[0]);

//         console.log("Fetching token silently...");
//         const response = await instance.acquireTokenSilent({
//           account: accounts[0],
//           scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//         });

//         const token = response.accessToken;
//         console.log("Token Acquired:", token); // Log the token

//         // Decode the JWT payload safely
//         try {
//           const tokenPayload = jwtDecode(token);
//           console.log("Token Payload:", tokenPayload);
//           console.log("Token Expiry:", new Date(tokenPayload.exp * 1000));
//         } catch (decodeError) {
//           console.error("Failed to decode token:", decodeError);
//         }

//         // Call Secure API with token
//         const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//           headers: { Authorization: `Bearer ${token}` },
//         });

//         setData(apiResponse.data);
//       } catch (error) {
//         console.error("Error fetching secure data:", error);

//         // If token is expired or invalid, request interactive login
//         if (error.message?.includes("AADB2C90077") || error.message?.includes("expired")) {
//           console.log("Token expired, requesting interactive login...");
//           instance
//             .loginPopup({
//               scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
//             })
//             .then((loginResponse) => {
//               console.log("New token acquired:", loginResponse.accessToken);
//             })
//             .catch((err) => {
//               console.error("Interactive login failed:", err);
//             });
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;















// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";
// import { jwtDecode } from "jwt-decode"; // Install using: npm install jwt-decode

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);
//   const [error, setError] = useState("");

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length === 0) {
//         console.warn("No active accounts found. User might not be logged in.");
//         setError("User not logged in.");
//         return;
//       }

//       try {
//         console.log("Fetching token silently...");

//         const response = await instance.acquireTokenSilent({
//           account: accounts[0],
//         //   scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/access_api"],
//         scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/.default"],
//         });

//         console.log("Token Response:", response);

//         if (!response || !response.accessToken) {
//           throw new Error("No access token received.");
//         }

//         const token = response.accessToken;
//         // console.log("Token Acquired:", token);
//         console.log("Token:", response.accessToken || "No token received");

//          try {
//           if (token.split(".").length !== 3) {
//             throw new Error("Invalid token format.");
//           }
//           const tokenPayload = jwtDecode(token);
//           console.log("Token Payload:", tokenPayload);
//         } catch (decodeError) {
//           throw new Error("Failed to decode token: " + decodeError.message);
//         }

//         // Call Secure API with token
//         console.log("Making API request with token...");
//         const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//           headers: { Authorization: `Bearer ${token}` },
//         });

//         setData(apiResponse.data);
//       } catch (error) {
//         console.error("Error fetching secure data:", error);
//         setError(error.message);

//         // Handle token expiration or invalid cases
//         if (error.message.includes("AADB2C90077") || error.message.includes("expired") || error.message.includes("No access token received")) {
//           console.log("Token expired or missing, requesting interactive login...");
//           instance
//             .loginPopup({
//             //   scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/access_api"],
//             scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/.default"],
//             })
//             .then((loginResponse) => {
//               console.log("New token acquired:", loginResponse.accessToken);
//             })
//             .catch((err) => {
//               console.error("Interactive login failed:", err);
//             });
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {error && <p style={{ color: "red" }}>{error}</p>}
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;




// import React, { useState, useEffect } from "react";
// import { useMsal } from "@azure/msal-react";
// import axios from "axios";
// import { jwtDecode } from "jwt-decode"; // Install using: npm install jwt-decode

// const SecureData = () => {
//   const { instance, accounts } = useMsal();
//   const [data, setData] = useState(null);
//   const [error, setError] = useState("");

//   useEffect(() => {
//     const fetchData = async () => {
//       if (accounts.length === 0) {
//         console.warn("No active accounts found. User might not be logged in.");
//         setError("User not logged in.");
//         return;
//       }

//       try {
//         console.log("Fetching token silently...");

//         const response = await instance.acquireTokenSilent({
//           account: accounts[0],
//           scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"], // ✅ Use correct scope
//         });

//         console.log("Token Response:", response);

//         if (!response || !response.accessToken) {
//           throw new Error("No access token received.");
//         }

//         const token = response.accessToken;
//         console.log("Token:", token);

//         try {
//           if (token.split(".").length !== 3) {
//             throw new Error("Invalid token format.");
//           }
//           const tokenPayload = jwtDecode(token);
//           console.log("Token Payload:", tokenPayload);
//         } catch (decodeError) {
//           throw new Error("Failed to decode token: " + decodeError.message);
//         }

//         // Call Secure API with token
//         console.log("Making API request with token...");
//         const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
//           headers: { Authorization: `Bearer ${token}` },
//         });

//         setData(apiResponse.data);
//       } catch (error) {
//         console.error("Error fetching secure data:", error);
//         setError(error.message);

//         // Handle token expiration or invalid cases
//         if (error.message.includes("AADB2C90077") || error.message.includes("expired") || error.message.includes("No access token received")) {
//           console.log("Token expired or missing, requesting interactive login...");
//           instance
//             .loginPopup({
//               scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"], // ✅ Correct scope
//             })
//             .then((loginResponse) => {
//               console.log("New token acquired:", loginResponse.accessToken);
//             })
//             .catch((err) => {
//               console.error("Interactive login failed:", err);
//             });
//         }
//       }
//     };

//     fetchData();
//   }, [accounts, instance]);

//   return (
//     <div>
//       <h2>Secure API Data</h2>
//       {error && <p style={{ color: "red" }}>{error}</p>}
//       {data ? <p>{data.message}</p> : <p>Loading...</p>}
//     </div>
//   );
// };

// export default SecureData;






import React, { useState, useEffect } from "react";
import { useMsal } from "@azure/msal-react";
import axios from "axios";
import { jwtDecode } from "jwt-decode"; // Ensure it's installed: npm install jwt-decode

const SecureData = () => {
  const { instance, accounts } = useMsal();
  const [data, setData] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      if (accounts.length === 0) {
        console.warn("No active accounts found. User might not be logged in.");
        setError("User not logged in. Please sign in first.");
        return;
      }

      try {
        console.log("🔄 Fetching token silently...");

        let tokenResponse;
        try {
          tokenResponse = await instance.acquireTokenSilent({
            account: accounts[0],
            scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
          });
        } catch (silentError) {
          console.warn("⚠️ Silent token acquisition failed:", silentError.message);
          setError("Token expired or unavailable. Please log in again.");

          console.log("🔄 Attempting interactive login...");
          try {
            tokenResponse = await instance.acquireTokenPopup({
              scopes: ["https://tusharazuretestingadb2c.onmicrosoft.com/api/user_impersonation"],
            });
          } catch (popupError) {
            console.error("🚨 Interactive login failed:", popupError.message);
            setError("Login required. Please refresh and sign in again.");
            return;
          }
        }

        if (!tokenResponse || !tokenResponse.accessToken) {
          throw new Error("No access token received.");
        }

        const token = tokenResponse.accessToken;
        console.log("✅ Acquired Token:", token);

        // Validate token format
        try {
          if (token.split(".").length !== 3) {
            throw new Error("Invalid token format.");
          }
          const tokenPayload = jwtDecode(token);
          console.log("🔍 Decoded Token Payload:", tokenPayload);
        } catch (decodeError) {
          throw new Error("Failed to decode token: " + decodeError.message);
        }

        // Call Secure API with token
        console.log("🌐 Making API request with token...");
        const apiResponse = await axios.get("http://localhost:5170/api/secure/data", {
          headers: { Authorization: `Bearer ${token}` },
        });

        setData(apiResponse.data);
      } catch (error) {
        console.error("❌ Error fetching secure data:", error);
        setError(error.message);
      }
    };

    fetchData();
  }, [accounts, instance]);

  return (
    <div>
      <h2>Secure API Data</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}
      {data ? <p>{data.message}</p> : <p>Loading...</p>}
    </div>
  );
};

export default SecureData;