import React from "react";
import styled from "styled-components";

const Container = styled.div`
  width: 90%;
  max-width: 1005px;
  margin: 5vh auto; /* Centers vertically */
  padding: 20px;
  background-color: #f9f9f9;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Title = styled.h3`
  text-align: center;
  margin-bottom: 30px;
  font-size: 24px;
  color: #333;
`;

const Form = styled.form`
  display: flex;
  flex-wrap: wrap;
  gap: 30px;
  justify-content: center;
  width: 100%;

  @media (max-width: 768px) {
    flex-direction: column;
  }
`;

const Column = styled.div`
  flex: 1;
  min-width: 320px; /* Ensures it doesn't shrink too much */
  background-color: #fff;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 100%;
`;

const FormGroup = styled.div`
  margin-bottom: 20px;
  display: flex;
  flex-direction: column;
`;

const Label = styled.label`
  font-weight: bold;
  color: #555;
  margin-bottom: 5px;
`;

const Input = styled.input`
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
`;

const Select = styled.select`
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
`;

const TextArea = styled.textarea`
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  resize: vertical;
  font-size: 14px;
`;

const ButtonGroup = styled.div`
  text-align: center;
  margin-top: 30px;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 10px;
`;

const Button = styled.button`
  padding: 12px 25px;
  border: none;
  border-radius: 5px;
  color: #fff;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;

  &.save {
    background-color: #28a745;
  }
  &.edit {
    background-color: #007bff;
  }
  &.delete {
    background-color: #dc3545;
  }
  &.refresh {
    background-color: #6c757d;
  }
  &.exit {
    background-color: #343a40;
  }

  &:hover {
    opacity: 0.9;
  }
`;

const CustomerForm = () => {
  return (
    <Container>
      <Title>Customer Form</Title>
      <Form>
        <Column>
          <FormGroup>
            <Label>Name / Code *</Label>
            <Input type="text" required />
          </FormGroup>

          <FormGroup>
            <Label>Region</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Type</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Studio Name</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Address 1 *</Label>
            <Input type="text" required />
          </FormGroup>

          <FormGroup>
            <Label>Address 2</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Pincode *</Label>
            <Input type="text" required />
          </FormGroup>

          <FormGroup>
            <Label>City *</Label>
            <Input type="text" required />
          </FormGroup>

          <FormGroup>
            <Label>State *</Label>
            <Input type="text" required />
          </FormGroup>

          <FormGroup>
            <Label>Phone No</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Mobile *</Label>
            <Input type="text" required />
          </FormGroup>
        </Column>

        <Column>
          <FormGroup>
            <Label>GST NO</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Discount (%)</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Email</Label>
            <Input type="email" />
          </FormGroup>

          <FormGroup>
            <Label>Remarks</Label>
            <TextArea rows="4" />
          </FormGroup>

          <FormGroup>
            <Label>Rate Mode *</Label>
            <Select required>
              <option>Normal Rate</option>
              <option>Discount Rate</option>
              <option>Offer Rate</option>
            </Select>
          </FormGroup>

          <FormGroup>
            <Label>Credit Amount</Label>
            <Input type="text" />
          </FormGroup>

          <FormGroup>
            <Label>Category *</Label>
            <Input type="text" required />
          </FormGroup>
        </Column>
      </Form>

      <ButtonGroup>
        <Button type="submit" className="save">
          Save
        </Button>
        <Button type="button" className="edit">
          Edit
        </Button>
        <Button type="button" className="delete">
          Delete
        </Button>
        <Button type="button" className="refresh">
          Refresh
        </Button>
        <Button type="button" className="exit">
          Exit
        </Button>
      </ButtonGroup>
    </Container>
  );
};

export default CustomerForm;
