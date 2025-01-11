const quantityDetail = document.getElementById("quantity_detail");
const increaseQuantity = document.getElementById("increaseButton");
const decreased = document.getElementById("decreasedButton");

increaseQuantity.addEventListener("click", () => {
  let quantity = quantityDetail.value;
  console.log(quantity);
  
  if (quantity > 1) {
    quantity -= 1;
    quantityDetail.value = quantity;
  }
});
decreased.addEventListener("click", () => {
  let quantity = quantityDetail.value;
  quantity = Number(quantity)
    quantity += 1;
    quantityDetail.value = quantity;
  }
);
