import React from "react";

const SugerenciasCard: React.FC = () => {
  // Ejemplo de sugerencias hardcodeadas para un perfil conservador
  const sugerencias = [
    {nombre: "GOOGL", cambio: 2.3, descripcion: "GOOGLE ONC CEDEAR"},
    {nombre: "ALUA", cambio: 1.8, descripcion: "ALUAR"},
    {nombre: "GD30", cambio: 0.9, descripcion: "Bono Rep.Arg U$S STEP UP.."},
    {nombre: "AL30", cambio: 0.5, descripcion: "Bono argentino en dólares"},
  ];

  return (
    <div className="w-full lg:max-w-sm lg:h-auto p-4 bg-white shadow-md dark:shadow-slate-900 dark:bg-slate-950 overflow-scroll scrollbar-none">
      <h2 className="text-center lg:text-start text-md font-semibold text-gray-800 dark:text-white mb-4 ">Sugerencias de Inversión</h2>
      <div className="space-y-3">
        {sugerencias.map((sugerencia, index) => (
          <div key={index} className="flex flex-col justify-between items-start p-3 bg-gray-100 dark:bg-slate-900 rounded w-full shadow-sm hover:bg-gray-200 dark:hover:bg-gray-800 transition">
            <div className="flex justify-between w-full items-center">
              <span className="text-sm font-medium text-gray-800 dark:text-gray-200">{sugerencia.nombre}</span>
              <span className={`text-sm font-semibold ${sugerencia.cambio >= 0 ? "text-green-600" : "text-red-600"}`}>{sugerencia.cambio > 0 ? `+${sugerencia.cambio}%` : `${sugerencia.cambio}%`}</span>
            </div>
            <p className="text-xs text-gray-500 dark:text-gray-400 mt-1 overflow-hidden text-ellipsis whitespace-nowrap" title={sugerencia.descripcion}>
              {sugerencia.descripcion}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default SugerenciasCard;
