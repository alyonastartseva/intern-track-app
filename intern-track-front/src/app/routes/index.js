import React, { useEffect, useState } from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';

import { LocalStorageHelper } from '../shared/helpers/localstore';
import { publicRoutes, privateRoutes } from './const';

import { PrivateRouteLayout } from '../layouts/privateRouteLayout';

export const AppRoutes = () => {
  const [isAuth, setIsAuth] = useState(false);

  const location = useLocation();

  useEffect(() => {
    setIsAuth(!!LocalStorageHelper.getData('email'));
  }, [location]);

  return !isAuth ? (
    <Routes>
      {publicRoutes.map((route) => (
        <Route key={route.path} path={route.path} element={route.component} />
      ))}
    </Routes>
  ) : (
    <Routes>
      {privateRoutes.map((route) => (
        <Route key={route.path} path={route.path} element={<PrivateRouteLayout component={route.component} />} />
      ))}
    </Routes>
  );
};
