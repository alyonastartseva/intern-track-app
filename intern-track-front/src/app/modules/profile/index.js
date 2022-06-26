import React, { useCallback } from 'react';
import { useNavigate } from 'react-router-dom';

import { Button } from 'antd';

import { useLogoutMutation } from 'src/app/store/api/auth';

export const MyProfile = () => {
  const [logout] = useLogoutMutation();
  const navigate = useNavigate();

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
