import React from 'react';

import { Table, Spin, Result } from 'antd';

import { useGetPlanInterviewByCompanyIdQuery } from 'src/app/store/api/record';
import { columnsRecording } from './const';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import './CompanyRecords.css';

export const CompanyRecords = () => {
  const {
    data: recordInterviws,
    error: errorRecord,
    isLoading: loadingRecord
  } = useGetPlanInterviewByCompanyIdQuery({
    companyId: LocalStorageHelper.getData('userId'),
    currentUserId: LocalStorageHelper.getData('userId')
  });

  return (
    <div>
      <h1>Список заявок</h1>
      {loadingRecord ? (
        <Spin className="loader" />
      ) : errorRecord ? (
        <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список заявок" />
      ) : (
        <Table dataSource={recordInterviws?.interviewPlansList} columns={columnsRecording} />
      )}
    </div>
  );
};
