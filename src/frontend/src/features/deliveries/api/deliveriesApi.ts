import { apiClient } from "../../../api/apiClient";
import type { PagedResponse } from "../../../types/pagedResponse";
import type { Delivery } from "../types/delivery";

export async function getDeliveries(): Promise<PagedResponse<Delivery>> {
  const response = await apiClient.get<PagedResponse<Delivery>>("/api/deliveries");
  return response.data;
}
