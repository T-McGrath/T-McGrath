<template>
    <div class="main">
        <img v-bind:src="imageUrl" />
        <div class="well-display">
    <div class="well">
        <span class="amount">{{ averageRating }}</span>
        Average Rating
    </div>

    <div class="well">
        <span class="amount">{{ numberOfOneStarReviews}}</span>
        1 Star Review{{ numberOfOneStarReviews === 1 ? '' : 's' }}
    </div>

    <div class="well">
        <span class="amount">{{numberOfTwoStarReviews}}</span>
        2 Star Review{{ numberOfTwoStarReviews === 1 ? '' : 's' }}
    </div>

    <div class="well">
        <span class="amount">{{numberOfThreeStarReviews}}</span>
        3 Star Review{{ numberOfThreeStarReviews === 1 ? '' : 's' }}
    </div>

    <div class="well">
        <span class="amount">{{numberOfFourStarReviews}}</span>
        4 Star Review{{ numberOfFourStarReviews === 1 ? '' : 's' }}
    </div>

    <div class="well">
        <span class="amount">{{numberOfFiveStarReviews}}</span>
        5 Star Review{{ numberOfFiveStarReviews === 1 ? '' : 's' }}
    </div>
</div>
        <h2>Product Reviews for {{ name }}</h2>

        <p class="description">{{ description }}</p>
        <div class="review" v-for="element in reviews" v-bind:key="element.id" v-bind:class="{ yellow: element.favorited}" >
            <h4>{{element.reviewer}}</h4>
            <div class="rating">
                <img src="../assets/star.png" v-bind:title="element.rating + ' Star Review'" v-for="n in element.rating" v-bind:key="n"/>
            </div>
            <h3> {{element.title}}</h3>
            <p>{{element.review}}</p>
            <p>Favorite? <input type="checkbox" v-model="element.favorited"/></p>
        </div>
    </div>
</template>

<script>
export default {
   data() {
    return {
        name: "Awesome Hedgehogs",
        description: 
            'A brain friendly guide to building extensible and maintainable object-oriented software.',
        imageUrl: 'data:image/png;base64,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',
        reviews: [
            {
                id: 1000,
                reviewer: 'R Perez',
                title: 'Approachable book about hedgehogs',
                review: 'I love the uncomplicated, informal narrative style. I highly recommend this text for anyone trying to understand Design Patterns in a super simple way',
                rating: 3,
                favorited: false
            },
                        {
                id: 1001,
                reviewer: 'Foxy',
                title: "I really WANT to chase hedgehogs.... but I won't",
                review: 'cute hedgehogs!!!',
                rating: 4,
                favorited: false
            }
        ]
    }
   },
   computed: {
    averageRating() {
      if (this.reviews.length === 0) {
        return 0;
      }

      // Use reduce to get the total of all the ratings
      let sum = this.reviews.reduce((currentSum, review) => {
        return currentSum + review.rating;
      }, 0);

      // Divide by the number of reviews
      return sum / this.reviews.length;
    },
    numberOfOneStarReviews() {
        const oneStarReviews = this.reviews.filter((r) => {
            return r.rating === 1;
        });        
        return oneStarReviews.length;
    },
        numberOfTwoStarReviews() {
      const twoStarReviews =  this.reviews.filter((review) => {
        return review.rating === 2;
      });
      return twoStarReviews.length;
    },
    numberOfThreeStarReviews() {
      const threeStarReviews =  this.reviews.filter((review) => {
        return review.rating === 3;
      });
      return threeStarReviews.length;
    },
    numberOfFourStarReviews() {
      const fourStarReviews =  this.reviews.filter((review) => {
        return review.rating === 4;
      });
      return fourStarReviews.length;
    },
    numberOfFiveStarReviews() {
      const fiveStarReviews =  this.reviews.filter((review) => {
        return review.rating === 5;
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
div.main div.review.favorited {
    background-color: lightyellow;
}

</style>



