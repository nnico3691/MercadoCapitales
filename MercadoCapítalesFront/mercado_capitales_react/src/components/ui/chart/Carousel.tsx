import {useState} from "react";
import {FaChevronLeft, FaChevronRight} from "react-icons/fa";
import Chart from "@/components/ui/chart/Chart";
const Carousel = () => {
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
      total: 9420.0,
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
      total: 44600.0,
    },
  ];

  const [currentIndex, setCurrentIndex] = useState(0);
  const charts = [<Chart inversiones={inversiones} type="bar" />, <Chart inversiones={inversiones} type="pie" />];

  const prevSlide = () => {
    setCurrentIndex((prevIndex) => (prevIndex === 0 ? charts.length - 1 : prevIndex - 1));
  };

  const nextSlide = () => {
    setCurrentIndex((prevIndex) => (prevIndex === charts.length - 1 ? 0 : prevIndex + 1));
  };

  return (
    <div className="relative w-full h-full">
      <div className="overflow-hidden h-full">
        <div className="flex max-h-full max-w-full transition-transform duration-500" style={{transform: `translateX(-${currentIndex * 100}%)`}}>
          {charts.map((chart, index) => (
            <div key={index} className="w-full mx-auto flex-shrink-0 h-full flex items-center justify-center">
              {chart}
            </div>
          ))}
        </div>
      </div>
      {/* <button onClick={prevSlide} className="absolute bottom-0 left-0 transform -translate-y-1/2 p-2 dark:hover:bg-slate-600 hover:bg-slate-300 bg-gray-200 dark:bg-gray-800 rounded-full">
        <FaChevronLeft className="h-3 w-3 text-gray-800 dark:text-gray-200 " />
      </button>
      <button onClick={nextSlide} className="absolute bottom-0 right-0 transform -translate-y-1/2 p-2 dark:hover:bg-slate-600 hover:bg-slate-300 bg-gray-200  dark:bg-gray-800 rounded-full">
        <FaChevronRight className="h-3 w-3 text-gray-800 dark:text-gray-200" />
      </button> */}
    </div>
  );
};

export default Carousel;
