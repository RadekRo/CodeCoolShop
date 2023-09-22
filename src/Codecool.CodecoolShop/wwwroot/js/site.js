// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function decrementQuantity(productId) {
    var quantitySpan = document.getElementById('quantity_' + productId);
    var currentQuantity = parseInt(quantitySpan.innerText);

    if (currentQuantity > 1) {
        var newQuantity = currentQuantity - 1;
        quantitySpan.innerText = newQuantity;
    }
}

function incrementQuantity(productId) {
    var quantitySpan = document.getElementById('quantity_' + productId);
    var currentQuantity = parseInt(quantitySpan.innerText);

    var newQuantity = currentQuantity + 1;
    quantitySpan.innerText = newQuantity;
}

function toggleDescription(productId) {
    var shortDescription = document.getElementById(`description${productId}`);
    var fullDescription = document.getElementById(`fullDescription${productId}`);
    var buttHide = document.getElementById(`niceButt${productId}`);

    shortDescription.style.display = "none";
    fullDescription.style.display = "inline";
    buttHide.style.display = "none";
}