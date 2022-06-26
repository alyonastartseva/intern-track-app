import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const interviewsApi = createApi({
  reducerPath: 'interviewsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/Interview' }),
  endpoints: (builder) => ({
    getInterviewsByStudentId: builder.query({
      query: (id) => `interviewsByStudentId?studentId=${id}`
    })
  })
});

export const { useGetInterviewsByStudentIdQuery } = interviewsApi;
