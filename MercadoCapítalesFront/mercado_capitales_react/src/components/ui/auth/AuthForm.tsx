import { useAuth } from '@/context/loginContext';
import { useRouter } from 'next/router';
import React from 'react';

const AuthForm = () => {
    const { login, loading } = useAuth();
    const router = useRouter();

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        login();  // Llama a login, que simula el retraso
        router.push('/'); // Redirige a una página protegida después del login (cuando termine)
    };

    return (
        <div className="bg-opacity-20 border-y p-8 border-gray-800 shadow-xl w-full max-w-md">
            <h2 className="text-2xl font-bold text-center mb-4 text-white">Iniciar Sesión</h2>

            <form className="space-y-6" onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="email" className="block text-sm font-medium">
                        Correo Electrónico
                    </label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        className="mt-1 block w-full rounded-sm h-8 border-gray-300 shadow-sm focus:outline-none text-black sm:text-sm"
                        placeholder=""
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password" className="block text-sm font-medium">
                        Contraseña
                    </label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        className="mt-1 block w-full rounded-sm h-8 border-gray-300 shadow-sm focus:outline-none text-black sm:text-sm"
                        placeholder="********"
                        required
                    />
                </div>
                <div className="flex items-center justify-between">
                    <div className="flex items-center">
                        <input
                            id="remember-me"
                            name="remember-me"
                            type="checkbox"
                            className="h-4 w-4 border-gray-300 rounded"
                        />
                        <label htmlFor="remember-me" className="ml-2 block text-sm">
                            Recordarme
                        </label>
                    </div>
                    <div className="text-sm">
                        <a href="#" className="font-medium text-white hover:text-slate-200">
                            ¿Olvidaste tu contraseña?
                        </a>
                    </div>
                </div>

                {/* Indicador de carga */}
                {loading ? (
                    <div className="flex justify-center">
                        <div className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full border-emerald-500 border-t-transparent" />
                    </div>
                ) : (
                    <div>
                        <button
                            type="submit"
                            className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-emerald-800 hover:bg-emerald-900"
                        >
                            Iniciar Sesión
                        </button>
                    </div>
                )}
            </form>
            <p className="mt-6 text-center text-sm text-gray-200">
                ¿No tienes cuenta?{' '}
                <a href="#" className="font-medium text-emerald-500 hover:text-emerald-600">
                    Regístrate
                </a>
            </p>
        </div>
    );
};

export default AuthForm;
