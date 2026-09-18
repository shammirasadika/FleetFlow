import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { getDeliveries, type GetDeliveriesParams } from "../api/deliveriesApi";

export function useDeliveries(params: GetDeliveriesParams) {
  return useQuery({
    queryKey: ["deliveries", params.page, params.pageSize],
    queryFn: () => getDeliveries(params),
    placeholderData: keepPreviousData,
  });
}
