import { useState } from "react";
import { Link, Outlet } from "react-router-dom";

const Nav = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleToggle = () => {
    setIsMenuOpen((prev) => !prev);
  };

  return (
    <div className="flex flex-col md:flex-row md:h-screen select-none">
      {/* Sidebar */}
      <aside className="bg-linear-to-b from-teal-600 to-teal-400 text-white md:w-64 flex flex-col">
        {/* Header (ALWAYS visible) */}
        <div className="flex items-center justify-between p-4 border-b border-white/20">
          <h2 className="text-xl font-bold">
            <Link to="/" className="hover:text-yellow-300 transition">
              Hospital Management
            </Link>
          </h2>

          {/* Toggle only on mobile */}
          <button
            onClick={handleToggle}
            className="focus:outline-none md:hidden"
            aria-label="Toggle Menu"
          >
            <svg
              className="w-6 h-6"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              {isMenuOpen ? (
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M6 18L18 6M6 6l12 12"
                />
              ) : (
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M4 6h16M4 12h16M4 18h16"
                />
              )}
            </svg>
          </button>
        </div>

        {/* Navigation Links */}
        <nav
          onClick={() => setIsMenuOpen(false)}
          className={`
          ${isMenuOpen ? "flex" : "hidden"}
          flex-col
          md:flex
          gap-4 md:gap-6
          p-4 md:p-6`}
        >
          <ul className="space-y-3">
            <li>
              <Link
                to="/branch"
                className="block px-3 py-2 rounded-md hover:bg-teal-700 hover:text-yellow-300 transition"
              >
                Branch
              </Link>
            </li>

            <li>
              <Link
                to="/department"
                className="block px-3 py-2 rounded-md hover:bg-teal-700 hover:text-yellow-300 transition"
              >
                Department
              </Link>
            </li>

            <li>
              <Link
                to="/doctor"
                className="block px-3 py-2 rounded-md hover:bg-teal-700 hover:text-yellow-300 transition"
              >
                Doctor
              </Link>
            </li>
          </ul>
        </nav>
      </aside>

      {/* Page Content */}
      <main className="flex-1 p-6 bg-gray-50">
        <Outlet />
      </main>
    </div>
  );
};

export default Nav;
