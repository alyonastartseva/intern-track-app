import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const recordsApi = createApi({
  reducerPath: 'recordsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44346/api/StudentPlanForInterview/' }),
  tagTypes: ['Records'],
  endpoints: (builder) => ({
    getPlanInterviewByCompanyId: builder.query({
      query: (companyId) => `StudentPlanForInterviewByCompanyId?companyId=${companyId}`,
      providesTags: ['Records']
    }),
    createUpdateRecord: builder.mutation({
      query: (data) => ({
        url: 'createUpdate',
        method: 'POST',
        body: data
      }),
      invalidatesTags: ['Records']
    })
  })
});

export const { useGetPlanInterviewByCompanyIdQuery, useCreateUpdateRecordMutation } = recordsApi;
