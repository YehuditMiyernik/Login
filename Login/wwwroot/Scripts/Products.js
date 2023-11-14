const loadProductsPage = async () => {
    const categories = await getCategories();
    displayCategories(categories);
    const products = await getProducts("");
    displayProducts(products);
}

const getCategories = async () => {
    try {
        const res = await fetch(`/api/categories`,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });
        if (!res.ok)
            throw new Error("No category found")
        const categories = await res.json();
        return categories;
    } catch (ex) {
        alert(ex.message);
    }
}

const displayCategories = (categories) => {
    const template = document.getElementById("temp-category").content;
    const container = document.getElementById("categoryList");
    categories.forEach(category => {
        const clone = template.cloneNode(true);
        const checkbox = clone.querySelector(".opt");
        const label = clone.querySelector("label");
        const optionName = clone.querySelector(".OptionName");
        checkbox.id = category.id;
        checkbox.value = category.id;
        label.setAttribute("for", category.id);
        optionName.textContent = category.categoryName;
        container.appendChild(clone);
    });
}

const getProducts = async (url) => {
    try {
        const res = await fetch('api/Products'+url,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });
        if (!res.ok)
            throw new Error("No product found");
        const products = await res.json();
        return products;
    } catch (ex) {
        alert(ex.message);
    }
}

const displayProducts = (products) => {
    let min = 1000000;
    let max = 0;
    const template = document.getElementById("temp-card").content;
    const ProductList = document.getElementById("ProductList");
    ProductList.replaceChildren();
    products.forEach(product => {
        const clone = template.cloneNode(true);
        const image = clone.querySelector("img");
        const h1 = clone.querySelector("h1");
        const price = clone.querySelector(".price");
        const description = clone.querySelector(".description");
        image.src = "./Images/" + product.prodImage;
        h1.textContent = product.prodName;
        price.textContent = product.price + " ₪";
        description.textContent = product.description;
        ProductList.appendChild(clone);
        if (product.price > max)
            max = product.price;
        else
            if (product.price < min)
                min = product.price;
    });
    const minPrice = document.getElementById("minPrice");
    minPrice.placeholder = min;
    const maxPrice = document.getElementById("maxPrice");
    maxPrice.placeholder = max;
    const counter = document.getElementById("counter");
    counter.innerHTML = products.length;
}

const filterProducts = async () => {
    const checkboxArray = document.getElementsByClassName("opt");
    const desc = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    let url = "?desc=" + desc + "&minPrice=" + minPrice + "&maxPrice=" + maxPrice;

    for (let i = 0; i < checkboxArray.length; i++) {
        if (checkboxArray[i].checked) {
            url += "&categoryIds=" + checkboxArray[i].id;
        }
    }
    const products = await getProducts(url);
    console.log(products);
    displayProducts(products);
}