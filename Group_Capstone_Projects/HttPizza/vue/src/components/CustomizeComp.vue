<template>
<div class="main">
    <div>
        <button @click="addToCart" class="addToCart">Add to Cart</button>
        <p v-show="addedToCart">Item added to cart!</p>
    </div>
    <div class="gallery">
        <img src="../../images/ThinCrust.jpg" />
        <h3>Sizes:</h3>
        <ul id="sizes">
            <li v-for="size in Sizes" v-bind:key="size.sizeId">
                <input type="radio" v-bind:value="size"  v-model="selectedSize"/>
                {{ size.sizeName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/Crust.jpg" />
        <h3>{{CrustFilter[0].ingredientType}}s:</h3>
        <ul id="crusts">
            <li v-for="crust in CrustFilter" v-bind:key="crust.ingredientId">
                <input type="radio" v-bind:value="crust" v-model="selectedCrust"/>
                {{ crust.ingredientName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/RegularSauce.jpg" />
        <h3>{{SauceFilter[0].ingredientType}}s:</h3>
        <ul id="sauces">
            <li v-for="sauce in SauceFilter" v-bind:key="sauce.ingredientId">
                <input type="checkbox" v-bind:value="sauce" v-model="selectedIngredients"/>
                {{ sauce.ingredientName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/Mozzarella.jpg" />
        <h3>{{CheeseFilter[0].ingredientType}}s:</h3>
        <ul id="cheeses">
            <li v-for="cheese in CheeseFilter" v-bind:key="cheese.ingredientId">
                <input type="checkbox" v-bind:value="cheese" v-model="selectedIngredients"/>
                {{ cheese.ingredientName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/ItalianSausage.jpg" />
        <h3>{{MeatFilter[0].ingredientType}}s:</h3>
        <ul id="meats">
            <li v-for="meat in MeatFilter" v-bind:key="meat.ingredientId">
                <input type="checkbox" v-bind:value="meat" v-model="selectedIngredients"/>
                {{ meat.ingredientName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/RedOnions.jpg" />
        <h3>{{VeggieFilter[0].ingredientType}}s:</h3>
        <ul id="veggies">
            <li v-for="veggie in VeggieFilter" v-bind:key="veggie.ingredientId">
                <input type="checkbox" v-bind:value="veggie" v-model="selectedIngredients"/>
                {{ veggie.ingredientName }}
            </li>
        </ul>
    </div>
    <div class="gallery">
        <img src="../../images/pineapple.webp" />
        <h3>{{PremiumFilter[0].ingredientType}}:</h3>
        <ul id="premium">
            <li v-for="prem in PremiumFilter" v-bind:key="prem.ingredientId">
                <input type="checkbox" v-bind:value="prem" v-model="selectedIngredients"/>
                {{ prem.ingredientName }}
            </li>
        </ul>
    </div>
</div>
    
</template>

<script>
import CustomerService from '../services/CustomerService';
import OrderService from '../services/OrderService';
import ORSService from '../services/ORSService';
import RIService from '../services/RIService'
import IngredientService from '../services/IngredientService';

export default{
    data(){
        return{
            addedToCart: false,
            selectedIngredients: [],
            selectedSize: {
                sizeId: 2,
                sizeName: 'Kilobyte',
                isAvailable: true
            }, // Make the default size Medium in case the customer forgets to pick one.
            selectedCrust: {},
            newOrder: {
                customerId: null,
                orderDateTime: new Date(),
                orderStatus: "Pending",
                isDelivery: true,
                totalPrice: 15.00
            },
            newOrderRecipeSize: {},
            newRecipeIngredient: {}
        }
    },
    computed:{
        CrustFilter() {
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Crust' && ingredient.isAvailable});
        },
        SauceFilter(){
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Sauce' && ingredient.isAvailable});
        },
        CheeseFilter(){
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Cheese' && ingredient.isAvailable});
        },
        MeatFilter() {
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Meat' && ingredient.isAvailable});
        },
        VeggieFilter() {
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Vegetable' && ingredient.isAvailable});
        },
        PremiumFilter() {
            return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Premium' && ingredient.isAvailable});
        },
        Sizes(){
            return this.allSizes;
        }
    },
    props: {
        allIngredients: {
            type: Array,
            required: true
        },
        allSizes: {
            type: Array,
            required: true
        },
    },
    created() {
        // Go into the store, grab the saved specialty (recipe) from customer Specialty Pizza page,
        // get the ingredients from that recipe and save them in the selectedIngredients list.
        // If no special has been selected, make selectedIngredients an empty list by default (see data section above).
        if (Object.keys(this.$store.state.selectedSpecialtyRecipe).length > 0) {
            IngredientService.getIngredientsByRecipeId(this.$store.state.selectedSpecialtyRecipe.recipeId).then(response => {
                this.selectedCrust = response.data.filter(ing => {return ing.ingredientType === 'Crust'});
                this.selectedCrust = this.selectedCrust[0]; // Don't want selectedCrust to be an array...arrays don't play nice when bound to radio inputs
                this.selectedIngredients = response.data.filter(ing => {return ing.ingredientType !== 'Crust'});
            });
        }
    },
    methods: {
    addToCart() {
        this.selectedIngredients.push(this.selectedCrust);
        CustomerService.getCustomerByUserId(this.$store.state.user.userId).then(response => {
            this.newOrder.customerId = response.data.customerId

            OrderService.createOrder(this.newOrder)
                .then(response => {
                    this.newOrder = response.data;

                    this.newOrderRecipeSize = {
                        orderId: this.newOrder.orderId,
                        recipeId: 6,
                        sizeId: this.selectedSize.sizeId
                    }
                    ORSService.linkRecipeOrderSize(this.newOrderRecipeSize)
                        .then(response => {
                            this.newOrderRecipeSize = response.data;

                            this.selectedIngredients.forEach(ingredient => {
                                if (ingredient.ingredientId != 6){
                                this.newRecipeIngredient = {
                                    recipeId: this.newOrderRecipeSize.recipeId,
                                    ingredientId: ingredient.ingredientId
                                }}
                                if(ingredient.ingredientId != 6){
                                RIService.linkRecipeIngredient(this.newRecipeIngredient)
                                    .then(response => {
                                        this.newRecipeIngredient = response.data;

                                        this.addedToCart = true;
                                        this.$router.push({name: "cart"});
                                    })}
                            })
                        })
                })
        });
        }
    }
}
</script>

<style scoped>
div.gallery {
  margin: 5px;
  float: left;
  width: 180px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

div.gallery:hover {
  border: 1px solid #777;
}

div.gallery img {
      width:  165px;
      height: 165px;
      border-radius: 10px;
      border: 5px solid beige;
      box-shadow: 0 10px 16px rgba(0, 0, 0, 50);
  }
div.desc {
  padding: 15px;
  text-align: center;
}
li{
  list-style-type: none;
  
}
</style>