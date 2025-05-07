import React from "react";
import { Link, useNavigate } from "react-router-dom";

const Navbar = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem("token");

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate("/login");
  };

  return (
    <nav className="bg-gray-800 text-white px-6 py-3 flex justify-between items-center shadow">
      <div className="space-x-4">
        <Link to="/" className="hover:underline">Home</Link>
        {token && (
          <>
            <Link to="/drivers" className="hover:underline">Drivers</Link>
            <Link to="/destinations" className="hover:underline">Destinations</Link>
            <Link to="/comments" className="hover:underline">Comments</Link>
            <Link to="/timetable" className="hover:underline">Timetable</Link>
          </>
        )}
      </div>
      <div className="space-x-4">
        {!token ? (
          <>
            <Link to="/login" className="hover:underline">Login</Link>
            <Link to="/register" className="hover:underline">Register</Link>
          </>
        ) : (
          <button onClick={handleLogout} className="bg-red-500 hover:bg-red-600 px-3 py-1 rounded">Logout</button>
        )}
      </div>
    </nav>
  );
};

export default Navbar;