import React, { useEffect, useState } from "react";

async function fetchAllExercise() {
  try {
    const response = await fetch("https://localhost:7060/api/Exercise/getAllExercises", {
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

export default function useFetchAllExercise() {
  const [data, setData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const result = await fetchAllExercise();
      setData(result);
    };

    fetchData();
  }, []); // Empty dependency array means it runs once on mount

  return data;
}
