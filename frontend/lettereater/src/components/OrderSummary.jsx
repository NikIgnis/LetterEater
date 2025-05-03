// src/components/OrderSummary.js
import React from 'react';

const OrderSummary = ({ order }) => {
  return (
    <div className="order-summary">
      <h3>Заказ №{order.OrderId}</h3>
      <p>Дата заказа: {order.OrderDate}</p>
      <p>Количество товаров: {order.OrderItemsId.length}</p>
      <p>Итоговая стоимость: {calculateTotalPrice(order)} ₽</p>
    </div>
  );

  function calculateTotalPrice(order) {
    // Здесь можно добавить логику подсчета общей стоимости
    return 0; // временно
  }
};

export default OrderSummary;