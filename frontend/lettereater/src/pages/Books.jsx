// src/pages/Books.js
import React, { useEffect, useState } from 'react';
import { getBooks } from '../services/bookService';
import BookCard from '../components/BookCard';

const Books = () => {
  const [books, setBooks] = useState([]);

  useEffect(() => {
    const fetchBooks = async () => {
      const data = await getBooks();
      setBooks(data);
    };
    fetchBooks();
  }, []);

  return (
    <div className="books">
      <h1>Все книги</h1>
      <div className="book-list">
        {books.map(book => (
          <BookCard key={book.BookId} book={book} />
        ))}
      </div>
    </div>
  );
};

export default Books;