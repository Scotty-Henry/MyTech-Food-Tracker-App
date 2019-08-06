<template>
  <div id="home">
    <h1>Tech Fitness App</h1>
    <profile></profile>
    <add-meal></add-meal>
    <progress-data></progress-data>
    <current></current>
    <goal></goal>
    <today></today>
  </div>
</template>

<script>
import Profile from '@/components/Profile';
import AddMeal from '@/components/AddMeal';
import ProgressData from '@/components/ProgressData';
import Current from '@/components/Current';
import Goal from '@/components/Goal';
import Today from '@/components/Today';

export default {
  name: 'home',
  components: {
    Profile,
    AddMeal,
    ProgressData,
    Current,
    Goal,
    Today    
  },
}
</script>

<style>
#home {
  display: grid;
  width: 100%;
  height: 250px;
  grid-template-areas: "profile progress progress progress"
                       "add-meal progress progress progress"
                       "add-meal current goal today"; 
}
#home > profile {
  grid-area: profile;
}
#home > add-meal {
  grid-area: add-meal;
}
#home > progress-data {
  grid-area: progress;
}
#home > current {
  grid-area: current;
}
#home > goal {
  grid-area: goal;
}
#home > today {
  grid-area: today;
}
</style>
