import React from "react";

async function ChangeUserApi(user){
    try {
      console.log(user);
        const response = await fetch("https://localhost:7060/api/Account/changeData", {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          
          body: JSON.stringify(user),
        });
      
        if (response.ok) {
          console.log("Users data changed successful");
          alert("To see your changes , you have to login👍");
          
        } else {
          console.log(response);
          alert("Error while changing data");
        }
      
    } catch (error) {
    console.error("Error:", error);
    }
}
export default function useChangeUserApi(){
    return ChangeUserApi;
}