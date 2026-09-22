import { useState } from "react";
import { PackagePlus, RefreshCw } from "lucide-react";

import { DeliveriesTable } from "../features/deliveries/components/DeliveriesTable";
import { DeliveriesTableSkeleton } from "../features/deliveries/components/DeliveriesTableSkeleton";
import { PaginationControls } from "../features/deliveries/components/PaginationControls";
import { useDeliveries } from "../features/deliveries/hooks/useDeliveries";

const PAGE_SIZE = 20;

export function DeliveriesPage() {
  const [page, setPage] = useState(1);
  const { data, isLoading, isError, error, refetch, isFetching } = useDeliveries({
    page,
    pageSize: PAGE_SIZE,
  });

  const totalPages = data ? Math.ceil(data.totalCount / data.pageSize) : 0;

  return (
    <div className="mx-auto max-w-5xl p-6">
      <div className="mb-6 flex flex-col gap-4 sm:flex-row sm:items-start sm:justify-between">
        <div>
          <h1 className="text-xl font-semibold text-gray-900">Deliveries</h1>
          <p className="mt-1 text-sm text-gray-500">Manage and track delivery jobs</p>
        </div>
        <button
          type="button"
          disabled
          title="Coming soon"
          className="inline-flex items-center gap-2 self-start rounded-md bg-blue-600 px-3.5 py-2 text-sm font-medium text-white shadow-sm disabled:cursor-not-allowed disabled:opacity-60"
        >
          <PackagePlus className="h-4 w-4" />
          Add Delivery
        </button>
      </div>

      {isLoading && <DeliveriesTableSkeleton />}

      {isError && (
        <div className="rounded-lg border border-red-200 bg-red-50 p-4">
          <p className="text-sm font-medium text-red-800">Failed to load deliveries</p>
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

      {!isLoading && !isError && data && data.items.length === 0 && (
        <div className="rounded-lg border border-gray-200 bg-white p-10 text-center">
          <p className="text-sm font-medium text-gray-900">No deliveries found.</p>
          <p className="mt-1 text-sm text-gray-500">Create a delivery to get started.</p>
        </div>
      )}

      {!isLoading && !isError && data && data.items.length > 0 && (
        <div className={isFetching ? "opacity-60 transition-opacity" : undefined}>
          <DeliveriesTable deliveries={data.items} />
          <PaginationControls
            page={page}
            pageSize={data.pageSize}
            totalCount={data.totalCount}
            totalPages={totalPages}
            onPreviousPage={() => setPage((current) => Math.max(1, current - 1))}
            onNextPage={() =>
              setPage((current) => (totalPages > 0 ? Math.min(totalPages, current + 1) : current + 1))
            }
          />
        </div>
      )}
    </div>
  );
}