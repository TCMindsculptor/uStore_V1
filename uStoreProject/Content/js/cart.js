var inventory = [
    {
        id: 1,
        name: "Laptop 1",
        price: 980.00
    },
    {
        id: 2,
        name: "Laptop 2",
        price: 1100.00
    },
    {
        id: 3,
        name: "Laptop 3",
        price: 1400.00
    },
    {
        id: 4,
        name: "Smartphone 1",
        price: 600.00
    },
    {
        id: 5,
        name: "Smartphone 2",
        price: 850.00
    },
    {
        id: 6,
        name: "Smartphone 3",
        price: 1000.00
    },
    {
        id: 7,
        name: "Tablet 1",
        price: 650.00
    },
    {
        id: 8,
        name: "Tablet 2",
        price: 850.00
    },
    {
        id: 9,
        name: "Tablet 3",
        price: 1050.00
    },
    {
        id: 10,
        name: "Camera 1",
        price: 200.00
    },
    {
        id: 11,
        name: "Camera 2",
        price: 450.00
    },
    {
        id: 12,
        name: "Camera 3",
        price: 800.00
    },
    {
        id: 13,
        name: "Accessory 1",
        price: 60.00
    },
    {
        id: 14,
        name: "Accessory 2",
        price: 140.00
    },
    {
        id: 15,
        name: "Accessory 3",
        price: 200.00
    }
];

//create array to store the user's cart informaion
var cart = [];

//add items to the car -- wired to anchor tags in the HTML
function addToCart(id) {
    //if the user has not added any of the titles yet, set the qty to 1 and add the book to our array
    //Otherwise, add 1 to qty
    var invObj = inventory[id - 1];
    if (typeof invObj.qty === 'undefined') { //could check for string, etc
        invObj.qty = 1;
        cart.push(invObj); //adding an item to an existing array
    }
    else {
        invObj.qty += 1;
    }

    /*Testing Purposes Only*/
    console.clear();
    var arrayLength = cart.length;
    for (var i = 0; i < arrayLength; i++) {
        console.log(cart[i]);
    }

    //made notification for number in cart visible
    document.getElementById('cart-notification').style.display = "block";

    //get the total number of books in the cart
    var cartQty = 0;

    for (var i = 0; i < arrayLength; i++) {
        cartQty += cart[i].qty
    }

    document.getElementById('cart-notification').innerHTML = cartQty;

    document.getElementById('cart-contents').innerHTML = getCartContents();
}

function getCartContents() {
    var cartContent = "";
    var cartTotal = 0;

    for (var i = 0; i < cart.length; i++) {
        cartContent += "Name: " + cart[i].name + "<br />";
        cartContent += "Price: $" + cart[i].price + "<br />";
        cartContent += "Quantity: " + cart[i].qty + "<br />";
        cartTotal += (cart[i].price * cart[i].qty);
        cartContent += "<br />";

    }
    cartContent += "Cart Total: $" + (cartTotal * 1).toFixed(2);
    return cartContent;
}