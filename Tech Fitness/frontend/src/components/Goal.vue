<template>
    <div class="current-values">
        <!-- Here I am! -->
        <div> Goal Weight: {{this.goalWeight}}</div>
        
    </div>
</template>

<script>
export default {
     name: 'Goal',
  props: {
    goalWeight: Number,
  },
    data() {
            return {
                form: {
                weight: '',
                calories: '',
                },
            }
        }
    }
</script>

<style>

</style>
