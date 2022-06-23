import { configureStore } from '@reduxjs/toolkit';

import { authApi } from './store/api/auth';
import { companiesApi } from './store/api/companies';

export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [companiesApi.reducerPath]: companiesApi.reducer
  },

  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(authApi.middleware, companiesApi.middleware)
});
