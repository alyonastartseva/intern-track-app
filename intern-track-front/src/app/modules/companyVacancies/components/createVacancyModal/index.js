import React, { useCallback } from 'react';

import { Modal, Form, Input, InputNumber } from 'antd';

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
        <Form.Item name="stack" label="Название" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item name="totalNumber" label="Количество мест" rules={[{ required: true }]}>
          <InputNumber min={1} />
        </Form.Item>
        <Form.Item name="description" label="Описание" rules={[{ required: true }]}>
          <Input.TextArea />
        </Form.Item>
      </Form>
    </Modal>
  );
};
