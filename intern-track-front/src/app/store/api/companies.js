import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const companiesApi = createApi({
  reducerPath: 'companiesApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/' }),
  endpoints: (builder) => ({
    getAllCompanies: builder.query({
      query: () => 'User/getallcompanies'
    })
  })
});

export const { useGetAllCompaniesQuery } = companiesApi;
