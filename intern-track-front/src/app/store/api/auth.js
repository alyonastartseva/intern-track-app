import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const authApi = createApi({
  reducerPath: 'authApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/Account/', mode: 'cors' }),
  endpoints: (builder) => ({
    registerAsStudent: builder.mutation({
      query: (formData) => ({
        url: `registerAsStudent`,
        method: 'POST',
        body: formData
      })
    }),
    register: builder.mutation({
      query: (formData) => ({
        url: `register`,
        method: 'POST',
        body: formData
      })
    }),
    login: builder.mutation({
      query: (formData) => ({
        url: `login`,
        method: 'POST',
        body: formData
      })
    }),
    logout: builder.mutation({
      query: () => ({
        url: 'logout',
        method: 'GET'
      })
    })
  })
});

export const { useRegisterAsStudentMutation, useRegisterMutation, useLoginMutation, useLogoutMutation } = authApi;
