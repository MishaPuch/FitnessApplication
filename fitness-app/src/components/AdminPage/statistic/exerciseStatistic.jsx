import React, { useContext, useEffect, useState } from 'react';
import { Card } from 'primereact/card';
import { Chart } from 'primereact/chart';

import { PlanDataContext } from '../../../State/PlanDataState';
import useFetchAllExercise from '../../../hooks/useFetchAllExercise';

const StatisticsExercise = () => {
  const { planData } = useContext(PlanDataContext);
  const dataFromHook = useFetchAllExercise();

  const [data, setData] = useState({
    labels: [],
    datasets: [
      {
        label: 'Exercise',
        backgroundColor: '#42A5F5',
        data: [],
      },
    ],
  });

  const fetchData = async () => {
    try {
      const labels = dataFromHook.map((element) => element.exerciseName);
      const salesData = dataFromHook.map((element) => element.statistic);

      setData({
        labels: labels,
        datasets: [
          {
            label: 'Sales',
            backgroundColor: '#42A5F5',
            data: salesData,
          },
        ],
      });

      console.log(data);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  useEffect(() => {
    fetchData();
  }, [dataFromHook]);

  const options = {
    responsive: true,
    maintainAspectRatio: false,
  };

  return (
    <div className="container">
        <Card>
          <Chart type="bar" data={data} options={options} style={{ width: '1200px', height: '420px' }} />
        </Card>
    </div>
  );
};

export default StatisticsExercise;
