import React from 'react';
import { Link } from 'react-router-dom';

import { Button, Form, Input, Select, Checkbox } from 'antd';
import { LockOutlined } from '@ant-design/icons';

import '../../Auth.css';

const { Option } = Select;

export const SignIn = () => {
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
        <h1>Вход</h1>
        <Form form={form} name="register" onFinish={onFinish}>
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

          <Form.Item name="rememberMe" valuePropName="checked" noStyle>
            <Checkbox>Remember me</Checkbox>
          </Form.Item>

          <Form.Item>
            <Button htmlType="submit" className="ita-btn submitBtn">
              Войти
            </Button>
          </Form.Item>

          <p className="extraText">
            У вас нет аккаутна?{' '}
            <Link to="/signup" className="link">
              Зарегистрироваться
            </Link>
          </p>
        </Form>
      </div>
    </div>
  );
};
