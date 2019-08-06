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
}
</script>

<style>
#home {
  display: grid;
  grid-template-areas: "profile chart chart chart"
                       "addmeal chart chart chart"
                       "addmeal current goal today";
}
#home > #profile {
  grid-area: profile;
}
#home > #meal {
  grid-area: addmeal;
}
#home > #progress {
  grid-area: chart;
}
#home > #current {
  grid-area: current;
}
#home > #goal {
  grid-area: goal;
}
#home > #today {
  grid-area: today;
}
</style>
