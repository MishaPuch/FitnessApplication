import React, { useContext, useState } from 'react';
import { Card } from 'primereact/card';
import { Chart } from 'primereact/chart';

import TaskBar from '../../TaskBar/TaskBar';
import Header from '../../Header/Header';

import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
import { PlanDataContext } from '../../../State/PlanDataState';
import useFetchAllExercise from '../../../hooks/useFetchAllExercise';
import useFetchAllMeal from '../../../hooks/useGetAllMeals';

const StatisticsMeal = () => {
  const { planData } = useContext(PlanDataContext);
  const dataFromHook = useFetchAllMeal();
  console.log(dataFromHook);
  const [data, setData] = useState({
    labels: [],
    datasets: [
      {
        label: 'Sales',
        backgroundColor: '#42A5F5',
        data: [],
      },
    ],
  });

  const fetchData = async () => {
    try {
      const labels = dataFromHook.map((element) => element.foodName);
      const salesData = dataFromHook.map((element) => element.statistic);

      setData({
        labels: labels,
        datasets: [
          {
            label: 'Meal',
            backgroundColor: '#42A5F5',
            data: salesData,
          },
        ],
      });

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


export default StatisticsMeal;

         