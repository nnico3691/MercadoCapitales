import {FC} from "react";
import {Bar, Pie} from "react-chartjs-2";
import {Chart as ChartJS, CategoryScale, LinearScale, BarElement, ArcElement, Title, Tooltip, Legend} from "chart.js";
import ChartDataLabels from "chartjs-plugin-datalabels"; // Plugin para etiquetas en las porciones

ChartJS.register(CategoryScale, LinearScale, BarElement, ArcElement, Title, Tooltip, Legend, ChartDataLabels);

type Props = {
  inversiones: {nombre: string; total: number}[];
  type?: "bar" | "pie"; // Tipos de gráficos soportados
};

const ChartComponent: FC<Props> = ({inversiones, type = "bar"}) => {
  // Ordenamos las inversiones de mayor a menor y tomamos el top 5
  const topInversiones = [...inversiones].sort((a, b) => b.total - a.total).slice(0, 5);

  const data = {
    labels: topInversiones.map((inv) => inv.nombre),
    datasets: [
      {
        label: "Total invertido (ARS)",
        data: topInversiones.map((inv) => inv.total),
        backgroundColor: [
          "rgba(56, 78, 102, 0.6)", // Azul oscuro suave
          "rgba(72, 90, 126, 0.6)", // Azul grisáceo
          "rgba(103, 119, 141, 0.6)", // Gris azulado medio
          "rgba(138, 149, 161, 0.6)", // Gris oscuro
          "rgba(171, 182, 194, 0.6)", // Gris claro azulado
        ],
        borderColor: [
          "rgba(56, 78, 102, 1)", // Azul oscuro
          "rgba(72, 90, 126, 1)", // Azul grisáceo
          "rgba(103, 119, 141, 1)", // Gris azulado medio
          "rgba(138, 149, 161, 1)", // Gris oscuro
          "rgba(171, 182, 194, 1)", // Gris claro azulado
        ],
        borderWidth: 1.5,
        hoverBackgroundColor: [
          "rgba(56, 78, 102, 0.8)", // Azul oscuro
          "rgba(72, 90, 126, 0.8)", // Azul grisáceo
          "rgba(103, 119, 141, 0.8)", // Gris azulado medio
          "rgba(138, 149, 161, 0.8)", // Gris oscuro
          "rgba(171, 182, 194, 0.8)", // Gris claro azulado
        ], // Efecto hover
      },
    ],
  };

  const options_pie = {
    responsive: true,
    plugins: {
      legend: {
        position: "top" as const,
        display: false, // Ocultamos la leyenda
        labels: {
          font: {
            size: 0,
            family: "'Roboto', sans-serif", // Tipografía más moderna
          },
          color: "#333",
        },
      },
      title: {
        display: false, // Ocultamos los títulos
      },
      datalabels: {
        display: true, // Mostramos las etiquetas
        color: "#000", // Color de las etiquetas
        font: {
          size: 12,
          family: "'Roboto', sans-serif", // Tipografía para las etiquetas
          weight: "bold", // Negrita para mayor legibilidad
        },
        formatter: (value: number, context: any) => {
          return `${context.chart.data.labels[context.dataIndex]}`; // Muestra nombre de la especie
        },
      },
    },
    animation: {
      duration: 1000, // Animación suave
      easing: "easeOutBounce", // Efecto de rebote
    },

    scales: {
      x: {
        grid: {
          display: false, // Quitar las líneas del grid en el gráfico de barras
        },
        ticks: {
          display: false, // Ocultar los ticks del eje X
        },
        border: {
          display: false, // Ocultar la línea del eje X
        },
      },
      y: {
        grid: {
          display: false, // Líneas de grid más suaves
        },
        ticks: {
          display: false, // Ocultar los ticks del eje Y
        },
        border: {
          display: false, // Ocultar la línea del eje Y
        },
      },
    },
  };

  const options_bar = {
    responsive: true,
    plugins: {
      legend: {
        position: "top" as const,
        display: false, // Ocultamos la leyenda
        labels: {
          font: {
            size: 0,
            family: "'Roboto', sans-serif", // Tipografía más moderna
          },
          color: "#333",
        },
      },
      title: {
        display: false, // Ocultamos los títulos
      },
      datalabels: {
        display: true, // Mostramos las etiquetas
        color: "#000", // Color de las etiquetas
        font: {
          size: 12,
          family: "'Roboto', sans-serif", // Tipografía para las etiquetas
          weight: "bold", // Negrita para mayor legibilidad
        },
        formatter: (value: number, context: any) => {
          return `${context.chart.data.labels[context.dataIndex]}`; // Muestra nombre de la especie
        },
      },
    },
    animation: {
      duration: 1000, // Animación suave
      easing: "", // Efecto de rebote
    },

    // scales: {
    //   x: {
    //     grid: {
    //       display: false, // Quitar las líneas del grid en el gráfico de barras
    //     },
    //     ticks: {
    //       display: false, // Ocultar los ticks del eje X
    //     },
    //     border: {
    //       display: false, // Ocultar la línea del eje X
    //     },
    //   },
    //   y: {
    //     grid: {
    //       display: false, // Líneas de grid más suaves
    //     },
    //     ticks: {
    //       display: false, // Ocultar los ticks del eje Y
    //     },
    //     border: {
    //       display: false, // Ocultar la línea del eje Y
    //     },
    //   },
    // },
  };

  return type === "bar" ? <Bar data={data} options={options_bar} /> : <Pie data={data} options={options_pie} />;
};

export default ChartComponent;
