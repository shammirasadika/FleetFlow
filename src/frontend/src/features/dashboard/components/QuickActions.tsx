import { Package, PackagePlus, Truck, Users } from "lucide-react";
import { Link } from "react-router-dom";

export function QuickActions() {
  return (
    <div className="rounded-lg border border-gray-200 bg-white p-4 shadow-sm">
      <h3 className="text-sm font-semibold text-gray-900">Quick Actions</h3>
      <div className="mt-4 flex flex-col gap-2">
        <Link
          to="/deliveries"
          className="flex items-center gap-2 rounded-md border border-gray-200 px-3 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        >
          <Package className="h-4 w-4" />
          View Deliveries
        </Link>
        <button
          type="button"
          disabled
          title="Coming soon"
          className="flex items-center gap-2 rounded-md border border-gray-200 px-3 py-2 text-sm font-medium text-gray-400 disabled:cursor-not-allowed"
        >
          <PackagePlus className="h-4 w-4" />
          Add Delivery
        </button>
        <Link
          to="/drivers"
          className="flex items-center gap-2 rounded-md border border-gray-200 px-3 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        >
          <Users className="h-4 w-4" />
          View Drivers
        </Link>
        <Link
          to="/vehicles"
          className="flex items-center gap-2 rounded-md border border-gray-200 px-3 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        >
          <Truck className="h-4 w-4" />
          View Vehicles
        </Link>
      </div>
    </div>
  );
}
