import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import WorkOrder from "../Pages/WorkOrder";
import QualityCheck from "../Pages/QualityCheck";
import Remarks from "../Pages/Remarks";
import CustomerForm from "../Pages/CustomerForm";
import MainLayout from "../Layouts/MainLayout";
import DirectWorkOrder from "../Pages/DirectWorkOrder";
import Login_Logout from "../Pages/Login-Logout-Handler";

function AppRouter() {
  return (
    <div>
      <Router>
        <MainLayout>
          <Routes>
          <Route path="/" element={<Login_Logout />} />
            <Route path="/workorder" element={<WorkOrder />} />
            <Route path="/directworkorder" element={<DirectWorkOrder />} />
            <Route path="/login" element={<Login_Logout/>} />
            <Route path="/customerform" element={<CustomerForm />} />
            <Route path="/qualitycheck" element={<QualityCheck />} />
            <Route path="/remarks" element={<Remarks />} />
          </Routes>
        </MainLayout>
      </Router>
    </div>
  );
}

export default AppRouter;
