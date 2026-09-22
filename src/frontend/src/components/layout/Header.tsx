import { Bell, ChevronDown, Menu, Search } from "lucide-react";
import { useLocation } from "react-router-dom";

import { NAV_ITEMS } from "./navigation";

interface HeaderProps {
  onMenuClick: () => void;
}

export function Header({ onMenuClick }: HeaderProps) {
  const { pathname } = useLocation();
  const currentPage = NAV_ITEMS.find((item) => item.to === pathname);

  return (
    <header className="flex h-16 shrink-0 items-center justify-between border-b border-white/60 bg-white/70 px-4 backdrop-blur-md sm:px-6">
      <div className="flex items-center gap-3">
        <button
          type="button"
          onClick={onMenuClick}
          className="rounded-md p-2 text-gray-500 hover:bg-gray-100 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 lg:hidden"
          aria-label="Open navigation menu"
        >
          <Menu className="h-5 w-5" />
        </button>
        <h2 className="text-base font-semibold text-gray-900">{currentPage?.label ?? "FleetFlow"}</h2>
      </div>
      <div className="flex items-center gap-3 sm:gap-4">
        <label className="relative hidden sm:block">
          <Search className="pointer-events-none absolute top-1/2 left-3 h-4 w-4 -translate-y-1/2 text-gray-400" />
          <input
            type="search"
            placeholder="Search..."
            aria-label="Search"
            className="w-48 rounded-full border border-gray-200 bg-white/80 py-1.5 pr-3 pl-9 text-sm text-gray-700 placeholder:text-gray-400 focus:border-blue-400 focus:ring-2 focus:ring-blue-100 focus:outline-none lg:w-64"
          />
        </label>
        <button
          type="button"
          className="relative rounded-md p-2 text-gray-500 hover:bg-gray-100 focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:outline-none"
          aria-label="Notifications"
        >
          <Bell className="h-5 w-5" />
          <span className="absolute top-1.5 right-1.5 h-2 w-2 rounded-full bg-red-500 ring-2 ring-white" />
        </button>
        <div className="flex items-center gap-2 border-l border-gray-200 pl-3 sm:pl-4">
          <span className="flex h-8 w-8 items-center justify-center rounded-full bg-gradient-to-br from-blue-500 to-indigo-600 text-xs font-semibold text-white">
            FA
          </span>
          <span className="hidden text-sm font-medium text-gray-700 sm:inline">FleetFlow Admin</span>
          <ChevronDown className="hidden h-4 w-4 text-gray-400 sm:inline" />
        </div>
      </div>
    </header>
  );
}
