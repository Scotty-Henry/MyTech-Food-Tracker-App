<template>
  <div id="home">
    <b-card-group id="home">
      <!-- <dashboard-overlay></dashboard-overlay> -->
      <b-card bg-variant="info" text-variant="white" header="Profile" class="text-center" id="profile">
        <profile id="profile" :name="this.userProfile.name" :birthdate="this.userProfile.birthdate"></profile>
      </b-card>

      <b-card id="progress">
        <progress-chart id="progress"></progress-chart>
      </b-card>

      <b-card header="Record Intake" text-variant="black" class="text-center" id="meal">
        <meal id="meal"></meal>
      </b-card>

      <b-card text-variant="black" header="Current Values" id="current">
        <current :currWeight ="this.userProfile.currWeight" :height="this.userProfile.height" :activity="this.userProfile.activityLevel" id="current"></current>
      </b-card>

      <b-card text-variant="black" header="Goal Values" id="goal">
        <goal :goalWeight ="this.userProfile.goalWeight" id="goal"></goal>
      </b-card>

      <b-card text-variant="black" header="D/W/M/LT" id="today">
        <today :nutrientsToday="arrayofDateObjects" id="today"></today>
      </b-card>>
    </b-card-group>
  </div>
</template>

<script>
import TFService from '@/TFService.js';
import Profile from '@/components/Profile';
import Meal from '@/components/Meal';
import ProgressChart from '@/components/ProgressChart';
import Current from '@/components/Current';
import Goal from '@/components/Goal';
import Today from '@/components/Today';
import History from '@/components/History';
import DashboardOverlay from '@/components/DashboardOverlay';


export default {
  name: 'home',
  components: {
    Profile,
    Meal,
    ProgressChart,
    Current,
    Goal,
    Today, 
    History, 
    // DashboardOverlay
  },
  data() {
    return {
      userProfile:{
        name: '',
        birthdate: Date,
        currWeight: '',
        goalWeight: '',
        activityLevel: '',
        height: '',
      },
      userMeals: [], 
      Today: Date,
      //use filter range to get different day's nutrition
      FilterRange: ['8/13/2019','8/14/2019'],
      Day: {
        Date: '',
        cal: '',
        carb: '',
        fat: ''
      },
      uniqueDates: [],
      arrayofDateObjects: [],
      filteredDayMeals: [],

      
    }
  },

    created()
    {
    //How you do it with Axios
    TFService.getProfileInfo().then((data) => {
      window.console.log(data);
      this.userProfile.name = data.name;
      this.userProfile.birthdate = TFService.stringtoDate(data.birthdate);
      this.userProfile.currWeight = data.currWeight;
      this.userProfile.goalWeight = data.goalWeight;
      this.userProfile.activityLevel = data.activityLevel;
      this.userProfile.height = data.height;

    })
     TFService.getMealbyUser().then((data) => {
            data.forEach((mealObj) => { 
              let meal = 
                  { 
                  date: TFService.stringtoDate(mealObj.date),
                  meal_category: mealObj.meal_category,
                  userID: mealObj.userID,
                  nutrition: {
                      cal: 0,
                      fat: 0,
                      pro: 0,
                      carb: 0
                  },
                 
                  foods: [  ], 
                  }  
                  this.isUniqeMealDate(meal);
                  mealObj.foods.forEach((food) => {
                                let foodItem = {
                                  ndbno: food.ndbno,
                                  name: food.name, 
                                  cal: food.cal,
                                  carb: food.carb,
                                  fat: food.fat,
                                  pro: food.pro,
                                  qty: food.qty,
                                  unit: food.unit,
                                  }
                                  meal.nutrition.cal += food.cal;
                                  meal.nutrition.fat += food.fat;
                                  meal.nutrition.pro += food.pro;
                                  meal.nutrition.carb += food.carb;
                                  meal.foods.push(foodItem);
                                });
                    
            this.userMeals.push(meal);      
      })
       //console.log(this.userMeals) 
    }),
TFService.getNutritionbyMealandDate().then((data) => {

    data.forEach((date) => {
      this.arrayofDateObjects.push(data)
      let DateObject = {
        date: date.Date,
        SUM_Cal: date.SUM_Cal,
        SUM_Pro: date.SUM_Pro,
        SUM_Carb: date.SUM_Carb,
        SUM_Fat: date.SUM_Fat
      }

    })

}
)










    //Get a today string
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();
    today = mm + '/' + dd + '/' + yyyy;
    this.Today = today;
   

      
    },

methods: {
      isUniqeMealDate(meal){
        if (!this.uniqueDates.includes(meal.date))
        {
          this.uniqueDates.push(meal.date)
        };
        }
      }, 
      mealsOnDay(date) {
      let filteredDayMeals = this.userMeals.filter(meal => meal.date === date);
      this.filteredDayMeals = filteredDayMeals;

    },      

    computed: {
    //filter the array of meals to today
    todayMeals() {
        return this.userMeals.filter(meal => meal.date === this.Today)
    },

    //filter array of meals based on an array of dates
    mealsForRangeofDays(){
          return this.userMeals.filter(meal => this.FilterRange.includes(meal.date));
    },

    nutritionforDay() {
      return this.todayMeals.reduce((totalNutrition, meal) => {
          totalNutrition.fat += meal.nutrition.fat;
          totalNutrition.cal += meal.nutrition.cal;
          totalNutrition.pro += meal.nutrition.pro;
          totalNutrition.carb += meal.nutrition.carb;
          return totalNutrition;
      }, {fat: 0, pro: 0, cal: 0, carb: 0});
    },
     nutrition2forDay() {
      return this.filteredDayMeals.reduce((totalNutrition, meal) => {
          totalNutrition.fat += meal.nutrition.fat;
          totalNutrition.cal += meal.nutrition.cal;
          totalNutrition.pro += meal.nutrition.pro;
          totalNutrition.carb += meal.nutrition.carb;
          return totalNutrition;
      }, {fat: 0, pro: 0, cal: 0, carb: 0});
    },
    //for each day in computed array of days 
      //created a day object {date, cal, pro, fat, carb}
      //set date to day
      //call todayMeals to return meals on day
          //call nutritionforday to return nutrtion on day
          //set day object's values
          //push day object to a day array.
    // createDateArrayObject(){
    //   this.uniqueDates.forEach(date => {
        
    //     }
    //     this.arrayofDateObjects.push(DateObject)
    //   )}
    





    // todayFat(){
    //     return this.todayMeals.reduce((acc, meal) => acc + this.getMealFat(meal), 0)
    // },

    }
}


</script>

<style>
#home {
  display: grid;
  padding: 20px;
  grid-template-areas: "profile chart chart chart"
                       "meal chart chart chart"
                       "meal current goal today";
  max-height: 75vh;
  width: auto;
  padding-left: 3%
}
#home > #profile {
  grid-area: profile;
  background-color: #5dc086;
  margin: .045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #meal {
  grid-area: meal;
  background-color: rgb(77, 135, 155);
  margin: .045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #progress {
  display: flex;
  grid-area: chart;
  background-color: whitesmoke;
  margin: .045em;
  border-radius: 2.5%;
}
#home > #current {
  grid-area: current;
  background-color: #cedee7;
  margin: .045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #goal {
  grid-area: goal;
  background-color: #cedee7;
  margin: .035em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #today {
  grid-area: today;
  background-color: #cedee7;
  margin: .045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
</style>
