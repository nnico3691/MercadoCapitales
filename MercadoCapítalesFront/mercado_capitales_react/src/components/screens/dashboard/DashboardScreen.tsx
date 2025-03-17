import {FC} from "react";
import DashboardCard from "../../ui/dashboard/DashboardCard";
import SugerenciasCard from "@/components/ui/sugerencias/SugerenciasCard";
import Chart from "@/components/ui/chart/Chart";
import Carousel from "@/components/ui/chart/Carousel";

type Props = {};

const DashboardScreen: FC<Props> = ({}) => {
  const cuenta = 905477;
  const cantidadPesos = 10000.0;
  const cantidadUsd = 4042.0;
  const invertido = 420200.4;
  const dolarCotizacion = 1200;

  const suma = () => {
    const totalUsdEnPesos = cantidadUsd * dolarCotizacion;
    return cantidadPesos + totalUsdEnPesos + invertido;
  };

  const totalEnPesos = suma();

  const formatNumber = (number: number) => {
    return number.toLocaleString("es-AR", {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    });
  };

  const inversiones = [
    {
      nombre: "AY24",
      cantidad: 150,
      ultimoPrecio: 50.25,
      volumen: 7523.75,
      total: 7537.5,
    },
    {
      nombre: "CL2D8",
      cantidad: 200,
      ultimoPrecio: 42.1,
      volumen: 8420.0,
      total: 8420.0,
    },
    {
      nombre: "AL30",
      cantidad: 75,
      ultimoPrecio: 64.5,
      volumen: 4837.5,
      total: 4837.5,
    },
    {
      nombre: "AL30",
      cantidad: 75,
      ultimoPrecio: 64.5,
      volumen: 4837.5,
      total: 4837.5,
    },
    {
      nombre: "AL30",
      cantidad: 87,
      ultimoPrecio: 64.5,
      volumen: 4837.5,
      total: 4837.5,
    },
    {
      nombre: "AL30",
      cantidad: 75,
      ultimoPrecio: 64.5,
      volumen: 4837.5,
      total: 4837.5,
    },
    {
      nombre: "AL30",
      cantidad: 75,
      ultimoPrecio: 64.5,
      volumen: 4837.5,
      total: 4837.5,
    },
  ];
  const nuevasInversiones = [
    {
      nombre: "YPF",
      cantidad: 100,
      ultimoPrecio: 600.5,
      volumen: 60050.0,
      total: 100050.0,
    },
    {
      nombre: "GGAL",
      cantidad: 50,
      ultimoPrecio: 200.75,
      volumen: 10037.5,
      total: 10037.5,
    },
    {
      nombre: "PAMP",
      cantidad: 120,
      ultimoPrecio: 150.3,
      volumen: 18036.0,
      total: 18036.0,
    },
    {
      nombre: "BMA",
      cantidad: 80,
      ultimoPrecio: 300.4,
      volumen: 24032.0,
      total: 24032.0,
    },
    {
      nombre: "CEPU",
      cantidad: 60,
      ultimoPrecio: 250.1,
      volumen: 15006.0,
      total: 15006.0,
    },
    {
      nombre: "TXAR",
      cantidad: 90,
      ultimoPrecio: 100.2,
      volumen: 9020.0,
      total: 9020.0,
    },
    {
      nombre: "MIRG",
      cantidad: 110,
      ultimoPrecio: 400.6,
      volumen: 44066.0,
      total: 44066.0,
    },
  ];

  inversiones.push(...nuevasInversiones);
  return (
    <div className="md:p-4 bg-slate-50 dark:bg-slate-950 max-h-screen max-w-full">
      <div className="grid grid-cols-1 lg:grid-cols-[3fr,1fr] gap-4 max-h-[700px]">
        <div className="space-y-4 lg:w-full w-full lg:mx-auto p-2 md:p-0 max-h-full">
          <div className="flex md:flex-row flex-col max-w-full gap-3 ">
            <DashboardCard title="Ingresar Fondos" className="flex w-full items-center p-3 cursor-pointer dark:hover:bg-slate-800 hover:bg-slate-50"></DashboardCard>
            <DashboardCard title="Invertir" className="flex w-full items-center p-3 cursor-pointer dark:hover:bg-teal-900 hover:bg-teal-50"></DashboardCard>
          </div>

          <DashboardCard title={`Total de la Cuenta: ${cuenta}`} className="px-4 pt-4">
            <div className="sm:flex sm:justify-between">
              <div>
                <p className="text-slate-700 dark:text-slate-400">Pesos: ARS {formatNumber(cantidadPesos)}</p>
                <p className="text-slate-700 dark:text-slate-400">Dolares: USD {formatNumber(cantidadUsd)}</p>
                <p className="text-slate-700 dark:text-slate-400">Total invertido: ARS {formatNumber(invertido)}</p>
              </div>
              <div className="sm:mt-auto mt-4">
                <h2 className="md:text-lg font-medium text-gray-800 dark:text-gray-200 mb-2 sm:mb-0">Total: ARS {formatNumber(totalEnPesos)}</h2>
              </div>
            </div>
          </DashboardCard>

          <DashboardCard title="Mis Inversiones" className="sm:col-span-2 p-3 max-h-full">
            <div className="overflow-x-auto hidden sm:flex space-x-4">
              <div className="w-full">
                <div className="overflow-x-auto overflow-y-auto max-h-[400px] ">
                  <table className="w-full table-auto border-collapse border border-gray-200 dark:border-slate-700 text-sm ">
                    <thead>
                      <tr className="bg-gray-100 dark:bg-slate-800 text-left sticky top-0">
                        <th className="p-2 border-y border-gray-200 dark:border-slate-700 dark:text-slate-200">Nombre</th>
                        <th className="p-2 border-y border-gray-200 dark:border-slate-700 dark:text-slate-200">Cantidad</th>
                        <th className="p-2 border-y border-gray-200 dark:border-slate-700 dark:text-slate-200">Precio</th>
                        <th className="p-2 border-y border-gray-200 dark:border-slate-700 dark:text-slate-200">PPC</th>
                        <th className="p-2 border-y border-gray-200 dark:border-slate-700 dark:text-slate-200">Total</th>
                      </tr>
                    </thead>
                    <tbody>
                      {inversiones.map((inv, index) => (
                        <tr key={index} className={`${index % 2 === 0 ? "bg-gray-50 dark:bg-slate-800" : "bg-white dark:bg-slate-900"}`}>
                          <td className="p-2 border-y border-slate-200 dark:border-slate-700 dark:text-slate-300">{inv.nombre}</td>
                          <td className="p-2 border-y border-slate-200 dark:border-slate-700 dark:text-slate-300">{inv.cantidad}</td>
                          <td className="p-2 border-y border-slate-200 dark:border-slate-700 dark:text-slate-300">{formatNumber(inv.ultimoPrecio)}</td>
                          <td className="p-2 border-y border-slate-200 dark:border-slate-700 dark:text-slate-300">{formatNumber(inv.volumen)}</td>
                          <td className="p-2 border-y border-slate-200 dark:border-slate-700 dark:text-slate-300">{formatNumber(inv.total)}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              </div>
              {/* <div className="space-y-4 justify-items-center hidden md:block max-w-full max-h-full">
                <Carousel />
              </div> */}
            </div>

            {/* Tarjetas para pantallas pequeñas */}
            <div className="block sm:hidden max-h-[400px] max-w-full overflow-y-auto space-y-2 scrollbar-none">
              {inversiones.map((inv, index) => (
                <div key={index} className="p-2 bg-white dark:bg-slate-900 rounded shadow-sm border-b dark:border-b-slate-600">
                  <h3 className="text-base font-semibold text-slate-800 dark:text-slate-200 mb-1">{inv.nombre}</h3>
                  <div className="text-xs space-y-1">
                    <p className="text-slate-700 dark:text-slate-200">
                      <span className="font-medium">Cantidad:</span> {inv.cantidad}
                    </p>
                    <p className="text-slate-700 dark:text-slate-200">
                      <span className="font-medium">Precio:</span> {formatNumber(inv.ultimoPrecio)}
                    </p>
                    <p className="text-slate-700 dark:text-slate-200">
                      <span className="font-medium">PPC:</span> {formatNumber(inv.volumen)}
                    </p>
                    <p className="text-slate-700 dark:text-slate-200">
                      <span className="font-medium">Total:</span> {formatNumber(inv.total)}
                    </p>
                  </div>
                </div>
              ))}
            </div>
          </DashboardCard>
        </div>

        <div className="flex justify-center items-center lg:items-start lg:justify-start min-w-[320px]">
          <SugerenciasCard />
        </div>
      </div>
    </div>
  );
};

export default DashboardScreen;
