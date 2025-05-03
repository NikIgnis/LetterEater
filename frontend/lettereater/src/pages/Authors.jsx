// src/pages/Authors.jsx
import React, { useEffect, useState } from 'react';
import { getAuthors } from '../services/authorService'; // Импорт named exports
import AuthorCard from '../components/AuthorCard';

const Authors = () => {
  const [authors, setAuthors] = useState([]);

  useEffect(() => {
    const fetchAuthors = async () => {
      const data = await getAuthors(); // Прямой вызов функции
      setAuthors(data);
    };
    fetchAuthors();
  }, []);

  return (
    <div className="authors">
      <h1>Все авторы</h1>
      <div className="author-list">
        {authors.map(author => (
          <AuthorCard key={author.AuthorId} author={author} />
        ))}
      </div>
    </div>
  );
};

export default Authors;