import { Routes, Route } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import Nav from "./components/Navbar/Nav";
import Branch from "./pages/Branch/Branch";
import Department from "./pages/Department/Department";
import DefaultPage from "./pages/DefaultPage/DefaultPage";
import Doctor from "./pages/Doctor/Doctor";
import AddBranch from "./pages/Branch/AddBranch";
import EditBranch from "./pages/Branch/EditBranch";
const App = () => {
  return (
    <>
      <ToastContainer position="top-right" autoClose={2000} />
      <Routes>
        <Route path="/" element={<Nav />}>
          <Route path="/" element={<DefaultPage />} />
          <Route path="branch" element={<Branch />} />
          <Route path="AddBranch" element={<AddBranch />} />
          <Route path="EditBranch/:id?" element={<EditBranch />} />

          <Route path="department" element={<Department />} />
          <Route path="doctor" element={<Doctor />} />
        </Route>
      </Routes>
    </>
  );
};

export default App;
