<template>
  <div id="register" class="text-center">
    <form class="form-register form-group mt-5" id="formregister" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal" id="create">Create Account</h1>
      <video-overlay></video-overlay>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        There were problems registering this user.
      </div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <router-link :to="{ name: 'login' }">Have an account?</router-link>

        <button type="submit" id="submit" class="btn btn-primary">
          Create Account
        </button>
    </form>
    <video-overlay></video-overlay>
  </div>
</template>

<script>
import VideoOverlay from '@/components/VideoOverlay';

export default {
  name: 'register',
  components: {
    VideoOverlay
  },
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
    };
  },
  methods: {
    register() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/register`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/login', query: { registration: 'success' } });
          } else {
            this.registrationErrors = true;
          }
        })
        .then((err) => console.error(err));
    },
  },
};
</script>

<style scoped>
#formregister {
  opacity: 1;
  z-index: 9999;
}
#create {
  color: whitesmoke !important;
}
#submit {
  margin: .75em;
}
#username {
  margin-top: .5em;
}
#password {
  margin-top: .5em;
}
#confirmPassword {
  margin-top: .5em;
}
</style>
