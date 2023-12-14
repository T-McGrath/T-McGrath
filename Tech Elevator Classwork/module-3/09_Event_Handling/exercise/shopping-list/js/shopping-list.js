let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById('title');
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ul = document.querySelector('ul');
  groceries.forEach((item) => {
    const li = document.createElement('li');
    li.innerText = item.name;
    const checkCircle = document.createElement('i');
    checkCircle.setAttribute('class', 'far fa-check-circle');
    li.appendChild(checkCircle);
    ul.appendChild(li);
  });
}

function markItemComplete(item) {
  // There HAS to be a better way to do this, right?
  if (item.getAttribute("class") !== "completed" && item.querySelector("i").getAttribute("class") !== "far fa-check-circle completed") {
    item.setAttribute("class", "completed");
    item.querySelector("i").setAttribute("class", "far fa-check-circle completed");
  }
}

function markItemIncomplete(item) {
  if (item.getAttribute("class") === "completed" && item.querySelector("i").getAttribute("class") === "far fa-check-circle completed") {
    item.removeAttribute("class");
    item.querySelector("i").setAttribute("class", "far fa-check-circle");
  }
}

function toggleCompleteButton(button) {
  const listOfItems = document.querySelectorAll("ul li");
  if(allItemsIncomplete) {
    allItemsIncomplete = false;
    button.innerText = "Mark All Incomplete";
    listOfItems.forEach(item => {
      markItemComplete(item)
    });
  }
  else {
    allItemsIncomplete = true;
    button.innerText = "Mark All Complete";
    listOfItems.forEach(item => {
      markItemIncomplete(item);
    });
  }
}

document.addEventListener("DOMContentLoaded", () => {
  setPageTitle();
  displayGroceries();

  const listOfItems = document.querySelector("ul");//querySelectorAll(".far fa-check-circle");
  listOfItems.addEventListener("click", (event) => {
    markItemComplete(event.target);
  });

  listOfItems.addEventListener("dblclick", (event) => {
    markItemIncomplete(event.target);
  });

  const completeButt = document.getElementById("toggleAll");
  completeButt.addEventListener("click", (event) => {
    toggleCompleteButton(event.target);
  });
});
