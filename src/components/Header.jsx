import React from "react";
import { NavLink } from "react-router-dom";
import styled from "styled-components";

const SidebarContainer = styled.aside`
  width: 250px;
  height: 100vh;
  background-color: #4769d9; /* Updated */
  padding: 20px;
  box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
  position: fixed;
  left: 0;
  top: 0;
`;

const SidebarTitle = styled.h2`
  color: white;
  font-size: 30px;
  margin-bottom: 10px;
`;

const SidebarList = styled.ul`
  list-style: none;
  padding-top: 40px;
  // padding: 0;
`;

const SidebarItem = styled.li`
  margin-bottom: 10px;
`;

const SidebarLink = styled(NavLink)`
  text-decoration: none;
  color: white;
  font-size: 16px;
  transition: color 0.3s, background 0.3s;
  padding: 10px;
  display: block;
  border-radius: 5px;

  &:hover {
    color: #0056b3;
    background: #e0e0e0;
  }

  &.active {
    background: #007bff;
    color: white;
  }
`;

const HeaderContainer = styled.nav`
  margin-left: 250px;
  padding: 10px;
  background-color: #4769d9; /* Updated */
`;

const NavList = styled.ul`
  display: flex;
  list-style: none;
  padding-left: 300px;
  margin: 0;
`;

const NavItem = styled.li`
  margin: 0 10px;
`;

const StyledNavLink = styled(NavLink)`
  color: white;
  text-decoration: none;
  font-size: 16px;
  padding: 10px;
  border-radius: 5px;
  transition: background 0.3s;

  &:hover {
    text-decoration: underline;
  }

  &.active {
    background: #007bff;
  }
`;

const Sidebar = () => {
  return (
    <SidebarContainer>
      <SidebarTitle>Accounts Settings</SidebarTitle>
      {/* <SidebarTitle></SidebarTitle> */}
      <SidebarList>
        <SidebarItem>
          <SidebarLink to="/company-registration">
            Company Registration
          </SidebarLink>
        </SidebarItem>
        <SidebarItem>
          <SidebarLink to="/machine-registration">
            Machine Registration
          </SidebarLink>
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
  );
};

const Header = () => {
  return (
    <>
      <Sidebar />
      <HeaderContainer>
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
            <StyledNavLink to="/remarks">Remarks</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/inventory">Inventory</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/reports">Reports</StyledNavLink>
          </NavItem>
          <NavItem>
            <StyledNavLink to="/azure_login">Logout</StyledNavLink>
          </NavItem>
          <NavItem>
            <div id="current-time"></div>
          </NavItem>
        </NavList>
      </HeaderContainer>
    </>
  );
};

export default Header;
