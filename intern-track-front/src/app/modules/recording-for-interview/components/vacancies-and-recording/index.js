import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';
import { useGetVacanciesByIdQuery } from 'src/app/store/api/companies';

import { Button, Col, Card, Divider } from 'antd';

import './VacanciesAndRecording.css';

export const VacanciesAndRecording = () => {
  const { companyId } = useParams();

  const { data, error, isLoading } = useGetVacanciesByIdQuery(companyId || '');

  console.log(data);

  const navigate = useNavigate();

  return (
    <div className="vacanciesPage">
      <header>
        <Button className="ita-btn _text _back" onClick={() => navigate(-1)}>
          <BackIcon />
          Назад к компаниям
        </Button>
        <h2>Доступные вакансии</h2>
      </header>
      <Col className="vacancies" span={8}>
        <Card title="Фронтенд разработчик">
          <p>
            <span className="descTitle">Описание:</span> Нужен хороший фронт
          </p>
          <p>
            <span className="descTitle">Количество мест:</span> 2
          </p>
        </Card>
      </Col>
      <Divider orientation="left">
        <h2 className="recordingTitle">Записаться на собеседование</h2>
      </Divider>
    </div>
  );
};
