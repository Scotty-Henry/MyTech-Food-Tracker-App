<template>
  <div id="home">
    <b-card-group id="home">

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
        <today :nutrientsToday="todayMeals" id="today"></today>
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

export default {
  name: 'home',
  components: {
    Profile,
    Meal,
    ProgressChart,
    Current,
    Goal,
    Today, 
    History  
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
      nutrientsToday: {
        cal: this.todayCals,
        pro: this.todayPro,
        fat: this.todayFat,
        carb: this.todayCarbs
      },
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
                  nutition: {
                      cal: 0,
                      fat: 0,
                      pro: 0,
                      carb: 0
                  },
                  foods: [  ], 
                  }  
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
                                  meal.nutition.cal += food.cal;
                                  meal.nutition.fat += food.fat;
                                  meal.nutition.pro += food.pro;
                                  meal.nutition.carb += food.carb;
                                  meal.foods.push(foodItem);
                                });
                    
            this.userMeals.push(meal);      
      })
       //console.log(this.userMeals) 
    })
    //Get a today string
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();
    today = mm + '/' + dd + '/' + yyyy;
    console.log(today);
    this.today = today;

      
    },
    //How you do it with fetch
    // {
    //   fetch(`${process.env.VUE_APP_REMOTE_API}/Account/dashboard`, {
    //     method: 'Get',
    //     headers: {
    //       Authorization: 'Bearer ' + auth.getToken(),
    //       Accept: 'application/json',
    //       'Content-Type': 'application/json',
    //     },
    //   })
    //     .then((response) => {
    //       if (response.ok) {
    //         window.console.log(response);
    //         return response.json();
    //       } else {
    //         this.invalidCredentials = true;
    //       }
    //     })
    //     .then((parsed_data) => {
    //                   window.console.log(parsed_data);
    //     })
    // },
  // computed: {
  //  profileData() {
  //     this.name=data.name;
  //   },
// }

methods: {
            getMealCals(meal){
                return meal.foods.reduce((acc, food) => acc+food.cal, 0)
            },
            getMealCarbs(meal){
                return meal.foods.reduce((acc, food) => acc+food.carb, 0)
            },
            getMealPro(meal){
                return meal.foods.reduce((acc, food) => acc+food.pro, 0)
            }, 
            getMealFat(meal){
                return meal.foods.reduce((acc, food) => acc+food.fat, 0)
            } 

        },
            computed: {
            //filter the array of meals to today
            todayMeals() {
                return this.userMeals.filter(meal => meal.date === this.today)
            },
            weekMeals() {
                return this.userMeals.filter(meal => meal.date === this.today)
            },

            //cals getMealCals to reduce Cals on a meal
            //Reduces all of Today's meals into Today cals
            todayCals(){
                return this.todayMeals.reduce((acc, meal) => acc + this.getMealCals(meal), 0)
            },
            todayCarbs(){
                return this.todayMeals.reduce((acc, meal) => acc + this.getMealCarbs(meal), 0)
            },
            todayPro(){
                return this.todayMeals.reduce((acc, meal) => acc + this.getMealPro(meal), 0)
            },
            todayFat(){
                return this.todayMeals.reduce((acc, meal) => acc + this.getMealFat(meal), 0)
            },
            bindtoday(){
              return {today: {cals: this.todayCals}}
            }
            

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
