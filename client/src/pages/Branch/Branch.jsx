import api from "../../api";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";

const Branch = () => {
  //Get Branch Data
  const [Branch, setBranch] = useState([]);
  const getBranchData = async () => {
    try {
      const res = await api.get("/Branch/GetAll");
      setBranch(res.data);
    } catch (error) {
      console.error("Error fetching branch data:", error);
    }
  };
  useEffect(() => {
    getBranchData();
  }, []);
  //console.log(Branch);
  //Delete Branch
  const deleteHandler = async (id) => {
    try {
      await api.delete(`/Branch/${id}`);
      toast.success("Branch deleted successfully");
      getBranchData();
    } catch (error) {
      console.error("Error deleting branch:", error);
      toast.error("Failed to delete branch");
    }
  };
  return (
    <div className="bg-gray-100 max-h-70vh p-4">
      {/* Header */}
      <h1 className="text-3xl font-bold text-gray-800 mb-4">Branches</h1>

      {/* Add Branch Button */}
      <div className="mb-4">
        <Link
          to={"/AddBranch"}
          className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 transition"
        >
          Add Branch
        </Link>
      </div>

      {/* Table Container */}
      <div
        className="bg-white rounded-lg shadow-md overflow-auto"
        style={{ maxHeight: "60vh" }}
      >
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50 sticky top-0">
            <tr>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                ID
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Branch Name
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Address
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                City
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Action
              </th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {Branch.map((item, index) => (
              <tr key={item.branchId} className="hover:bg-gray-50 transition">
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                  {index + 1}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                  {item.branchName}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                  {item.branchCity}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                  {item.branchAddress}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                  <div className="flex gap-2">
                    <Link
                      to={"/EditBranch" + "/" + item.branchId}
                      className="px-3 py-1 bg-blue-500 text-white text-xs font-semibold rounded hover:bg-blue-600 transition"
                    >
                      Edit
                    </Link>
                    <button
                      onClick={() => deleteHandler(item.branchId)}
                      className="px-3 py-1 bg-red-500 text-white text-xs font-semibold rounded hover:bg-red-600 transition"
                    >
                      Delete
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Branch;
