// useLoginApi.jsx
async function LoginApi(email , password){
    debugger;
    const response = await fetch(`https://localhost:7060/api/Account/user/${email}/${password}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
    });
    if (response.ok) {
        const responseData = await response.json();
        if(responseData.length > 0){
            return { user: responseData, isLogged: true };
        }
        else {
            return { user: null, isLogged: false };
        }
    } else {
        throw new Error('Error while fetching users');  
    }
}

export default LoginApi;
