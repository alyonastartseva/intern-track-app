import React from 'react';

import { Link } from 'react-router-dom';
import { Card } from 'antd';

import { useGetAllCompaniesQuery } from 'src/app/store/api/companies';

export const RecordingForInterview = () => {
  const { data, error, isLoading } = useGetAllCompaniesQuery();

  console.log(data);

  return (
    <Card title="НТР" extra={<Link to="/vacancies-and-recording">Вакансии</Link>} style={{ width: 300 }}>
      <p>Описание</p>
    </Card>
  );
};
