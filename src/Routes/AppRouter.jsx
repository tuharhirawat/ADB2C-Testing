import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import WorkOrder from "../Pages/WorkOrder";
import QualityCheck from "../Pages/QualityCheck";
import Remarks from "../Pages/Remarks";
import CustomerForm from "../Pages/CustomerForm";
import MainLayout from "../Layouts/MainLayout";
import DirectWorkOrder from "../Pages/DirectWorkOrder";
import Login_Logout from "../Pages/Login-Logout-Handler";
import NormalSignup from "../Components/NormalSignup";
import NormalLogin from "../Components/NormalLogin";

function AppRouter() {
  return (
    <div>
      <Router>
        <MainLayout>
          <Routes>
          <Route path="/" element={<Login_Logout />} />
            <Route path="/workorder" element={<WorkOrder />} />
            <Route path="/directworkorder" element={<DirectWorkOrder />} />
            <Route path="/azure_login" element={<Login_Logout/>} />
            <Route path="/customerform" element={<CustomerForm />} />
            <Route path="/qualitycheck" element={<QualityCheck />} />
            <Route path="/remarks" element={<Remarks />} />
            <Route path="/signup" element={<NormalSignup />} />
            <Route path="/login" element={<NormalLogin />} />
          </Routes>
        </MainLayout>
      </Router>
    </div>
  );
}

export default AppRouter;
