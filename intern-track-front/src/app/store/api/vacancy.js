import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const vacanciesApi = createApi({
  reducerPath: 'vacanciesApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/Vacancy/' }),
  tagTypes: ['Vacancies'],
  endpoints: (builder) => ({
    createUpdateVacancy: builder.mutation({
      query: (data) => ({
        url: 'createUpdate',
        method: 'POST',
        body: data
      }),
      invalidatesTags: ['Vacancies']
    }),
    getVacancies: builder.query({
      query: (id) => `vacanciesByCompanyId?companyId=${id}`,
      providesTags: ['Vacancies']
    }),
    deleteVacancy: builder.mutation({
      query: (id) => ({
        url: `remove?id=${id}`,
        method: 'POST'
      }),
      invalidatesTags: ['Vacancies']
    })
  })
});

export const { useCreateUpdateVacancyMutation, useGetVacanciesQuery, useDeleteVacancyMutation } = vacanciesApi;
