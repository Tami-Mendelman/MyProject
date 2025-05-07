import React, { useEffect, useState } from "react";
import axios from "axios";

const Drivers = () => {
  const [drivers, setDrivers] = useState<any[]>([]);
  const [form, setForm] = useState({ name: "", phone: "", fileImage: null as File | null });
  const [editId, setEditId] = useState<number | null>(null);

  const fetchDrivers = async () => {
    const res = await axios.get("https://localhost:7091/api/Driver");
    setDrivers(res.data);
  };

  useEffect(() => {
    fetchDrivers();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, files } = e.target;
    if (name === "fileImage" && files) {
      setForm({ ...form, fileImage: files[0] });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("name", form.name);
    formData.append("phone", form.phone);
    if (form.fileImage) formData.append("fileImage", form.fileImage);

    try {
      if (editId !== null) {
        await axios.put(`https://localhost:5001/api/Driver/${editId}`, formData);
      } else {
        await axios.post("https://localhost:5001/api/Driver", formData);
      }
      setForm({ name: "", phone: "", fileImage: null });
      setEditId(null);
      fetchDrivers();
    } catch (error) {
      alert("Error saving driver");
    }
  };

  const handleDelete = async (id: number) => {
    await axios.delete(`https://localhost:5001/api/Driver/${id}`);
    fetchDrivers();
  };

  const handleEdit = (driver: any) => {
    setForm({ name: driver.name, phone: driver.phone, fileImage: null });
    setEditId(driver.id);
  };

  return (
    <div className="p-6 max-w-4xl mx-auto">
      <h2 className="text-2xl font-bold mb-4">Drivers</h2>
      <form onSubmit={handleSubmit} className="space-y-2 mb-6">
        <input name="name" value={form.name} onChange={handleChange} placeholder="Name" className="border p-2 rounded w-full" />
        <input name="phone" value={form.phone} onChange={handleChange} placeholder="Phone" className="border p-2 rounded w-full" />
        <input name="fileImage" type="file" onChange={handleChange} className="w-full" />
        <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">{editId !== null ? "Update" : "Add"} Driver</button>
      </form>

      <ul className="space-y-2">
        {drivers.map((d) => (
          <li key={d.id} className="border p-3 rounded flex justify-between items-center">
            <div>
              <div><strong>{d.name}</strong> – {d.phone}</div>
            </div>
            <div className="space-x-2">
              <button onClick={() => handleEdit(d)} className="bg-yellow-400 px-3 py-1 rounded">Edit</button>
              <button onClick={() => handleDelete(d.id)} className="bg-red-500 text-white px-3 py-1 rounded">Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Drivers;