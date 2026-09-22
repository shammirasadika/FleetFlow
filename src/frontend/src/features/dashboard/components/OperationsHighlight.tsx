import { Quote, Truck } from "lucide-react";

// Decorative branding panel only - no operational data, no external image assets.
export function OperationsHighlight() {
  return (
    <div className="relative flex h-full flex-col justify-between overflow-hidden rounded-xl bg-gradient-to-br from-indigo-600 via-blue-600 to-cyan-500 p-6 text-white shadow-sm">
      <Truck
        className="pointer-events-none absolute -bottom-6 -right-6 h-40 w-40 text-white/10"
        aria-hidden="true"
      />
      <div className="relative">
        <h3 className="text-xl font-bold leading-snug">Reliable Deliveries. Stronger Businesses.</h3>
        <p className="mt-2 text-sm text-white/80">Efficient. Transparent. Always on track.</p>
      </div>
      <div className="relative mt-6 flex items-start gap-2 border-t border-white/20 pt-4 text-sm text-white/90">
        <Quote className="h-4 w-4 shrink-0 text-white/60" />
        <p className="italic">Logistics is not just about moving goods. It's about moving possibilities.</p>
      </div>
    </div>
  );
}
