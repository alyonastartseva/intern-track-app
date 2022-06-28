import React, { useCallback, useState } from 'react';

import { Button, Col, Card, Row, Spin, Result } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import moment from 'moment';

import { CreateInterviewModal } from './components/createInterviewModal';
import {
  useCreateUpdateInterviewMutation,
  useGetInterviewsByCompanyIdQuery,
  useDeleteInterviewMutation
} from 'src/app/store/api/interviews';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';
import { studentInterviewsStatusType } from './const';

import './CompanyInterview.css';

export const CompanyInterviews = () => {
  const [visibleCreateModal, setVisibleCreateModal] = useState(false);
  const [currentInterview, setCurrentInterview] = useState(null);

  const [createUpdateInterview] = useCreateUpdateInterviewMutation();
  const {
    data: interviews,
    isLoading: interviewsLoading,
    error: interviewsError
  } = useGetInterviewsByCompanyIdQuery(LocalStorageHelper.getData('userId'));
  const [deleteInterview] = useDeleteInterviewMutation();

  const handleOnOkCreateInterview = useCallback(
    (formData) => {
      const preparedData = {
        ...formData,
        id: 0,
        companyId: LocalStorageHelper.getData('userId'),
        date: moment(formData.date).toISOString()
      };
      console.log(preparedData);
      createUpdateInterview(preparedData);
      setVisibleCreateModal((prev) => !prev);
    },
    [createUpdateInterview]
  );

  const handleOnOkEditInterview = useCallback(
    (formData) => {
      createUpdateInterview({
        ...formData,
        id: currentInterview?.interviewId,
        companyId: LocalStorageHelper.getData('userId'),
        date: moment(formData.date).toISOString()
      });
      setVisibleCreateModal((prev) => !prev);
    },
    [createUpdateInterview, currentInterview?.interviewId]
  );

  const handleOnCancelCreateInterview = useCallback(() => {
    setVisibleCreateModal((prev) => !prev);
    setCurrentInterview(null);
  }, []);

  const handleOnEditInterview = useCallback(
    (id) => {
      const interv = interviews?.interviews?.find((el) => el.interviewId === id);
      setCurrentInterview(interv);
      setVisibleCreateModal((prev) => !prev);
    },
    [interviews]
  );

  const handleOnDeleteInterview = useCallback(
    (id) => {
      deleteInterview(id);
    },
    [deleteInterview]
  );

  return (
    <div>
      <Button className="ita-btn create-interview" onClick={() => setVisibleCreateModal((prev) => !prev)}>
        Создать интервью
      </Button>

      {interviewsLoading ? (
        <Spin className="loader" />
      ) : interviewsError ? (
        <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список вакансий" />
      ) : (
        <Row gutter={[16, 16]}>
          {interviews?.interviews?.map((item) => (
            <Col key={item.key} span={8}>
              <Card
                title={item.vacancyStack}
                actions={[
                  <EditOutlined onClick={() => handleOnEditInterview(item.interviewId)} key="edit" />,
                  <DeleteOutlined onClick={() => handleOnDeleteInterview(item.interviewId)} key="delete" />
                ]}
              >
                <p>
                  <span className="descTitle">Собеседующийся:</span>
                  <span>{item.studentName}</span>
                </p>
                <p>
                  <span className="descTitle">Дата:</span>
                  <span>{moment(item.date).format('DD.MM.YYYY')}</span>
                </p>
                <p>
                  <span className="descTitle">Формат встречи:</span>
                  <span>{item.format}</span>
                </p>
                <p>
                  <span className="descTitle">Место встречи:</span>
                  <span>{item.place}</span>
                </p>
                <p>
                  <span className="descTitle">Статус собеседования:</span>
                  <span>
                    {studentInterviewsStatusType.find((el) => el.key === item.studentInterviewStatusType)?.value}
                  </span>
                </p>
              </Card>
            </Col>
          ))}
        </Row>
      )}

      <CreateInterviewModal
        isVisible={visibleCreateModal}
        onOkCreate={handleOnOkCreateInterview}
        onOkEdit={handleOnOkEditInterview}
        onCancel={handleOnCancelCreateInterview}
        interview={currentInterview}
      />
    </div>
  );
};
