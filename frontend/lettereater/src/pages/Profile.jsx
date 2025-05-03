// src/pages/Profile.js
import React, { useEffect, useState } from 'react';
import { getUser } from '../services/userService';

const Profile = () => {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      const data = await getUser();
      setUser(data);
    };
    fetchUser();
  }, []);

  return (
    <div className="profile">
      {user ? (
        <>
          <h1>Профиль пользователя</h1>
          <p>Имя: {user.Name}</p>
          <p>Фамилия: {user.Surename}</p>
          <p>Email: {user.Email}</p>
          <p>Телефон: {user.ContactNumber}</p>
        </>
      ) : (
        <p>Загрузка...</p>
      )}
    </div>
  );
};

export default Profile;