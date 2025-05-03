import { get, post, put, deleteRequest } from './apiService';

export const getPublishingHouses = async () => {
  return await get('Publishing-houses');
};

export const getPublishingHouseById = async (id) => {
  return await get(`Publishing-houses/${id}`);
};

export const addPublishingHouse = async (data) => {
  return await post('Publishing-houses', data);
};

export const updatePublishingHouse = async (id, data) => {
  return await put(`Publishing-houses/${id}`, data);
};

export const deletePublishingHouse = async (id) => {
  return await deleteRequest(`Publishing-houses/${id}`);
};