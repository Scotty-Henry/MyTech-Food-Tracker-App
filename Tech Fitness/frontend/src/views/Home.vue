<template>
  <div id="home">
    <profile id="profile"></profile>
    <progress-chart id="progress"></progress-chart>
    <add-meal id="meal"></add-meal>
    <current id="current"></current>
    <goal id="goal"></goal>
    <today id="today"></today>
  </div>
</template>

<script>
import auth from '../auth';
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
    // {
    // TFService.getProfileInfo().then((data) => {
    //   window.console.log(data)
    // });
    // }
    {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/dashboard`, {
        method: 'Get',
        headers: {
          Authorization: 'Bearer ' + auth.getToken(),
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
      })
        .then((response) => {
          if (response.ok) {
            window.console.log(response);
          } else {
            this.invalidCredentials = true;
          }
        })
    },
}
</script>

<style>
#home {
  display: grid;
  padding: 25px;
  grid-template-areas: "profile chart chart chart"
                       "addmeal chart chart chart"
                       "addmeal current goal today";
}
#home > #profile {
  grid-area: profile;
  background-color: #648ca6;
}
#home > #meal {
  grid-area: addmeal;
  background-color: #394263;
}
#home > #progress {
  grid-area: chart;
  background-color: #8fd4d9;
}
#home > #current {
  grid-area: current;
  background-color: #648ca6;
}
#home > #goal {
  grid-area: goal;
  background-color: #648ca6;
}
#home > #today {
  grid-area: today;
  background-color: #648ca6;
}
</style>
