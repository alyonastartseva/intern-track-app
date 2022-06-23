import React from 'react';

import { Link } from 'react-router-dom';
import { Card, Spin, Result, Col, Row } from 'antd';

import { useGetAllCompaniesQuery } from 'src/app/store/api/companies';

import './RecordingForInterview.css';

export const RecordingForInterview = () => {
  const { data, error, isLoading } = useGetAllCompaniesQuery();

  return (
    <div className="recordingPage">
      <h1>Компании-партнёры</h1>
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
                extra={<Link to={`/vacancies-and-recording/${company.companyId}`}>Посмотреть вакансии</Link>}
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
