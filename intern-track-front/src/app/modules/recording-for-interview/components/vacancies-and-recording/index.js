import React, { useCallback, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';
import { useGetVacanciesByIdQuery } from 'src/app/store/api/companies';
import { columnsRecording } from './const';
import { CreateRecordModal } from './component/createRecordModal';
import { useGetPlanInterviewByCompanyIdQuery, useCreateUpdateRecordMutation } from 'src/app/store/api/record';

import { Button, Col, Card, Table, Tabs } from 'antd';

import './VacanciesAndRecording.css';

const { TabPane } = Tabs;

export const VacanciesAndRecording = () => {
  const [createRecordModalVisible, setCreateRecordModalVisible] = useState(false);

  const { companyId } = useParams();

  const {
    data: vacancies,
    error: errorVacancies,
    isLoading: loadingVacancies
  } = useGetVacanciesByIdQuery(companyId || '');

  const {
    data: recordInterviws,
    error: errorRecord,
    isLoading: loadingRecord
  } = useGetPlanInterviewByCompanyIdQuery(companyId || '');

  const [createUpdateRecord] = useCreateUpdateRecordMutation();

  const navigate = useNavigate();

  const handleOnClickAddRecord = useCallback(() => {
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  const handleOnOkRecordCreate = useCallback(
    (formData) => {
      const preparedData = {
        ...formData,
        id: 0,
        companyId
      };
      console.log(preparedData);
      createUpdateRecord(preparedData);
      setCreateRecordModalVisible((prev) => !prev);
    },
    [companyId, createUpdateRecord]
  );

  const handleOnCancelRecordCreate = useCallback(() => {
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  return (
    <div className="vacanciesPage">
      <header>
        <Button className="ita-btn _text _back" onClick={() => navigate(-1)}>
          <BackIcon />
          Назад к компаниям
        </Button>
      </header>

      <Tabs defaultActiveKey="1">
        <TabPane tab="Вакансии" key="1">
          <Col className="vacancies" span={8}>
            <Card title="Фронтенд разработчик">
              <p>
                <span className="descTitle">Описание:</span> Нужен хороший фронт
              </p>
              <p>
                <span className="descTitle">Количество мест:</span> 2
              </p>
            </Card>
          </Col>
        </TabPane>
        <TabPane tab="Запись на собеседование" key="2">
          <Button className="ita-btn add-record" onClick={handleOnClickAddRecord} type="primary">
            Добавить запись
          </Button>
          <Table dataSource={recordInterviws?.interviewPlansList} columns={columnsRecording} />
        </TabPane>
      </Tabs>

      <CreateRecordModal
        isVisible={createRecordModalVisible}
        onOk={handleOnOkRecordCreate}
        onCancel={handleOnCancelRecordCreate}
      />
    </div>
  );
};
