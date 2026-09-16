import { BrowserRouter, Route, Routes } from "react-router-dom";

import { DashboardPage } from "../pages/DashboardPage";
import { DeliveriesPage } from "../pages/DeliveriesPage";
import { DriversPage } from "../pages/DriversPage";

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DashboardPage />} />
        <Route path="/deliveries" element={<DeliveriesPage />} />
        <Route path="/drivers" element={<DriversPage />} />
      </Routes>
    </BrowserRouter>
  );
}