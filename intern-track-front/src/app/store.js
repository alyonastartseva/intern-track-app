import { configureStore } from '@reduxjs/toolkit';

import { authApi } from './store/api/auth';
import { companiesApi } from './store/api/companies';
import { recordsApi } from './store/api/record';
import { userApi } from './store/api/user';
import { interviewsApi } from './store/api/interviews';

export const store = configureStore({
  reducer: {
    [authApi.reducerPath]: authApi.reducer,
    [companiesApi.reducerPath]: companiesApi.reducer,
    [recordsApi.reducerPath]: recordsApi.reducer,
    [userApi.reducerPath]: userApi.reducer,
    [interviewsApi.reducerPath]: interviewsApi.reducer
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
      authApi.middleware,
      companiesApi.middleware,
      recordsApi.middleware,
      userApi.middleware,
      interviewsApi.middleware
    )
});
