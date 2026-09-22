export interface PaginationControlsProps {
  page: number;
  pageSize: number;
  totalPages: number;
  totalCount: number;
  onPreviousPage: () => void;
  onNextPage: () => void;
}

export function PaginationControls({
  page,
  pageSize,
  totalPages,
  totalCount,
  onPreviousPage,
  onNextPage,
}: PaginationControlsProps) {
  const rangeStart = totalCount === 0 ? 0 : (page - 1) * pageSize + 1;
  const rangeEnd = totalCount === 0 ? 0 : Math.min(page * pageSize, totalCount);

  return (
    <div className="flex flex-col gap-3 pt-4 sm:flex-row sm:items-center sm:justify-between">
      <span className="text-sm text-gray-600">
        {totalCount > 0
          ? `Showing ${rangeStart}–${rangeEnd} of ${totalCount} deliveries`
          : "No deliveries to show"}
      </span>
      <div className="flex items-center gap-3">
        <button
          type="button"
          onClick={onPreviousPage}
          disabled={page <= 1}
          className="rounded-md border border-gray-300 px-3 py-1.5 text-sm font-medium text-gray-700 disabled:cursor-not-allowed disabled:opacity-50 hover:enabled:bg-gray-50"
        >
          Previous
        </button>
        <span className="text-sm text-gray-600">
          Page {page}
          {totalPages > 0 ? ` of ${totalPages}` : ""}
        </span>
        <button
          type="button"
          onClick={onNextPage}
          disabled={totalPages > 0 && page >= totalPages}
          className="rounded-md border border-gray-300 px-3 py-1.5 text-sm font-medium text-gray-700 disabled:cursor-not-allowed disabled:opacity-50 hover:enabled:bg-gray-50"
        >
          Next
        </button>
      </div>
    </div>
  );
}
