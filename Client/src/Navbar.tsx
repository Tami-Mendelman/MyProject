// // import React from "react";
// // import { Link, useNavigate } from "react-router-dom";

// // const Navbar = () => {
// //   const navigate = useNavigate();
// //   const token = localStorage.getItem("token");

// //   const handleLogout = () => {
// //     localStorage.removeItem("token");
// //     navigate("/login");
// //   };

// //   return (
// //     <nav className="bg-gray-800 text-white px-6 py-3 flex justify-between items-center shadow">
// //       <div className="space-x-4">
// //         <Link to="/" className="hover:underline">Home</Link>
// //         {token && (
// //           <>
// //             <Link to="/drivers" className="hover:underline">Drivers</Link>
// //             <Link to="/destinations" className="hover:underline">Destinations</Link>
// //             <Link to="/comments" className="hover:underline">Comments</Link>
// //             <Link to="/timetable" className="hover:underline">Timetable</Link>
// //           </>
// //         )}
// //       </div>
// //       <div className="space-x-4">
// //         {!token ? (
// //           <>
// //             <Link to="/login" className="hover:underline">Login</Link>
// //             <Link to="/register" className="hover:underline">Register</Link>
// //           </>
// //         ) : (
// //           <button onClick={handleLogout} className="bg-red-500 hover:bg-red-600 px-3 py-1 rounded">Logout</button>
// //         )}
// //       </div>
// //     </nav>
// //   );
// // };

// // export default Navbar;
// import React, { useEffect, useState } from "react";
// import { Link, useNavigate } from "react-router-dom";
// import axios from "axios";

// const Navbar = () => {
//   const navigate = useNavigate();
//   const token = localStorage.getItem("token");
//   const userId = localStorage.getItem("userId");
//   const role = localStorage.getItem("role");

//   const [user, setUser] = useState<any>(null);

//   useEffect(() => {
//     if (!token || !userId || !role) return;

//     let endpoint = "";
//     if (role === "Driver") {
//       endpoint = `https://localhost:7091/api/Driver/${userId}`;
//     } else if (role === "User") {
//       endpoint = `https://localhost:7091/api/User/${userId}`;
//     } else {
//       console.warn("role לא חוקי ב-localStorage:", role);
//       return;
//     }

//     axios
//       .get(endpoint)
//       .then((res) => setUser(res.data))
//       .catch((err) => {
//         console.error("שגיאה בטעינת נתוני המשתמש:", err);
//         setUser(null);
//       });
//   }, []);

//   const handleLogout = () => {
//     localStorage.clear();
//     navigate("/login");
//   };

//   return (
//     <nav className="bg-gray-800 text-white px-6 py-3 flex justify-between items-center shadow">
//       <div className="space-x-4">
//         <Link to="/" className="hover:underline">Home</Link>
//         {token && (
//           <>
//             <Link to="/drivers" className="hover:underline">Drivers</Link>
//             <Link to="/destinations" className="hover:underline">Destinations</Link>
//             <Link to="/comments" className="hover:underline">Comments</Link>
//             <Link to="/timetable" className="hover:underline">Timetable</Link>
//           </>
//         )}
//       </div>

//       <div className="flex items-center gap-4">
//         {user && (
//           <>
//             <span>שלום ל: {user.name}</span>
//             {user.arrImage && (
//               <img
//                 src={`data:image/jpeg;base64,${user.arrImage}`}
//                 alt="תמונה"
//                 className="w-8 h-8 rounded-full border"
//               />
//             )}
//           </>
//         )}
//         {token ? (
//           <button onClick={handleLogout} className="bg-red-500 hover:bg-red-600 px-3 py-1 rounded">Logout</button>
//         ) : (
//           <>
//             <Link to="/login" className="hover:underline">Login</Link>
//             <Link to="/register" className="hover:underline">Register</Link>
//           </>
//         )}
//       </div>
//     </nav>
//   );
// };

// export default Navbar;
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import ProfileImage from "./pages/ProfileImage"; // ודאי שהנתיב נכון

const Navbar = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem("token");

  const handleLogout = () => {
    localStorage.clear();
    navigate("/login");
  };

  return (
    <nav className="sticky top-0 z-50 bg-gray-800 text-white px-6 py-3 flex justify-between items-center shadow-md">
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

      <div className="flex items-center gap-4">
        {token ? (
          <>
            <ProfileImage />
            <button
              onClick={handleLogout}
              className="bg-red-500 hover:bg-red-600 px-3 py-1 rounded"
            >
              Logout
            </button>
          </>
        ) : (
          <>
            <Link to="/login" className="hover:underline">Login</Link>
            <Link to="/register" className="hover:underline">Register</Link>
          </>
        )}
      </div>
    </nav>
  );
};

export default Navbar;

