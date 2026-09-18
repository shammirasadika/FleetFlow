import { apiClient } from "../../../api/apiClient";
import type { PagedResponse } from "../../../types/pagedResponse";
import type { Delivery } from "../types/delivery";

export interface GetDeliveriesParams {
  page: number;
  pageSize: number;
}

export async function getDeliveries(
  params: GetDeliveriesParams
): Promise<PagedResponse<Delivery>> {
  const response = await apiClient.get<PagedResponse<Delivery>>("/api/deliveries", {
    params,
  });
  return response.data;
}
