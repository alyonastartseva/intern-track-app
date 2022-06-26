import React, { useCallback, useState } from 'react';

import { Button } from 'antd';

import { CreateVacancyModal } from './components/createVacancyModal';

export const CompanyVacancies = () => {
  const [visibleCreateModal, setVisibleCreateModal] = useState(false);

  const handleOnOk = useCallback((formData) => {
    console.log(formData);
    setVisibleCreateModal((prev) => !prev);
  }, []);

  const handleOnCancel = useCallback(() => {
    setVisibleCreateModal((prev) => !prev);
  }, []);

  return (
    <div>
      <Button className="ita-btn" onClick={() => setVisibleCreateModal((prev) => !prev)}>
        Создать вакансию
      </Button>

      <CreateVacancyModal isVisible={visibleCreateModal} onOk={handleOnOk} onCancel={handleOnCancel} />
    </div>
  );
};
