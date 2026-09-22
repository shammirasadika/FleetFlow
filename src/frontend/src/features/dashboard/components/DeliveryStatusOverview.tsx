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

  const maxCount = Math.max(1, ...STATUS_ORDER.map((status) => counts[status]));

  return (
    <div className="rounded-lg border border-gray-200 bg-white p-4 shadow-sm">
      <h3 className="text-sm font-semibold text-gray-900">Delivery Status</h3>
      {isLoading ? (
        <div className="mt-4 space-y-3">
          {STATUS_ORDER.map((status) => (
            <div key={status} className="h-3 animate-pulse rounded bg-gray-100" />
          ))}
        </div>
      ) : (
        <ul className="mt-4 space-y-3">
          {STATUS_ORDER.map((status) => (
            <li key={status} className="text-sm">
              <div className="flex items-center justify-between text-gray-600">
                <span>{status}</span>
                <span className="font-medium text-gray-900">{counts[status]}</span>
              </div>
              <div className="mt-1 h-1.5 rounded-full bg-gray-100">
                <div
                  className="h-1.5 rounded-full bg-blue-500"
                  style={{ width: `${(counts[status] / maxCount) * 100}%` }}
                />
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
