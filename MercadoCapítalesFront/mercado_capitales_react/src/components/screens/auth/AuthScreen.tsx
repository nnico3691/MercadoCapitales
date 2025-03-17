import Image from "next/image";
import { FC } from "react";
import Logo from '@/assets/emunah-logo-bco-nuevo.svg';
import AuthForm from "@/components/ui/auth/AuthForm";
type Props = {

}

const AuthScreen: FC<Props> = ({ }) => {

    return (
        <div className="h-screen w-full flex items-center justify-center bg-gradient-to-r from-teal-950 to-slate-950 ">
            <div className="absolute top-0 left-0 p-4">

                <Image
                    priority
                    src={Logo}
                    alt="Logo"
                    className="w-32 sm:w-40 h-auto"
                />
            </div>
            <AuthForm />
        </div>
    )
}


export default AuthScreen;