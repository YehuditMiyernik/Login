const user = sessionStorage.getItem('user')
const jsonUser = JSON.parse(user)

const loadHomePage = () => {
    const welcome = document.getElementById('welcome')
    welcome.innerHTML = `hello ${jsonUser.name}!!! welcome to my home page:)`
}

const showUpdateUser = async () => {
    const update = document.getElementById("update")
    update.style.visibility = "initial"
    const userName = document.getElementById("userName")
    userName.value = jsonUser.userName
    const password = document.getElementById("password")
    password.value = jsonUser.password
    const name = document.getElementById("name")
    name.value = jsonUser.name
    const lastName = document.getElementById("lastName")
    lastName.value = jsonUser.lastName
}

const updateUser = async () => {
    try {
        const userName = document.getElementById("userName").value
        const password = document.getElementById("password").value
        const name = document.getElementById("name").value
        const lastName = document.getElementById("lastName").value
        //const id- js variables start with lowerCase
        const Id = jsonUser.id
        //const progress = document.getElementById("progress").value

        //if (progress < 3) {
        //    throw new Error("try another password")
        //}

        const user = { Id, userName, password, name, lastName }

        const res = await fetch(`/api/users/${Id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

]//check response's status- if status==401 alert(userName or password are invalid)
//if status==400 model validation error... etc
//If (res.status == 200) save the new user details in SessionStorage
// and   alert a suitable message
//alert instead of throwing an error
        if (!res.ok)
            throw new Error("failed to update")
        window.location.href = "./login.html"
    } catch (ex) {
        //Exceptions you should log to the console (or to a special error file) it is not nice to alert the exceptions. 
        alert(ex.message)
    }

}