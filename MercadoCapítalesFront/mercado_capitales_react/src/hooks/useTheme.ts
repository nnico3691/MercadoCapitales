// src/hooks/useTheme.ts
import { useEffect, useState } from "react";

const useTheme = () => {
  const [isDarkMode, setIsDarkMode] = useState(false);

  useEffect(() => {
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme) {
      setIsDarkMode(savedTheme === "dark");
    } else {
      const prefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
      setIsDarkMode(prefersDark);
    }
  }, []);

  const toggleTheme = () => {
    setIsDarkMode((prev) => !prev);
    localStorage.setItem("theme", !isDarkMode ? "dark" : "light");
  };

  return { isDarkMode, toggleTheme };
};

export default useTheme;
