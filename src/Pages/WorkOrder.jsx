import React from "react";
import styled from "styled-components";

const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #e8effe;
  min-height: 100vh;
  padding: 20px;
  margin-left: 250px; /* Adjusted to account for sidebar width */
`;

const Heading = styled.h1`
  text-align: center;
`;

const Wrapper = styled.div`
  width: 100%;
  max-width: 800px;
  background: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  padding: 20px;
`;

const Grid = styled.div`
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 20px;
  margin-bottom: 20px;
`;

const Label = styled.label`
  font-weight: 500;
  width: 100px;
`;

const Input = styled.input`
  flex: 1;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  font-size: 14px;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const TableContainer = styled.div`
  overflow-x: auto;
  margin-bottom: 20px;
`;

const Table = styled.table`
  width: 100%;
  border-collapse: collapse;
`;

const Th = styled.th`
  background: #3478f6;
  color: white;
  padding: 10px;
  border: 1px solid #ccc;
  text-align: left;
`;

const Td = styled.td`
  padding: 10px;
  border: 1px solid #ccc;
`;

const ButtonGroup = styled.div`
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
`;

const Button = styled.button`
  background: #3478f6;
  color: white;
  padding: 10px 20px;
  font-size: 14px;
  font-weight: 500;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: background 0.3s;
  margin: 5px;

  &:hover {
    background: #285fc4;
  }

  &:active {
    transform: scale(0.98);
  }
`;

const WorkOrder = () => {
  return (
    <Container>
      <Wrapper>
        <Heading>Work Order</Heading>
        {/* Order Details */}
        <Grid>
          <div>
            <div style={{ display: "flex", alignItems: "center" }}>
              <Label>Order No:</Label>
              <Input placeholder="Enter Order No" />
            </div>
          </div>
          <div>
            <div style={{ display: "flex", alignItems: "center" }}>
              <Label>Outstanding:</Label>
              <Input placeholder="Enter Outstanding" />
            </div>
          </div>
        </Grid>

        {/* Table */}
        <TableContainer>
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
                <Td>Paper</Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
              </tr>
              <tr>
                <Td>Cover Page</Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
              </tr>
              <tr>
                <Td>Add Ons</Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
                <Td></Td>
              </tr>
            </tbody>
          </Table>
        </TableContainer>

        {/* Amount Details */}
        <Grid>
          <div>
            <div style={{ display: "flex", alignItems: "center" }}>
              <Label>Amount:</Label>
              <Input placeholder="Enter Amount" />
            </div>
            <div
              style={{
                display: "flex",
                alignItems: "center",
                marginTop: "10px",
              }}
            >
              <Label>Discount:</Label>
              <Input placeholder="Enter Discount" />
            </div>
          </div>
          <div>
            <div style={{ display: "flex", alignItems: "center" }}>
              <Label>Net Amount:</Label>
              <Input placeholder="Enter Net Amount" />
            </div>
            <div
              style={{
                display: "flex",
                alignItems: "center",
                marginTop: "10px",
              }}
            >
              <Label>Advance:</Label>
              <Input placeholder="Enter Advance" />
            </div>
          </div>
        </Grid>

        {/* Buttons */}
        <ButtonGroup>
          <Button>Save & Invoice</Button>
          <Button>Save</Button>
          <Button>Edit</Button>
          <Button>Cancel</Button>
          <Button>Refresh</Button>
          <Button>Exit</Button>
        </ButtonGroup>
      </Wrapper>
    </Container>
  );
};

export default WorkOrder;
