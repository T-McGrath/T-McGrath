// add pageTitle
pageTitle = "My Shopping List";

// add groceries
groceries = ["milk", "eggs", "fabric softener", "gold bars", "rocket ship", "a pig", "tears of children", "wizard hat", "computer that doesn't suck", "not an iPhone"];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById("title");
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const groceryList = document.getElementById("groceries");
  groceries.forEach((itemOnList) => {
    const liItem = document.createElement("li");
    liItem.setAttribute("class", "buy-this");
    liItem.innerText = itemOnList;
    groceryList.appendChild(liItem);
  });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
  const allGroceries = document.querySelectorAll(".buy-this");
  allGroceries.forEach((oneGroceryItem) => oneGroceryItem.setAttribute("class", "completed"));
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
