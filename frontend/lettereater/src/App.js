// src/App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar';

// Pages
import Home from './pages/Home';
import Books from './pages/Books';
import Authors from './pages/Authors';
import PublishingHouses from './pages/PublishingHouses';
import Cart from './pages/Cart';
import Orders from './pages/Orders';
import Profile from './pages/Profile';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/books" element={<Books />} />
        <Route path="/authors" element={<Authors />} />
        <Route path="/publishing-houses" element={<PublishingHouses />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/orders" element={<Orders />} />
        <Route path="/profile" element={<Profile />} />
      </Routes>
    </Router>
  );
}

export default App;