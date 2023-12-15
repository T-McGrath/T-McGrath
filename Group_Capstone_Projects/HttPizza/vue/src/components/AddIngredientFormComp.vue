<template>
    <div class="main">
      <div class="meat">
        <h4>Meats: </h4>
        <label>
            <p>Bacon</p>
            <input type="checkbox" name="Bacon" value="Bacon">
            <img src="../../images/Bacon.jpg" />
        </label>
        <label>
            <p>GrilledChicken</p>
            <input type="checkbox" name="meat" value="GrilledChicken">
            <img src="../../images/GrilledChicken.jpg" />
        </label>
        <label>
            <p>Ham</p>
            <input type="checkbox" name="meat" value="Ham">
            <img src="../../images/Ham.jpg" />
        </label>
        <label>
            <p>ItalianSausage</p>
            <input type="checkbox" name="meat" value="ItalianSausage">
            <img src="../../images/ItalianSausage.jpg" />
        </label>
        <label>
            <p>MeatBalls</p>
            <input type="checkbox" name="meat" value="MeatBalls">
            <img src="../../images/MeatBalls.jpg" />
        </label>
        <label>
            <p>Pepperoni</p>
            <input type="checkbox" name="meat" value="Pepperoni">
            <img src="../../images/Pepperoni.jpg" />
        </label>
      </div>
      <div class="veggie">
        <h4>Veggies: </h4>
        <label>
            <p>ArtichokeHearts</p>
            <input type="checkbox" name="veggie" value="ArtichokeHearts">
            <img src="../../images/ArtichokeHearts.jpg" />
        </label>
        <label>
            <p>Broccoli</p>
            <input type="checkbox" name="veggie" value="Broccoli">
            <img src="../../images/Broccoli.jpg" />
        </label>
        <label>
            <p>Mushrooms</p>
            <input type="checkbox" name="veggie" value="Mushroom">
            <img src="../../images/Mushroom.webp" />
        </label>
        <label>
            <p>Olives</p>
            <input type="checkbox" name="veggie" value="Olives">
            <img src="../../images/Olives.webp" />
        </label>
        <label>
            <p>Onions</p>
            <input type="checkbox" name="veggie" value="Onions">
            <img src="../../images/onions.jpg" />
        </label>
        <label>
            <p>Pineapples</p>
            <input type="checkbox" name="veggie" value="Pineapple">
            <img src="../../images/pineapple.webp" />
        </label>
        <label>
            <p>RedOnions</p>
            <input type="checkbox" name="veggie" value="RedOnion">
            <img src="../../images/RedOnions.jpg" />
        </label>
        <label>
            <p>Spinach</p>
            <input type="checkbox" name="veggie" value="Spinach">
            <img src="../../images/Spinach.jpg" />
        </label>
      </div>
      <div class="sauce">
        <h4>Sauces: </h4>
        <label>
            <p>BBQSauce</p>
            <input type="checkbox" name="sauce" value="BBQSauce">
            <img src="../../images/BBQSauce.webp" />
        </label>
        <label>
            <p>RegularSauce</p>
            <input type="checkbox" name="sauce" value="RegularSauce">
            <img src="../../images/RegularSauce.jpg" />
        </label>
        <label>
            <p>Ranch</p>
            <input type="checkbox" name="sauce" value="Ranch">
            <img src="../../images/Ranch.jpg" />
        </label>
      </div>
      <div class="cheese">

        <h4>Cheese: </h4>
        <label>
            <p>Mozzarella</p>
            <input type="checkbox" name="cheese" value="Mozzarella">
            <img src="../../images/Mozzarella.jpg" />
        </label>
        <label>
            <p>RicottaCheese</p>
            <input type="checkbox" name="cheese" value="RicottaCheese">
            <img src="../../images/RicottaCheese.jpg" />
        </label>
    </div>
</div>
</template>

<script>
export default{
};
</script>

<style scoped>
div.meat {
  margin: 5px;
  float: left;
  width: 180px;
}

div.meat:hover {
  border: 1px solid #777;
}

div.meat img {
  width: 100%;
  height: auto;
}
div.veggie {
  margin: 5px;
  float: left;
  width: 180px;
}

div.veggie:hover {
  border: 1px solid #777;
}

div.veggie img {
  width: 100%;
  height: auto;
}

div.sauce {
  margin: 5px;
  float: left;
  width: 180px;
}

div.sauce:hover {
  border: 1px solid #777;
}

div.sauce img {
  width: 100%;
  height: auto;
}
div.cheese {
  margin: 5px;
  float: left;
  width: 180px;
}

div.cheese:hover {
  border: 1px solid #777;
}

div.cheese img {
  width: 100%;
  height: auto;
}

div.desc {
  padding: 15px;
  text-align: center;
}
</style>