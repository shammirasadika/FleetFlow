import type { DeliveryStatus } from "../types/delivery";

const STATUS_STYLES: Record<DeliveryStatus, string> = {
  Created: "bg-gray-100 text-gray-700 ring-gray-200",
  Assigned: "bg-blue-50 text-blue-700 ring-blue-200",
  Accepted: "bg-indigo-50 text-indigo-700 ring-indigo-200",
  PickedUp: "bg-purple-50 text-purple-700 ring-purple-200",
  InTransit: "bg-amber-50 text-amber-700 ring-amber-200",
  Delivered: "bg-green-50 text-green-700 ring-green-200",
  Failed: "bg-red-50 text-red-700 ring-red-200",
  Cancelled: "bg-gray-100 text-gray-500 ring-gray-200",
};

export function DeliveryStatusBadge({ status }: { status: DeliveryStatus }) {
  return (
    <span
      className={`inline-flex items-center whitespace-nowrap rounded-full px-2.5 py-0.5 text-xs font-medium ring-1 ring-inset ${STATUS_STYLES[status]}`}
    >
      {status}
    </span>
  );
}
