import axios from 'axios';

const BASE_URL = 'http://localhost:5000'; // URL шлюза API (WebAPIGateway)

export const fetchBooks = async () => {
    return await axios.get(`${BASE_URL}/books`);
};

export const fetchBookById = async (id) => {
    return await axios.get(`${BASE_URL}/books/${id}`);
};

export const fetchAuthors = async () => {
    return await axios.get(`${BASE_URL}/authors`);
};

export const fetchAuthorById = async (id) => {
    return await axios.get(`${BASE_URL}/authors/${id}`);
};

export const fetchPublishingHouses = async () => {
    return await axios.get(`${BASE_URL}/publishing-houses`);
};

export const fetchPublishingHouseById = async (id) => {
    return await axios.get(`${BASE_URL}/publishing-houses/${id}`);
};

export const fetchCartItems = async (userId) => {
    return await axios.get(`${BASE_URL}/cart-items?userId=${userId}`);
};

export const addCartItem = async (data) => {
    return await axios.post(`${BASE_URL}/cart-items`, data);
};

export const updateCartItem = async (cartItemId, data) => {
    return await axios.put(`${BASE_URL}/cart-items/${cartItemId}`, data);
};

export const deleteCartItem = async (cartItemId) => {
    return await axios.delete(`${BASE_URL}/cart-items/${cartItemId}`);
};

export const fetchOrders = async (userId) => {
    return await axios.get(`${BASE_URL}/orders?userId=${userId}`);
};

export const placeOrder = async (data) => {
    return await axios.post(`${BASE_URL}/orders`, data);
};

export const login = async (data) => {
    return await axios.post(`${BASE_URL}/auth/login`, data);
};

export const registerUser = async (data) => {
    return await axios.post(`${BASE_URL}/users/register`, data);
};