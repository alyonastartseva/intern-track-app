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
import { CompanyRecords } from '../modules/companyRecords';
import { Users } from '../modules/users';
import { UserResults } from '../modules/users/components/result-users';

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
    path: '/vacancies',
    component: <CompanyVacancies />
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
    path: '/admin-interviews',
    component: <CompanyInterviews />
  },
  {
    path: '/company-records',
    component: <CompanyRecords />
  },
  {
    path: '/users',
    component: <Users />
  },
  {
    path: 'user-results/:userId',
    component: <UserResults />
  }
];
