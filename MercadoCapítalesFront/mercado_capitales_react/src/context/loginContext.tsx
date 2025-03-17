import React, { createContext, useContext, useState, ReactNode } from "react";

interface AuthContextType {
    isLoggedIn: boolean;
    loading: boolean;
    login: () => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [isLoggedIn, setIsLoggedIn] = useState(true);
    const [loading, setLoading] = useState(false);

    const login = () => {
        setLoading(true);
        setTimeout(() => {
            setIsLoggedIn(true);
            setLoading(false);
        }, 2000);
    };
    const logout = () => setIsLoggedIn(false);

    return (
        <AuthContext.Provider value={{ isLoggedIn, loading, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
};
