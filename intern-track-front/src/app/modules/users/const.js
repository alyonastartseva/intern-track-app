import moment from 'moment';
import { studentInterviewsStatusType } from '../companyInterview/const';

export const columnsStudents = [
  {
    title: 'Имя',
    dataIndex: 'firstName',
    key: 'firstName'
  },
  {
    title: 'Фамилия',
    dataIndex: 'lastName',
    key: 'lastName'
  },
  {
    title: 'Email',
    dataIndex: 'email',
    key: 'email'
  },
  {
    title: 'Курс',
    dataIndex: 'course',
    key: 'course'
  },
  {
    title: 'Статус',
    dataIndex: 'generalStudentStatus',
    key: 'generalStudentStatus'
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
