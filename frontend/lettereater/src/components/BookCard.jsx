import React from 'react';

const BookCard = ({ book }) => {
  return (
    <div className="book-card">
      <h3>{book.Title}</h3>
      <p>Автор: {book.AuthorName}</p>
      <p>Год издания: {book.PublicationYear}</p>
      <p>Жанр: {book.Genre}</p>
      <p>Цена: {book.Price} ₽</p>
      <button onClick={() => console.log('Добавить в корзину')}>Добавить в корзину</button>
    </div>
  );
};

export default BookCard;