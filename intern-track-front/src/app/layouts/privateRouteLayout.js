import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import { Layout, Menu } from 'antd';
import { HomeOutlined, FormOutlined, UsergroupDeleteOutlined, SettingOutlined } from '@ant-design/icons';

const { Content, Footer, Sider } = Layout;

function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label
  };
}

const items = [
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
  ),
  getItem(
    <Link to="/vacancies" className="nav-text">
      Управление вакансиями
    </Link>,
    '4',
    <SettingOutlined />
  )
];

export const PrivateRouteLayout = ({ component }) => {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <Layout
      style={{
        minHeight: '100vh'
      }}
    >
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div className="logo" />
        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} />
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
