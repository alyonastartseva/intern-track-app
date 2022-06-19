import React from 'react';

import { SignIn } from '../modules/auth/components/signin';
import { SignUpStudent } from '../modules/auth/components/signup/SignupStudent';
import { SignUp } from '../modules/auth/components/signup/Signup';

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

export const privateRoutes = [];
