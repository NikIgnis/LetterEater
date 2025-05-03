// src/components/CartItem.js
import React from 'react';

const CartItem = ({ item }) => {
  return (
    <div className="cart-item">
      <p>Книга: {item.BookId}</p>
      <p>Количество: {item.Quantity}</p>
      <p>Цена: {item.Price} ₽</p>
      <button onClick={() => console.log('Удалить из корзины')}>Удалить</button>
    </div>
  );
};

export default CartItem;