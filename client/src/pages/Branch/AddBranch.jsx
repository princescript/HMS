import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import api from "../../api";
import { toast } from "react-toastify";

const AddBranch = () => {
  const navigate = useNavigate();

  const initialBranch = {
    branchName: "",
    branchCity: "",
    branchAddress: "",
  };
  const [branch, setBranch] = useState(initialBranch);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setBranch({ ...branch, [name]: value });
    //console.log(branch);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await api.post("/Branch", branch);
      toast.success("Branch created successfully");
      setBranch(initialBranch);
      navigate("/Branch");
      //console.log("Branch submitted:", res.data);
    } catch (error) {
      console.error("Error adding branch:", error);
      toast.error("Failed to create branch");
      setBranch(initialBranch);
      navigate("/Branch");
    }
  };
  return (
    <>
      <Link to="/branch" className="text-blue-600 hover:underline font-medium">
        ← Back to Branches
      </Link>
      <div className="flex items-center justify-center bg-gray-100 p-3 rounded-lg min-h-[70vh]">
        <div className="w-full max-w-md bg-white rounded-xl shadow-lg p-6">
          <h1 className="text-2xl font-bold text-gray-800 mb-6 text-center">
            Add Branch
          </h1>

          <form onSubmit={handleSubmit} className="space-y-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">
                Branch Name
              </label>
              <input
                onChange={handleInputChange}
                value={branch?.branchName ?? []}
                type="text"
                name="branchName"
                className="w-full rounded-lg border px-3 py-2 focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">
                Branch City
              </label>
              <input
                onChange={handleInputChange}
                value={branch.branchCity}
                type="text"
                name="branchCity"
                className="w-full rounded-lg border px-3 py-2 focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">
                Branch Address
              </label>
              <textarea
                onChange={handleInputChange}
                value={branch.branchAddress}
                name="branchAddress"
                rows="3"
                className="w-full rounded-lg border px-3 py-2 focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <button className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700">
              Save Branch
            </button>
          </form>
        </div>
      </div>
    </>
  );
};

export default AddBranch;
