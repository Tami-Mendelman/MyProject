import React, { useEffect, useState } from "react";
import axios from "axios";

const Destinations = () => {
  const [destinations, setDestinations] = useState<any[]>([]);
  const [form, setForm] = useState({ name: "", city: "" });
  const [editId, setEditId] = useState<number | null>(null);

  const fetchDestinations = async () => {
    const res = await axios.get("https://localhost:7091/api/Destination");
    setDestinations(res.data);
  };

  useEffect(() => {
    fetchDestinations();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("name", form.name);
    formData.append("city", form.city);

    try {
      if (editId !== null) {
        await axios.put(`https://localhost:5001/api/Destination/${editId}`, formData);
      } else {
        await axios.post("https://localhost:5001/api/Destination", formData);
      }
      setForm({ name: "", city: "" });
      setEditId(null);
      fetchDestinations();
    } catch (error) {
      alert("Error saving destination");
    }
  };

  const handleDelete = async (id: number) => {
    await axios.delete(`https://localhost:5001/api/Destination/${id}`);
    fetchDestinations();
  };

  const handleEdit = (dest: any) => {
    setForm({ name: dest.name, city: dest.city });
    setEditId(dest.id);
  };

  return (
    <div className="p-6 max-w-4xl mx-auto">
      <h2 className="text-2xl font-bold mb-4">Destinations</h2>
      <form onSubmit={handleSubmit} className="space-y-2 mb-6">
        <input name="name" value={form.name} onChange={handleChange} placeholder="Name" className="border p-2 rounded w-full" />
        <input name="city" value={form.city} onChange={handleChange} placeholder="City" className="border p-2 rounded w-full" />
        <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">{editId !== null ? "Update" : "Add"} Destination</button>
      </form>

      <ul className="space-y-2">
        {destinations.map((d) => (
          <li key={d.id} className="border p-3 rounded flex justify-between items-center">
            <div><strong>{d.name}</strong> – {d.city}</div>
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

export default Destinations;