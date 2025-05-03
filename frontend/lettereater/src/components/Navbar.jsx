import React from 'react';
import { Link } from 'react-router-dom';
import './Navbar.module.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="navbar-brand">
        <Link to="/">LetterEater</Link>
      </div>
      <ul className="navbar-links">
        <li><Link to="/books">Книги</Link></li>
        <li><Link to="/authors">Авторы</Link></li>
        <li><Link to="/publishing-houses">Издательства</Link></li>
        <li><Link to="/cart">Корзина</Link></li>
        <li><Link to="/orders">Заказы</Link></li>
        <li><Link to="/profile">Профиль</Link></li>
      </ul>
    </nav>
  );
};

export default Navbar;