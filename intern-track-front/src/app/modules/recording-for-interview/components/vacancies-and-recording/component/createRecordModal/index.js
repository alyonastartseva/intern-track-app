import React, { useCallback } from 'react';

import { useParams } from 'react-router-dom';
import { Modal, Form, Input, Select } from 'antd';

import { priorityDict, stackTypesDict } from '../../const';
import { useGetStackTypesByCompanyIdQuery } from 'src/app/store/api/record';

const { Option } = Select;

export const CreateRecordModal = ({ isVisible, onCancel, onOk }) => {
  const { companyId } = useParams();

  const { data: stackTypes } = useGetStackTypesByCompanyIdQuery(companyId || '');

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
            {stackTypes?.map((item) => (
              <Option key={item.key} value={item.key}>
                {stackTypesDict.find((el) => el.key === item.value)?.value}
              </Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item name="resumeLink" label="Ссылка на резюме">
          <Input />
        </Form.Item>
      </Form>
    </Modal>
  );
};
