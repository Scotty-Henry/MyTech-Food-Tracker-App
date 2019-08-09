<template>
      <button type="submit" class="btn btn-primary btn-md" id="logout" @submit.prevent="logout">Logout</button>
</template>

<script>
import auth from '../auth';

export default {
  name: 'logout',
  components: {},
  data() {
    return {
      user: {

      },
      invalidCredentials: false,
    };
  },
  methods: {
    logout() {
        auth.logout();
        this.$router.push('/login');     
    },
  },
};
</script>

<style>

</style>
