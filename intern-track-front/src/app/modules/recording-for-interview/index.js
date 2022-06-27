import React, { useEffect, useState } from 'react';

import { Link, useNavigate } from 'react-router-dom';
import { Card, Spin, Result, Col, Row } from 'antd';

import { useGetAllCompaniesQuery } from 'src/app/store/api/companies';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import './RecordingForInterview.css';

export const RecordingForInterview = () => {
  const { data, error, isLoading } = useGetAllCompaniesQuery();
  const [role, setRole] = useState(null);

  const navigate = useNavigate();

  useEffect(() => {
    if (LocalStorageHelper.getData('role') === 'Company') {
      navigate('/vacancies');
    }
  }, [navigate]);

  useEffect(() => {
    setRole(LocalStorageHelper.getData('role'));
  }, []);

  return (
    <div className="recordingPage">
      <h1>{role === 'Student' ? 'Выбери компанию, в которой хочешь пройти стажировку' : 'Компании-партнёры'}</h1>
      {isLoading ? (
        <Spin className="loader" />
      ) : error ? (
        <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список компаний" />
      ) : (
        <Row gutter={[16, 16]}>
          {data.companies.map((company) => (
            <Col key={company.companyId} span={8}>
              <Card
                title={company.name}
                extra={
                  <Link className="showVacancies" to={`/vacancies-and-recording/${company.companyId}`}>
                    Подробнее
                  </Link>
                }
              >
                <p>{company.about}</p>
              </Card>
            </Col>
          ))}
        </Row>
      )}
    </div>
  );
};
