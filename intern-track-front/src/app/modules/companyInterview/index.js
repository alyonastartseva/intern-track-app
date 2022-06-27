import React, { useCallback, useState } from 'react';

import { Button, Col, Card } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import moment from 'moment';

import { CreateInterviewModal } from './components/createInterviewModal';

import './CompanyInterview.css';

export const CompanyInterviews = () => {
  const [visibleCreateModal, setVisibleCreateModal] = useState(false);

  const handleOnOkCreateInterview = useCallback((formData) => {
    console.log(formData);
    setVisibleCreateModal((prev) => !prev);
  }, []);

  const handleOnCancelCreateInterview = useCallback(() => {
    setVisibleCreateModal((prev) => !prev);
  }, []);

  return (
    <div>
      <Button className="ita-btn create-interview" onClick={() => setVisibleCreateModal((prev) => !prev)}>
        Создать интервью
      </Button>

      <Col span={8}>
        <Card actions={[<EditOutlined key="edit" />, <DeleteOutlined key="delete" />]}>
          <p>
            <span className="descTitle">Вакансия:</span>
          </p>
          <p>
            <span className="descTitle">Собеседующийся:</span>
          </p>
          <p>
            <span className="descTitle">Дата:</span>
          </p>
          <p>
            <span className="descTitle">Формат встречи:</span>
          </p>
          <p>
            <span className="descTitle">Место встречи:</span>
          </p>
          <p>
            <span className="descTitle">Статус собеседования:</span>
          </p>
        </Card>
      </Col>

      <CreateInterviewModal
        isVisible={visibleCreateModal}
        onOkCreate={handleOnOkCreateInterview}
        onCancel={handleOnCancelCreateInterview}
      />
    </div>
  );
};
