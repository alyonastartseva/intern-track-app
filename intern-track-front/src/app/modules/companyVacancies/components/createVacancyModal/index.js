import React, { useCallback, useEffect } from 'react';

import { Modal, Form, Input, InputNumber } from 'antd';

export const CreateVacancyModal = ({ isVisible, onCancel, onOkCreate, onOkEdit, vacancy }) => {
  const [form] = Form.useForm();

  useEffect(() => {
    if (vacancy) {
      form.setFields([
        {
          name: 'stack',
          value: vacancy.stack
        },
        {
          name: 'totalNumber',
          value: vacancy.totalNumber
        },
        {
          name: 'description',
          value: vacancy.description
        }
      ]);
    }
  }, [form, vacancy]);

  const handleAfterClose = useCallback(() => {
    if (!vacancy) {
      form.resetFields();
    }
  }, [form, vacancy]);

  return (
    <Modal
      title="Создать вакансию"
      centered
      visible={isVisible}
      onOk={!vacancy ? () => onOkCreate(form.getFieldsValue()) : () => onOkEdit(form.getFieldsValue())}
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
