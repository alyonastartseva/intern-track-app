import React, { useCallback, useState } from 'react';

import { Button, Card, Col, Row } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';

import { CreateVacancyModal } from './components/createVacancyModal';
import './CompanyVacancies.css';

export const CompanyVacancies = () => {
  const [visibleCreateModal, setVisibleCreateModal] = useState(false);

  const handleOnOkCreateVacancy = useCallback((formData) => {
    console.log(formData);
    setVisibleCreateModal((prev) => !prev);
  }, []);

  const handleOnCancelCreateVacancy = useCallback(() => {
    setVisibleCreateModal((prev) => !prev);
  }, []);

  const handleOnEditVacancy = useCallback((id) => {
    console.log(id);
  }, []);

  const handleOnDeleteVacancy = useCallback((id) => {
    console.log(id);
  }, []);

  return (
    <div>
      <Button className="ita-btn create-vacancy" onClick={() => setVisibleCreateModal((prev) => !prev)}>
        Создать вакансию
      </Button>

      <Row gutter={[16, 16]}>
        <Col span={8}>
          <Card
            title="Название вакансии"
            actions={[
              <EditOutlined onClick={() => handleOnEditVacancy(5)} key="edit" />,
              <DeleteOutlined onClick={() => handleOnDeleteVacancy(5)} key="delete" />
            ]}
          >
            <p>Описание вакансии</p>
          </Card>
        </Col>
      </Row>

      <CreateVacancyModal
        isVisible={visibleCreateModal}
        onOk={handleOnOkCreateVacancy}
        onCancel={handleOnCancelCreateVacancy}
      />
    </div>
  );
};
