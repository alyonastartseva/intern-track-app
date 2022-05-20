import React from 'react';
import { Alert } from '@mui/material';

export const App = () => {
  let person = {
    name: 'Yoda',
    designation: 'Jedi Master '
  };

  function trainJedi(jediWarrion) {
    if (jediWarrion.name === 'Yoda') {
      console.log('No need! already trained');
    }
    console.log(`Training ${jediWarrion.name} complete`);
  }

  trainJedi(person);
  trainJedi({ name: 'Adeel', designation: 'padawan' });
};
