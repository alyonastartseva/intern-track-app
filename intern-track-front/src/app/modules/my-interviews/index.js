import React from 'react';

import { Table } from 'antd';

import { columnsMyInterviews } from './const';

import './MyInterviews.css';

export const MyInterviews = () => {
  return (
    <div className="myInterviewsPage">
      <h1>Мои собеседования</h1>
      <Table columns={columnsMyInterviews} dataSource={[]} />
    </div>
  );
};
