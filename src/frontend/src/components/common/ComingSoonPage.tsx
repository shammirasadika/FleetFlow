interface ComingSoonPageProps {
  title: string;
  description?: string;
}

export function ComingSoonPage({ title, description }: ComingSoonPageProps) {
  return (
    <div className="mx-auto max-w-5xl p-6">
      <h1 className="text-xl font-semibold text-gray-900">{title}</h1>
      <div className="mt-6 rounded-lg border border-dashed border-gray-300 bg-white p-10 text-center">
        <p className="text-sm font-medium text-gray-900">Coming soon</p>
        <p className="mt-1 text-sm text-gray-500">
          {description ?? `${title} management isn't available yet.`}
        </p>
      </div>
    </div>
  );
}
