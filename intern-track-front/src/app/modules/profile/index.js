import React, { useCallback, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Button } from 'antd';

import { useLogoutMutation } from 'src/app/store/api/auth';
import { useGetUserInfoQuery } from 'src/app/store/api/user';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import './Profile.css';

export const MyProfile = () => {
  const [logout] = useLogoutMutation();
  const navigate = useNavigate();

  const [role, setRole] = useState(null);

  const { data: profile } = useGetUserInfoQuery(LocalStorageHelper.getData('userId'));

  useEffect(() => {
    setRole(profile?.role);
  }, [profile?.role]);

  const handleOnLogout = useCallback(() => {
    logout()
      .unwrap()
      .then(() => {
        localStorage.clear();
        navigate('/');
      });
  }, [logout, navigate]);

  return (
    <div className="profile-page">
      <h1>{role === 'Company' ? profile?.companyName : profile?.email}</h1>
      {role === 'Company' && (
        <div>
          <p>
            <span className="descTitle">Email:</span>
            <span>{profile.email || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">Адрес:</span>
            <span>{profile.companyAddress || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">О компании:</span>
            <span>{profile.about || 'Не указано'}</span>
          </p>
        </div>
      )}
      {role === 'Deanery' && (
        <div>
          <p>
            <span className="descTitle">Адрес:</span>
            <span>{profile.deaneryAddress || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">Дополнительная информация:</span>
            <span>{profile.about || 'Не указано'}</span>
          </p>
        </div>
      )}
      {role === 'Curator' && (
        <div>
          <p>
            <span className="descTitle">Имя:</span>
            <span>{profile.firstName || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">Фамилия:</span>
            <span>{profile.lastName || 'Не указано'}</span>
          </p>
        </div>
      )}
      {role === 'Student' && (
        <div>
          <p>
            <span className="descTitle">Имя:</span>
            <span>{profile.firstName || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">Фамилия:</span>
            <span>{profile.lastName || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">Курс:</span>
            <span>{profile.course || 'Не указано'}</span>
          </p>
          <p>
            <span className="descTitle">О себе:</span>
            <span>{profile.about || 'Не указано'}</span>
          </p>
        </div>
      )}
      <Button className="ita-btn logout-btn" onClick={handleOnLogout}>
        Выход
      </Button>
    </div>
  );
};
