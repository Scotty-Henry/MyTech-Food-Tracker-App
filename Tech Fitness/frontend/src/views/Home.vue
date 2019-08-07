<template>
  <div id="home">
    <b-card-group id="home">
      <b-card bg-variant="info" text-variant="white" header="Profile" class="text-center" id="profile">
        <profile id="profile"></profile>
      </b-card>
      <b-card id="progress">
        <progress-chart id="progress"></progress-chart>
      </b-card>
      <b-card bg-variant="dark" header="Record Intake" text-variant="white" class="text-center" id="meal">
        <add-meal id="meal"></add-meal>
      </b-card>
      <b-card bg-variant="secondary" text-variant="white" header="Current Values" id="current">
        <current id="current"></current>
      </b-card>
      <b-card bg-variant="secondary" text-variant="white" header="Goal Values" id="goal">
        <goal id="goal"></goal>
      </b-card>
        <b-card bg-variant="secondary" text-variant="white" header="D/W/M/LT" id="today">
      <today id="today"></today>
        </b-card>>
    </b-card-group>
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
  background-color: lightblue;
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
  background-color: #648ca6;
  margin: .045em;
  border-radius: 5%;
}
#home > #goal {
  grid-area: goal;
  background-color: #648ca6;
  margin: .045em;
  border-radius: 5%;
}
#home > #today {
  grid-area: today;
  background-color: #648ca6;
  margin: .045em;
  border-radius: 5%;
}
</style>
