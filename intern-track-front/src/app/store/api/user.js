import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const userApi = createApi({
  reducerPath: 'userApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/User' }),
  endpoints: (builder) => ({
    getUserInfo: builder.query({
      query: (id) => `getuserinfo?id=${id}`
    }),
    getAllStudents: builder.query({
      query: () => 'getallstudents'
    })
  })
});

export const { useGetUserInfoQuery, useGetAllStudentsQuery } = userApi;
