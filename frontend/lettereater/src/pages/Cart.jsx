import React, { useEffect, useState } from 'react';
import { getCartItems } from '../services/cartService';
import CartItem from '../components/CartItem';

const Cart = () => {
  const [cartItems, setCartItems] = useState([]);

  useEffect(() => {
    const fetchCartItems = async () => {
      const data = await getCartItems();
      setCartItems(data);
    };
    fetchCartItems();
  }, []);

  return (
    <div className="cart">
      <h1>Корзина</h1>
      <div className="cart-items">
        {cartItems.map(item => (
          <CartItem key={item.CartItemId} item={item} />
        ))}
      </div>
    </div>
  );
};

export default Cart;