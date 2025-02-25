import React from "react";
import styled from "styled-components";

const FooterContainer = styled.footer`
  background-color: #4769d9;
  color: white;
  padding: 15px;
  text-align: center;
  font-size: 14px;
  bottom: 0;
  right: 0;
  left: 0;
  width: 100%;
  margin-top: auto; /* Pushes footer down when needed */
`;

const Footer = () => {
  return (
    <FooterContainer>
      <p>ZOOM DIGITAL PRESS PVT LTD (2024-2025) | Staff: N. SANTHOSH (ADMIN)</p>
      <p>All Rights Reserved &copy; | Powered by TellerSoft Pvt Ltd</p>
    </FooterContainer>
  );
};

export default Footer;
