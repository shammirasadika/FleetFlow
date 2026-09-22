import type { DeliveryPriority } from "../types/delivery";

const PRIORITY_STYLES: Record<DeliveryPriority, string> = {
  Low: "bg-gray-100 text-gray-600 ring-gray-200",
  Normal: "bg-blue-50 text-blue-700 ring-blue-200",
  High: "bg-orange-50 text-orange-700 ring-orange-200",
  Urgent: "bg-red-50 text-red-700 ring-red-200",
};

export function DeliveryPriorityBadge({ priority }: { priority: DeliveryPriority }) {
  return (
    <span
      className={`inline-flex items-center whitespace-nowrap rounded-full px-2.5 py-0.5 text-xs font-medium ring-1 ring-inset ${PRIORITY_STYLES[priority]}`}
    >
      {priority}
    </span>
  );
}
