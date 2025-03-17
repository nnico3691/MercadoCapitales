import React, { createContext, useContext, useState, ReactNode } from 'react';

// Define el tipo del contexto
interface SidebarContextType {
    isSidebarOpen: boolean;
    toggleSidebar: () => void;
}

// Crea el contexto
const SidebarContext = createContext<SidebarContextType | undefined>(undefined);

// Proveedor del contexto
export const SidebarProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [isSidebarOpen, setSidebarOpen] = useState(false);

    const toggleSidebar = () => {
        setSidebarOpen(!isSidebarOpen);
    };

    return (
        <SidebarContext.Provider value={{ isSidebarOpen, toggleSidebar }}>
            {children}
        </SidebarContext.Provider>
    );
};

// Hook para usar el contexto
export const useSidebar = () => {
    const context = useContext(SidebarContext);
    if (!context) {
        throw new Error('useSidebar must be used within a SidebarProvider');
    }
    return context;
};
