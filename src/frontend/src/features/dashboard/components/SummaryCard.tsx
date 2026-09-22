import type { LucideIcon } from "lucide-react";

type SummaryCardAccent = "blue" | "green" | "purple" | "orange";

const ACCENT_ICON_STYLES: Record<SummaryCardAccent, string> = {
  blue: "bg-blue-50 text-blue-600",
  green: "bg-green-50 text-green-600",
  purple: "bg-purple-50 text-purple-600",
  orange: "bg-orange-50 text-orange-600",
};

interface SummaryCardProps {
  label: string;
  value: string | number;
  icon: LucideIcon;
  helperText?: string;
  accent?: SummaryCardAccent;
}

export function SummaryCard({ label, value, icon: Icon, helperText, accent = "blue" }: SummaryCardProps) {
  return (
    <div className="rounded-xl border border-gray-100 bg-white/80 p-5 shadow-sm backdrop-blur-sm transition-shadow hover:shadow-md">
      <div className="flex items-center gap-3">
        <span className={`flex h-10 w-10 items-center justify-center rounded-xl ${ACCENT_ICON_STYLES[accent]}`}>
          <Icon className="h-5 w-5" />
        </span>
        <span className="text-sm font-medium text-gray-600">{label}</span>
      </div>
      <div className="mt-3 text-3xl font-semibold text-gray-900">{value}</div>
      {helperText && <p className="mt-1 text-xs text-gray-500">{helperText}</p>}
    </div>
  );
}
