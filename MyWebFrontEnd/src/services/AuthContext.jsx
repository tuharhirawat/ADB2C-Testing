// import React, { createContext, useState, useEffect } from "react";

// const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [isAuthenticated, setIsAuthenticated] = useState(
//     localStorage.getItem("isAuthenticated") === "true"
//   );

//   // Function to login
//   const login = () => {
//     setIsAuthenticated(true);
//     localStorage.setItem("isAuthenticated", "true");
//   };

//   // Function to logout
//   const logout = () => {
//     setIsAuthenticated(false);
//     localStorage.removeItem("isAuthenticated");
//   };

//   return (
//     <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
//       {children}
//     </AuthContext.Provider>
//   );
// };

// export default AuthContext;






import React, { createContext, useState, useEffect } from "react";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(
    localStorage.getItem("isAuthenticated") === "true" // Read from localStorage on page load
  );

  // Function to login
  const login = () => {
    console.log("Login function called"); // Debug log
    setIsAuthenticated(true);
    localStorage.setItem("isAuthenticated", "true"); // Store in localStorage
    console.log("isAuthenticated stored in localStorage:", localStorage.getItem("isAuthenticated"));
  };

  // Function to logout
  const logout = () => {
    console.log("Logout function called"); // Debug log
    setIsAuthenticated(false);
    localStorage.removeItem("isAuthenticated"); // Remove from localStorage
    console.log("isAuthenticated removed from localStorage:", localStorage.getItem("isAuthenticated"));
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
