import React, { useCallback } from 'react';
import { useNavigate } from 'react-router-dom';

import { Table, Spin, Result } from 'antd';

import { useGetAllStudentsQuery } from 'src/app/store/api/user';
import { columnsStudents } from './const';

import './Users.css';

export const Users = () => {
  const { data: students, error: errorStudents, isLoading: loadingStudents } = useGetAllStudentsQuery();

  const navigate = useNavigate();

  const handleOnSelectRow = useCallback(
    (student) => {
      navigate(`/user-results/${student.studentId}`);
    },
    [navigate]
  );

  return (
    <div>
      <h1>Список студентов</h1>
      {loadingStudents ? (
        <Spin className="loader" />
      ) : errorStudents ? (
        <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список студентов" />
      ) : (
        <Table
          onRow={(record, rowIndex) => {
            return {
              onClick: (event) => {
                if (handleOnSelectRow) handleOnSelectRow(record);
              }
            };
          }}
          dataSource={students?.students}
          columns={columnsStudents}
        />
      )}
    </div>
  );
};
