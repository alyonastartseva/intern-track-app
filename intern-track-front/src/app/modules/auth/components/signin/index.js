import React, { useCallback } from 'react';
import { Link, useNavigate } from 'react-router-dom';

import { Button, Form, Input, Select, Checkbox, message } from 'antd';
import { LockOutlined } from '@ant-design/icons';

import { useLoginMutation } from 'src/app/store/api/auth';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import '../../Auth.css';

const { Option } = Select;

export const SignIn = () => {
  const [form] = Form.useForm();

  const navigate = useNavigate();

  const [login] = useLoginMutation();

  const onFinish = useCallback(
    (values) => {
      login(values)
        .unwrap()
        .then((payload) => {
          LocalStorageHelper.setData('role', payload.role);
          navigate('/');
        })
        .catch((error) => {
          message.error(error.data.message);
        });
    },
    [login, navigate]
  );

  return (
    <div className="page">
      <div className="form">
        <span className="icon">
          <LockOutlined />
        </span>
        <h1>Вход</h1>
        <Form form={form} name="register" onFinish={onFinish}>
          <Form.Item
            name="email"
            rules={[
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
