<template>
  <div id="home">
    <b-card-group id="home">
      
      <b-card bg-variant="info" text-variant="white" header="Profile" class="text-center" id="profile">
        <profile id="profile" :name="this.userProfile.name" :birthdate="this.userProfile.birthdate"></profile>
      </b-card>

      <b-card id="progress">
        <progress-chart :Datedata="arrayofDateObjects" id="progress"></progress-chart>
      </b-card>

      <b-card header="Record Intake" text-variant="white" class="text-center" id="meal">
        <meal id="meal"></meal>
      </b-card>

      <b-card text-variant="black" header="Current Values" id="current">
        <current :userProfile="userProfile" id="current"></current>
      </b-card>

      <b-card text-variant="black" header="Goal Values" id="goal">
        <goal :userProfile="userProfile" id="goal"></goal>
      </b-card>

      <b-card text-variant="black" :header="this.Today" class="text-left" id="today" align="center">
        <!-- <today :nutrientsToday="arrayofDateObjects" id="today"></today> -->
        <bar-chart
          :NutritionOnDay="nutritionforDay"
          :goalCarb="userProfile.goalCarb"
          :goalFat="userProfile.goalFat"
          :goalPro="userProfile.goalPro"
          id="barchart"
        ></bar-chart>
      </b-card>>
    </b-card-group>
  </div>
</template>

<script>
import TFService from "@/TFService.js";
import Profile from "@/components/Profile";
import Meal from "@/components/Meal";
import ProgressChart from "@/components/ProgressChart";
import Current from "@/components/Current";
import Goal from "@/components/Goal";
// import Today from "@/components/Today";
import BarChart from "@/components/BarChart";

export default {
  name: "home",
  components: {
    Profile,
    Meal,
    ProgressChart,
    Current,
    Goal,
    // Today,
    BarChart
  },
  data() {
    return {
      userProfile: {
        name: "",
        birthdate: Date,
        currWeight: "",
        goalWeight: "",
        activityLevel: "",
        height: "",
        bmi: "",
        goalbmi: "",
        TDEE: "",
        goalCarb: "",
        goalFat: "",
        goalPro: ""
      },
      userMeals: [],
      Today: Date,
      //use filter range to get different day's nutrition
      FilterRange: ["8/13/2019", "8/14/2019"],
      Day: {
        Date: "",
        cal: "",
        carb: "",
        fat: ""
      },
      uniqueDates: [],
      //this below arrofDate is important right now
      arrayofDateObjects: [],
      filteredDayMeals: []
    };
  },

  created() {
    //How you do it with Axios
    TFService.getProfileInfo().then(data => {
      window.console.log(data);
      this.userProfile.name = data.name;
      this.userProfile.birthdate = TFService.stringtoDate(data.birthdate);
      this.userProfile.currWeight = data.currWeight;
      this.userProfile.goalWeight = data.goalWeight;
      this.userProfile.activityLevel = data.activityLevel;
      this.userProfile.height = data.height;
      this.userProfile.bmi = (
        703 *
        (data.currWeight / (data.height * data.height))
      ).toFixed(2);
      this.userProfile.goalbmi = (
        703 *
        (data.goalWeight / (data.height * data.height))
      ).toFixed(2);
      this.userProfile.TDEE = this.calulcateTDEE(data);
      this.userProfile.goalCarb = this.calculateMacrosCarb(
        this.userProfile.TDEE
      );
      this.userProfile.goalPro = this.calculateMacrosPro(this.userProfile.TDEE);
      this.userProfile.goalFat = this.calculateMacrosFat(this.userProfile.TDEE);
    }),
      TFService.getNutritionbyMealandDate().then(data => {
       let arraytobebuilt = [];
        data.forEach(element => {
          let dateObject = {
          date: TFService.stringtoDate(element.date),
          suM_Cal: element.suM_Cal,
          suM_Carb: element.suM_Carb,
          suM_Fat: element.suM_Fat,
          suM_Pro: element.suM_Pro
      };
      arraytobebuilt.push(dateObject);
    });
    this.arrayofDateObjects = arraytobebuilt;
      }),
    TFService.getMealbyUser().then(data => {
      data.forEach(mealObj => {
        let meal = {
          date: TFService.stringtoDate(mealObj.date),
          meal_category: mealObj.meal_category,
          userID: mealObj.userID,
          nutrition: {
            cal: 0,
            fat: 0,
            pro: 0,
            carb: 0
          },
          foods: []
        };
        this.isUniqeMealDate(meal);
            mealObj.foods.forEach(food => {
              let foodItem = {
                ndbno: food.ndbno,
                name: food.name,
                cal: food.cal,
                carb: food.carb,
                fat: food.fat,
                pro: food.pro,
                qty: food.qty,
                unit: food.unit
              };
              meal.nutrition.cal += food.cal;
              meal.nutrition.fat += food.fat;
              meal.nutrition.pro += food.pro;
              meal.nutrition.carb += food.carb;
              meal.foods.push(foodItem);
            });
          this.userMeals.push(meal);
      });
    });
 

    //Get a today string
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, "0");
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();
    today = mm + "/" + dd + "/" + yyyy;
    this.Today = today;
  },

  methods: {
    calulcateTDEE(data) {
      let part1 = (10 * data.currWeight) / 2.2046;
      let part2 = data.height * 2.54 * 6.25;
      let birthdate = new Date(data.birthdate);
      let today = new Date(this.Today);
      let age = today.getFullYear() - birthdate.getFullYear();
      let part3 = 5 * age;
      let result = part1 + part2 - part3 + 5;
      if (this.userProfile.activityLevel == "Moderate") {
        result *= 1.55;
      } else if (this.userProfile.activityLevel == "Low") {
        result *= 1.375;
      } else if (this.userProfile.activityLevel == "Very Low") {
        result *= 1.2;
      } else if (this.userProfile.activityLevel == "High") {
        result *= 1.725;
      } else if (this.userProfile.activityLevel == "Very High") {
        result *= 1.9;
      }
      return result;
    },
    calculateMacrosCarb(TDEE) {
      let carbCals = TDEE * 0.5;
      let macroGrams = {
        carbGrams: (carbCals / 4).toFixed(0)
      };
      return macroGrams;
    },
    calculateMacrosPro(TDEE) {
      let proCals = TDEE * 0.25;
      let macroGrams = {
        proGrams: (proCals / 4).toFixed(0)
      };
      return macroGrams;
    },
    calculateMacrosFat(TDEE) {
      let fatCals = TDEE * 0.25;
      let macroGrams = {
        fatGrams: (fatCals / 9).toFixed(0)
      };
      return macroGrams;
    },
    isUniqeMealDate(meal) {
      if (!this.uniqueDates.includes(meal.date)) {
        this.uniqueDates.push(meal.date);
      }
    },
    mealsOnDay(date) {
      let filteredDayMeals = this.userMeals.filter(meal => meal.date === date);
      this.filteredDayMeals = filteredDayMeals;
  }
  },

  computed: {
    //filter the array of meals to today
    todayMeals() {
      return this.userMeals.filter(meal => meal.date === this.Today);
    },

    //filter array of meals based on an array of dates
    mealsForRangeofDays() {
      return this.userMeals.filter(meal =>
        this.FilterRange.includes(meal.date)
      );
    },

    nutritionforDay() {
      return this.todayMeals.reduce(
        (totalNutrition, meal) => {
          totalNutrition.fat += meal.nutrition.fat;
          totalNutrition.cal += meal.nutrition.cal;
          totalNutrition.pro += meal.nutrition.pro;
          totalNutrition.carb += meal.nutrition.carb;
          return totalNutrition;
        },
        { fat: 0, pro: 0, cal: 0, carb: 0 }
      );
    }
  }
};
</script>

<style>
#home {
  display: grid;
  padding: 20px;
  grid-template-areas:
    "profile chart chart chart"
    "meal chart chart chart"
    "meal current goal today";
  max-height: 75vh;
  width: auto;
  padding-left: 3%;
}
#home > #profile {
  grid-area: profile;
  background-color: #5dc086;
  margin: 0.045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #meal {
  grid-area: meal;
  background-color: rgb(77, 135, 155);
  margin: 0.045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #progress {
  display: flex;
  grid-area: chart;
  background-color: whitesmoke;
  margin: 0.045em;
  border-radius: 2.5%;
}
#home > #current {
  grid-area: current;
  background-color: #cedee7;
  margin: 0.045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #goal {
  grid-area: goal;
  background-color: #cedee7;
  margin: 0.035em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #today {
  grid-area: today;
  display: flex;
  background-color: #cedee7;
  margin: 0.045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
</style>
