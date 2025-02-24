// import { createContext, useState, useEffect } from "react";
// import axios from "axios";

// export const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [user, setUser] = useState(null);

  
//   useEffect(() => {
//     axios.get("http://localhost:5000/api/auth/me", { withCredentials: true })
//       .then(response => setUser(response.data))
//       .catch(() => setUser(null)); 
//   }, []);

//   const login = async (email, password) => {
//     try {
//       await axios.post("http://localhost:5000/api/login", { email, password }, { withCredentials: true });
//       const res = await axios.get("http://localhost:5000/api/auth/me", { withCredentials: true });
//       setUser(res.data);
//     } catch (error) {
//       throw error.response?.data?.message || "Login failed!";
//     }
//   };

//   const logout = async () => {
//     await axios.post("http://localhost:5000/api/logout", {}, { withCredentials: true });
//     setUser(null);
//   };

//   return (
//     <AuthContext.Provider value={{ user, login, logout }}>
//       {children}
//     </AuthContext.Provider>
//   );
// };





// import { createContext, useState, useEffect } from "react";
// import axios from "axios";

// export const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [user, setUser] = useState(null);

//   // Function to check if user is authenticated
//   const fetchUser = async () => {
//     try {
//       const res = await axios.get("http://localhost:5131/api/UserTable/me", {
//         withCredentials: true, // Include credentials (JWT cookie)
//       });
//       setUser(res.data);
//     } catch (error) {
//       setUser(null);
//     }
//   };

//   useEffect(() => {
//     fetchUser();
//   }, []);

//   const login = async (email, password) => {
//     try {
//       const res = await axios.post(
//         "http://localhost:5131/api/UserTable/login",
//         { email, password },
//         { withCredentials: true } 
//       );

//       if (res.data.success) {
//         fetchUser(); 
//       } else {
//         throw new Error(res.data.message);
//       }
//     } catch (error) {
//       throw error.response?.data?.message || "Login failed!";
//     }
//   };

//   const logout = async () => {
//     await axios.post("http://localhost:5131/api/UserTable/logout", {}, { withCredentials: true });
//     setUser(null);
//   };

//   return (
//     <AuthContext.Provider value={{ user, login, logout }}>
//       {children}
//     </AuthContext.Provider>
//   );
// };













import { createContext, useState, useEffect } from "react";
import axios from "axios";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  
  const fetchUser = async () => {
    try {
      const res = await axios.get("http://localhost:5131/api/UserTable/me", {
        withCredentials: true, 
      });
      setUser(res.data);
    } catch (error) {
      setUser(null);
    }
  };

  useEffect(() => {
    fetchUser();
  }, []);

  const Nlogin = async (email, password) => {
    try {
      const res = await axios.post(
        "http://localhost:5131/api/UserTable/login",
        { email, password },
        { withCredentials: true } 
      );

      if (res.data.success) {
        fetchUser(); 
      } else {
        throw new Error(res.data.message);
      }
    } catch (error) {
      throw error.response?.data?.message || "Login failed!";
    }
  };

  const Nlogout = async () => {
    await axios.post("http://localhost:5131/api/UserTable/logout", {}, { withCredentials: true });
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, Nlogin, Nlogout }}>
      {children}
    </AuthContext.Provider>
  );
};
