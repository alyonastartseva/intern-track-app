import React, { useCallback } from 'react';

import { Modal, Form, Input, Select } from 'antd';

import { priorityDict, stackTypesDict } from '../../const';

const { Option } = Select;

export const CreateRecordModal = ({ isVisible, onCancel, onOk }) => {
  const [form] = Form.useForm();

  const handleAfterClose = useCallback(() => {
    form.resetFields();
  }, [form]);

  return (
    <Modal
      title="Записаться на собеседование"
      centered
      visible={isVisible}
      onOk={() => onOk(form.getFieldsValue())}
      onCancel={onCancel}
      afterClose={handleAfterClose}
      cancelText="Отменить"
      okText="Сохранить"
    >
      <Form form={form} name="create-record">
        <Form.Item name="preferableTime" label="Введите предпочитаемое время" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item name="priority" label="Введите приоритет" rules={[{ required: true }]}>
          <Select>
            {priorityDict.map((item) => (
              <Option key={item.key} value={item.key}>
                {item.value}
              </Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item name="stackTypes" label="Желаемые направления стажировки" rules={[{ required: true }]}>
          <Select mode="multiple">
            {stackTypesDict.map((item) => (
              <Option key={item.key} value={item.key}>
                {item.value}
              </Option>
            ))}
          </Select>
        </Form.Item>
      </Form>
    </Modal>
  );
};
