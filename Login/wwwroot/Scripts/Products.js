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

const displayCategories = (categories) => {
    const template = document.getElementById("temp-category").content;
    const container = document.getElementById("categoryList");
    categories.forEach(category => {
        const clone = template.cloneNode(true);
        const checkbox = clone.querySelector(".opt");
        const label = clone.querySelector("label");
        const optionName = clone.querySelector(".OptionName");
/*        const count = clone.querySelector(".Count");*/
        checkbox.id = category.id;
        checkbox.value = category.id;
        label.setAttribute("for", category.id);
        optionName.textContent = category.categoryName;
        /*        count.innerHtml = category.;*/
        container.appendChild(clone);
    });
}

const getProducts = async () => {
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
    console.log(products);
}

const generateUrl = () => { }