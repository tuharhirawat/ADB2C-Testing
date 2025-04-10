export const msalConfig = {
  auth: {
      clientId: "34aefe3c-e5b0-40e3-816d-a2ec21508337",
      authority: "https://tusharazuretestingadb2c.b2clogin.com/tusharazuretestingadb2c.onmicrosoft.com/B2C_1_susi1",
      knownAuthorities: ["tusharazuretestingadb2c.b2clogin.com"],
      redirectUri: "http://localhost:5173/",
  },
  cache: {
      cacheLocation: "sessionStorage",
      storeAuthStateInCookie: false,
  },
};

export const loginRequest = {
  scopes: [
      "openid",
      "offline_access",
      "https://TusharAzureTestingADB2C.onmicrosoft.com/api/user/user_impersonation"
  ]
};

