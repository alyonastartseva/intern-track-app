import React from 'react';

import { Button, Form, Input, Select } from 'antd';
import { LockOutlined } from '@ant-design/icons';

import { Roles } from 'src/app/shared/consts';

import './Signup.css';

const { Option } = Select;

export const SignUp = () => {
  const [form] = Form.useForm();

  const onFinish = (values) => {
    console.log('Received values of form: ', values);
  };

  return (
    <div className="page">
      <div className="form">
        <span className="icon">
          <LockOutlined />
        </span>
        <h1>Регистрация</h1>
        <Form form={form} name="register" onFinish={onFinish}>
          <div className="userInfo">
            <Form.Item
              name="userName"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <Input placeholder="Имя пользователя" />
            </Form.Item>

            <Form.Item
              name="role"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <Select placeholder="Роль" style={{ width: 170 }}>
                {Roles.map((item) => (
                  <Option key={item.key} value={item.key}>
                    {item.value}
                  </Option>
                ))}
              </Select>
            </Form.Item>
          </div>

          <Form.Item
            name="email"
            rules={[
              {
                type: 'email',
                message: 'Введён неверный адрес электронной почты!'
              },
              {
                required: true,
                message: 'Обязательное поле!'
              }
            ]}
          >
            <Input placeholder="Email" />
          </Form.Item>

          <Form.Item
            name="password"
            rules={[
              {
                required: true,
                message: 'Обязательное поле!'
              }
            ]}
          >
            <Input.Password placeholder="Пароль" />
          </Form.Item>

          <Form.Item
            name="confirmPassword"
            dependencies={['password']}
            rules={[
              {
                required: true,
                message: 'Обязательное поле!'
              },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue('password') === value) {
                    return Promise.resolve();
                  }

                  return Promise.reject(new Error('Два введённых вами пароля не совпадают!'));
                }
              })
            ]}
          >
            <Input.Password placeholder="Подтвердить пароль" />
          </Form.Item>

          <Form.Item name="about">
            <Input.TextArea placeholder="О себе" />
          </Form.Item>

          <Form.Item>
            <Button htmlType="submit" className="ita-btn submitBtn">
              Зарегистрироваться
            </Button>
          </Form.Item>

          <p className="extraText">
            <span className="link">Зарегистрироваться</span> как студент
          </p>

          <p className="extraText">
            У вас уже есть аккаунт? <span className="link">Войти</span>
          </p>
        </Form>
      </div>
    </div>
  );
};
