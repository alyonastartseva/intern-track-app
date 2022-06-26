import React, { useCallback, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

import { Button, Form, Input, Select, message } from 'antd';
import { LockOutlined } from '@ant-design/icons';

import { Roles } from 'src/app/shared/consts';
import { useRegisterMutation } from 'src/app/store/api/auth';
import { LocalStorageHelper } from 'src/app/shared/helpers/localstore';

import '../../Auth.css';

const { Option } = Select;

export const SignUp = () => {
  const [form] = Form.useForm();
  const navigate = useNavigate();

  const [register] = useRegisterMutation();

  const [isCompany, setIsCompany] = useState(false);

  const onFinish = useCallback(
    (values) => {
      register(values)
        .unwrap()
        .then((payload) => {
          LocalStorageHelper.setData('role', payload.role);
          navigate('/');
        })
        .catch((error) => {
          message.error(error.data.message);
        });
    },
    [navigate, register]
  );

  const handleOnFieldsChange = useCallback(() => {
    if (form.getFieldValue('role') === 'company') {
      setIsCompany(true);
    } else {
      setIsCompany(false);
    }
  }, [form]);

  return (
    <div className="page">
      <div className="form">
        <span className="icon">
          <LockOutlined />
        </span>
        <h1>Регистрация</h1>
        <Form form={form} name="register" onFinish={onFinish} onFieldsChange={handleOnFieldsChange}>
          <div className="userInfo">
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

          {isCompany ? (
            <Form.Item
              name="companyName"
              rules={[
                {
                  required: true,
                  message: 'Обязательное поле!'
                }
              ]}
            >
              <Input placeholder="Название компании" />
            </Form.Item>
          ) : (
            <div className="userInfo">
              <Form.Item name="firstName">
                <Input placeholder="Имя" />
              </Form.Item>
              <Form.Item name="lastName">
                <Input placeholder="Фамилия" />
              </Form.Item>
            </div>
          )}

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
            <Link to="/signupStudent" className="link">
              Зарегистрироваться
            </Link>{' '}
            как студент
          </p>

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
