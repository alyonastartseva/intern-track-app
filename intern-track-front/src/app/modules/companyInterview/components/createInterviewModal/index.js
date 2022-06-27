import React, { useCallback, useEffect } from 'react';

import { Modal, Form, Input, Select, DatePicker } from 'antd';

import { useGetVacanciesByIdQuery } from 'src/app/store/api/companies';
import { useGetAllStudentsQuery } from 'src/app/store/api/user';
import { studentInterviewsStatusType } from '../../const';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

const { Option } = Select;

export const CreateInterviewModal = ({ isVisible, onCancel, onOkCreate, onOkEdit, interview }) => {
  const [form] = Form.useForm();

  const { data: vacancies } = useGetVacanciesByIdQuery(LocalStorageHelper.getData('userId'));
  const { data: students } = useGetAllStudentsQuery();

  useEffect(() => {
    if (interview) {
      form.setFields([
        {
          name: 'vacancyId',
          value: interview.vacancyStack
        }
      ]);
    }
  }, [form, interview]);

  const handleAfterClose = useCallback(() => {
    if (!interview) {
      form.resetFields();
    }
  }, [form, interview]);

  return (
    <Modal
      title="Создать интервью"
      centered
      visible={isVisible}
      onOk={!interview ? () => onOkCreate(form.getFieldsValue()) : () => onOkEdit(form.getFieldsValue())}
      onCancel={onCancel}
      afterClose={handleAfterClose}
      cancelText="Отменить"
      okText="Создать"
    >
      <Form form={form} name="create-vacancy">
        <Form.Item name="vacancyId" label="Вакансия" rules={[{ required: true }]}>
          <Select>
            {vacancies?.vacancies?.map((item) => (
              <Option key={item.id} value={item.id}>
                {item.stack}
              </Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item name="studentId" label="Студент" rules={[{ required: true }]}>
          <Select>
            {students?.students?.map((s) => (
              <Option key={s.studentId} value={s.studentId}>
                {s.email}
              </Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item name="date">
          <DatePicker placeholder="Выберите дату" />
        </Form.Item>
        <Form.Item name="format" label="Формат" rules={[{ required: true }]}>
          <Select>
            <Option key="1" value={1}>
              Online
            </Option>
            <Option key="2" value={2}>
              Offline
            </Option>
          </Select>
        </Form.Item>
        <Form.Item name="place" label="Место" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item name="studentInterviewStatusType" label="Статус собеседования" rules={[{ required: true }]}>
          <Select>
            {studentInterviewsStatusType.map((item) => (
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
