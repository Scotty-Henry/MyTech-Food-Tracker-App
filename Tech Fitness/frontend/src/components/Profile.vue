<template>
    <div class="profile">
        <router-link to="/CreateProfile">
            <b-img center img-top src="https://picsum.photos/125/125/?image=58" alt="Center image" id="image"></b-img>
        </router-link>
        <hr>
        <router-link to="/CreateProfile">
                <p id="username"> {{ this.name }} </p>
        </router-link>
                <div> Birthdate: {{this.birthdate}} </div>
        <hr>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et 
            dolore magna aliqua.  
        </p>
    </div>
</template>

<script>
export default {
name: 'profile',
  props: {
    name: String,
    birthdate: String,
  }
  
}
</script>

<style>
#image {
    border-radius: 50%;
}
#username {
    text-decoration: none;
    color: black;
}
</style>

