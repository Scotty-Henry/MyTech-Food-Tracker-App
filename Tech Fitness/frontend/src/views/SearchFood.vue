<template>
  <b-container id="search-container" class="container">
    <b-row>
      <b-col>
        <div id="search-food" class="text-center">
          <form id="foodsearchform" class="form-signin mt-1" @submit.prevent="handleSubmit">
            <h1 class="h3 mb-3 font-weight-normal">Find a food!</h1>
            <label for="name" class="sr-only" id="food-search">Food name</label>
            <input
              id="item"
              type="text"
              class="form-control"
              placeholder="Nom nom nom . . ."
              v-model="food.name"
              required
              autofocus
            />
            <b-button block type="submit" id="searchbutton" class="btn btn-success btn-md">Search!</b-button>
          </form>

          <div id="table" class="text-center">
            <b-table
              selectable
              select-mode="single"
              striped
              hover
              dark
              :items="food.results"
              :fields="fields"
              @row-selected="rowSelected"
              responsive="sm"
            ></b-table>
          </div>
        </div>
      </b-col>
      <b-col id="mealcol">
        <div id="search-food" class="text-left">
          <form id="ndbnosearchform" class="form-signin mt-1" @submit.prevent="handleNDBNO">
            <h1 class="h3 mb-3 font-weight-normal text-center">Track Food!</h1>
            <label for="meal-form-qty" class="sr-only" id="add-qty">Qty</label>
            <input
              id="meal-form-qty"
              type="text"
              class="form-control"
              placeholder="Qty."
              v-model="foodItem.qty"
              autofocus
            />
            <b-button block type="submit" id="foodbutton" class="btn btn-success btn-md">Add Food!</b-button>
          </form>

          <div>
            <b-container id="cardcontainer" class="container">
              <b-row>
                <b-col>
                  <b-card
                    id="foodcard"
                    tag="article"
                    style="max-width: 20rem;"
                    class="mb-2"
                    bg-variant="dark"
                    header="Food Item Info:"
                    text-variant="white"
                  >
                    <div>{{this.foodItem.name}}</div>
                    <br />
                    <div>My food's cals: {{this.foodItem.cal}}</div>
                    <div>My food's pro: {{this.foodItem.pro}}</div>
                    <div>My food's fat: {{this.foodItem.fat}}</div>
                    <div>My food's carbs: {{this.foodItem.carb}}</div>
                  </b-card>
                </b-col>
                <b-col>
                  <b-card
                    id="mealcard"
                    tag="article"
                    style="max-width: 20rem;"
                    class="mb-2"
                    bg-variant="dark"
                    header="Meal Info:"
                    text-variant="white"
                  >
                    <div>
                      <div>
                        My Meal:
                        <ul>
                          <li v-for="food in foodArray" v-bind:key="food.id">{{food.name}}</li>
                        </ul>
                      </div>
                    </div>
                  </b-card>
                </b-col>
              </b-row>
            </b-container>

            <form class="form-signin form-group mt-1" @submit.prevent="submitMeal">
              <label id="mealactivity" for="activity">Meal</label>
              <select
                id="activity"
                name="activity"
                class="selectpicker form-control"
                v-model="mealObj.meal_category"
              >
                <option disabled value>Select Meal</option>
                <option value="1">Breakfast</option>
                <option value="2">Lunch</option>
                <option value="3">Dinner</option>
                <option value="4">Snack - 1</option>
                <option value="5">Snack - 2</option>
              </select>
              <label id="date" for="date">Date of Meal</label>
              <input
                type="date"
                id="date"
                name="date"
                class="form-control"
                placeholder="Date"
                v-model="mealObj.date"
              />

              <b-button
                block
                type="submit"
                id="searchbutton"
                class="btn btn-success btn-md"
              >Submit Meal</b-button>
            </form>
          </div>
        </div>
        <!-- <meal id="meal" :foodArray="this.foodArray"></meal> -->
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import auth from "../auth";
import TFService from "@/TFService.js";
import Meal from "@/components/Meal";

export default {
  name: "SearchFood",
  components: {
    Meal
  },
  data() {
    return {
      mealObj: {
        foods: [],
        meal_category: "",
        date: ""
      },
      selected: "",
      foodItem: {
        ndbno: "",
        name: "",
        fat: "",
        pro: "",
        carb: "",
        cal: "",
        unit: "",
        qty: ""
      },
      foodArray: [],
      food: {
        name: "",
        results: []
      },
      fields: ["name"]
    };
  },
  methods: {
    handleSubmit() {
      TFService.getFoods(this.food.name).then(response => {
        this.food.results = response.list.item;
        console.log(response.list.item);
      });
    },

    rowSelected(items) {
      this.selected = items;
      this.foodItem = items[0];
    },

    submitMeal() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/addMeal`, {
        method: "POST",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.mealObj)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .catch(err => console.error(err));
      this.$router.push("/");
    },

    handleNDBNO() {
      TFService.getFood(this.foodItem.ndbno).then(response => {
        let currentFood = {
          ndbno: this.foodItem.ndbno,
          cal: TFService.findNutrient("Energy", response.report.food.nutrients),
          pro: TFService.findNutrient(
            "Protein",
            response.report.food.nutrients
          ),
          fat: TFService.findNutrient(
            "Total lipid (fat)",
            response.report.food.nutrients
          ),
          carb: TFService.findNutrient(
            "Carbohydrate, by difference",
            response.report.food.nutrients
          ),
          name: response.report.food.name,
          unit: response.report.food.ru,
          qty: this.foodItem.qty
        };
        this.foodItem.name = currentFood.name;
        this.foodItem.fat = currentFood.fat;
        this.foodItem.pro = currentFood.pro;
        this.foodItem.carb = currentFood.carb;
        this.foodItem.cal = currentFood.cal;
        this.mealObj.foods.push(currentFood);
        this.foodArray.push(currentFood);
      });
    }
  }
};
</script>

<style>
#search-food {
  color: whitesmoke !important;
  margin-top: 7.5%;
  justify-content: center;
}
#table {
  margin-top: 3.5%;
  max-height: 73vh;
  overflow: auto;
}
#foodsearchform {
  display: inline;
}
#ndbnosearchform {
  display: inline;
}
#foodbutton {
  display: inline;
  margin-top: 2%;
}
#searchbutton {
  display: inline;
  margin-top: 2%;
}
::-webkit-scrollbar {
  display: none;
}
#foodcard {
  margin-top: 5%;
  height: 90%;
}
#mealcard {
  margin-top: 5%;
  height: 90%;
}
</style>
