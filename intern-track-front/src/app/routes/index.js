import React, { useEffect, useState } from 'react';
import { Routes, Route } from 'react-router-dom';

import { LocalStorageHelper } from '../shared/helpers/localstore';
import { publicRoutes, privateRoutes } from './const';

export const AppRoutes = () => {
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    setIsAuth(LocalStorageHelper.getData('username'));
  }, []);

  return !isAuth ? (
    <Routes>
      {publicRoutes.map((route) => (
        <Route key={route.path} path={route.path} element={route.component} />
      ))}
    </Routes>
  ) : (
    <Routes>
      {privateRoutes.map((route) => (
        <Route key={route.path} path={route.path} element={route.component} />
      ))}
    </Routes>
  );
};
