const showRegister = () => {
    const register = document.getElementById("register")
    register.style.visibility = "initial"
}

const login = async () => {
    try {
        const userName = document.getElementById("userName").value
        const password = document.getElementById("password").value

        const res = await fetch(`/api/users?userName=${userName}&password=${password}`,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });
        if (!res.ok)
            throw new Error("wrong name or password!")
        const user = await res.json();
        sessionStorage.setItem('user', JSON.stringify(user));
        window.location.href = "./home.html";
    } catch (ex) {
        alert(ex.message);
    }
}


const register = async () => {
    try {
        const userName = document.getElementById("registerUserName").value
        const password = document.getElementById("registerPassword").value
        const name = document.getElementById("name").value
        const lastName = document.getElementById("lastName").value
        const progress = document.getElementById("progress").value

        if (progress < 3) {
            throw new Error("try another password")
        }

        const user = { userName, password, name, lastName }

        const res = await fetch('/api/users',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });

        if (!res.ok)
            throw new Error("Error adding user to server")
        const created = await res.json();
        alert(`${created.id} was created`);
    } catch (ex) {
        alert(ex.message);
    }
}

const checkPassword = async () => {
    try {
        const password = document.getElementById("registerPassword").value
        const res = await fetch('/api/users/pwd',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(password)
            });
        console.log(res);
        const score = await res.json();
        const progress = document.getElementById("progress")
        progress.value = score;
    } catch (ex) {
        alert(ex.message);
    }
}
