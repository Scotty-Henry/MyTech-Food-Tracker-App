<template>
    <div class="current-values">
        <!-- Here I am! -->
        <div> Goal Weight: {{this.userProfile.goalWeight}}</div>
        <div> BMI: {{this.userProfile.goalbmi}}</div>        
    </div>
</template>

<script>
export default {
     name: 'Goal',
  props: {
    userProfile: Object
  },
    data() {
            return {
               
            }
        }
    }
</script>

<style>

</style>
