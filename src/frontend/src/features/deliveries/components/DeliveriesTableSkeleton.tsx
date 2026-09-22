const SKELETON_ROWS = 8;

export function DeliveriesTableSkeleton() {
  return (
    <div className="overflow-x-auto rounded-lg border border-gray-200">
      <table className="min-w-full divide-y divide-gray-200 text-sm">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Customer</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Route</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Scheduled Date</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Priority</th>
            <th className="px-4 py-2 text-left font-medium text-gray-600">Status</th>
          </tr>
        </thead>
        <tbody className="divide-y divide-gray-100 bg-white">
          {Array.from({ length: SKELETON_ROWS }, (_, index) => (
            <tr key={index}>
              <td className="px-4 py-3">
                <div className="h-3 w-32 animate-pulse rounded bg-gray-200" />
                <div className="mt-2 h-2.5 w-20 animate-pulse rounded bg-gray-100" />
              </td>
              <td className="px-4 py-3">
                <div className="h-3 w-40 animate-pulse rounded bg-gray-200" />
                <div className="mt-2 h-3 w-36 animate-pulse rounded bg-gray-100" />
              </td>
              <td className="px-4 py-3">
                <div className="h-3 w-24 animate-pulse rounded bg-gray-200" />
              </td>
              <td className="px-4 py-3">
                <div className="h-5 w-16 animate-pulse rounded-full bg-gray-200" />
              </td>
              <td className="px-4 py-3">
                <div className="h-5 w-20 animate-pulse rounded-full bg-gray-200" />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
