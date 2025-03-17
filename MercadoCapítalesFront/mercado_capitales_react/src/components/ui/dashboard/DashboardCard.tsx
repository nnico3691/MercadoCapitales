import React from "react";

type DashboardCardProps = {
  title: string;
  children?: React.ReactNode;
  className?: string; // Para personalizar ancho/alto usando Tailwind u otras clases
};

const DashboardCard: React.FC<DashboardCardProps> = ({
  title,
  children,
  className = "",
}) => {
  return (
    <div
      className={`p-2 bg-white dark:bg-slate-900 rounded shadow-md ${className}`}
    >
      <h2 className="md:text-lg font-medium text-slate-800 dark:text-slate-200 mb-2">
        {title}
      </h2>
      <div className="text-sm text-slate-600 dark:text-slate-400">{children}</div>
    </div>
  );
};

export default DashboardCard;
