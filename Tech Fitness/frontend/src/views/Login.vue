<template>
  <div id="login" class="text-center">
    <form class="form-signin form-group mt-5"  @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal" id="sign-in">Please Sign In</h1>
        <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
          Invalid username and password!
        </div>
        <div class="alert alert-success" id="alert" role="alert" v-if="this.$route.query.registration">
          Thank you for registering, please sign in.
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
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
      <button type="submit" class="btn btn-primary" id="submit">Sign in</button>
    </form>
  </div>
</template>

<script>
import auth from '../auth';

export default {
  name: 'login',
  components: {},
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/login`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then((token) => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, '');
            }
            auth.saveToken(token);
            this.$router.push('/CreateProfile');
          }
        })
        .catch((err) => console.error(err));
    },
  },
};
</script>

<style scoped>
#sign-in {
  color: whitesmoke !important;
}
#submit {
  margin: .75em;
}
#username {
  margin: .5em;
}
#password {
  margin: .5em;
}

</style>
