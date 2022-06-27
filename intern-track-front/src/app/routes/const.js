import React from 'react';

import { SignIn } from '../modules/auth/components/signin';
import { SignUpStudent } from '../modules/auth/components/signup/SignupStudent';
import { SignUp } from '../modules/auth/components/signup/Signup';
import { RecordingForInterview } from '../modules/recording-for-interview';
import { MyProfile } from '../modules/profile';
import { MyInterviews } from '../modules/my-interviews';
import { VacanciesAndRecording } from '../modules/recording-for-interview/components/vacancies-and-recording';
import { CompanyVacancies } from '../modules/companyVacancies';
import { CompanyInterviews } from '../modules/companyInterview';

export const publicRoutes = [
  {
    path: '/',
    component: <SignIn />
  },
  {
    path: '/signupStudent',
    component: <SignUpStudent />
  },
  {
    path: '/signup',
    component: <SignUp />
  }
];

export const privateRoutes = [
  {
    path: '/',
    component: <RecordingForInterview />
  },
  {
    path: '/profile',
    component: <MyProfile />
  },
  {
    path: '/my-interviews',
    component: <MyInterviews />
  },
  {
    path: '/vacancies-and-recording/:companyId',
    component: <VacanciesAndRecording />
  },
  {
    path: '/vacancies',
    component: <CompanyVacancies />
  },
  {
    path: '/admin-interviews',
    component: <CompanyInterviews />
  }
];
