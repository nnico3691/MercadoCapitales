import React, {useState, useEffect, useRef, memo} from "react";
import MatBarofexPopup from "./MatbaRofexPopup";
import {FaChevronDown, FaChevronUp} from "react-icons/fa";

// Interfaces
interface MatbaRofexMarketDataDto {
  type: string;
  timestamp: number;
  instrumentId: {
    marketId: string;
    symbol: string;
  };
  marketData: {
    OP?: number | null | undefined;
    EV: number;
    CL?: {price?: number; date: number};
    OF?: {price: number; size: number}[];
    OI?: {size?: number; date: number};
    BI?: {price: number; size: number}[];
    HI?: number | null;
    SE?: {price?: number; date: number};
    NV?: number;
    TV?: number;
    ACP?: number | null;
    LO?: number | null;
    IV?: number | null;
    LA?: {price?: number; size?: number; date?: number};
  };
}
interface MatbaRofexTableProps {
  marketData: MatbaRofexMarketDataDto[];
}

const MatbaRofexTable: React.FC<MatbaRofexTableProps> = ({marketData}) => {
  // State hooks
  const [expandedRows, setExpandedRows] = useState<{[key: number]: boolean}>({});
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedOrder, setSelectedOrder] = useState<{
    symbol: string;
    price: number;
    size: number;
  } | null>(null);
  const [highlightedBuyRows, setHighlightedBuyRows] = useState<{
    [key: number]: boolean;
  }>({});
  const [highlightedSellRows, setHighlightedSellRows] = useState<{
    [key: number]: boolean;
  }>({});

  // Previous market data ref
  const prevMarketData = useRef<MatbaRofexMarketDataDto[]>(marketData);

  // Effect for row highlighting based on price change
  useEffect(() => {
    const newHighlightedBuyRows: {[key: number]: boolean} = {};
    const newHighlightedSellRows: {[key: number]: boolean} = {};

    marketData.forEach((item, index) => {
      const currentBuyPrice = item.marketData.BI?.[0]?.price ?? null;
      const currentSellPrice = item.marketData.OF?.[0]?.price ?? null;
      const prevItem = prevMarketData.current[index];

      if (prevItem) {
        const prevBuyPrice = prevItem.marketData.BI?.[0]?.price ?? null;
        const prevSellPrice = prevItem.marketData.OF?.[0]?.price ?? null;

        if (currentBuyPrice !== prevBuyPrice) {
          newHighlightedBuyRows[index] = true;
        }

        if (currentSellPrice !== prevSellPrice) {
          newHighlightedSellRows[index] = true;
        }
      }
    });

    setHighlightedBuyRows(newHighlightedBuyRows);
    setHighlightedSellRows(newHighlightedSellRows);

    const timeout = setTimeout(() => {
      setHighlightedBuyRows({});
      setHighlightedSellRows({});
    }, 2000);

    return () => clearTimeout(timeout);
  }, [marketData]);

  // Update previous market data when marketData changes
  useEffect(() => {
    prevMarketData.current = [...marketData];
  }, [marketData]);

  // Toggle row expansion
  const toggleRowExpansion = (index: number) => {
    setExpandedRows((prev) => ({...prev, [index]: !prev[index]}));
  };

  // Modal handling
  const handleInstrumentClick = (symbol: string, price: number, size: number) => {
    setSelectedOrder({symbol, price, size});
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
    setSelectedOrder(null);
  };

  const handleSubmit = () => {
    // Submit order logic (to be implemented)
  };

  // Number formatting
  const formatNumber = (number: number) => {
    return new Intl.NumberFormat("es-AR", {
      style: "decimal",
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    }).format(number);
  };

  const styleBody = {
    instrumentRow: "dark:bg-teal-950 bg-teal-100 hover:underline md:font-bold dark:bg-opacity-40 bg-opacity-35 w-[150px] min-w-[150px] max-w-[150px] ",
    paddingDefault: "px-4 py-1",
    defaultWidth: "max-w-[100px] w-[100px] min-w-[100px]",
    default: "whitespace-nowrap text-xs cursor-pointer",
    hiddenMd: "hidden md:table-cell",
    hover: "dark:hover:bg-slate-900 hover:bg-slate-200",
  };

  const styleHead = {
    default: "px-4 py-2 md:min-w-[100px] md:max-w-[100px] md:w-[100px] text-left text-xs dark:font-medium font-bold dark:text-white text-black uppercase tracking-wider",
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
  // Render table rows
  const renderTableRows = () => {
    return marketData.length ? (
      marketData.map((item, index) => {
        const currentPriceSell = item.marketData.OF?.[item.marketData.OF.length - 1]?.price || 0;
        const currentSizeSell = item.marketData.OF?.[item.marketData.OF.length - 1]?.size || 0;

        const variacion = item.marketData.LA?.price != null && item.marketData.CL?.price != null ? parseFloat((((item.marketData.LA.price - item.marketData.CL.price) / item.marketData.CL.price) * 100).toFixed(2)) : 0;

        return (
          <React.Fragment key={index}>
            <tr className={`${styleBody.hover}`}>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.instrumentRow}`} onClick={() => handleInstrumentClick(item.instrumentId.symbol, currentPriceSell, currentSizeSell)}>
                {item.instrumentId.symbol ?? "N/A"}
              </td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.defaultWidth} ${styleBody.hiddenMd} dark:bg-emerald-950 bg-emerald-50  dark:bg-opacity-20 bg-opacity-35`}>{item.marketData.BI?.[0]?.size ?? "-"}</td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.defaultWidth} dark:bg-emerald-950 bg-emerald-50  bg-opacity-35 dark:bg-opacity-20 ${highlightedBuyRows[index] ? "dark:bg-emerald-300 dark:bg-opacity-60 bg-emerald-200 bg-opacity-60" : ""}`}>{formatNumber(item.marketData.BI?.[0]?.price ?? 0)}</td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.defaultWidth} dark:bg-red-950 bg-red-50 bg-opacity-65 dark:bg-opacity-20 ${highlightedSellRows[index] ? "dark:bg-red-300 dark:bg-opacity-60 bg-red-300 bg-opacity-60" : ""}`}>{formatNumber(item.marketData.OF?.[0]?.price ?? 0)}</td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.defaultWidth} md:hidden text-center`} onClick={() => toggleRowExpansion(index)}>
                {expandedRows[index] ? <FaChevronUp /> : <FaChevronDown />}
              </td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.hiddenMd} ${styleBody.defaultWidth} dark:bg-red-950 bg-red-50  bg-opacity-65 dark:bg-opacity-20`}>{item.marketData.OF?.[0]?.size ?? "-"}</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{formatNumber(item.marketData.LA?.price ?? 0)}</td>
              <td className={`${styleBody.paddingDefault} ${styleBody.default} ${styleBody.hiddenMd} ${styleBody.defaultWidth} ${variacion >= 0 ? "text-green-500" : "text-red-500"}`}>{variacion}%</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{formatNumber(item.marketData.SE?.price ?? 0)}</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{formatNumber(item.marketData.HI ?? 0)}</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{formatNumber(item.marketData.LO ?? 0)}</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{formatNumber(item.marketData.NV ?? 0)}</td>
              <td className={`${styleBody.default} ${styleBody.hiddenMd} ${styleBody.paddingDefault} ${styleBody.defaultWidth}`}>{"13:45:43"}</td>
            </tr>

            {expandedRows[index] && (
              <tr className="dark:bg-slate-900 bg-inherit md:hidden">
                <td colSpan={5}>
                  <div className="p-4 text-xs sm:text-sm dark:text-white text-slate-950 space-y-2">
                    <div>
                      <strong>Vol. V:</strong> {item.marketData.OF?.[0]?.size ?? "-"}
                    </div>
                    <div>
                      <strong>Último:</strong> {item.marketData.LA?.price ?? "-"}
                    </div>
                    <div>
                      <strong>Variación:</strong> <span className={variacion >= 0 ? "text-green-500" : "text-red-500"}>{variacion}%</span>
                    </div>
                    <div>
                      <strong>Cierre/Ajuste:</strong> {item.marketData.SE?.price ?? "-"}
                    </div>
                    <div>
                      <strong>Min:</strong> {item.marketData.HI ?? "-"}
                    </div>
                    <div>
                      <strong>Max:</strong> {item.marketData.LO ?? "-"}
                    </div>
                    <div>
                      <strong>Vol. Nominal:</strong> {item.marketData.NV ?? "-"}
                    </div>
                    <div>
                      <strong>Hora:</strong> {"13:45:43"}
                    </div>
                  </div>
                </td>
              </tr>
            )}
          </React.Fragment>
        );
      })
    ) : (
      <tr>
        <td colSpan={12} className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
          No data available
        </td>
      </tr>
    );
  };

  return (
    <div className="rounded-md border-t-2 md:border dark:border-gray-800 border-gray-400 md:shadow-md dark:md:shadow-gray-800 max-h-full md:max-h-[700px] max-w-full w-full flex flex-col overflow-scroll overflow-x-scroll scrollbar-none sm:scrollbar dark:scrollbar-thumb-slate-600 dark:hover:scrollbar-thumb-slate-500 hover:scrollbar-thumb-slate-300 scrollbar-thumb-slate-200 ">
      <table className="w-full table-auto divide-y dark:divide-black divide-slate-400 opacity-95">
        <thead className="dark:bg-slate-950 bg-slate-100 sticky top-0 z-10 m-0">
          <tr>
            {tableHeads.map((head, index) => (
              <th key={index} className={head.style}>
                {head.name}
              </th>
            ))}
          </tr>
        </thead>
        <tbody className="dark:bg-slate-950 bg-slate-50 divide-y dark:text-white text-slate-950 dark:divide-gray-700 divide-slate-400 ">{renderTableRows()}</tbody>
      </table>

      {selectedOrder && <MatBarofexPopup isOpen={isModalOpen} closeModal={closeModal} order={selectedOrder} handleSubmit={handleSubmit} />}
    </div>
  );
};

export default memo(MatbaRofexTable);
