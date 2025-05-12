
// import React, { useState } from "react";
// import axios from "axios";

// const Register = () => {
//   const [form, setForm] = useState({
//     name: "",
//     password: "",
//     mail: "",
//     role: "User", // או Driver
//   });
//   const [fileImage, setFileImage] = useState<File | null>(null);

//   const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
//     setForm({ ...form, [e.target.name]: e.target.value });
//   };

//   const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
//     if (e.target.files && e.target.files[0]) {
//       setFileImage(e.target.files[0]);
//     }
//   };

//   const handleSubmit = async (e: React.FormEvent) => {
//     e.preventDefault();

//     const formData = new FormData();
//     formData.append("Name", form.name);
//     formData.append("Password", form.password);
//     formData.append("Mail", form.mail);
//     formData.append("Role", form.role);
//     if (fileImage) {
//       formData.append("fileImage", fileImage);
//     }

//     // הדפסת כל מה שנשלח
//     for (const pair of formData.entries()) {
//       console.log(pair[0], pair[1]);
//     }

//     const url =
//       form.role === "User"
//         ? "https://localhost:7091/api/User"
//         : "https://localhost:7091/api/Driver";

//     try {
//       const response = await axios.post(url, formData, {
//         headers: { "Content-Type": "multipart/form-data" },
//       });
//       alert("נרשמת בהצלחה");
//     } catch (error: any) {
//       if (error.response && error.response.data) {
//         console.error("שגיאה מהשרת:", error.response.data);
//         alert("שגיאה בהרשמה:\n" + JSON.stringify(error.response.data.errors, null, 2));
//       } else {
//         alert("שגיאה כללית בשליחה");
//       }
//     }
//   };

//   return (
//     <div className="p-6 max-w-md mx-auto">
//       <h2 className="text-2xl font-bold mb-4">הרשמה</h2>
//       <form onSubmit={handleSubmit} className="space-y-4">
//         <input name="name" value={form.name} onChange={handleChange} placeholder="שם מלא" className="border p-2 w-full rounded" />
//         <input name="password" type="password" value={form.password} onChange={handleChange} placeholder="סיסמה" className="border p-2 w-full rounded" />
//         <input name="mail" value={form.mail} onChange={handleChange} placeholder="מייל" className="border p-2 w-full rounded" />
        
//         <select name="role" value={form.role} onChange={handleChange} className="border p-2 w-full rounded">
//           <option value="User">משתמש רגיל</option>
//           <option value="Driver">נהג</option>
//         </select>

//         <input type="file" onChange={handleFileChange} accept="image/*" className="border p-2 w-full rounded" />

//         <button type="submit" className="bg-green-600 text-white p-2 w-full rounded">הרשם</button>
//       </form>
//     </div>
//   );
// };

// export default Register;
import React, { useState } from "react";
import axios from "axios";

const Register = () => {
  const [form, setForm] = useState({
    name: "",
    password: "",
    mail: "",
    role: "User", // או Driver
    accessible: false,
    trunk: false,
    numberOfSeatsInTheCar: 4,
  });
  const [fileImage, setFileImage] = useState<File | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value, type } = e.target;

    if (type === "checkbox") {
      const checked = (e.target as HTMLInputElement).checked;
      setForm({ ...form, [name]: checked });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      setFileImage(e.target.files[0]);
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const formData = new FormData();
    formData.append("Name", form.name);
    formData.append("Password", form.password);
    formData.append("Mail", form.mail);
    if (fileImage) {
      formData.append("fileImage", fileImage);
    }

    let url = "";

    if (form.role === "User") {
      formData.append("Role", "User");
      url = "https://localhost:7091/api/User";
    } else {
      formData.append("Accessible", String(form.accessible));
      formData.append("Trunk", String(form.trunk));
      formData.append("NumberOfSeatsInTheCar", String(form.numberOfSeatsInTheCar));
      url = "https://localhost:7091/api/Driver";
    }

    for (const pair of formData.entries()) {
      console.log(pair[0], pair[1]);
    }

    try {
      const response = await axios.post(url, formData, {
        headers: { "Content-Type": "multipart/form-data" },
      });
      alert("נרשמת בהצלחה");
    } catch (error: any) {
      if (error.response && error.response.data) {
        console.error("שגיאה מהשרת:", error.response.data);
        alert("שגיאה בהרשמה:\n" + JSON.stringify(error.response.data.errors, null, 2));
      } else {
        alert("שגיאה כללית בשליחה");
      }
    }
  };

  return (
    <div className="p-6 max-w-md mx-auto">
      <h2 className="text-2xl font-bold mb-4">הרשמה</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input name="name" value={form.name} onChange={handleChange} placeholder="שם מלא" className="border p-2 w-full rounded" />
        <input name="password" type="password" value={form.password} onChange={handleChange} placeholder="סיסמה" className="border p-2 w-full rounded" />
        <input name="mail" value={form.mail} onChange={handleChange} placeholder="מייל" className="border p-2 w-full rounded" />

        <select name="role" value={form.role} onChange={handleChange} className="border p-2 w-full rounded">
          <option value="User">משתמש רגיל</option>
          <option value="Driver">נהג</option>
        </select>

        {form.role === "Driver" && (
          <>
            <label className="block">
              <input type="checkbox" name="accessible" checked={form.accessible} onChange={handleChange} className="mr-2" />
              נגיש לכסא גלגלים
            </label>
            <label className="block">
              <input type="checkbox" name="trunk" checked={form.trunk} onChange={handleChange} className="mr-2" />
              תא מטען גדול
            </label>
            <input
              name="numberOfSeatsInTheCar"
              type="number"
              value={form.numberOfSeatsInTheCar}
              onChange={handleChange}
              placeholder="מספר מושבים ברכב"
              className="border p-2 w-full rounded"
              min={1}
              max={10}
              
            />
          </>
        )}

        <input type="file" onChange={handleFileChange} accept="image/*" className="border p-2 w-full rounded" />

        <button type="submit" className="bg-green-600 text-white p-2 w-full rounded">הרשם</button>
      </form>
    </div>
  );
};

export default Register;
