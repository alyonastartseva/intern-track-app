import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import { Layout, Menu } from 'antd';
import {
  HomeOutlined,
  FormOutlined,
  UsergroupDeleteOutlined,
  SettingOutlined,
  FileDoneOutlined,
  OrderedListOutlined
} from '@ant-design/icons';
import { LocalStorageHelper } from '../shared/helpers/localstore';

const { Content, Footer, Sider } = Layout;

function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label
  };
}

const studentItems = [
  getItem(
    <Link to="/" className="nav-text">
      Запись на собеседование
    </Link>,
    '1',
    <FormOutlined />
  ),
  getItem(
    <Link to="/my-interviews" className="nav-text">
      Мои собеседования
    </Link>,
    '2',
    <UsergroupDeleteOutlined />
  ),
  getItem(
    <Link to="/profile" className="nav-text">
      Мой профиль
    </Link>,
    '3',
    <HomeOutlined />
  )
];

const companyItems = [
  getItem(
    <Link to="/vacancies" className="nav-text">
      Управление вакансиями
    </Link>,
    '1',
    <SettingOutlined />
  ),
  getItem(
    <Link to="/admin-interviews" className="nav-text">
      Управление собеседованиями
    </Link>,
    '2',
    <FileDoneOutlined />
  ),
  getItem(
    <Link to="/profile" className="nav-text">
      Мой профиль
    </Link>,
    '3',
    <HomeOutlined />
  ),
  getItem(
    <Link to="/company-records" className="nav-text">
      Список заявок
    </Link>,
    '4',
    <OrderedListOutlined />
  )
];

const univItems = [
  getItem(
    <Link to="/" className="nav-text">
      Компании-партнёры
    </Link>,
    '1',
    <FormOutlined />
  ),
  getItem(
    <Link to="/users" className="nav-text">
      Статусы студентов
    </Link>,
    '2',
    <HomeOutlined />
  ),
  getItem(
    <Link to="/profile" className="nav-text">
      Мой профиль
    </Link>,
    '3',
    <HomeOutlined />
  )
];

export const PrivateRouteLayout = ({ component }) => {
  const [collapsed, setCollapsed] = useState(false);

  const [role, setRole] = useState(null);

  useEffect(() => {
    setRole(LocalStorageHelper.getData('role'));
  }, []);

  return (
    <Layout
      style={{
        minHeight: '100vh'
      }}
    >
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div className="logo" />
        <Menu
          theme="dark"
          defaultSelectedKeys={['1']}
          mode="inline"
          items={role === 'Student' ? studentItems : role === 'Company' ? companyItems : univItems}
        />
      </Sider>
      <Layout className="site-layout">
        <Content
          style={{
            margin: '48px 24px'
          }}
        >
          <div>{component}</div>
        </Content>
        <Footer
          style={{
            textAlign: 'center'
          }}
        >
          HITs, Team 5, 2022
        </Footer>
      </Layout>
    </Layout>
  );
};
