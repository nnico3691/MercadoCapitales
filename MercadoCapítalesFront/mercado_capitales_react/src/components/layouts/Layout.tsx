import {SidebarProvider} from "@/context/SidebarContext";
import React, {FC} from "react";
import Navbar from "./common/Navbar";
import Sidebar from "./common/Sidebar";
import AuthScreen from "../screens/auth/AuthScreen";
import {useAuth} from "@/context/loginContext";
import useTheme from "@/hooks/useTheme";

type Props = {
  children: React.ReactNode;
};

const Layout: FC<Props> = ({children}) => {
  const {isDarkMode, toggleTheme} = useTheme(); // Mover lógica de tema a un hook
  const {isLoggedIn} = useAuth();

  return (
    <main className={`min-h-screen flex md:block ${isDarkMode ? "dark" : ""} bg-slate-50`}>
      {isLoggedIn ? (
        <SidebarProvider>
          <div className="w-full">
            <Navbar isDarkMode={isDarkMode} toggleTheme={toggleTheme} />
            <div className="h-screen-minus-navbar flex md:flex-col">
              <Sidebar />
              <ContentWrapper>{children}</ContentWrapper>
            </div>
          </div>
        </SidebarProvider>
      ) : (
        <AuthScreen />
      )}
    </main>
  );
};

const ContentWrapper: FC<{children: React.ReactNode}> = ({children}) => <div className="flex-1 md:p-3 dark:bg-slate-950 bg-slate-50 max-w-full h-full overflow-scroll xl:overflow-auto">{children}</div>;

export default Layout;
