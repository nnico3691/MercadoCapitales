import {FC, useEffect, useState} from "react";
import MatbaRofexTable from "@/components/ui/matbaRofex/MatbaRofexTable";
import axios from "axios";
import SugerenciasCard from "@/components/ui/sugerencias/SugerenciasCard";

type Props = {};

const MatbaRofexScreen: FC<Props> = () => {
  // Estado para almacenar los datos del mercado
  const [marketData, setMarketData] = useState<any[]>([]);

  const MarketDataComponent = () => {
    const socket = new WebSocket("ws://localhost:3001");

    console.log("Se abre socket");

    socket.onmessage = (event) => {
      const data = JSON.parse(event.data);

      setMarketData((prevData) => {
        const index = prevData.findIndex((item) => item.instrumentId.symbol === data.instrumentId.symbol);
        if (index !== -1) {
          const updatedData = [...prevData];
          updatedData[index] = {...updatedData[index], marketData: data.marketData};
          return updatedData;
        } else {
          return [...prevData, data];
        }
      });
    };

    socket.onerror = (error) => {
      console.error("Error en WebSocket:", error);
    };

    socket.onclose = () => {
      console.log("WebSocket cerrado");
    };

    // Limpiar la conexión al desmontar el componente
    return () => {
      socket.close();
    };
  };

  useEffect(() => {
    // Abre el WebSocket para actualizar los precios en tiempo real
    const cleanup = MarketDataComponent();
    return cleanup;
  }, []);

  return (
    <div className="h-full flex flex-col max-w-full">
      <h2 className="md:text-xl font-bold my-2 mx-2 text-slate-950 dark:text-white">Rofex</h2>
      <div className="flex flex-row overflow-hidden gap-4">
        <MatbaRofexTable marketData={marketData} />
        <div className="md:block hidden w-[500px]">
          <SugerenciasCard />
        </div>
      </div>
    </div>
  );
};

export default MatbaRofexScreen;
