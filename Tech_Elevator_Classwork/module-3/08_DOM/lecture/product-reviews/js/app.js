const bookName = "Cigar Parties for Dummies (and Squirrels)";
const description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
const reviews = [
  {
    reviewer: 'Malcolm Madwell',
    title: 'What a book!',
    review:
    "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language. Yes indeed, it is a book!",
    rating: 3
  },
  {
    reviewer: 'Tim Ferriss',
    title: 'Had a cigar party started in less than 4 hours.',
    review:
      "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
    rating: 4
  },
  {
    reviewer: 'Ramit Sethi',
    title: 'What every new entrepreneurs needs. A door stop.',
    review:
      "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
    rating: 1
  },
  {
    reviewer: 'Gary Vaynerchuk',
    title: 'And I thought I could write',
    review:
      "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
    rating: 3
  }
];

/**
 * Add the product name to the page title
 * Get the page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  const pageTitle = document.getElementById("page-title");
  pageTitle.querySelector("span.name").innerText = bookName; //bookName variable up top
}

/**
 * Add the product description to the page.
 */
function setProductDescription() {
  document.querySelector(".description").innerText = description; //description variable up top, too
}

/**
 * Display all of the reviews on the page.
 * Loop over the array of reviews and use some helper functions
 * to create the elements needed for the markup and add them to the DOM.
 */
function displayReviews() {
  const main = document.getElementById("main");
  reviews.forEach((reviewObject) => {
    const container = document.createElement("div");
    container.setAttribute("class", "review");
    addReviewer(container, reviewObject.reviewer);
    addRating(container, reviewObject.rating);
    addTitle(container, reviewObject.title);
    addReview(container, reviewObject.review);
    main.insertAdjacentElement("beforeend", container);
  });
}
  
/**
 * Create a new h2 element with the name of the reviewer and append it to
 * the parent element that is passed to me.
 *
 * @param {HTMLElement} parent: The element to append the reviewer to
 * @param {string} name The name of the reviewer
 */
function addReviewer(parent, theName) {
  const reviewerElement = document.createElement("h2");
  reviewerElement.innerText = theName;
  parent.appendChild(reviewerElement);
}

/**
 * Add the rating div along with a star image for the number of ratings 1-5
 * @param {HTMLElement} parent
 * @param {Number} numberOfStars
 */
function addRating(parent, numberOfStars) {
  const rating = document.createElement("div");
  rating.setAttribute("class", "rating");
  for(let i = 0; i < numberOfStars; i++) {
    const star = document.createElement("img");
    star.src = "img/star.png";
    star.setAttribute("class", "ratingStar");
    rating.appendChild(star);
  }
  parent.appendChild(rating);
}
  
/**
 * Add an h3 element along with the review title
 * @param {HTMLElement} parent
 * @param {string} title
 */
function addTitle(parent, title) {
  const h3 = document.createElement("h3");
  h3.innerText = title;
  parent.appendChild(h3);
}

/**
 * Add the product review
 * @param {HTMLElement} parent
 * @param {string} review
 */
function addReview(parent, review) {
  const reviewWords = document.createElement("p");
  reviewWords.innerText = review;
  parent.appendChild(reviewWords);
}

// set the product reviews page title
setPageTitle();
// set the product reviews page description
setProductDescription();
// display all of the product reviews on the page
displayReviews();
