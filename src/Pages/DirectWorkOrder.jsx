import React from "react";
import styled from "styled-components";

const Container = styled.div`
  max-width: 995px;
  margin: 19px auto;
  padding: 30px;
  background-color: #f9f9f9;
  border-radius: 15px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  position: relative;
  left: 126px;
  transition: left 0.3s ease;
  @media (max-width: 768px) {
    left: 0; /* For smaller screens, the form will occupy full width */
    margin: 20px;
  }
`;
const Title = styled.h3`
  text-align: center;
  margin-bottom: 40px;
  font-size: 28px;
  color: #222222;
  font-weight: 700;
`;

const Grid = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 20px;

  @media (max-width: 768px) {
    grid-template-columns: 1fr;
  }
`;

const FormGroup = styled.div`
  margin-bottom: 25px;
`;

const Label = styled.label`
  display: block;
  margin-bottom: 10px;
  font-weight: 600;
  color: #444444;
`;

const Input = styled.input`
  width: 70%;
  padding: 14px;
  border: 1px solid #dddddd;
  border-radius: 8px;
  font-size: 15px;
  background-color: #ffffff;
  transition: border-color 0.3s;

  &:focus {
    border-color: #007bff;
    outline: none;
  }
`;

const Select = styled.select`
  width: 100%;
  padding: 14px;
  border: 1px solid #dddddd;
  border-radius: 8px;
  font-size: 15px;
  background-color: #fafafa;
  transition: border-color 0.3s;

  &:focus {
    border-color: #007bff;
    outline: none;
  }
`;

const TextArea = styled.textarea`
  width: 70%;
  padding: 14px;
  border: 1px solid #dddddd;
  border-radius: 8px;
  resize: vertical;
  font-size: 15px;
  background-color: #ffffff;
  transition: border-color 0.3s;

  &:focus {
    border-color: #007bff;
    outline: none;
  }
`;

const Table = styled.table`
  width: 100%;
  border-collapse: collapse;
  margin-top: 1rem;
  background-color: #f8f8f8;
  border-radius: 12px;
  overflow: hidden;
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.1);
`;

const Th = styled.th`
  background-color: #4769d9;
  color: #ffffff;
  padding: 12px;
  text-align: center;
`;

const Td = styled.td`
  border: 1px solid #d1d5db;
  padding: 12px;
  text-align: center;
  background-color: #ffffff;
`;

const PaymentMode = styled.div`
  display: flex;
  align-items: center;
  gap: 20px;
  margin-top: 20px;
`;

const CheckboxContainer = styled.div`
  display: flex;
  align-items: center;
  margin-top: 20px;
`;

const ButtonGroup = styled.div`
  text-align: center;
  margin-top: 40px;
`;

const Button = styled.button`
  margin: 10px;
  padding: 14px 30px;
  border: none;
  border-radius: 8px;
  color: #ffffff;
  font-size: 17px;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.3s, transform 0.2s;

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
    transform: translateY(-3px);
    opacity: 0.95;
  }
`;

const DirectWorkOrder = () => {
  return (
    <Container>
      <Title>Direct Work Order</Title>

      <Grid>
        <FormGroup>
          <Label>Order No</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Outstanding</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Order Date</Label>
          <Input type="datetime-local" />
        </FormGroup>
      </Grid>

      <Grid>
        <FormGroup>
          <Label>Studio New</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Name</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Delivery Date & Time</Label>
          <Input type="datetime-local" />
        </FormGroup>
        <FormGroup>
          <Label>Studio</Label>
          <Input type="text" />
        </FormGroup>
      </Grid>

      <Grid>
        <FormGroup>
          <Label>Address</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Mobile No</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Delivery Mode</Label>
          <Select>
            <option>Counter</option>
            <option>Home Delivery</option>
          </Select>
        </FormGroup>
        <FormGroup>
          <Label>Delivery SubMode</Label>
          <Select>
            <option>....</option>
            <option>....</option>
          </Select>
        </FormGroup>
      </Grid>

      <FormGroup>
        <Label>Remarks</Label>
        <TextArea rows="4"></TextArea>
      </FormGroup>

      <Table>
        <thead>
          <tr>
            <Th>Main Head</Th>
            <Th>Subhead</Th>
            <Th>Qty</Th>
            <Th>Rate</Th>
            <Th>GTotal</Th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <Td>
              <Input type="text" />
            </Td>
            <Td>
              <Input type="text" />
            </Td>
            <Td>
              <Input type="number" />
            </Td>
            <Td>
              <Input type="number" />
            </Td>
            <Td>
              <Input type="number" readOnly />
            </Td>
          </tr>
        </tbody>
      </Table>

      <Grid>
        <FormGroup>
          <Label>Amount</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Discount</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Sub Amount</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Tax</Label>
          <Input type="text" />
        </FormGroup>
      </Grid>

      <Grid>
        <FormGroup>
          <Label>Cess</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Net Amount</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Advance</Label>
          <Input type="text" />
        </FormGroup>
        <FormGroup>
          <Label>Balance</Label>
          <Input type="text" />
        </FormGroup>
      </Grid>

      <FormGroup>
        <Label>Payment Mode</Label>
        <PaymentMode>
          <div>
            <Input type="radio" name="payment" id="cash" />
            <Label htmlFor="cash">Cash</Label>
          </div>
          <div>
            <Input type="radio" name="payment" id="bank" />
            <Label htmlFor="bank">Bank</Label>
          </div>
          <div>
            <Input type="radio" name="payment" id="card" />
            <Label htmlFor="card">Card</Label>
          </div>
          <div>
            <Input type="radio" name="payment" id="upi" />
            <Label htmlFor="upi">UPI</Label>
          </div>
        </PaymentMode>
      </FormGroup>

      <CheckboxContainer>
        <Input type="checkbox" id="viewPrint" />
        <Label htmlFor="viewPrint">View Print</Label>
      </CheckboxContainer>

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

export default DirectWorkOrder;
