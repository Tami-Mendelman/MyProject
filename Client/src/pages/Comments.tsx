
import React, { useEffect, useState } from "react";
import axios from "axios";

const Comments = () => {
  const [drivers, setDrivers] = useState([]);
  const [selectedDriverCode, setSelectedDriverCode] = useState("");
  const [description, setDescription] = useState("");

  const token = localStorage.getItem("token");
  const userId = localStorage.getItem("userId");

  useEffect(() => {
    axios
      .get("https://localhost:7091/api/Driver")
      .then((res) => {
        console.log("🚗 Loaded drivers:", res.data);
        setDrivers(res.data);
      })
      .catch((err) => console.error("Failed to load drivers", err));
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!token || !userId) {
      alert("You must be logged in to comment.");
      return;
    }

    try {
      await axios.post(
        "https://localhost:7091/api/Comments",
        {
          Description: description,
          DriverCode: parseInt(selectedDriverCode),
          UserId: parseInt(userId)
        },
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );
      alert("Comment submitted!");
      setDescription("");
    } catch (error) {
      alert("Failed to submit comment");
      console.error(error);
    }
  };

  return (
    <div className="p-4 max-w-xl mx-auto">
      <h2 className="text-2xl font-bold mb-4">Leave a Comment for a Driver</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <select
          className="w-full p-2 border rounded"
          value={selectedDriverCode}
          onChange={(e) => setSelectedDriverCode(e.target.value)}
          required
        >
          <option value="">Select a driver</option>
          {drivers.map((driver: any) => (
            <option key={driver.driverCode} value={driver.driverCode}>
              {driver.name}
            </option>
          ))}
        </select>

        <textarea
          className="w-full p-2 border rounded"
          rows={4}
          placeholder="Write your comment..."
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
        />

        <button
          type="submit"
          className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        >
          Submit Comment
        </button>
      </form>
    </div>
  );
};

export default Comments;
