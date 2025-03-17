import React, { useState, useEffect } from 'react';
import { FaBars, FaUserCircle, FaUser, FaBell, FaSignOutAlt, FaSun, FaMoon, FaEye, FaEyeSlash } from 'react-icons/fa';
import Image from 'next/image';
import Logo from '@/assets/emunah-logo-bco-nuevo.svg';
import LogoNegro from '@/assets/emunah-logo-negro.svg';
import { useSidebar } from '@/context/SidebarContext';

type NavbarProps = {
    isDarkMode: boolean;
    toggleTheme: () => void;
};

const Navbar: React.FC<NavbarProps> = ({ isDarkMode, toggleTheme }) => {
    const { toggleSidebar } = useSidebar();
    const [isUserOpen, setIsUserOpen] = useState(false);
    const [isARS, setIsARS] = useState(true);
    const [isVisible, setIsVisible] = useState(true);

    const handleUserOpen = () => {
        setIsUserOpen(!isUserOpen);
    };

    const handleClickOutside = (event: MouseEvent) => {
        if (!(event.target as HTMLElement).closest('.user-menu')) {
            setIsUserOpen(false);
        }
    };

    useEffect(() => {
        if (isUserOpen) {
            document.addEventListener('mousedown', handleClickOutside);
        } else {
            document.removeEventListener('mousedown', handleClickOutside);
        }

        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, [isUserOpen]);

    const toggleCurrency = () => {
        setIsARS(!isARS);
    };

    const toggleVisibility = () => {
        setIsVisible(!isVisible);
    };

    return (
        <nav className="flex justify-between items-center p-4 md:min-w-0 w-full min-h-20 border-b-[1px] dark:border-slate-900  dark:bg-gradient-to-b dark:from-teal-950 dark:to-slate-950 bg-slate-50 max-w-full overflow-hidden">

            <div className="flex items-center gap-4">
                <button onClick={toggleSidebar} className="dark:text-white text-slate-500 focus:outline-none md:hidden">
                    <FaBars size={24} />
                </button>
                <div className="flex items-center">
                    <Image
                        priority
                        src={isDarkMode ? Logo : LogoNegro}
                        alt="Logo"
                        className="w-32 sm:w-40 h-auto"
                    />
                </div>
            </div>

            <div className="flex items-center gap-4">
                <div className="hidden md:flex items-center gap-2 text-sm border dark:border-slate-700 border-slate-200 rounded p-2">
                    <span className="dark:text-white text-slate-700">Total cuenta:</span>
                    {isVisible ? (
                        <span className="dark:text-emerald-400 text-black">
                            {isARS ? 'ARS 100.000' : 'USD 1.000'}
                        </span>
                    ) : (
                        <span className="dark:text-emerald-400 text-black">****</span>
                    )}
                    <label className="relative inline-flex items-center cursor-pointer">
                        <input type="checkbox" className="sr-only peer" checked={!isARS} onChange={toggleCurrency} />
                        <div className="w-8 h-4 bg-gray-200 peer-focus:outline-none  rounded-full peer dark:bg-gray-700 peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-0.5 after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-3 after:w-3 after:transition-all dark:border-gray-600"></div>
                        <span className="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">{isARS ? 'ARS' : 'USD'}</span>
                    </label>
                    <button onClick={toggleVisibility} className="dark:text-white text-slate-500 focus:outline-none">
                        {isVisible ? <FaEyeSlash /> : <FaEye />}
                    </button>
                </div>

                <button
                    onClick={handleUserOpen}
                    className="dark:text-white text-slate-500 no-underline cursor-pointer flex justify-center items-center"
                >
                    <FaUserCircle size={30} className="mr-2" />
                </button>
            </div>

            {isUserOpen && (
                <div className="fixed inset-0 bg-black bg-opacity-50 z-40" onClick={handleUserOpen}></div>
            )}

            <div
                className={`user-menu absolute border z-50 gap-4 top-16 right-2 bg-white dark:bg-slate-950 p-4 rounded-md shadow-md transform transition-all duration-300 ${isUserOpen ? 'opacity-100 scale-100' : 'opacity-0 scale-90 pointer-events-none'
                    }`}
            >
                <div className="absolute -top-2 right-6 w-4 h-4 bg-white dark:bg-slate-950 rotate-45 transform border-t transition-all duration-300 dark:border-slate-950 border-slate-200"></div>

                <ul className="flex flex-col gap-4 text-sm">
                    <li className="flex items-center gap-3 cursor-pointer text-slate-800 dark:text-slate-100 dark:hover:text-emerald-500 hover:text-emerald-500">
                        <FaUser />
                        <span>Cuenta</span>
                    </li>

                    <li className="flex items-center gap-3 cursor-pointer text-slate-800 dark:text-slate-100 dark:hover:text-emerald-500 hover:text-emerald-500">
                        <FaBell />
                        <span>Novedades</span>
                    </li>

                    <li className="flex items-center justify-between cursor-pointer text-slate-800 dark:hover:text-emerald-500 dark:text-slate-100 hover:text-emerald-500">
                        <div className="flex items-center gap-3">
                            <button onClick={toggleTheme}>
                                {isDarkMode ? <FaSun /> : <FaMoon />}
                            </button>
                            <span onClick={toggleTheme}>Tema</span>
                        </div>
                    </li>

                    <li className="flex items-center gap-3 cursor-pointer text-slate-800 dark:text-slate-100 dark:hover:text-red-200 hover:text-red-500">
                        <FaSignOutAlt />
                        <span>Logout</span>
                    </li>
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;