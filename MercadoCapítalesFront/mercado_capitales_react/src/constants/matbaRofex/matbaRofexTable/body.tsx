const bodyStyles = {
    default: 'px-4 py-1.5 text-xs  sm:text-sm max-w-[100px] whitespace-nowrap cursor-pointer',
    hidden: 'hidden md:table-cell',
    symbol: 'max-w-[170px] hover:underline dark:bg-sky-950 bg-blue-200 font-bold',
    opacity: 'dark:bg-opacity-40 bg-opacity-35',
    emerald: 'dark:bg-emerald-950 bg-emerald-50',
    red: 'dark:bg-red-950 bg-red-50',
};


const tableColumnsBody = [
    { key: 'symbol', className: ` ${bodyStyles.symbol} ${bodyStyles.default}  ${bodyStyles.opacity} `, content: (item: any) => item.instrumentId.symbol ?? 'N/A' },
    { key: 'BI.size', className: `${bodyStyles.hidden} ${bodyStyles.default} ${bodyStyles.opacity} ${bodyStyles.emerald} `, content: (item: any) => item.marketData.BI?.[0]?.size ?? '-' },
    { key: 'BI.price', className: ` ${bodyStyles.default} ${bodyStyles.opacity} ${bodyStyles.emerald} `, content: (item: any) => item.marketData.BI?.[0]?.price ?? '-' },
    { key: 'OF.price', className: ` ${bodyStyles.default} ${bodyStyles.opacity}  ${bodyStyles.red} `, content: (item: any) => item.marketData.OF?.[0]?.price ?? '-' },
    { key: 'OF.size', className: `${bodyStyles.hidden} ${bodyStyles.default}  ${bodyStyles.opacity}  ${bodyStyles.red}  `, content: (item: any) => item.marketData.OF?.[0]?.size ?? '-' },
    { key: 'LA.price', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => item.marketData.LA?.price ?? '-' },
    {
        key: 'variacion', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => {
            const variacion = item.marketData.LA?.price != null && item.marketData.CL?.price != null
                ? parseFloat((((item.marketData.LA.price) - (item.marketData.CL.price)) / (item.marketData.CL.price) * 100).toFixed(2))
                : 0;
            return <span className={variacion >= 0 ? 'text-green-500' : 'text-red-500'}>{variacion}%</span>;
        }
    },
    { key: 'SE.price', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => item.marketData.SE?.price ?? '-' },
    { key: 'HI', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => item.marketData.HI ?? '-' },
    { key: 'LO', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => item.marketData.LO ?? '-' },
    { key: 'NV', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: (item: any) => item.marketData.NV ?? '-' },
    { key: 'time', className: `${bodyStyles.default} ${bodyStyles.hidden}`, content: () => '13:45:43' },
];



export default tableColumnsBody;