import { Package, RefreshCw, Truck, Users } from "lucide-react";

import { DeliveryStatusOverview } from "../features/dashboard/components/DeliveryStatusOverview";
import { OperationsHighlight } from "../features/dashboard/components/OperationsHighlight";
import { QuickActions } from "../features/dashboard/components/QuickActions";
import { RecentDeliveries } from "../features/dashboard/components/RecentDeliveries";
import { SummaryCard } from "../features/dashboard/components/SummaryCard";
import { useDeliveries } from "../features/deliveries/hooks/useDeliveries";

// Largest page size the API allows; used to sample enough deliveries for the overview widgets.
const OVERVIEW_SAMPLE_SIZE = 100;

export function DashboardPage() {
  const { data, isLoading, isError, error, refetch } = useDeliveries({
    page: 1,
    pageSize: OVERVIEW_SAMPLE_SIZE,
  });

  const deliveries = data?.items ?? [];
  const inTransitCount = deliveries.filter((delivery) => delivery.status === "InTransit").length;
  const recentDeliveries = deliveries.slice(0, 5);

  return (
    <div className="relative mx-auto max-w-6xl p-6">
      <div className="mb-8">
        <h1 className="text-2xl font-bold tracking-tight text-gray-900 sm:text-3xl">Dashboard</h1>
        <p className="mt-2 text-sm text-gray-600 sm:text-base">
          Overview of your fleet and delivery operations
        </p>
        <div className="mt-3 h-1 w-16 rounded-full bg-gradient-to-r from-blue-500 to-cyan-400" />
      </div>

      {isError && (
        <div className="mb-6 rounded-lg border border-red-200 bg-red-50 p-4">
          <p className="text-sm font-medium text-red-800">Failed to load delivery data</p>
          <p className="mt-1 text-sm text-red-700">
            {error instanceof Error ? error.message : "Unknown error"}
          </p>
          <button
            type="button"
            onClick={() => refetch()}
            className="mt-3 inline-flex items-center gap-2 rounded-md border border-red-300 bg-white px-3 py-1.5 text-sm font-medium text-red-700 hover:bg-red-100"
          >
            <RefreshCw className="h-4 w-4" />
            Retry
          </button>
        </div>
      )}

      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-4">
        <SummaryCard
          label="Total Deliveries"
          value={isLoading ? "--" : (data?.totalCount ?? "--")}
          icon={Package}
          helperText="All delivery jobs"
          accent="blue"
        />
        <SummaryCard
          label="In Transit"
          value={isLoading ? "--" : inTransitCount}
          icon={Truck}
          helperText="Active shipments"
          accent="green"
        />
        <SummaryCard
          label="Drivers"
          value="--"
          icon={Users}
          helperText="Driver data not yet available"
          accent="purple"
        />
        <SummaryCard
          label="Vehicles"
          value="--"
          icon={Truck}
          helperText="Vehicle data not yet available"
          accent="orange"
        />
      </div>

      <div className="mt-6 grid grid-cols-1 gap-6 lg:grid-cols-3">
        <div className="lg:col-span-2">
          <DeliveryStatusOverview deliveries={deliveries} isLoading={isLoading} />
        </div>
        <QuickActions />
      </div>

      <div className="mt-6 grid grid-cols-1 gap-6 lg:grid-cols-3">
        <div className="lg:col-span-2">
          <RecentDeliveries deliveries={recentDeliveries} isLoading={isLoading} />
        </div>
        <OperationsHighlight />
      </div>
    </div>
  );
}