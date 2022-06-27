import React, { useCallback } from 'react';
import { useNavigate } from 'react-router-dom';

import { Button } from 'antd';

import { useLogoutMutation } from 'src/app/store/api/auth';
import { useGetUserInfoQuery } from 'src/app/store/api/user';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

export const MyProfile = () => {
  const [logout] = useLogoutMutation();
  const navigate = useNavigate();

  const { data: profile } = useGetUserInfoQuery(LocalStorageHelper.getData('userId'));

  console.log(profile);

  const handleOnLogout = useCallback(() => {
    logout()
      .unwrap()
      .then(() => {
        localStorage.clear();
        navigate('/');
      });
  }, [logout, navigate]);

  return (
    <div>
      <Button className="ita-btn" onClick={handleOnLogout}>
        Выход
      </Button>
    </div>
  );
};
