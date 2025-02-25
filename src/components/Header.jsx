// import React from "react";
// import { NavLink } from "react-router-dom";
// import styled from "styled-components";

// const SidebarContainer = styled.aside`
//   width: 250px;
//   height: 100vh;
//   background-color: #4769d9; /* Updated */
//   padding: 20px;
//   box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
//   position: fixed;
//   left: 0;
//   top: 0;
// `;

// const SidebarTitle = styled.h2`
//   color: white;
//   font-size: 30px;
//   margin-bottom: 10px;
// `;

// const SidebarList = styled.ul`
//   list-style: none;
//   padding-top: 40px;
//   // padding: 0;
// `;

// const SidebarItem = styled.li`
//   margin-bottom: 10px;
// `;

// const SidebarLink = styled(NavLink)`
//   text-decoration: none;
//   color: white;
//   font-size: 16px;
//   transition: color 0.3s, background 0.3s;
//   padding: 10px;
//   display: block;
//   border-radius: 5px;

//   &:hover {
//     color: #0056b3;
//     background: #e0e0e0;
//   }

//   &.active {
//     background: #007bff;
//     color: white;
//   }
// `;

// const HeaderContainer = styled.nav`
//   margin-left: 250px;
//   padding: 10px;
//   background-color: #4769d9; /* Updated */
// `;

// const NavList = styled.ul`
//   display: flex;
//   list-style: none;
//   padding-left: 300px;
//   margin: 0;
// `;

// const NavItem = styled.li`
//   margin: 0 10px;
// `;

// const StyledNavLink = styled(NavLink)`
//   color: white;
//   text-decoration: none;
//   font-size: 16px;
//   padding: 10px;
//   border-radius: 5px;
//   transition: background 0.3s;

//   &:hover {
//     text-decoration: underline;
//   }

//   &.active {
//     background: #007bff;
//   }
// `;

// const Sidebar = () => {
//   return (
//     <SidebarContainer>
//       <SidebarTitle>Accounts Settings</SidebarTitle>
//       {/* <SidebarTitle></SidebarTitle> */}
//       <SidebarList>
//         <SidebarItem>
//           <SidebarLink to="/company-registration">
//             Company Registration
//           </SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/machine-registration">
//             Machine Registration
//           </SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/head-master">Head Master</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/work-assign">Work Assign</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/bulk-rate">Bulk Rate</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/individual-rate">Individual Rate</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/azure_login">Logout</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/login">Normal-Login</SidebarLink>
//         </SidebarItem>
//         <SidebarItem>
//           <SidebarLink to="/signup">Normal-Signup</SidebarLink>
//         </SidebarItem>
//       </SidebarList>
//     </SidebarContainer>
//   );
// };

// const Header = () => {
//   return (
//     <>
//       <Sidebar />
//       <HeaderContainer>
//         <NavList>
//           <NavItem>
//             <StyledNavLink to="/workorder">Work Order</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/directworkorder">Direct-Work</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/customerform">Customer</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/qualitycheck">Quality</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/remarks">Remarks</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/inventory">Inventory</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/reports">Reports</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/azure_login">Logout</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <div id="current-time"></div>
//           </NavItem>
//         </NavList>
//       </HeaderContainer>
//     </>
//   );
// };

// export default Header;






// import React, { useState } from "react";
// import { NavLink } from "react-router-dom";
// import styled from "styled-components";
// import { FiMenu, FiX } from "react-icons/fi"; // Icons for menu toggle

// // Styled Components

// const SidebarContainer = styled.aside`
//   width: 250px;
//   height: 100vh;
//   background-color: #4769d9;
//   padding: 20px;
//   box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
//   position: fixed;
//   left: ${({ open }) => (open ? "0" : "-250px")}; /* Sidebar slides in/out */
//   top: 0;
//   transition: left 0.3s ease-in-out;
//   z-index: 1000;

//   @media (max-width: 768px) {
//     width: 200px;
//   }
// `;

// const Overlay = styled.div`
//   display: ${({ open }) => (open ? "block" : "none")};
//   position: fixed;
//   top: 0;
//   left: 0;
//   width: 100%;
//   height: 100%;
//   background: rgba(0, 0, 0, 0.5);
//   z-index: 999;
// `;

// const SidebarTitle = styled.h2`
//   color: white;
//   font-size: 24px;
//   margin-bottom: 10px;
// `;

// const SidebarList = styled.ul`
//   list-style: none;
//   padding-top: 20px;
// `;

// const SidebarItem = styled.li`
//   margin-bottom: 10px;
// `;

// const SidebarLink = styled(NavLink)`
//   text-decoration: none;
//   color: white;
//   font-size: 16px;
//   transition: color 0.3s, background 0.3s;
//   padding: 10px;
//   display: block;
//   border-radius: 5px;

//   &:hover {
//     color: #0056b3;
//     background: #e0e0e0;
//   }

//   &.active {
//     background: #007bff;
//     color: white;
//   }
// `;

// // Header Styles
// const HeaderContainer = styled.nav`
//   padding: 15px;
//   background-color: #4769d9;
//   display: flex;
//   align-items: center;
//   justify-content: space-between;
//   position: fixed;
//   top: 0;
//   left: ${({ open }) => (open ? "250px" : "0")}; /* Shifts when sidebar is open */
//   width: ${({ open }) => (open ? "calc(100% - 250px)" : "100%")};
//   transition: left 0.3s ease-in-out, width 0.3s ease-in-out;
//   z-index: 900;

//   @media (max-width: 768px) {
//     left: 0;
//     width: 100%;
//   }
// `;

// const NavList = styled.ul`
//   display: flex;
//   list-style: none;
//   padding: 0;
//   margin: 0;

//   @media (max-width: 768px) {
//     flex-wrap: wrap;
//     justify-content: center;
//   }
// `;

// const NavItem = styled.li`
//   margin: 0 10px;
// `;

// const StyledNavLink = styled(NavLink)`
//   color: white;
//   text-decoration: none;
//   font-size: 16px;
//   padding: 10px;
//   border-radius: 5px;
//   transition: background 0.3s;

//   &:hover {
//     text-decoration: underline;
//   }

//   &.active {
//     background: #007bff;
//   }
// `;

// // Menu Toggle Button for Small Screens
// const MenuButton = styled.button`
//   background: none;
//   border: none;
//   color: white;
//   font-size: 24px;
//   cursor: pointer;
//   position: absolute;
//   top: 15px;
//   left: 10px;
//   z-index: 1100;

//   @media (min-width: 769px) {
//     display: none;
//   }
// `;

// // Sidebar Component
// const Sidebar = ({ open, toggleSidebar }) => {
//   return (
//     <>
//       <Overlay open={open} onClick={toggleSidebar} />
//       <SidebarContainer open={open}>
//         <MenuButton onClick={toggleSidebar}>
//           <FiX />
//         </MenuButton>
//         <SidebarTitle>Accounts Settings</SidebarTitle>
//         <SidebarList>
//           <SidebarItem>
//             <SidebarLink to="/company-registration">Company Registration</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/machine-registration">Machine Registration</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/head-master">Head Master</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/work-assign">Work Assign</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/bulk-rate">Bulk Rate</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/individual-rate">Individual Rate</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/azure_login">Logout</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/login">Normal-Login</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/signup">Normal-Signup</SidebarLink>
//           </SidebarItem>
//         </SidebarList>
//       </SidebarContainer>
//     </>
//   );
// };

// // Header Component
// const Header = () => {
//   const [sidebarOpen, setSidebarOpen] = useState(false);

//   const toggleSidebar = () => {
//     setSidebarOpen(!sidebarOpen);
//   };

//   return (
//     <>
//       <MenuButton onClick={toggleSidebar}>
//         <FiMenu />
//       </MenuButton>
//       <Sidebar open={sidebarOpen} toggleSidebar={toggleSidebar} />
//       <HeaderContainer open={sidebarOpen}>
//         <NavList>
//           <NavItem>
//             <StyledNavLink to="/workorder">Work Order</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/directworkorder">Direct-Work</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/customerform">Customer</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/qualitycheck">Quality</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/remarks">Remarks</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/inventory">Inventory</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/reports">Reports</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/azure_login">Logout</StyledNavLink>
//           </NavItem>
//         </NavList>
//       </HeaderContainer>
//     </>
//   );
// };

// export default Header;





// import React, { useState, useRef, useEffect } from "react";
// import { NavLink } from "react-router-dom";
// import styled from "styled-components";
// import { FiMenu, FiX } from "react-icons/fi";


// const SidebarContainer = styled.aside`
//   width: 250px;
//   height: 100vh;
//   background-color: #4769d9;
//   padding-left: 30px;
//   padding-top: 30px;
//   padding-right: 20px;
//   // margin-top:30px;
//   box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
//   position: fixed;
//   left: ${({ open }) => (open ? "0" : "-250px")}; /* Sidebar slides in/out */
//   top: 0;
//   transition: left 0.3s ease-in-out;
//   z-index: 1000;
// `;

// const Overlay = styled.div`
//   display: ${({ open }) => (open ? "block" : "none")};
//   position: fixed;
//   top: 0;
//   left: 0;
//   width: 100%;
//   height: 100%;
//   background: rgba(0, 0, 0, 0.5);
//   z-index: 999;
// `;

// const SidebarTitle = styled.h2`
//   color: white;
//   font-size: 24px;
//   margin-top: 20px;
//   margin-bottom: 10px;
// `;

// const SidebarList = styled.ul`
//   list-style: none;
//   padding-top: 20px;
// `;

// const SidebarItem = styled.li`
//   margin-bottom: 10px;
//   display: flex;
// `;

// const SidebarLink = styled(NavLink)`
//   text-decoration: none;
//   color: white;
//   align-items: center;
//   justify-content: center;
//   font-size: 16px;
//   transition: color 0.3s, background 0.3s;
//   padding: 10px;
//   display: block;
//   border-radius: 5px;

//   &:hover {
//     color: #0056b3;
//     background: #e0e0e0;
//   }

//   &.active {
//     background: #007bff;
//     color: white;
//   }
// `;

// // Header Styles
// const HeaderContainer = styled.nav`
//   padding: 15px;
//   background-color: #4769d9;
//   display: flex;
//   align-items: center;
//   justify-content: space-between;
//   position: fixed;
//   top: 0;
//   left: ${({ open }) => (open ? "250px" : "0")}; /* Header moves when sidebar is open */
//   width: ${({ open }) => (open ? "calc(100% - 250px)" : "100%")};
//   transition: left 0.3s ease-in-out, width 0.3s ease-in-out;
//   z-index: 900;
// `;

// const NavList = styled.ul`
//   display: flex;
//   list-style: none;
//   padding: 0;
//   margin-left: 20%;
//   margin-right: 20%;

//   @media (max-width: 768px) {
//     flex-wrap: wrap;
//     justify-content: center;
//   }
// `;

// const NavItem = styled.li`
//   margin: 0 10px;
// `;

// const StyledNavLink = styled(NavLink)`
//   color: white;
//   text-decoration: none;
//   font-size: 16px;
//   padding: 10px;
//   border-radius: 5px;
//   transition: background 0.3s;

//   &:hover {
//     text-decoration: underline;
//   }

//   &.active {
//     background: #007bff;
//   }
// `;

// // Fixed Menu Button (Always Visible)
// const MenuButton = styled.button`
//   background: none;
//   border: none;
//   color: white;
//   font-size: 24px;
//   cursor: pointer;
//   position: fixed;
//   top: 15px;
//   left: 10px;
//   z-index: 1101; /* Always on top */

//   &:focus {
//     outline: none;
//   }
// `;

// // Sidebar Component
// const Sidebar = ({ open, toggleSidebar }) => {
//   return (
//     <>
//       <Overlay open={open} onClick={toggleSidebar} />
//       <SidebarContainer open={open}>
//         <SidebarTitle>Accounts Settings</SidebarTitle>
//         <SidebarList>
//           <SidebarItem>
//             <SidebarLink to="/company-registration">Company Registration</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/machine-registration">Machine Registration</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/head-master">Head Master</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/work-assign">Work Assign</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/bulk-rate">Bulk Rate</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/individual-rate">Individual Rate</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/azure_login">Logout</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/login">Normal-Login</SidebarLink>
//           </SidebarItem>
//           <SidebarItem>
//             <SidebarLink to="/signup">Normal-Signup</SidebarLink>
//           </SidebarItem>
//         </SidebarList>
//       </SidebarContainer>
//     </>
//   );
// };

// // Header Component
// const Header = () => {
//   const [sidebarOpen, setSidebarOpen] = useState(false);
//   const sidebarRef = useRef(null);
//   const menuButtonRef = useRef(null);

//   const toggleSidebar = () => {
//     setSidebarOpen((prev) => !prev);
//   };

//   useEffect(() => {
//     const handleOutsideClick = (event) => {
//       if (
//         sidebarOpen &&
//         sidebarRef.current &&
//         !sidebarRef.current.contains(event.target) &&
//         menuButtonRef.current &&
//         !menuButtonRef.current.contains(event.target)
//       ) {
//         setSidebarOpen(false);
//       }
//     };

//     document.addEventListener("mousedown", handleOutsideClick);
//     return () => {
//       document.removeEventListener("mousedown", handleOutsideClick);
//     };
//   }, [sidebarOpen]);

//   return (
//     <>
//       <MenuButton ref={menuButtonRef} onClick={toggleSidebar}>
//         {sidebarOpen ? <FiX /> : <FiMenu />}
//       </MenuButton>
//       <div ref={sidebarRef}>
//         <Sidebar open={sidebarOpen} toggleSidebar={toggleSidebar} />
//       </div>
//       <HeaderContainer open={sidebarOpen}>
//         <NavList>
//           <NavItem>
//             <StyledNavLink to="/workorder">Work Order</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/directworkorder">Direct-Work</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/customerform">Customer</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/qualitycheck">Quality</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/remarks">Remarks</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/inventory">Inventory</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/reports">Reports</StyledNavLink>
//           </NavItem>
//           <NavItem>
//             <StyledNavLink to="/azure_login">Logout</StyledNavLink>
//           </NavItem>
//         </NavList>
//       </HeaderContainer>
//     </>
//   );
// };

// export default Header;




















import React, { useState, useRef, useEffect } from "react";
import { NavLink } from "react-router-dom";
import styled from "styled-components";
import { FiMenu, FiX } from "react-icons/fi";

// Sidebar Styling
const SidebarContainer = styled.aside`
  width: 250px;
  height: 100vh;
  background-color: #4769d9;
  padding: 30px 20px;
  box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
  position: fixed;
  left: ${({ open }) => (open ? "0" : "-250px")}; /* Sidebar slides in/out */
  top: 0;
  transition: left 0.3s ease-in-out;
  z-index: 1000;
  display: flex;
  flex-direction: column;
  align-items: center; /* Centers content inside sidebar */
  
  @media (max-width: 768px) {
    width: 200px; /* Reduce width on smaller screens */
  }
`;

const Overlay = styled.div`
  display: ${({ open }) => (open ? "block" : "none")};
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  z-index: 999;
`;

const SidebarTitle = styled.h2`
  color: white;
  font-size: 22px;
  text-align: center;
  margin-bottom: 20px;
`;

const SidebarList = styled.ul`
  list-style: none;
  padding-top: 10px;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center; /* Centering items inside */
`;

const SidebarItem = styled.li`
  margin-bottom: 10px;
  width: 100%;
`;

const SidebarLink = styled(NavLink)`
  text-decoration: none;
  color: white;
  font-size: 16px;
  padding: 10px;
  display: block;
  border-radius: 5px;
  transition: color 0.3s, background 0.3s;

  &:hover {
    color: #0056b3;
    background: #e0e0e0;
  }

  &.active {
    background: #007bff;
    color: white;
  }
`;

// Header Styling
const HeaderContainer = styled.nav`
  padding: 15px;
  background-color: #4769d9;
  display: flex;
  align-items: center;
  justify-content: center; /* Centers content in header */
  position: fixed;
  top: 0;
  left: ${({ open }) => (open ? "250px" : "0")};
  width: ${({ open }) => (open ? "calc(100% - 250px)" : "100%")};
  transition: left 0.3s ease-in-out, width 0.3s ease-in-out;
  z-index: 900;

  @media (max-width: 768px) {
    left: 0;
    width: 100%;
    padding: 10px; /* Reduce padding for small screens */
  }
`;

const NavList = styled.ul`
  display: flex;
  list-style: none;
  padding: 0;
  margin: 0;
  gap: 15px;
  flex-wrap: wrap;
  justify-content: center; /* Centers nav links */

  @media (max-width: 768px) {
    gap: 10px;
  }
`;

const NavItem = styled.li`
  text-align: center;
`;

const StyledNavLink = styled(NavLink)`
  color: white;
  text-decoration: none;
  font-size: 14px;
  padding: 8px 12px;
  border-radius: 5px;
  transition: background 0.3s;

  &:hover {
    text-decoration: underline;
  }

  &.active {
    background: #007bff;
  }

  @media (max-width: 768px) {
    font-size: 12px;
    padding: 6px 10px; /* Reduce size for small screens */
  }
`;

// Fixed Menu Button (Always Visible)
const MenuButton = styled.button`
  background: none;
  border: none;
  color: white;
  font-size: 24px;
  cursor: pointer;
  position: fixed;
  top: 15px;
  left: 10px;
  z-index: 1101;

  &:focus {
    outline: none;
  }

  @media (max-width: 768px) {
    font-size: 22px;
    top: 10px;
  }
`;

// Sidebar Component
const Sidebar = ({ open, toggleSidebar }) => {
  return (
    <>
      <Overlay open={open} onClick={toggleSidebar} />
      <SidebarContainer open={open}>
        <SidebarTitle>Accounts Settings</SidebarTitle>
        <SidebarList>
          <SidebarItem>
            <SidebarLink to="/company-registration">Company Registration</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/machine-registration">Machine Registration</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/head-master">Head Master</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/work-assign">Work Assign</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/bulk-rate">Bulk Rate</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/individual-rate">Individual Rate</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/azure_login">Logout</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/login">Normal-Login</SidebarLink>
          </SidebarItem>
          <SidebarItem>
            <SidebarLink to="/signup">Normal-Signup</SidebarLink>
          </SidebarItem>
        </SidebarList>
      </SidebarContainer>
    </>
  );
};

// Header Component
const Header = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);
  const sidebarRef = useRef(null);
  const menuButtonRef = useRef(null);

  const toggleSidebar = () => {
    setSidebarOpen((prev) => !prev);
  };

  useEffect(() => {
    const handleOutsideClick = (event) => {
      if (
        sidebarOpen &&
        sidebarRef.current &&
        !sidebarRef.current.contains(event.target) &&
        menuButtonRef.current &&
        !menuButtonRef.current.contains(event.target)
      ) {
        setSidebarOpen(false);
      }
    };

    document.addEventListener("mousedown", handleOutsideClick);
    return () => {
      document.removeEventListener("mousedown", handleOutsideClick);
    };
  }, [sidebarOpen]);

  return (
    <>
      <MenuButton ref={menuButtonRef} onClick={toggleSidebar}>
        {sidebarOpen ? <FiX /> : <FiMenu />}
      </MenuButton>
      <div ref={sidebarRef}>
        <Sidebar open={sidebarOpen} toggleSidebar={toggleSidebar} />
      </div>
      <HeaderContainer open={sidebarOpen}>
        <NavList>
          <NavItem>
            <StyledNavLink to="/workorder">Work Order</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/directworkorder">Direct-Work</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/customerform">Customer</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/qualitycheck">Quality</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/inventory">Inventory</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/reports">Reports</StyledNavLink>
          </NavItem>
        </NavList>
      </HeaderContainer>
    </>
  );
};

export default Header;
