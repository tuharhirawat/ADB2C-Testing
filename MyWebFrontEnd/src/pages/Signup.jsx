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
//   background: #007bff;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Signup() {
//     const navigate = useNavigate();
//   const [user, setUser] = useState({ fullName: "", email: "", passwordHash: "" });

//   const handleChange = (e) => {
//     setUser({ ...user, [e.target.name]: e.target.value });
//   };

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     await axios.post("http://localhost:5247/api/Users", user);
//     alert("Signup successful!");
//     navigate("/login");
//   };

//   return (
//     <Container>
//       <h2>Signup</h2>
//       <Form onSubmit={handleSubmit}>
//         <Input type="text" name="fullName" placeholder="Full Name" onChange={handleChange} required />
//         <Input type="email" name="email" placeholder="Email" onChange={handleChange} required />
//         <Input type="password" name="password" placeholder="Password" onChange={handleChange} required />
//         <Button type="submit">Signup</Button>
//       </Form>
//     </Container>
//   );
// }

// export default Signup;






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
//   background: #007bff;
//   color: white;
//   border: none;
//   cursor: pointer;
// `;

// function Signup() {
//   const navigate = useNavigate();
//   const [user, setUser] = useState({ fullName: "", email: "", passwordHash: "" });

//   const handleChange = (e) => {
//     setUser({ ...user, [e.target.name]: e.target.value });
//   };

//   const handleSubmit = async (e) => {
//     e.preventDefault();
    
//     // Ensure we're sending the correct field name
//     const newUser = {
//       fullName: user.fullName,
//       email: user.email,
//       passwordHash: user.passwordHash, // Using passwordHash as per API requirements
//     };

//     try {
//       await axios.post("http://localhost:5247/api/Users", newUser);
//       alert("Signup successful!");
//       navigate("/login");
//     } catch (error) {
//       console.error("Signup Error:", error.response?.data || error.message);
//       alert("Signup failed! Please try again.");
//     }
//   };

//   return (
//     <Container>
//       <h2>Signup</h2>
//       <Form onSubmit={handleSubmit}>
//         <Input type="text" name="fullName" placeholder="Full Name" value={user.fullName} onChange={handleChange} required />
//         <Input type="email" name="email" placeholder="Email" value={user.email} onChange={handleChange} required />
//         <Input type="password" name="passwordHash" placeholder="Password" value={user.passwordHash} onChange={handleChange} required />
//         <Button type="submit">Signup</Button>
//       </Form>
//     </Container>
//   );
// }

// export default Signup;








import React, { useState } from "react";
import styled from "styled-components";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 50px;
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 10px;
  width: 300px;
`;

const Input = styled.input`
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 5px;
`;

const Button = styled.button`
  padding: 10px;
  background: #007bff;
  color: white;
  border: none;
  cursor: pointer;
`;

function Signup() {
  const navigate = useNavigate();
  const [user, setUser] = useState({ fullName: "", email: "", passwordHash: "" });

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await axios.post("http://localhost:5247/api/Users/signup", user);
      alert("Signup successful!");
      navigate("/login");
    } catch (error) {
      console.error("Signup Error:", error.response?.data || error.message);
      alert("Signup failed! Please try again.");
    }
  };

  return (
    <Container>
      <h2>Signup</h2>
      <Form onSubmit={handleSubmit}>
        <Input type="text" name="fullName" placeholder="Full Name" value={user.fullName} onChange={handleChange} required />
        <Input type="email" name="email" placeholder="Email" value={user.email} onChange={handleChange} required />
        <Input type="password" name="passwordHash" placeholder="Password" value={user.passwordHash} onChange={handleChange} required />
        <Button type="submit">Signup</Button>
      </Form>
    </Container>
  );
}

export default Signup;
