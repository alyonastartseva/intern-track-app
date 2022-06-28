import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { Table, Button } from 'antd';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';
import { useGetInterviewsByStudentIdQuery } from 'src/app/store/api/interviews';
import { columnsMyInterviews } from '../../const';

export const UserResults = () => {
  const { userId } = useParams();
  const navigate = useNavigate();

  const { data: myInterviews } = useGetInterviewsByStudentIdQuery(userId || '');

  return (
    <div className="myInterviewsPage">
      <header>
        <Button className="ita-btn _text _back" onClick={() => navigate(-1)}>
          <BackIcon />
          Назад к списку студентов
        </Button>
      </header>

      <h1>Собеседования студента</h1>
      <Table columns={columnsMyInterviews} dataSource={myInterviews?.interviews} />
    </div>
  );
};
