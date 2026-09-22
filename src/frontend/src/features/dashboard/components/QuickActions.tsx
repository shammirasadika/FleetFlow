import { Package, PackagePlus, Truck, Users } from "lucide-react";
import { Link } from "react-router-dom";

const ACTION_STYLES = {
  blue: "border-blue-100 bg-blue-50/60 hover:bg-blue-100",
  green: "border-green-100 bg-green-50/60 hover:bg-green-100",
  purple: "border-purple-100 bg-purple-50/60 hover:bg-purple-100",
  orange: "border-orange-100 bg-orange-50/60 hover:bg-orange-100",
} as const;

const ICON_STYLES = {
  blue: "bg-blue-600",
  green: "bg-green-600",
  purple: "bg-purple-600",
  orange: "bg-orange-600",
} as const;

export function QuickActions() {
  return (
    <div className="rounded-xl border border-gray-100 bg-white/80 p-5 shadow-sm backdrop-blur-sm">
      <h3 className="text-base font-semibold text-gray-900">Quick Actions</h3>
      <div className="mt-4 grid grid-cols-2 gap-3">
        <Link
          to="/deliveries"
          className={`flex flex-col items-start gap-2 rounded-lg border p-3 transition-colors focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:outline-none ${ACTION_STYLES.blue}`}
        >
          <span className={`rounded-md p-1.5 text-white ${ICON_STYLES.blue}`}>
            <Package className="h-4 w-4" />
          </span>
          <span className="text-sm font-medium text-gray-800">View Deliveries</span>
        </Link>
        <button
          type="button"
          disabled
          title="Coming soon"
          className={`flex flex-col items-start gap-2 rounded-lg border p-3 text-left opacity-60 transition-colors disabled:cursor-not-allowed ${ACTION_STYLES.green}`}
        >
          <span className={`rounded-md p-1.5 text-white ${ICON_STYLES.green}`}>
            <PackagePlus className="h-4 w-4" />
          </span>
          <span className="text-sm font-medium text-gray-800">Add Delivery</span>
        </button>
        <Link
          to="/drivers"
          className={`flex flex-col items-start gap-2 rounded-lg border p-3 transition-colors focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:outline-none ${ACTION_STYLES.purple}`}
        >
          <span className={`rounded-md p-1.5 text-white ${ICON_STYLES.purple}`}>
            <Users className="h-4 w-4" />
          </span>
          <span className="text-sm font-medium text-gray-800">View Drivers</span>
        </Link>
        <Link
          to="/vehicles"
          className={`flex flex-col items-start gap-2 rounded-lg border p-3 transition-colors focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:outline-none ${ACTION_STYLES.orange}`}
        >
          <span className={`rounded-md p-1.5 text-white ${ICON_STYLES.orange}`}>
            <Truck className="h-4 w-4" />
          </span>
          <span className="text-sm font-medium text-gray-800">View Vehicles</span>
        </Link>
      </div>
    </div>
  );
}
