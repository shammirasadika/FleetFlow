import type { LucideIcon } from "lucide-react";
import { Bell, LayoutDashboard, Package, Truck, Users, Wrench } from "lucide-react";

export interface NavItem {
  to: string;
  label: string;
  icon: LucideIcon;
}

export const NAV_ITEMS: NavItem[] = [
  { to: "/dashboard", label: "Dashboard", icon: LayoutDashboard },
  { to: "/deliveries", label: "Deliveries", icon: Package },
  { to: "/drivers", label: "Drivers", icon: Users },
  { to: "/vehicles", label: "Vehicles", icon: Truck },
  { to: "/maintenance", label: "Maintenance", icon: Wrench },
  { to: "/notifications", label: "Notifications", icon: Bell },
];
