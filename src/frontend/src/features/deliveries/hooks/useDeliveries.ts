import { useQuery } from "@tanstack/react-query";
import { getDeliveries } from "../api/deliveriesApi";

export function useDeliveries() {
  return useQuery({
    queryKey: ["deliveries"],
    queryFn: getDeliveries,
  });
}
