import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';

import { Button } from 'antd';

import './VacanciesAndRecording.css';

export const VacanciesAndRecording = () => {
  const { companyId } = useParams();

  const navigate = useNavigate();

  return (
    <div className="vacanciesPage">
      <Button className="ita-btn _text _back" onClick={() => navigate(-1)}>
        <BackIcon />
        Назад к компаниям
      </Button>
      <p>{companyId}</p>
    </div>
  );
};
