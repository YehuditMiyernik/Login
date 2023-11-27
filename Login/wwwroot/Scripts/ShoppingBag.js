const loadCartPage = () => {
    const p = sessionStorage.getItem("productsInCart");
    const productsInCart = JSON.parse(p);
    displayCartProducts(productsInCart);
}

const displayCartProducts = (products) => {
    let sum = 0;
    const template = document.getElementById("temp-row").content;
    const tbody = document.querySelector("tbody");
    const prodIds = [];
    const tableBody = document.querySelector("tbody");
    tableBody.replaceChildren();
    products.forEach(p => {
        if (prodIds.includes(p.id)) {
            const prod = document.getElementById(p.id);
            prod.querySelector('.quantity').innerHTML++;
        }
        else {
            const clone = template.cloneNode(true);
            const image = clone.querySelector(".image");
            const itemName = clone.querySelector(".itemName");
            const itemNumber = clone.querySelector(".itemNumber");
            clone.querySelector("tr").id = p.id;
            prodIds.push(p.id);
            image.src = "./Images/" + p.prodImage;
            itemName.innerText = p.prodName;
            itemNumber.innerText += " " + p.price;
            tbody.appendChild(clone);
        } 
        sum += p.price;
    })
    document.getElementById("itemCount").innerHTML = products.length;
    document.getElementById("totalAmount").innerHTML = sum ;
}

const deleteProduct = () => {
    const deleteButton = event.target;
    const row = deleteButton.closest('.item-row');
    const rowId = row.id;
    const products = JSON.parse(sessionStorage.getItem("productsInCart"));
    const productsInCart = products.filter(p => p.id !== parseInt(rowId));
    sessionStorage.setItem("productsInCart", JSON.stringify(productsInCart));
    loadCartPage(productsInCart);
}

const placeOrder = () => {
    if (!(sessionStorage.getItem("user"))) {
        window.location.href = "login.html";
    }
    else
        createOrder();
}

const createOrder = async () => {
    const orders = JSON.parse(sessionStorage.getItem("productsInCart"));
    let orderSum = 0;
    orders.forEach(p => {
        orderSum += p.price
        let prod = document.getElementById(item.id);
        let quantity = prod.querySelector('.quantity').innerHTML;
        let productId = item.id;
        let orderItem = { productId, quantity };

        orderItems.push(orderItem);
    });
    const userId = JSON.parse(sessionStorage.getItem("user")).id;
    const orderDate = new Date();
    const order = { orderDate, orderSum, userId }
    try { 
        const res = await fetch('/api/orders',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });

        if (!res.ok)
            throw new Error("Error place order")
        const created = await res.json();
        console.log(created);
    //    saveProductsInDB(created.OrderId, orderItems);
    } catch (ex) {
        alert(ex.message);
    }
}

//saveProductsInDB = async (orderId, orderItems) => {
//    orderItems.forEach(p => {
//        p = {p.qu, p.pr, orderId}
//    });
//    try {
//        const res = await fetch('/api/ordersItems',
//            {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json'
//                },
//                body: products
//            });
//        if (!res.ok)
//            throw new Error("Error save items")
//        //const created = await res.json();
//        //console.log(created);
//        saveProductsInDB();
//    } catch (ex) {
//        alert(ex.message);
//    }
//}