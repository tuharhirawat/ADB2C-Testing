import React from "react";
import styled from "styled-components";

const Container = styled.div`
  background-color: #e8effe;
  min-height: 100vh;
  padding: 20px;
  display: flex;
  justify-content: center;
  padding-left: 275px; /* Adjust the value based on the width of your side menu */
`;

const Wrapper = styled.div`
  max-width: 1200px;
  margin: 0 auto;
  background: #ffffff;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  width: 100%;
`;

const Title = styled.h2`
  font-size: 24px;
  color: #3478f6;
  margin-bottom: 20px;
`;

const Header = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 20px;
`;

const Label = styled.label`
  font-weight: 500;
  font-size: 16px;
`;

const Input = styled.input`
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  font-size: 14px;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const ButtonGroup = styled.div`
  display: flex;
  gap: 10px;
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

  &:hover {
    background: #285fc4;
  }

  &:active {
    transform: scale(0.98);
  }
`;

const TableWrapper = styled.div`
  margin-top: 20px;
  overflow-x: auto;
`;

const Table = styled.table`
  width: 100%;
  border-collapse: collapse;
  text-align: left;
`;

const Thead = styled.thead`
  background-color: #3478f6;
  color: white;
`;

const Th = styled.th`
  padding: 10px;
  font-size: 14px;
`;

const Tbody = styled.tbody`
  & > tr:nth-child(even) {
    background-color: #f3f3f3;
  }
`;

const Tr = styled.tr``;

const Td = styled.td`
  padding: 10px;
  font-size: 14px;
  border: 1px solid #ccc;
`;

const Remarks = () => {
  return (
    <Container>
      <Wrapper>
        <Title>Delivery Details</Title>
        <Header>
          <div>
            <Label>Date</Label>
            <Input type="date" />
          </div>
          <ButtonGroup>
            <Button>View All</Button>
            <Button>Refresh</Button>
            <Button>Exit</Button>
          </ButtonGroup>
        </Header>
        <TableWrapper>
          <Table>
            <Thead>
              <Tr>
                <Th>Sl No</Th>
                <Th>Customer Name</Th>
                <Th>Studio Name</Th>
                <Th>WorkOrderNo (BillNo)</Th>
                <Th>Invoice Amount</Th>
                <Th>Paid Amount</Th>
                <Th>Mobile No</Th>
                <Th>Remarks</Th>
              </Tr>
            </Thead>
            <Tbody>
              <Tr>
                <Td>1</Td>
                <Td>ROHIT YELAMANCHILI</Td>
                <Td>YALAMANCHILI CC</Td>
                <Td>MR-B-2866 (5)</Td>
                <Td>2620.00</Td>
                <Td>0.00</Td>
                <Td>+917799324242</Td>
                <Td>Remarks</Td>
              </Tr>
              <Tr>
                <Td>2</Td>
                <Td>ROHIT YELAMANCHILI</Td>
                <Td>YALAMANCHILI CC</Td>
                <Td>MR-B-2867 (5)</Td>
                <Td>1360.00</Td>
                <Td>0.00</Td>
                <Td>+917799324242</Td>
                <Td>Remarks</Td>
              </Tr>
            </Tbody>
          </Table>
        </TableWrapper>
      </Wrapper>
    </Container>
  );
};

export default Remarks;
