import React from 'react';

import { ThemeProvider } from '@mui/material/styles';
import { appTheme } from './app/styles/theme';

import { SignUp } from './app/modules/auth/components/signup';

export const App = () => {
  return (
    <ThemeProvider theme={appTheme}>
      <SignUp />
    </ThemeProvider>
  );
};
