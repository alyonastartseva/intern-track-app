import React, { useCallback, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';
import { useGetVacanciesByIdQuery } from 'src/app/store/api/companies';
import { columnsRecording, stackTypesDict } from './const';
import { CreateRecordModal } from './component/createRecordModal';
import { useGetPlanInterviewByCompanyIdQuery, useCreateUpdateRecordMutation } from 'src/app/store/api/record';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import { Button, Col, Card, Table, Tabs, Spin, Result, Row } from 'antd';

import './VacanciesAndRecording.css';

const { TabPane } = Tabs;

export const VacanciesAndRecording = () => {
  const [createRecordModalVisible, setCreateRecordModalVisible] = useState(false);
  const currentUserId = LocalStorageHelper.getData('userId');

  console.log(currentUserId);

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
  } = useGetPlanInterviewByCompanyIdQuery({ companyId, currentUserId });

  const [createUpdateRecord] = useCreateUpdateRecordMutation();

  const navigate = useNavigate();

  const handleOnClickAddRecord = useCallback(() => {
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  const handleOnOkRecordCreate = useCallback(
    (formData) => {
      const ids = formData?.vacancyIds.map((item) => Number(item));
      const preparedData = {
        vacancyIds: ids,
        preferableTime: formData.preferableTime,
        priority: formData.priority,
        resumeLink: formData.resumeLink,
        id: 0,
        companyId,
        studentId: LocalStorageHelper.getData('userId')
      };
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

      {vacancies?.vacancies?.length ? (
        <Tabs defaultActiveKey="1">
          <TabPane tab="Вакансии" key="1">
            {loadingVacancies ? (
              <Spin className="loader" />
            ) : errorVacancies ? (
              <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список вакансий" />
            ) : vacancies.vacancies.length ? (
              <Row gutter={[16, 16]}>
                {vacancies.vacancies.map((vac, index) => (
                  <Col key={vac.id || index} span={8}>
                    <Card title={vac.stack}>
                      <p>
                        <span className="descTitle">Описание:</span>
                        {vac.description}
                      </p>
                      <p>
                        <span className="descTitle">Количество занятых мест / Общее количество мест:</span>
                        {vac.totalNumber - vac.freeNumber} / {vac.totalNumber}
                      </p>
                    </Card>
                  </Col>
                ))}
              </Row>
            ) : (
              <Result title="К сожалению, в данный момент у компании нет открытых вакансий" />
            )}
          </TabPane>
          <TabPane tab="Запись на собеседование" key="2">
            <Button className="ita-btn add-record" onClick={handleOnClickAddRecord} type="primary">
              Добавить запись
            </Button>
            <Table dataSource={recordInterviws?.interviewPlansList} columns={columnsRecording} />
          </TabPane>
        </Tabs>
      ) : (
        <Result title="К сожалению, в данный момент у компании нет открытых вакансий" />
      )}

      <CreateRecordModal
        isVisible={createRecordModalVisible}
        onOk={handleOnOkRecordCreate}
        onCancel={handleOnCancelRecordCreate}
      />
    </div>
  );
};
