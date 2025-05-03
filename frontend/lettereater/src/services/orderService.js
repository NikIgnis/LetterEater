import { get, post } from './apiService';

export const getOrders = async () => {
  return await get('Order');
};

export const placeOrder = async (data) => {
  return await post('Order', data);
};