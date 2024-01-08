import React, { useEffect, useState } from "react";

async function fetchAllMeal() {
  try {
    const response = await fetch("https://localhost:7060/api/Meal/getAllMealAsync", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      alert("Error while fetching data");
    }
  } catch (error) {
    console.error("Error:", error);
  }
}

export default function useFetchAllMeal() {
  const [data, setData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const result = await fetchAllMeal();
      setData(result);
    };

    fetchData();
  }, []); 

  return data;
}
