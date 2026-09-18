import { useState } from "react";

import { DeliveriesTable } from "../features/deliveries/components/DeliveriesTable";
import { PaginationControls } from "../features/deliveries/components/PaginationControls";
import { useDeliveries } from "../features/deliveries/hooks/useDeliveries";

const PAGE_SIZE = 20;

export function DeliveriesPage() {
  const [page, setPage] = useState(1);
  const { data, isLoading, isError, error } = useDeliveries({ page, pageSize: PAGE_SIZE });

  const totalPages = data ? Math.ceil(data.totalCount / data.pageSize) : 0;

  return (
    <div className="mx-auto max-w-5xl p-6">
      <h1 className="mb-4 text-xl font-semibold text-gray-900">Deliveries</h1>

      {isLoading && <p className="text-gray-600">Loading deliveries…</p>}

      {isError && (
        <p className="text-red-600">
          Failed to load deliveries: {error instanceof Error ? error.message : "Unknown error"}
        </p>
      )}

      {!isLoading && !isError && data && data.items.length === 0 && (
        <p className="text-gray-600">No deliveries found.</p>
      )}

      {!isLoading && !isError && data && data.items.length > 0 && (
        <>
          <DeliveriesTable deliveries={data.items} />
          <PaginationControls
            page={page}
            totalPages={totalPages}
            onPreviousPage={() => setPage((current) => Math.max(1, current - 1))}
            onNextPage={() => setPage((current) => (totalPages > 0 ? Math.min(totalPages, current + 1) : current + 1))}
          />
        </>
      )}
    </div>
  );
}