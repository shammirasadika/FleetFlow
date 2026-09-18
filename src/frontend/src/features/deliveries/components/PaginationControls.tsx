export interface PaginationControlsProps {
  page: number;
  totalPages: number;
  onPreviousPage: () => void;
  onNextPage: () => void;
}

export function PaginationControls({
  page,
  totalPages,
  onPreviousPage,
  onNextPage,
}: PaginationControlsProps) {
  return (
    <div className="flex items-center justify-between pt-4">
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
  );
}
