import type { Delivery } from "../types/delivery";

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
            <th className="px-4 py-2 text-left font-medium text-gray-600">Pickup</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Destination</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Scheduled Date</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Priority</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Status</th>
          </tr>
        </thead>
        <tbody className="divide-y divide-gray-100 bg-white">
          {deliveries.map((delivery) => (
            <tr key={delivery.id}>
              <td className="px-4 py-2 text-gray-900">{delivery.customerName}</td>
              <td className="px-4 py-2 text-gray-700">{delivery.pickupAddress}</td>
              <td className="px-4 py-2 text-gray-700">{delivery.deliveryAddress}</td>
              <td className="px-4 py-2 text-gray-700">{formatDate(delivery.scheduledDate)}</td>
              <td className="px-4 py-2 text-gray-700">{delivery.priority}</td>
              <td className="px-4 py-2 text-gray-700">{delivery.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
