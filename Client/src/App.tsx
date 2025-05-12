import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Home from "./pages/Home";
import Drivers from "./pages/Drivers";
import Destinations from "./pages/Destinations";
import Comments from "./pages/Comments";
import Timetable from "./pages/Timetable";
import NotFound from "./pages/NotFound";
import ProtectedRoute from "./ProtectedRoute";
import DriverDashboard from "./pages/DriverDashboard";
import UserDashboard from "./pages/UserDashboard";


import Navbar from "./Navbar";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/drivers" element={<ProtectedRoute><Drivers /></ProtectedRoute>} />
        <Route path="/destinations" element={<ProtectedRoute><Destinations /></ProtectedRoute>} />
        <Route path="/comments" element={<ProtectedRoute><Comments /></ProtectedRoute>} />
        <Route path="/timetable" element={<ProtectedRoute><Timetable /></ProtectedRoute>} />
        <Route path="*" element={<NotFound />} />
        <Route path="/driver-dashboard" element={<ProtectedRoute><DriverDashboard /></ProtectedRoute>} />
<Route path="/user-dashboard" element={<ProtectedRoute><UserDashboard /></ProtectedRoute>} />

      </Routes>
    </Router>
  );
}

export default App;