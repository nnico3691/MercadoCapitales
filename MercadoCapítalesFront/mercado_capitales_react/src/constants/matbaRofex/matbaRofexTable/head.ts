const styleHead = {
  default: "px-4 py-3 md:min-w-[100px] md:max-w-[100px] md:w-[100px] text-left text-xs dark:font-medium font-bold dark:text-white text-black uppercase tracking-wider",
  hidden: "hidden md:table-cell",
  empty: "md:hidden",
};

const tableHeads = [
  {name: "Instrumento", key: "instrumentId.symbol", style: `${styleHead.default}`},
  {name: "Vol. C", key: "marketData.BI.0.size", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Compra", key: "marketData.BI.0.price", style: `${styleHead.default}`},
  {name: "Venta", key: "marketData.OF.0.price", style: `${styleHead.default}`},
  {name: "", key: "empty", style: `${styleHead.default} ${styleHead.empty}`},
  {name: "Vol. V", key: "marketData.OF.0.size", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Último", key: "marketData.LA.price", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Variación", key: "marketData.LA.price", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Cierre/Ajuste", key: "marketData.SE.price", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Min", key: "marketData.HI", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Max", key: "marketData.LO", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Vol. Nominal", key: "marketData.NV", style: `${styleHead.default} ${styleHead.hidden}`},
  {name: "Hora", key: "hora", style: `${styleHead.default} ${styleHead.hidden}`},
];

export default tableHeads;
