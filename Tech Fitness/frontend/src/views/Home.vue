<template>
  <div id="home">
    <b-card-group id="home">
      <b-card bg-variant="info" text-variant="white" header="Profile" class="text-center" id="profile">
        <profile id="profile"></profile>
      </b-card>
      <b-card id="progress">
        <progress-chart id="progress"></progress-chart>
      </b-card>
      <b-card header="Record Intake" text-variant="black" class="text-center" id="meal">
        <add-meal id="meal"></add-meal>
      </b-card>
      <b-card text-variant="black" header="Current Values" id="current">
        <current id="current"></current>
      </b-card>
      <b-card text-variant="black" header="Goal Values" id="goal">
        <goal id="goal"></goal>
      </b-card>
        <b-card text-variant="black" header="D/W/M/LT" id="today">
      <today id="today"></today>
        </b-card>>
    </b-card-group>
  </div>
</template>

<script>
//import auth from '../auth';
import TFService from '@/TFService.js';
import Profile from '@/components/Profile';
import AddMeal from '@/components/AddMeal';
import ProgressChart from '@/components/ProgressChart';
import Current from '@/components/Current';
import Goal from '@/components/Goal';
import Today from '@/components/Today';

export default {
  name: 'home',
  components: {
    Profile,
    AddMeal,
    ProgressChart,
    Current,
    Goal,
    Today    
  },
    created()
    {
    TFService.getProfileInfo().then((data) => {
      window.console.log(data)
    });
    }
    //How you do it 
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
}
</script>

<style>
#home {
  display: grid;
  padding: 25px;
  grid-template-areas: "profile chart chart chart"
                       "addmeal chart chart chart"
                       "addmeal current goal today";
  max-height: 75vh;
}
#home > #profile {
  grid-area: profile;
  background-color: #41a56a;
  margin: .045em;
  border-radius: 5%;
}
#home > #meal {
  grid-area: addmeal;
  background-color: rgb(77, 135, 155);
  margin: .045em;
  border-radius: 5%;
}
#home > #progress {
  grid-area: chart;
  background-color: whitesmoke;
  margin: .045em;
  border-radius: 2.5%;
}
#home > #current {
  grid-area: current;
  background-color: #bad1df;
  margin: .045em;
  border-radius: 5%;
}
#home > #goal {
  grid-area: goal;
  background-color: #bad1df;
  margin: .045em;
  border-radius: 5%;
}
#home > #today {
  grid-area: today;
  background-color: #bad1df;
  margin: .045em;
  border-radius: 5%;
}
</style>
