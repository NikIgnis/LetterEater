// src/pages/PublishingHouses.js
import React, { useEffect, useState } from 'react';
import { getPublishingHouses } from '../services/publishingHouseService';
import PublishingHouseCard from '../components/PublishingHouseCard';

const PublishingHouses = () => {
  const [publishingHouses, setPublishingHouses] = useState([]);

  useEffect(() => {
    const fetchPublishingHouses = async () => {
      const data = await getPublishingHouses();
      setPublishingHouses(data);
    };
    fetchPublishingHouses();
  }, []);

  return (
    <div className="publishing-houses">
      <h1>Все издательства</h1>
      <div className="publishing-house-list">
        {publishingHouses.map(publishingHouse => (
          <PublishingHouseCard key={publishingHouse.PublishingHouseId} publishingHouse={publishingHouse} />
        ))}
      </div>
    </div>
  );
};

export default PublishingHouses;