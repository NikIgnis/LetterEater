import { get, post, put, deleteRequest } from './apiService';

export const getBooks = async () => {
  return await get('Books');
};

export const getBookById = async (id) => {
  return await get(`Books/${id}`);
};

export const addBook = async (data) => {
  return await post('Books', data);
};

export const updateBook = async (id, data) => {
  return await put(`Books/${id}`, data);
};

export const deleteBook = async (id) => {
  return await deleteRequest(`Books/${id}`);
};