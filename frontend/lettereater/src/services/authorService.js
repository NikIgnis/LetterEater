import { get, post, put, deleteRequest } from './apiService';

export const getAuthors = async () => {
  return await get('Authors');
};

export const getAuthorById = async (id) => {
  return await get(`Authors/${id}`);
};

export const addAuthor = async (data) => {
  return await post('Authors', data);
};

export const updateAuthor = async (id, data) => {
  return await put(`Authors/${id}`, data);
};

export const deleteAuthor = async (id) => {
  return await deleteRequest(`Authors/${id}`);
};