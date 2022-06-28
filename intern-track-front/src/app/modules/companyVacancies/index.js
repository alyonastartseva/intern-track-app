import React, { useCallback, useState } from 'react';

import { Button, Card, Col, Row, Spin, Result } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';

import { CreateVacancyModal } from './components/createVacancyModal';
import {
  useCreateUpdateVacancyMutation,
  useGetVacanciesQuery,
  useDeleteVacancyMutation
} from 'src/app/store/api/vacancy';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import './CompanyVacancies.css';

export const CompanyVacancies = () => {
  const [visibleCreateModal, setVisibleCreateModal] = useState(false);
  const [currentVacancy, setCurrentVacancy] = useState(null);

  const {
    data: vacancies,
    error: errorVacancies,
    isLoading: loadingVacancies
  } = useGetVacanciesQuery(LocalStorageHelper.getData('userId'));
  const [createUpdateVacancy] = useCreateUpdateVacancyMutation();
  const [deleteVacancy] = useDeleteVacancyMutation();

  const handleOnOkCreateVacancy = useCallback(
    (formData) => {
      createUpdateVacancy({
        ...formData,
        companyId: LocalStorageHelper.getData('userId')
      });
      setVisibleCreateModal((prev) => !prev);
    },
    [createUpdateVacancy]
  );

  const handleOnOkEditVacancy = useCallback(
    (formData) => {
      createUpdateVacancy({
        ...formData,
        companyId: LocalStorageHelper.getData('userId'),
        vacancyId: currentVacancy?.id
      });
      setCurrentVacancy(null);
      setVisibleCreateModal((prev) => !prev);
    },
    [createUpdateVacancy, currentVacancy?.id]
  );

  const handleOnCancelCreateVacancy = useCallback(() => {
    setVisibleCreateModal((prev) => !prev);
    setCurrentVacancy(null);
  }, []);

  const handleOnEditVacancy = useCallback(
    (id) => {
      const vac = vacancies.vacancies.find((el) => el.id === id);
      setCurrentVacancy(vac);
      setVisibleCreateModal((prev) => !prev);
    },
    [vacancies]
  );

  const handleOnDeleteVacancy = useCallback(
    (id) => {
      deleteVacancy(id);
    },
    [deleteVacancy]
  );

  return (
    <div>
      <Button className="ita-btn create-vacancy" onClick={() => setVisibleCreateModal((prev) => !prev)}>
        Создать вакансию
      </Button>

      {loadingVacancies ? (
        <Spin className="loader" />
      ) : errorVacancies ? (
        <Result status="500" title="Что-то пошло не так" subTitle="Не удалось загрузить список вакансий" />
      ) : (
        <Row gutter={[16, 16]}>
          {vacancies.vacancies.map((item) => (
            <Col key={item.id} span={8}>
              <Card
                title={item.stack}
                actions={[
                  <EditOutlined onClick={() => handleOnEditVacancy(item.id)} key="edit" />,
                  <DeleteOutlined onClick={() => handleOnDeleteVacancy(item.id)} key="delete" />
                ]}
              >
                <p>
                  <span className="descTitle">Описание:</span>
                  {item.description}
                </p>
                <p>
                  <span className="descTitle">Количество мест:</span>
                  {item.totalNumber}
                </p>
              </Card>
            </Col>
          ))}
        </Row>
      )}

      <CreateVacancyModal
        isVisible={visibleCreateModal}
        onOkCreate={handleOnOkCreateVacancy}
        onOkEdit={handleOnOkEditVacancy}
        onCancel={handleOnCancelCreateVacancy}
        vacancy={currentVacancy}
      />
    </div>
  );
};
