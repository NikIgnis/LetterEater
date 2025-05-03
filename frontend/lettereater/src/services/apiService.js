import axios from 'axios';

const BASE_URL = '/api';

export const get = async (endpoint) => {
  try {
    const response = await axios.get(`${BASE_URL}/${endpoint}`);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const post = async (endpoint, data) => {
  try {
    const response = await axios.post(`${BASE_URL}/${endpoint}`, data);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const put = async (endpoint, data) => {
  try {
    const response = await axios.put(`${BASE_URL}/${endpoint}`, data);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const deleteRequest = async (endpoint) => {
  try {
    const response = await axios.delete(`${BASE_URL}/${endpoint}`);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};