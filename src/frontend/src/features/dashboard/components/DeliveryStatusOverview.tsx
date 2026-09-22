import { ChevronDown } from "lucide-react";

import type { Delivery, DeliveryStatus } from "../../deliveries/types/delivery";

const STATUS_ORDER: DeliveryStatus[] = [
  "Created",
  "Assigned",
  "Accepted",
  "PickedUp",
  "InTransit",
  "Delivered",
  "Failed",
  "Cancelled",
];

// Tailwind class for the legend dot alongside the equivalent hex value for the CSS conic-gradient donut.
const STATUS_COLORS: Record<DeliveryStatus, { dot: string; hex: string }> = {
  Created: { dot: "bg-gray-400", hex: "#9ca3af" },
  Assigned: { dot: "bg-blue-500", hex: "#3b82f6" },
  Accepted: { dot: "bg-indigo-500", hex: "#6366f1" },
  PickedUp: { dot: "bg-purple-500", hex: "#a855f7" },
  InTransit: { dot: "bg-amber-500", hex: "#f59e0b" },
  Delivered: { dot: "bg-green-500", hex: "#22c55e" },
  Failed: { dot: "bg-red-500", hex: "#ef4444" },
  Cancelled: { dot: "bg-gray-300", hex: "#d1d5db" },
};

interface DeliveryStatusOverviewProps {
  deliveries: Delivery[];
  isLoading: boolean;
}

export function DeliveryStatusOverview({ deliveries, isLoading }: DeliveryStatusOverviewProps) {
  const counts = STATUS_ORDER.reduce<Record<DeliveryStatus, number>>((acc, status) => {
    acc[status] = 0;
    return acc;
  }, {} as Record<DeliveryStatus, number>);

  deliveries.forEach((delivery) => {
    counts[delivery.status] += 1;
  });

  const total = deliveries.length;
  const activeStatuses = STATUS_ORDER.filter((status) => counts[status] > 0);

  let cursor = 0;
  const gradientStops = activeStatuses.map((status) => {
    const start = cursor;
    cursor += total > 0 ? (counts[status] / total) * 100 : 0;
    return `${STATUS_COLORS[status].hex} ${start}% ${cursor}%`;
  });
  const donutBackground = gradientStops.length > 0 ? `conic-gradient(${gradientStops.join(", ")})` : "#e5e7eb";

  return (
    <div className="rounded-xl border border-gray-100 bg-white/80 p-5 shadow-sm backdrop-blur-sm">
      <div className="flex items-center justify-between">
        <h3 className="text-base font-semibold text-gray-900">Delivery Status</h3>
        <button
          type="button"
          disabled
          title="Filtering coming soon"
          className="flex items-center gap-1 rounded-full border border-gray-200 px-3 py-1 text-xs font-medium text-gray-500 disabled:cursor-not-allowed"
        >
          All time
          <ChevronDown className="h-3 w-3" />
        </button>
      </div>

      {isLoading ? (
        <div className="mt-6 flex items-center gap-6">
          <div className="h-36 w-36 shrink-0 animate-pulse rounded-full bg-gray-100" />
          <div className="flex-1 space-y-3">
            {STATUS_ORDER.slice(0, 4).map((status) => (
              <div key={status} className="h-3 animate-pulse rounded bg-gray-100" />
            ))}
          </div>
        </div>
      ) : total === 0 ? (
        <p className="mt-6 text-sm text-gray-500">No delivery data available.</p>
      ) : (
        <div className="mt-6 flex flex-col items-center gap-6 sm:flex-row">
          <div className="relative h-36 w-36 shrink-0 rounded-full" style={{ background: donutBackground }}>
            <div className="absolute inset-3 flex flex-col items-center justify-center rounded-full bg-white">
              <span className="text-2xl font-bold text-gray-900">{total}</span>
              <span className="text-xs text-gray-500">Total</span>
            </div>
          </div>
          <ul className="w-full flex-1 space-y-3">
            {activeStatuses.map((status) => (
              <li key={status} className="flex items-center justify-between text-sm">
                <span className="flex items-center gap-2 text-gray-600">
                  <span className={`h-2.5 w-2.5 rounded-full ${STATUS_COLORS[status].dot}`} />
                  {status}
                </span>
                <span className="font-semibold text-gray-900">{counts[status]}</span>
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}
