// src/components/PublishingHouseCard.js
import React from 'react';

const PublishingHouseCard = ({ publishingHouse }) => {
  return (
    <div className="publishing-house-card">
      <h3>{publishingHouse.Name}</h3>
      <p>Количество книг: {publishingHouse.BooksId.length}</p>
    </div>
  );
};

export default PublishingHouseCard;