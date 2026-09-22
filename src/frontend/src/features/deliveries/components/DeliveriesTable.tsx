import type { Delivery } from "../types/delivery";
import { DeliveryPriorityBadge } from "./DeliveryPriorityBadge";
import { DeliveryStatusBadge } from "./DeliveryStatusBadge";

function formatDate(value: string): string {
  const date = new Date(value);
  if (Number.isNaN(date.getTime())) {
    return value;
  }
  return date.toLocaleDateString(undefined, {
    year: "numeric",
    month: "short",
    day: "numeric",
  });
}

export function DeliveriesTable({ deliveries }: { deliveries: Delivery[] }) {
  return (
    <div className="overflow-x-auto rounded-lg border border-gray-200">
      <table className="min-w-full divide-y divide-gray-200 text-sm">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Customer</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Route</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Scheduled Date</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Priority</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Status</th>
          </tr>
        </thead>
        <tbody className="divide-y divide-gray-100 bg-white">
          {deliveries.map((delivery) => (
            <tr key={delivery.id} className="align-top hover:bg-gray-50">
              <td className="px-4 py-3">
                <div className="font-medium text-gray-900">{delivery.customerName}</div>
                {delivery.customerPhone && (
                  <div className="mt-0.5 text-xs text-gray-500">{delivery.customerPhone}</div>
                )}
              </td>
              <td className="px-4 py-3 text-gray-700">
                <div className="flex flex-col gap-0.5">
                  <span>{delivery.pickupAddress}</span>
                  <span className="text-xs text-gray-400" aria-hidden="true">
                    ↓
                  </span>
                  <span>{delivery.deliveryAddress}</span>
                </div>
              </td>
              <td className="whitespace-nowrap px-4 py-3 text-gray-700">
                {formatDate(delivery.scheduledDate)}
              </td>
              <td className="px-4 py-3">
                <DeliveryPriorityBadge priority={delivery.priority} />
              </td>
              <td className="px-4 py-3">
                <DeliveryStatusBadge status={delivery.status} />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
