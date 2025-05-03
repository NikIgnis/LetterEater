// src/pages/Home.js
import React, { useEffect, useState } from 'react';
import { getBooks } from '../services/bookService';
import BookCard from '../components/BookCard';

const Home = () => {
  const [books, setBooks] = useState([]);

  useEffect(() => {
    const fetchBooks = async () => {
      const data = await getBooks();
      setBooks(data);
    };
    fetchBooks();
  }, []);

  return (
    <div className="home">
      <h1>Рекомендуемые книги</h1>
      <div className="book-list">
        {books.map(book => (
          <BookCard key={book.BookId} book={book} />
        ))}
      </div>
    </div>
  );
};

export default Home;