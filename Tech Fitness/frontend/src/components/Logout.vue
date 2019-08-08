<template>
  <div id="login" class="text-center">
    <form class="form-signin form-group mt-5"  @submit.prevent="logout">
      <button type="submit">Logout</button>
    </form>
  </div>
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
