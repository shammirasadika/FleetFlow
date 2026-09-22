import { Bell, Menu, User } from "lucide-react";
import { useLocation } from "react-router-dom";

import { NAV_ITEMS } from "./navigation";

interface HeaderProps {
  onMenuClick: () => void;
}

export function Header({ onMenuClick }: HeaderProps) {
  const { pathname } = useLocation();
  const currentPage = NAV_ITEMS.find((item) => item.to === pathname);

  return (
    <header className="flex h-16 shrink-0 items-center justify-between border-b border-gray-200 bg-white px-4 sm:px-6">
      <div className="flex items-center gap-3">
        <button
          type="button"
          onClick={onMenuClick}
          className="rounded-md p-2 text-gray-500 hover:bg-gray-100 lg:hidden"
          aria-label="Open navigation menu"
        >
          <Menu className="h-5 w-5" />
        </button>
        <h2 className="text-base font-semibold text-gray-900">{currentPage?.label ?? "FleetFlow"}</h2>
      </div>
      <div className="flex items-center gap-4">
        <button
          type="button"
          className="rounded-md p-2 text-gray-500 hover:bg-gray-100"
          aria-label="Notifications"
        >
          <Bell className="h-5 w-5" />
        </button>
        <div className="flex items-center gap-2 border-l border-gray-200 pl-4">
          <span className="flex h-8 w-8 items-center justify-center rounded-full bg-gray-100 text-gray-500">
            <User className="h-4 w-4" />
          </span>
          <span className="hidden text-sm font-medium text-gray-700 sm:inline">FleetFlow Admin</span>
        </div>
      </div>
    </header>
  );
}
