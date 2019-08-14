<template>
  <div id="login" class="text-center">
    <form class="form-signin form-group mt-5" id='signinform'  @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal" id="sign-in">Please Sign In</h1>
        <div id ="alert" class="alert alert-danger" role="alert" v-if="invalidCredentials">
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
    <video-overlay></video-overlay>
    <!-- <div class="video-shuffle can-be-moved" style="height: 529px; width: 100%; position: fixed; top: 0px;">
        <div class="story-video-overlay"></div>
        <video loop="loop" autoplay="autoplay" poster="https://static0.fitbit.com/simple.b-cssdisabled-jpg.h96a0cd6e3468e7d6c0a88055d30c496b.pack?items=%2Fcontent%2Fassets%2Fwhy%2Fimages%2Fintro_01.jpg" style="width: 100%; margin-left: 0px;">
            <source src="http://cache.fitbit.com/media/us/story/fitbit4.mp4" type="video/mp4">
            <source src="http://cache.fitbit.com/media/us/story/fitbit5.webm" type="video/webm">
        </video>
    </div> -->
  </div> 
</template>

<script>
import auth from '../auth';
import TFService from "@/TFService.js";
import VideoOverlay from '@/components/VideoOverlay';

export default {
  name: 'login',
  components: {
    VideoOverlay
  },
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
            this.$router.push("/CreateProfile");
          }
        })

    },
  },
};
</script>

<style scoped>
#signinform {
  opacity: 1;
  /* -webkit-transform: translateZ(0) translateX(-50%);
  -ms-transform: translateZ(0) translateX(-50%);
  transform: translateZ(0) translateX(-50%); */
  z-index: 9999;
}
#sign-in {
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

</style>
