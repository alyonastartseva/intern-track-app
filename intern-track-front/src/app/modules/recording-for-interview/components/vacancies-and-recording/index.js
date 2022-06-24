import React, { useCallback, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

import { ReactComponent as BackIcon } from 'src/assets/svg/backIcon.svg';
import { useGetVacanciesByIdQuery } from 'src/app/store/api/companies';
import { columnsRecording } from './const';
import { CreateRecordModal } from './component/createRecordModal';

import { Button, Col, Card, Divider, Table } from 'antd';

import './VacanciesAndRecording.css';

export const VacanciesAndRecording = () => {
  const [createRecordModalVisible, setCreateRecordModalVisible] = useState(false);

  const { companyId } = useParams();

  const { data, error, isLoading } = useGetVacanciesByIdQuery(companyId || '');

  const navigate = useNavigate();

  const handleOnClickAddRecord = useCallback(() => {
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  const handleOnOkRecordCreate = useCallback((formData) => {
    console.log(formData);
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  const handleOnCancelRecordCreate = useCallback((formData) => {
    console.log(formData);
    setCreateRecordModalVisible((prev) => !prev);
  }, []);

  return (
    <div className="vacanciesPage">
      <header>
        <Button className="ita-btn _text _back" onClick={() => navigate(-1)}>
          <BackIcon />
          Назад к компаниям
        </Button>
        <h2>Доступные вакансии</h2>
      </header>
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
      <Divider orientation="center">
        <h2 className="recordingTitle">Записаться на собеседование</h2>
      </Divider>
      <Button className="ita-btn add-record" onClick={handleOnClickAddRecord}>
        Добавить запись
      </Button>
      <Table dataSource={[]} columns={columnsRecording} />

      <CreateRecordModal
        isVisible={createRecordModalVisible}
        onOk={handleOnOkRecordCreate}
        onCancel={handleOnCancelRecordCreate}
      />
    </div>
  );
};
