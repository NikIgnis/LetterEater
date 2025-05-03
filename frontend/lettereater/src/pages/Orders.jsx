// src/pages/Orders.js
import React, { useEffect, useState } from 'react';
import { getOrders } from '../services/orderService';
import OrderSummary from '../components/OrderSummary';

const Orders = () => {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    const fetchOrders = async () => {
      const data = await getOrders();
      setOrders(data);
    };
    fetchOrders();
  }, []);

  return (
    <div className="orders">
      <h1>История заказов</h1>
      <div className="order-list">
        {orders.map(order => (
          <OrderSummary key={order.OrderId} order={order} />
        ))}
      </div>
    </div>
  );
};

export default Orders;