<template>
  <div id="container" class="container">
    <div id="CreateProfile" class="text-center">
      <div id="sidebar" class="h3 mb-3 font-weight-normal">
        <h1 class="h3 mb-3 font-weight-normal" id="createprofile">Edit Profile</h1>
        <b-img
          center
          img-top
          src="https://picsum.photos/125/125/?image=58"
          alt="Center image"
          id="image"
        ></b-img>
      </div>
      <form id="form" class="review-form" @submit.prevent="updateprofile">
        <label id="name" for="name">Username:</label>
        <input type="text" id="name" class="form-control" name="name" v-model="user.name" />

        <label id="bday" for="bday">Birthday:</label>
        <input type="date" id="bday" name="bday" class="form-control" v-model="user.birthdate" />

        <label id="height" for="height">Height in Inches:</label>
        <input type="number" id="height" name="height" class="form-control" v-model="user.height" />

        <label id="currWeight" for="currWeight">Current Weight:</label>
        <input
          type="number"
          id="currWeight"
          name="currWeight"
          class="form-control"
          v-model="user.currWeight"
        />

        <label id="goalWeight" for="goalWeight">Goal Weight:</label>
        <input
          type="number"
          id="goalWeight"
          name="goalWeight"
          class="form-control"
          v-model="user.goalWeight"
        />

        <label id="activity" for="activity">Activity Level:</label>
        <select
          id="activity"
          name="activity"
          class="selectpicker form-control"
          v-model="user.activityLevel"
        >
          <option disabled value>Please select Activity Level :</option>
          <option>Very Low</option>
          <option>Low</option>
          <option>Moderate</option>
          <option>High</option>
          <option>Very High</option>
        </select>
        <br />
        <button type="submit" class="btn btn-primary" id="submit">Update Profile</button>
      </form>
    </div>
  </div>
</template>

<script>
import auth from "../auth";
import TFService from "@/TFService.js";

export default {
  name: "EditProfile",
  components: {
    auth
  },
  data() {
    return {
      user: {
        name: "",
        birthdate: "",
        currWeight: "",
        goalWeight: "",
        height: "",
        activityLevel: ""
      }
    };
  },
  created() {
    //How you do it with Axios
    TFService.getProfileInfo().then(data => {
      window.console.log(data);
      this.user.name = data.name;
      this.user.birthdate = data.birthdate;
      this.user.currWeight = data.currWeight;
      this.user.goalWeight = data.goalWeight;
      this.user.activityLevel = data.activityLevel;
      this.user.height = data.height;
    });
  },
  methods: {
    updateprofile() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/updateprofile`, {
        method: "PUT",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.user)
      })
        //here can i just push them to their dashboard? I'm only expecting a 200
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
            this.$router.push("/Dashboard");
          }
        })
        .catch(err => console.error(err));
    }
  }
};
</script>

<style>
#container {
  display: flex;
  background-color: rgb(209, 222, 231);
  max-width: 65vw;
  height: auto;
  padding-top: 5%;
  border-radius: 0.75%;
  padding-bottom: 5%;
}
#name,
#bday,
#height,
#currWeight,
#goalWeight,
#activity,
#createprofile {
  padding-bottom: 0.25em;
  padding-top: 0.25em;
  color: black !important;
}
#form {
  padding-left: 4em;
  padding-top: 2.5em;
}
#sidebar {
  padding-left: 1.5em;
}
</style>