import React from 'react';

export const columnsRecording = [
  {
    title: 'Студент',
    dataIndex: 'studentName',
    key: 'studentName'
  },
  {
    title: 'Предпочитаемое время',
    dataIndex: 'preferableTime',
    key: 'preferableTime'
  },
  {
    title: 'Желаемый стэк',
    dataIndex: 'stackTypes',
    key: 'stackTypes'
  },
  {
    title: 'Приоритет',
    dataIndex: 'priority',
    key: 'priority'
  },
  {
    title: 'Ссылка на резюме',
    dataIndex: 'resumeLink',
    key: 'resumeLink',
    render: (text) => (text ? <a href={text}>Резюме</a> : '')
  }
];

export const priorityDict = [
  {
    value: 'Высокий',
    key: 1
  },
  {
    value: 'Средний',
    key: 2
  },
  {
    value: 'Низкий',
    key: 3
  }
];

export const stackTypesDict = [
  {
    value: 'Frontend',
    key: '1'
  },
  {
    value: 'Backend',
    key: '2'
  },
  {
    value: 'ML',
    key: '3'
  },
  {
    value: 'Analytic',
    key: '4'
  }
];
