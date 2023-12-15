<template>
    <div class="main">
        <div class="well-display">
            <div class="well">
                <span class="amount">{{ averageRating }}</span>
                Average Rating
            </div>

            <div class="well">
                <span class="amount">{{ numberOfOneStarReviews }}</span>
                1 Star Review{{ numberOfOneStarReviews === 1 ? "" : "s" }}
            </div>

            <div class="well">
                <span class="amount">{{ numberOfTwoStarReviews }}</span>
                2 Star Review{{ numberOfTwoStarReviews === 1 ? "" : "s" }}
            </div>

            <div class="well">
                <span class="amount">{{ numberOfThreeStarReviews }}</span>
                3 Star Review{{ numberOfThreeStarReviews === 1 ? "" : "s" }}
            </div>

            <div class="well">
                <span class="amount">{{ numberOfFourStarReviews }}</span>
                4 Star Review{{ numberOfFourStarReviews === 1 ? "" : "s" }}
            </div>

            <div class="well">
                <span class="amount">{{ numberOfFiveStarReviews }}</span>
                5 Star Review{{ numberOfFiveStarReviews === 1 ? "" : "s" }}
            </div>
        </div>

        <h2>Product Reviews for {{ name }}</h2>

        <p class="description">{{ description }}</p>
        <div class="review" v-for="element in reviews" v-bind:key="element.id" v-bind:class="{yellow: element.favorited}">
            <h4>{{ element.reviewer }}</h4>
            <div class="rating">
                <img src="../assets/star.png" v-bind:title="element.rating + ' Star Review'" v-for="numStars in element.rating" v-bind:key="numStars"/>
            </div>
            <h3>{{ element.title }}</h3>
            <p>{{ element.review }}</p>
            <p>Favorite? <input type="checkbox" v-model="element.favorited"/></p>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            name: "THIS IS A BOOK TITLE??????",
            description: "I'm describing this book!",
            reviews: [
                {
                    id: 1000,
                    reviewer: "Harry Buddidges",
                    title: "This is a Book!",
                    review: "I like to review things because typing is a fun activity in life.",
                    rating: 2,
                    favorited: false
                },
                {
                    id: 1001,
                    reviewer: "Hobbes & Mozzarella",
                    title: "Meow",
                    review: "Meow meow meow MEOW meow meeeeeeoooooowwww!",
                    rating: 5,
                    favorited: false
                }
            ]
        }
    },
    computed: {
        averageRating() {
            if(this.reviews.length === 0) {
                return 0;
            }

            let sum = this.reviews.reduce((currentSum, review) => {
                return currentSum + review.rating;
            }, 0);

            return (sum / this.reviews.length).toFixed(2);
        },
        numberOfOneStarReviews() {
            const oneStarReviews = this.reviews.filter((rev) => {
                return rev.rating === 1;
            });
            return oneStarReviews.length;
        },
        numberOfTwoStarReviews() {
            const twoStarReviews = this.reviews.filter((rev) => {
                return rev.rating === 2;
            });
            return twoStarReviews.length;
        },
        numberOfThreeStarReviews() {
            const threeStarReviews = this.reviews.filter((rev) => {
                return rev.rating === 3;
            });
            return threeStarReviews.length;
        },
        numberOfFourStarReviews() {
            const fourStarReviews = this.reviews.filter((rev) => {
                return rev.rating === 4;
            });
            return fourStarReviews.length;
        },
        numberOfFiveStarReviews() {
            const fiveStarReviews = this.reviews.filter((rev) => {
                return rev.rating === 5;
            });
            return fiveStarReviews.length;
        }
    }
}
</script>

<style scoped>
div.main {
    margin: 1rem 0;
}

.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}

.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  padding: 0.25rem;
}
.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

.yellow {
  background-color: lightyellow;
}

.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

.rating img {
  height: 100%;
}

.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}
.review p {
  margin: 20px;
}

.review h3 {
  display: inline-block;
}

.review h4 {
  font-size: 1rem;
}


</style>