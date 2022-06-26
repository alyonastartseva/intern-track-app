import React from 'react';

import { Table } from 'antd';

import { columnsMyInterviews } from './const';
import { useGetUserInfoQuery } from 'src/app/store/api/user';

import './MyInterviews.css';

export const MyInterviews = () => {
  const { data: currentUser } = useGetUserInfoQuery();

  console.log(currentUser);

  return (
    <div className="myInterviewsPage">
      <h1>Мои собеседования</h1>
      <Table columns={columnsMyInterviews} dataSource={[]} />
    </div>
  );
};
