import { Link } from "react-router-dom";

import { DeliveriesTable } from "../../deliveries/components/DeliveriesTable";
import { DeliveriesTableSkeleton } from "../../deliveries/components/DeliveriesTableSkeleton";
import type { Delivery } from "../../deliveries/types/delivery";

interface RecentDeliveriesProps {
  deliveries: Delivery[];
  isLoading: boolean;
}

export function RecentDeliveries({ deliveries, isLoading }: RecentDeliveriesProps) {
  return (
    <div className="rounded-lg border border-gray-200 bg-white p-4 shadow-sm">
      <div className="mb-4 flex items-center justify-between">
        <h3 className="text-sm font-semibold text-gray-900">Recent Deliveries</h3>
        <Link to="/deliveries" className="text-sm font-medium text-blue-600 hover:text-blue-700">
          View all deliveries
        </Link>
      </div>
      {isLoading ? (
        <DeliveriesTableSkeleton />
      ) : deliveries.length === 0 ? (
        <p className="text-sm text-gray-500">No deliveries found.</p>
      ) : (
        <DeliveriesTable deliveries={deliveries} />
      )}
    </div>
  );
}
