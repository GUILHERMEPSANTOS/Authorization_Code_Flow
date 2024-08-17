'use client'
import React, { FormEvent, useState } from 'react';

const Register = () => {
    const [successMessage, setSuccessMessage] = useState('');
    const [formData, setFormData] = useState({
        email: '',
        password: '',
        firstName: '',
        lastName: '',
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>, name: string) => {
        setFormData({
            ...formData,
            [name]: e.target.value,
        });
    };

    const handleSubmit = async () => {

        const response = await fetch("http://localhost:5278/idp/users/register", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });

        if (response.ok) {
            setSuccessMessage('Cadastro realizado com sucesso!');

            setTimeout(() => {
                setSuccessMessage('');
            }, 3000);
        }
    };

    return (
        <div className="flex justify-center items-center h-screen">
            <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Cadastro</h2>
                <div>
                    <label className="block text-sm font-medium text-gray-700">Primeiro Nome</label>
                    <input
                        type="text"
                        name="firstName"
                        value={formData.firstName}
                        onChange={(e) => handleChange(e, "firstName")}
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-blue-500"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700">Sobrenome</label>
                    <input
                        type="text"
                        name="lastName"
                        value={formData.lastName}
                        onChange={(e) => handleChange(e, "lastName")}
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-blue-500"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700">Email</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={(e) => handleChange(e, "email")}
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-blue-500"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700">Senha</label>
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={(e) => handleChange(e, "password")}
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring focus:ring-blue-500"
                        required
                    />
                </div>
                <button
                    type="submit"
                    className="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    onClick={handleSubmit}
                >
                    Cadastrar
                </button>

            </div>
            {successMessage && (
                <div className="absolute top-4 right-4 bg-green-500 text-white px-4 py-2 rounded-md shadow-lg transition-opacity duration-500 ease-in-out">
                    {successMessage}
                </div>
            )}

        </div>
    );
};

export default Register;
