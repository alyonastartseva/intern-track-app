import React from 'react';

import { Table } from 'antd';

import { columnsMyInterviews } from './const';
import { useGetInterviewsByStudentIdQuery } from 'src/app/store/api/interviews';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import './MyInterviews.css';

export const MyInterviews = () => {
  const { data: myInterviews } = useGetInterviewsByStudentIdQuery(LocalStorageHelper.getData('userId'));

  return (
    <div className="myInterviewsPage">
      <h1>Мои собеседования</h1>
      <Table columns={columnsMyInterviews} dataSource={myInterviews?.interviews} />
    </div>
  );
};
