import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";

const NormalSignup = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSignup = async (e) => {
    e.preventDefault();
    setError("");

    try {
      await axios.post("http://localhost:5131/api/UserTable", { email, password });
      navigate("/workorder");
    } catch (err) {
      setError(err.response?.data?.message || "Signup failed!");
    }
  };

  return (
    <Container>
      <Form onSubmit={handleSignup}>
        <Title>Create an Account</Title>
        {error && <Error>{error}</Error>}
        <InputWrapper>
          <Label>Email:</Label>
          <Input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </InputWrapper>
        <InputWrapper>
          <Label>Password:</Label>
          <Input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </InputWrapper>
        <Button type="submit">Signup</Button>
        <Links>
          <a href="/login">Already have an account? Login</a>
        </Links>
      </Form>
    </Container>
  );
};

const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color:rgb(240, 240, 240);
`;

const Form = styled.form`
  background-color: #fff;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 400px;
`;

const Title = styled.h2`
  text-align: center;
  color: #ef5350;
  margin-bottom: 25px;
  font-size: 34px;
`;

const InputWrapper = styled.div`
  margin-bottom: 20px;
`;

const Label = styled.label`
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
  font-size: 22px;
`;

const Input = styled.input`
  width: 100%;
  padding: 12px;
  border: 1px solid #ddd;
  border-radius: 5px;
  font-size: 16px;
  box-sizing: border-box;
`;

const Button = styled.button`
  width: 100%;
  padding: 15px;
  background-color: #ef5350;
  color: white;
  border: none;
  font-size: 20px;
  border-radius: 5px;
  font-weight: bold;
  cursor: pointer;
`;

const Error = styled.p`
  color: #f44336;
  font-size: 14px;
  text-align: center;
`;

const Links = styled.div`
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
  font-size: 14px;
  a {
    color: #ef5350;
    text-decoration: none;
    font-size: 16px;
    &:hover {
      text-decoration: underline;
    }
  }
`;

export default NormalSignup;
