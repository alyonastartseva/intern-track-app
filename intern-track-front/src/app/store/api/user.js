import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const userApi = createApi({
  reducerPath: 'userApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/User' }),
  endpoints: (builder) => ({
    getUserInfo: builder.query({
      query: () => 'getuserinfo'
    })
  })
});

export const { useGetUserInfoQuery } = userApi;
