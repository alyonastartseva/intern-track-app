import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const companiesApi = createApi({
  reducerPath: 'companiesApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/' }),
  endpoints: (builder) => ({
    getAllCompanies: builder.query({
      query: () => 'User/getallcompanies'
    }),
    getVacanciesById: builder.query({
      query: (companyId) => `VacancyApi/VacanciesByCompanyId?companyId=${companyId}`
    })
  })
});

export const { useGetAllCompaniesQuery, useGetVacanciesByIdQuery } = companiesApi;
