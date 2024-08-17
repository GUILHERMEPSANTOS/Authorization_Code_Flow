'use client'

import { signIn } from "next-auth/react";
import { useRouter } from "next/navigation";

export default function Home() {
    const router = useRouter();

    return (
        <main className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
            <span className="text-7xl pb-5">😂</span>
            <span className="text-2xl font-semibold mb-6 fade-in">Olá, bem-vindo ao meu teste de OAuth.</span>
            <div className="space-y-4 space-x-1 ">
                <button className="bg-blue-500 text-white py-2 px-4 rounded transition-transform duration-300 hover:bg-blue-600 hover:scale-105"
                    onClick={() => signIn("keycloak", { redirect: true, callbackUrl: "/" })}>
                    Login
                </button>
                <button className="bg-green-500 text-white py-2 px-4 rounded transition-transform duration-300 hover:bg-green-600 hover:scale-105"
                    onClick={() => router.push('/register')}>
                    Cadastrar-se
                </button>
            </div>
        </main>
    );
}
