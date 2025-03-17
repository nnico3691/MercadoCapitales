import React, { useState, useEffect } from 'react';

interface MatBarofexPopupProps {
    isOpen: boolean;
    closeModal: () => void;
    order: {
        symbol: string;
        price: number;
        size: number;
    } | null;
    handleSubmit: (order: { symbol: string; price: number; size: number }) => void;
}

const MatBarofexPopup: React.FC<MatBarofexPopupProps> = ({ isOpen, closeModal, order, handleSubmit }) => {
    const [price, setPrice] = useState<number>(order?.price ?? 0);
    const [size, setSize] = useState<number>(order?.size ?? 0);


    useEffect(() => {
        if (order) {
            setPrice(order.price);
            setSize(order.size);
        }
    }, [order]);

    if (!isOpen || !order) return null;

    const handlePriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setPrice(value === "" ? 0 : parseFloat(value));
    };

    const handleSizeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setSize(value === "" ? 0 : parseInt(value, 10));
    };

    const handleFormSubmit = () => {
        handleSubmit({ symbol: order.symbol, price, size });
        closeModal();
    };

    return (
        <div className="fixed inset-0 bg-black bg-opacity-70 flex justify-center items-center transition-transform z-40">
            <div className="dark:bg-slate-950 bg-slate-100 p-6 rounded-lg shadow-xl gap-5 h-[400px] w-[600px] mx-4 flex flex-col justify-between z-50">
                <h2 className="text-xl font-semibold dark:text-white text-slate-950">Carga de Orden</h2>

                <div className="border-t-2 border-b-2 border-slate-800 h-full dark:text-white text-slate-950 p-4 flex flex-col justify-between gap-4">
                    <p className="text-lg"><strong>Instrumento:</strong> {order.symbol}</p>
                    <div className="flex flex-col gap-2">
                        <label className="text-sm font-medium">Precio:</label>
                        <input
                            value={price}
                            onChange={handlePriceChange}
                            className="px-3 py-2 border border-gray-300 rounded-md text-black focus:outline-none focus:ring-2 focus:ring-blue-900"
                            inputMode="decimal"
                        />
                    </div>

                    <div className="flex flex-col gap-2">
                        <label className="text-sm font-medium">Cantidad:</label>
                        <input
                            value={size}
                            onChange={handleSizeChange}
                            className="px-3 py-2 border border-gray-300 rounded-md focus:outline-none text-black focus:ring-2 focus:ring-blue-900"
                            inputMode="numeric"
                        />
                    </div>
                </div>

                <div className="flex justify-end gap-2">
                    <button
                        onClick={closeModal}
                        className="px-2 py-2 dark:text-white text-slate-950 rounded-md bg-transparent hover:underline transition"
                    >
                        Cancelar
                    </button>
                    <button
                        onClick={handleFormSubmit}
                        className="px-2 py-2 dark:bg-pink-950 bg-slate-300 dark:text-white text-slate-950 rounded-md dark:hover:bg-pink-900 hover:bg-slate-400 transition"
                    >
                        Venta
                    </button>
                    <button
                        onClick={handleFormSubmit}
                        className="px-2 py-2 dark:bg-emerald-950 bg-emerald-500 dark:text-white text-slate-950 rounded-md dark:hover:bg-emerald-900 hover:bg-emerald-400 transition"
                    >
                        Compra
                    </button>
                </div>
            </div>
        </div>
    );
};

export default MatBarofexPopup;