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
        const Id = jsonUser.id
        //const progress = document.getElementById("progress").value

        //if (progress < 3) {
        //    throw new Error("try another password")
        //}

        const user = { id, userName, password, name, lastName }

        const res = await fetch(`/api/users/${Id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!res.ok)
            throw new Error("failed to update")
        window.location.href = "./login.html"
    } catch (ex) {
        alert(ex.message)
    }

}