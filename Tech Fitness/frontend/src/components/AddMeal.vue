<template>
    <div>
        <b-form @submit="onSubmit">
            <b-form-group id="input-group-3" label="Food:" label-for="input-3">
                <b-form-input
                id="input-3"
                v-model="form.food"
                required
                placeholder="Enter Food"
                >
                </b-form-input>
            </b-form-group>
            <b-button type="submit" variant="primary">Submit</b-button>
        </b-form>
    </div>
</template>

<script>
export default {
    data() {
            return {
                form: {
                food: ''
                },
            }
        }
    }
</script>
   
<style>

</style>
