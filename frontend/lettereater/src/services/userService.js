// src/services/userService.js
import { get } from './apiService';

export const getUser = async () => {
  return await get('User/me'); // Предполагается, что API возвращает текущего пользователя
};