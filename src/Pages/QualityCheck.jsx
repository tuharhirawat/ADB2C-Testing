import React from "react";
import styled from "styled-components";

const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #e8effe;
  min-height: 100vh;
  padding: 20px;
  margin-left: 250px;
`;

const Wrapper = styled.div`
  width: 100%;
  max-width: 800px; /* Increased the width to 900px */
  background: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  padding: 30px; /* Increased padding for more space */
`;

const Title = styled.h2`
  text-align: center;
  font-size: 28px; /* Increased font size */
  font-weight: 600;
  color: #333;
  margin-bottom: 30px; /* Increased margin for spacing */
`;

const Form = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 30px; /* Increased gap between fields */

  & > div {
    display: flex;
    flex-direction: column;
  }
`;

const Label = styled.label`
  font-weight: 500;
  margin-bottom: 8px; /* Increased margin for better spacing */
  font-size: 16px; /* Increased font size */
`;

const Input = styled.input`
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 15px; /* Increased padding for more space inside inputs */
  font-size: 16px; /* Increased font size */

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const TextArea = styled.textarea`
  grid-column: 1 / -1;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 15px; /* Increased padding */
  font-size: 16px; /* Increased font size */
  resize: vertical;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const ButtonGroupWrapper = styled.div`
  width: 100%;
`;

const ButtonGroup = styled.div`
  display: flex;
  gap: 20px; /* Increased gap between buttons */
  justify-content: center;
`;

const Button = styled.button`
  background: #3478f6;
  color: white;
  padding: 12px 25px; /* Increased padding for buttons */
  font-size: 16px; /* Increased font size */
  font-weight: 500;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: background 0.3s;

  &:hover {
    background: #285fc4;
  }

  &:active {
    transform: scale(0.98);
  }
`;

const QualityCheck = () => {
  return (
    <Container>
      <Wrapper>
        <Title>Quality Check</Title>
        <Form>
          <div>
            <Label>Order No</Label>
            <Input placeholder="Enter Order No" />
          </div>
          <div>
            <Label>Name</Label>
            <Input placeholder="Enter Name" />
          </div>
          <div>
            <Label>Date</Label>
            <Input type="date" />
          </div>
          <div>
            <Label>Time</Label>
            <Input type="time" />
          </div>
          <TextArea rows="4" placeholder="Enter Remarks"></TextArea>
          <ButtonGroupWrapper>
            <ButtonGroup>
              <Button>Save</Button>
              <Button>Edit</Button>
              <Button>Refresh</Button>
              <Button>Exit</Button>
            </ButtonGroup>
          </ButtonGroupWrapper>
        </Form>
      </Wrapper>
    </Container>
  );
};

export default QualityCheck;
