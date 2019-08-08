<template>
    <div class="current-values">
        <!-- Here I am! -->
        <div> Current Weight: {{this.currWeight}}</div>
        <div> Height (in): {{this.height}}</div>
        <div> Activity Level: {{this.activity}}</div>
        <!-- <b-form @submit="onSubmit">
            <b-form-group id="input-group-1" label="Weight:" label-for="input-1">
                <b-form-input
                id="input-1"
                v-model="form.weight"
                required
                placeholder="Enter Weight"
                >
                </b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">Submit</b-button>
        </b-form>

        <b-form @submit="onSubmit">
            <b-form-group id="input-group-2" label="Calories:" label-for="input-2">
                <b-form-input
                id="input-2"
                v-model="form.calories"
                required
                placeholder="Enter Total Calories"
                >
                </b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">Submit</b-button>
        </b-form> -->
    </div>
</template>

<script>
export default {
    name: 'Current',
  props: {
    currWeight: Number,
    height: Number,
    activity: String,
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
