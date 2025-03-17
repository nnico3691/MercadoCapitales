import React from 'react';
import Link from 'next/link';
import { FaTimes, FaTachometerAlt, FaChartLine, FaWallet, FaClipboardList } from 'react-icons/fa';
import { useSidebar } from '@/context/SidebarContext';

const Sidebar = () => {
    const { isSidebarOpen, toggleSidebar } = useSidebar();

    return (
        <div className="flex">
            {/* Background overlay */}
            {isSidebarOpen && (
                <div className="fixed inset-0 bg-black bg-opacity-50 z-30" onClick={toggleSidebar}></div>
            )}

            {/* Sidebar menu */}
            <div
                className={`fixed md:static md:w-full inset-y-0 left-0 transform ${isSidebarOpen ? 'translate-x-0' : '-translate-x-full'
                    } md:translate-x-0 transition-transform duration-300 md:transition-none ease-in-out dark:bg-slate-950 dark:text-white md:bg-white bg-slate-50 text-teal-950 w-52 z-40 md:z-0`}
            >
                <div className="flex items-center justify-between p-4 md:hidden">
                    <span className="text-xl font-bold">Menu</span> {/* Título opcional */}
                    <button onClick={toggleSidebar} className="dark:text-white text-slate-950 focus:outline-none">
                        <FaTimes size={24} />
                    </button>
                </div>
                <nav className="flex text-sm flex-col md:flex-row md:items-center md:justify-end md:px-4 transition-transform duration-300 ease-in-out gap-2">
                    <Link href="/" legacyBehavior>
                        <a className="py-2.5 px-2 md:px-0 hover:underline flex items-center md:justify-center">
                            <FaTachometerAlt className="mr-2" /> Dashboard
                        </a>
                    </Link>
                    <Link href="/matbaRofex" legacyBehavior>
                        <a className="py-2.5 px-2 md:px-0 hover:underline flex items-center md:justify-center">
                            <FaChartLine className="mr-2" /> MatbaRofex
                        </a>
                    </Link>
                    <Link href="/wallet" legacyBehavior>
                        <a className="py-2.5 px-2 md:px-0 hover:underline flex items-center md:justify-center">
                            <FaWallet className="mr-2" /> Wallet
                        </a>
                    </Link>
                    <Link href="/reports" legacyBehavior>
                        <a className="py-2.5 px-2 md:px-0 hover:underline flex items-center md:justify-center">
                            <FaClipboardList className="mr-2" /> Reports
                        </a>
                    </Link>
                </nav>
            </div>
        </div>
    );
};

export default Sidebar;