import { toast } from "react-toastify";
import { Link, useParams, useNavigate } from "react-router-dom";
import api from "../../api";
import { useState } from "react";
import { useEffect } from "react";

const EditBranch = () => {
  const id = useParams().id;
  const navigate = useNavigate();
  const initialBranchData = {
    branchName: "",
    branchCity: "",
    branchAddress: "",
  };
  const [branch, setBranch] = useState(initialBranchData);

  const getBranchData = async (id) => {
    try {
      const res = await api.get(`/Branch/${id}`);
      setBranch(res.data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    getBranchData(id);
  }, [id]);

  const onChangeHandler = (e) => {
    const { name, value } = e.target;
    setBranch({ ...branch, [name]: value });
  };
  const onSubmitHandler = async (e) => {
    e.preventDefault();
    try {
      const res = await api.put(`/Branch/${id}`, branch);
      console.log(res.data);
      setBranch(initialBranchData);
      navigate("/Branch");
      toast.success("Branch Updated successfully");
    } catch (error) {
      console.error("Error updating branch:", error);
      toast.error("Branch not Updated");
    }
  };
  return (
    <div>
      <Link
        to="/branch"
        className="text-blue-600 hover:underline font-medium mb-2 block"
      >
        ← Back to Branches
      </Link>

      <div className="max-w-md mx-auto  p-6 bg-white shadow-md rounded-lg">
        <h1 className="text-3xl font-bold text-gray-800 mb-6 text-center">
          Edit Branch
        </h1>
        <form onSubmit={onSubmitHandler} className="space-y-4">
          <div className="flex flex-col">
            <label
              htmlFor="branchName"
              className="mb-2 font-medium text-gray-700"
            >
              Branch Name
            </label>
            <input
              onChange={onChangeHandler}
              value={branch.branchName}
              type="text"
              id="branchName"
              name="branchName"
              className="px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Enter branch name"
            />
          </div>

          <div className="flex flex-col">
            <label
              htmlFor="branchCity"
              className="mb-2 font-medium text-gray-700"
            >
              Branch City
            </label>
            <input
              onChange={onChangeHandler}
              value={branch.branchCity}
              type="text"
              id="branchCity"
              name="branchCity"
              className="px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Enter city"
            />
          </div>

          <div className="flex flex-col">
            <label
              htmlFor="branchAddress"
              className="mb-2 font-medium text-gray-700"
            >
              Branch Address
            </label>
            <input
              onChange={onChangeHandler}
              value={branch.branchAddress}
              type="text"
              id="branchAddress"
              name="branchAddress"
              className="px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Enter address"
            />
          </div>

          <button
            type="submit"
            className="w-full py-2 mt-4 bg-blue-600 text-white font-semibold rounded-md hover:bg-blue-700 transition-colors"
          >
            Save Changes
          </button>
        </form>
      </div>
    </div>
  );
};

export default EditBranch;
