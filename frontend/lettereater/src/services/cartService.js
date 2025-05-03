import { get, post, deleteRequest } from './apiService';

export const getCartItems = async () => {
  return await get('CartItem');
};

export const addToCart = async (data) => {
  return await post('CartItem', data);
};

export const removeFromCart = async (id) => {
  return await deleteRequest(`CartItem/${id}`);
};