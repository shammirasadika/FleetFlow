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
    <div className="rounded-xl border border-gray-100 bg-white/80 p-5 shadow-sm backdrop-blur-sm">
      <div className="mb-4 flex items-center justify-between">
        <h3 className="text-base font-semibold text-gray-900">Recent Deliveries</h3>
        <Link
          to="/deliveries"
          className="rounded-md text-sm font-medium text-blue-600 hover:text-blue-700 focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:outline-none"
        >
          View all
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
