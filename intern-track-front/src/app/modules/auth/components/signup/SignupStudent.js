import React from 'react';
import { Link } from 'react-router-dom';

import { Button, Form, Input, InputNumber } from 'antd';
import { LockOutlined } from '@ant-design/icons';

import { useRegisterAsStudentMutation } from 'src/app/store/api/auth';

import '../../Auth.css';

export const SignUpStudent = () => {
  const [form] = Form.useForm();

  const [registerAsStudent, result] = useRegisterAsStudentMutation();

  const onFinish = (values) => {
    registerAsStudent(values);
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
              name="course"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <InputNumber placeholder="Курс" min={1} max={4} />
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

          <div className="userInfo">
            <Form.Item
              name="firstName"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <Input placeholder="Имя" />
            </Form.Item>

            <Form.Item
              name="lastName"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <Input placeholder="Фамилия" />
            </Form.Item>
          </div>

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
            У вас уже есть аккаунт?{' '}
            <Link to="/" className="link">
              Войти
            </Link>
          </p>
        </Form>
      </div>
    </div>
  );
};
