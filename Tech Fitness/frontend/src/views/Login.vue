<template>
  <div id="login" class="text-center">
    <form class="form-signin form-group mt-5" id="signinform" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal" id="apptitle">MyTech Fitness Tracker</h1>
      <br />
      <h1 class="h3 mb-3 font-weight-normal" id="sign-in">Please Sign In</h1>
      <div
        id="alert"
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        id="alert"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
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
    <video-overlay></video-overlay>
    <h2 class="h3 mb-3 font-weight-normal" id="apptag">Track what moves you...</h2>
  </div>
</template>

<script>
import auth from "../auth";
import TFService from "@/TFService.js";
import VideoOverlay from "@/components/VideoOverlay";

export default {
  name: "login",
  components: {
    VideoOverlay
  },
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/login`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then(token => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, "");
            }
            auth.saveToken(token);
            TFService.getProfileInfo()
              .then(result => {
                this.$router.push("/");
              })
              .catch(this.$router.push("/CreateProfile"));
          }
        });
    }
  }
};
</script>

<style scoped>
#signinform {
  opacity: 1;
  z-index: 9999;
}
#apptitle {
  opacity: 1;
  z-index: 9999;
  color: whitesmoke !important;
  font-family: "Proxima Nova ThinT", Arial, Helvetica, sans-serif;
  font-size: 2.5em;
}
#apptag {
  opacity: 1;
  z-index: 9999;
  color: whitesmoke !important;
  font-family: "Proxima Nova ThinT", Arial, Helvetica, sans-serif;
  font-size: 1.5em;
}
#sign-in {
  color: whitesmoke !important;
}
#submit {
  margin: 0.75em;
}
#username {
  margin-top: 0.5em;
}
#password {
  margin-top: 0.5em;
}
</style>
