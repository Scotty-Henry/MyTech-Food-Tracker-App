<template>
  <div class="current-values">
    <!-- Here I am! -->
    <div>Current Weight: {{this.userProfile.currWeight}}</div>
    <div>Height (in): {{this.userProfile.height}}</div>
    <div>Activity Level: {{this.userProfile.activityLevel}}</div>
    <div>BMI: {{this.userProfile.bmi}}</div>
  </div>
</template>

<script>
export default {
  name: "Current",
  props: {
    userProfile: Object
  },

  data() {
    return {
      form: {
        weight: "",
        calories: ""
      }
    };
  }
};
</script>

<style>
</style>
