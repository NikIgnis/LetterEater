// src/components/AuthorCard.js
import React from 'react';

const AuthorCard = ({ author }) => {
  return (
    <div className="author-card">
      <h3>{author.Name} {author.Surename}</h3>
      <p>Количество книг: {author.BooksId.length}</p>
    </div>
  );
};

export default AuthorCard;