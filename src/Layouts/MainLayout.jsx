// import React, { Children } from "react";
// import Header from "../Components/Header";
// import Footer from "../Components/Footer";

// function MainLayout({ children }) {
//   return (
//     <div>
//       <Header />
//       <main>{children}</main>
//       <Footer />
//     </div>
//   );
// }

// export default MainLayout;



import React from "react";
import Header from "../Components/Header";
import Footer from "../Components/Footer";
import styled from "styled-components";

const LayoutContainer = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh; /* Ensures full viewport height */
`;

const Content = styled.main`
  flex: 1; /* Pushes footer down when content is short */
  padding: 20px;
`;

const MainLayout = ({ children }) => {
  return (
    <LayoutContainer>
      <Header />
      <Content>{children}</Content>
      <Footer />
    </LayoutContainer>
  );
};

export default MainLayout;
