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
    title: 'Ссылка на резюме',
    dataIndex: 'resumeLink',
    key: 'resumeLink',
    render: (text) => (text ? <a href={text}>Резюме</a> : '')
  }
];
