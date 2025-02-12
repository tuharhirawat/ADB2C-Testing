// import { PublicClientApplication } from "@azure/msal-browser";

// const msalConfig = {
//   auth: {
//     clientId: "e628713e-173c-487b-aee7-08c673c3633d",
//     authority: "https://TusharAzureTestingADB2C.b2clogin.com/TusharAzureTestingADB2C.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_SignupSignin&client_id=8ab9d15f-383e-4aa2-8b9d-fff354e1854c&nonce=defaultNonce&redirect_uri=https%3A%2F%2Flocalhost%3A5001%2Fsignin-oidc&scope=openid&response_type=code&prompt=login",
//     redirectUri: "http://localhost:3000",
//   },
//   cache: {
//     cacheLocation: "sessionStorage",
//     storeAuthStateInCookie: false,
//   },
// };

// export const msalInstance = new PublicClientApplication(msalConfig);




import { PublicClientApplication } from "@azure/msal-browser";

const msalConfig = {
  auth: {
    clientId: "8ab9d15f-383e-4aa2-8b9d-fff354e1854c", // Correct client ID
    authority: "https://TusharAzureTestingADB2C.b2clogin.com/TusharAzureTestingADB2C.onmicrosoft.com/B2C_1_SignupSignin", // Correct authority
    redirectUri: "http://localhost:3000", // Must match Azure B2C portal configuration
    knownAuthorities: ["TusharAzureTestingADB2C.b2clogin.com"], // Ensures B2C authority validation
  },
  cache: {
    cacheLocation: "sessionStorage", 
    storeAuthStateInCookie: false, 
  },
};

export const msalInstance = new PublicClientApplication(msalConfig);
