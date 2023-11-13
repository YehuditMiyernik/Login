const loadProductsPage = async () => {
    const categories = await getCategories();
    displayCategories(categories);
    const products = await getProducts();
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

//const sendToFilter = (checkBox) => {
//    if (checkBox.checked) {
//        console.log(checkBox.value);
//        generateUrl(checkBox.value);
//    }
//}

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
        const res = await fetch(`api/Products`,
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
    const template = document.getElementById("temp-card").content;
/*    const ProductList = document.getElementById("ProductList").content;*/
/*    ProductList.appendChild()*/
    console.log(products);
    products.forEach(product => {
        const clone = template.cloneNode(true);
        const image = clone.querySelector("img");
        const h1 = clone.querySelector("h1");
        const price = clone.querySelector(".price");
        const description = clone.querySelector(".description");
        image.src = "./Images/" + product.prodImage;
        h1.textContent = product.prodName;
        price.textContent = product.price +" ₪";
        description.textContent = product.description;
/*        ProductList.appendChild(clone);*/
        document.body.appendChild(clone);
    });
}

const filterProducts = () => {

}

const generateUrl = (desc, minPrice, maxPrice, categoryIds) => {
    const url = "";
    if (desc)
        url += "/" + desc;
    if (minPrice)
        url += "/" + minPrice;
    if (maxPrice)
        url += "/" + maxPrice;
    //if (categoryIds)
    console.log(url);
    //getProducts(url);
}