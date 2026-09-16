export type DeliveryPriority = "Low" | "Normal" | "High" | "Urgent";

export type DeliveryStatus =
  | "Created"
  | "Assigned"
  | "Accepted"
  | "PickedUp"
  | "InTransit"
  | "Delivered"
  | "Failed"
  | "Cancelled";

export interface Delivery {
  id: string;
  companyId: string;
  customerName: string;
  customerPhone: string;
  pickupAddress: string;
  deliveryAddress: string;
  scheduledDate: string;
  priority: DeliveryPriority;
  status: DeliveryStatus;
  driverId: string | null;
  vehicleId: string | null;
  createdAt: string;
}
