
// import React, { useState } from "react";
// import { useNavigate } from "react-router-dom";
// import axios from "axios";

// const Login = () => {
//   const [name, setName] = useState("");
//   const [password, setPassword] = useState("");
//   const navigate = useNavigate();

//   const handleLogin = async (e: React.FormEvent) => {
//     e.preventDefault();
//     const formData = new FormData();
//     formData.append("name", name);
//     formData.append("password", password);

//     try {
//       const response = await axios.post("https://localhost:7091/api/Login/login", formData);

//       localStorage.setItem("token", response.data.token);   // ✅ שמירה נכונה של הטוקן
//       localStorage.setItem("userId", response.data.userId); // ✅ שמירה של userId

//       navigate("/");
//     } catch (err) {
//       alert("Login failed");
//     }
//   };

//   return (
//     <div className="p-6 max-w-md mx-auto">
//       <h2 className="text-2xl mb-4 font-bold">Login</h2>
//       <form onSubmit={handleLogin} className="space-y-4">
//         <input
//           type="text"
//           placeholder="Username"
//           value={name}
//           onChange={(e) => setName(e.target.value)}
//           className="border p-2 w-full rounded"
//         />
//         <input
//           type="password"
//           placeholder="Password"
//           value={password}
//           onChange={(e) => setPassword(e.target.value)}
//           className="border p-2 w-full rounded"
//         />
//         <button type="submit" className="bg-blue-600 text-white p-2 rounded w-full">
//           Login
//         </button>
//       </form>
//     </div>
//   );
// };

// export default Login;
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

const Login = () => {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    const formData = new FormData();
    formData.append("name", name);
    formData.append("password", password);

    try {
      const response = await axios.post("https://localhost:7091/api/Login/login", formData);

      const { token, userId, role } = response.data;

      localStorage.setItem("token", token);
      localStorage.setItem("userId", userId);
      localStorage.setItem("role", role); // 👈 קריטי!

      if (role === "Driver") navigate("/driver-dashboard");
      else navigate("/user-dashboard");
    } catch (err) {
      alert("Login failed");
    }
  };

  return (
    <div className="p-6 max-w-md mx-auto">
      <h2 className="text-2xl mb-4 font-bold">Login</h2>
      <form onSubmit={handleLogin} className="space-y-4">
        <input type="text" placeholder="Username" value={name} onChange={(e) => setName(e.target.value)} className="border p-2 w-full rounded" />
        <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} className="border p-2 w-full rounded" />
        <button type="submit" className="bg-blue-600 text-white p-2 rounded w-full">Login</button>
      </form>
    </div>
  );
};

export default Login;
