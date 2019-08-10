<template>
  <div id="home">
    <b-card-group id="home">

      <b-card bg-variant="info" text-variant="white" header="Profile" class="text-center" id="profile">
        <profile id="profile" :name="this.name" :birthdate="this.birthdate"></profile>
      </b-card>

      <b-card id="progress">
        <progress-chart id="progress"></progress-chart>
      </b-card>

      <b-card header="Record Intake" text-variant="black" class="text-center" id="meal">
        <meal id="meal"></meal>
      </b-card>

      <b-card text-variant="black" header="Current Values" id="current">
        <current :currWeight ="this.currWeight" :height="this.height" :activity="this.activityLevel" id="current"></current>
      </b-card>

      <b-card text-variant="black" header="Goal Values" id="goal">
        <goal :goalWeight ="this.goalWeight" id="goal"></goal>
      </b-card>

      <b-card text-variant="black" header="D/W/M/LT" id="today">
        <today id="today"></today>
      </b-card>>
    </b-card-group>
  </div>
</template>

<script>
import auth from '../auth';
import TFService from '@/TFService.js';
import Profile from '@/components/Profile';
import Meal from '@/components/Meal';
import ProgressChart from '@/components/ProgressChart';
import Current from '@/components/Current';
import Goal from '@/components/Goal';
import Today from '@/components/Today';
import Logout from '@/components/Logout';

export default {
  name: 'home',
  components: {
    Profile,
    Meal,
    ProgressChart,
    Current,
    Goal,
    Today, 
    Logout   
  },
  data() {
    return {
      name: '',
      birthdate: '',
      currWeight: '',
      goalWeight: '',
      activityLevel: '',
      height: '',

    }
  },
    created()
    {
    //How you do it with Axios
    TFService.getProfileInfo().then((data) => {
      window.console.log(data);
      this.name = data.name;
      this.birthdate = data.birthdate;
      this.currWeight = data.currWeight;
      this.goalWeight = data.goalWeight;
      this.activityLevel = data.activityLevel;
      this.height = data.height;

    });
      TFService.getMealbyUser().then((data) => {
      window.console.log(data);

    });



    },
    //How you do it with fetch
    // {
    //   fetch(`${process.env.VUE_APP_REMOTE_API}/Account/dashboard`, {
    //     method: 'Get',
    //     headers: {
    //       Authorization: 'Bearer ' + auth.getToken(),
    //       Accept: 'application/json',
    //       'Content-Type': 'application/json',
    //     },
    //   })
    //     .then((response) => {
    //       if (response.ok) {
    //         window.console.log(response);
    //         return response.json();
    //       } else {
    //         this.invalidCredentials = true;
    //       }
    //     })
    //     .then((parsed_data) => {
    //                   window.console.log(parsed_data);
    //     })
    // },
  // computed: {
  //  profileData() {
  //     this.name=data.name;
  //   },
// }
}

</script>

<style>
#home {
  display: grid;
  padding: 20px;
  grid-template-areas: "profile chart chart chart"
                       "meal chart chart chart"
                       "meal current goal today";
  max-height: 75vh;
  width: auto;
  padding-left: 3%
}
#home > #profile {
  grid-area: profile;
  background-color: #5dc086;
  margin: .045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #meal {
  grid-area: meal;
  background-color: rgb(77, 135, 155);
  margin: .045em;
  border-radius: 5%;
  width: 25vw;
  height: auto;
}
#home > #progress {
  display: flex;
  grid-area: chart;
  background-color: whitesmoke;
  margin: .045em;
  border-radius: 2.5%;
}
#home > #current {
  grid-area: current;
  background-color: #cedee7;
  margin: .045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #goal {
  grid-area: goal;
  background-color: #cedee7;
  margin: .035em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
#home > #today {
  grid-area: today;
  background-color: #cedee7;
  margin: .045em;
  border-radius: 5%;
  width: 20vw;
  height: auto;
}
</style>
