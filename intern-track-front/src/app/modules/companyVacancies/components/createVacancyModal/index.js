import React, { useCallback } from 'react';

import { Modal, Form, Input } from 'antd';

export const CreateVacancyModal = ({ isVisible, onCancel, onOk }) => {
  const [form] = Form.useForm();

  const handleAfterClose = useCallback(() => {
    form.resetFields();
  }, [form]);

  return (
    <Modal
      title="Создать вакансию"
      centered
      visible={isVisible}
      onOk={() => onOk(form.getFieldsValue())}
      onCancel={onCancel}
      afterClose={handleAfterClose}
      cancelText="Отменить"
      okText="Создать"
    >
      <Form form={form} name="create-vacancy">
        <Form.Item name="preferableTime" label="Введите предпочитаемое время" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
      </Form>
    </Modal>
  );
};
