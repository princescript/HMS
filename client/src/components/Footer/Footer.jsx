import React from "react";

const Footer = () => {
  return (
    <footer className="mt-auto bg-white  text-center py-3 text-sm text-gray-600">
      © {new Date().getFullYear()} Hospital Management System — Built by Prince
    </footer>
  );
};

export default Footer;
