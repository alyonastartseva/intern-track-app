import moment from 'moment';

import { studentInterviewsStatusType } from '../companyInterview/const';

export const formatDict = [
  {
    key: '1',
    value: 'Online'
  },
  {
    key: '2',
    value: 'Offline'
  }
];

export const columnsMyInterviews = [
  {
    title: 'Компания',
    dataIndex: 'companyName',
    key: 'companyName'
  },
  {
    title: 'Позиция',
    dataIndex: 'vacancyStack',
    key: 'vacancyStack'
  },
  {
    title: 'Дата',
    dataIndex: 'date',
    key: 'date',
    render: (text) => moment(text).format('DD.MM.YYYY')
  },
  {
    title: 'Формат',
    dataIndex: 'format',
    key: 'format'
  },
  {
    title: 'Место',
    dataIndex: 'place',
    key: 'place'
  },
  {
    title: 'Статус',
    dataIndex: 'studentInterviewStatusType',
    key: 'studentInterviewStatusType',
    render: (text) => studentInterviewsStatusType.find((el) => el.key === text)?.value
  }
];
