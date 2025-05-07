import React, { useEffect, useState } from "react";
import axios from "axios";

const Timetable = () => {
  const [timetables, setTimetables] = useState<any[]>([]);
  const [form, setForm] = useState({ day: "", hour: "", driverId: "", destinationId: "" });
  const [editId, setEditId] = useState<number | null>(null);

  const fetchData = async () => {
    const res = await axios.get("https://localhost:7091/api/Timetable");
    setTimetables(res.data);
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("day", form.day);
    formData.append("hour", form.hour);
    formData.append("driverId", form.driverId);
    formData.append("destinationId", form.destinationId);

    try {
      if (editId !== null) {
        await axios.put(`https://localhost:5001/api/Timetable/${editId}`, formData);
      } else {
        await axios.post("https://localhost:5001/api/Timetable", formData);
      }
      setForm({ day: "", hour: "", driverId: "", destinationId: "" });
      setEditId(null);
      fetchData();
    } catch (error) {
      alert("Error saving timetable");
    }
  };

  const handleDelete = async (id: number) => {
    await axios.delete(`https://localhost:5001/api/Timetable/${id}`);
    fetchData();
  };

  const handleEdit = (item: any) => {
    setForm({
      day: item.day,
      hour: item.hour,
      driverId: item.driverId,
      destinationId: item.destinationId,
    });
    setEditId(item.id);
  };

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h2 className="text-2xl font-bold mb-4">Timetable</h2>
      <form onSubmit={handleSubmit} className="grid grid-cols-2 gap-4 mb-6">
        <input name="day" value={form.day} onChange={handleChange} placeholder="Day" className="border p-2 rounded" />
        <input name="hour" value={form.hour} onChange={handleChange} placeholder="Hour" className="border p-2 rounded" />
        <input name="driverId" value={form.driverId} onChange={handleChange} placeholder="Driver ID" className="border p-2 rounded" />
        <input name="destinationId" value={form.destinationId} onChange={handleChange} placeholder="Destination ID" className="border p-2 rounded" />
        <button type="submit" className="col-span-2 bg-blue-600 text-white p-2 rounded">
          {editId !== null ? "Update" : "Add"} Timetable
        </button>
      </form>

      <ul className="space-y-2">
        {timetables.map((item) => (
          <li key={item.id} className="border p-3 rounded flex justify-between items-center">
            <div>
              <strong>{item.day}</strong> – {item.hour}, Driver #{item.driverId}, Destination #{item.destinationId}
            </div>
            <div className="space-x-2">
              <button onClick={() => handleEdit(item)} className="bg-yellow-400 px-3 py-1 rounded">Edit</button>
              <button onClick={() => handleDelete(item.id)} className="bg-red-500 text-white px-3 py-1 rounded">Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Timetable;