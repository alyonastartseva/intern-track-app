import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const interviewsApi = createApi({
  reducerPath: 'interviewsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/Interview' }),
  tagTypes: ['Interviews'],
  endpoints: (builder) => ({
    getInterviewsByStudentId: builder.query({
      query: (id) => `interviewsByStudentId?studentId=${id}`,
      providesTags: ['Interview']
    }),
    getInterviewsByCompanyId: builder.query({
      query: (id) => `interviewsByCompanyId?studentId=${id}`,
      providesTags: ['Interview']
    }),
    createUpdateInterview: builder.mutation({
      query: (data) => ({
        url: 'createUpdate',
        method: 'POST',
        body: data
      }),
      invalidatesTags: ['Interview']
    }),
    deleteInterview: builder.mutation({
      query: (id) => ({
        url: `remove?id=${id}`,
        method: 'POST'
      }),
      invalidatesTags: ['Interview']
    })
  })
});

export const {
  useGetInterviewsByStudentIdQuery,
  useGetInterviewsByCompanyIdQuery,
  useCreateUpdateInterviewMutation,
  useDeleteInterviewMutation
} = interviewsApi;
