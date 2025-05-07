import React, { useState } from "react";
import axios from "axios";

const Register = () => {
  const [form, setForm] = useState({
    name: "",
    password: "",
    mail: "",
    role: ""
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("name", form.name);
    formData.append("password", form.password);
    formData.append("mail", form.mail);
    formData.append("role", form.role);

    try {
      const response = await axios.post("https://localhost:7091/api/Login", formData);
      alert("Registered successfully");
    } catch (error) {
      alert("Registration failed");
    }
  };

  return (
    <div className="p-6 max-w-md mx-auto">
      <h2 className="text-2xl font-bold mb-4">Register</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input name="name" value={form.name} onChange={handleChange} placeholder="Name" className="border p-2 w-full rounded" />
        <input name="password" value={form.password} onChange={handleChange} placeholder="Password" type="password" className="border p-2 w-full rounded" />
        <input name="mail" value={form.mail} onChange={handleChange} placeholder="Email" className="border p-2 w-full rounded" />
        <input name="role" value={form.role} onChange={handleChange} placeholder="Role" className="border p-2 w-full rounded" />
        <button type="submit" className="bg-green-600 text-white p-2 w-full rounded">Register</button>
      </form>
    </div>
  );
};

export default Register;