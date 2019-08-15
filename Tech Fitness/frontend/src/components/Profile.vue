<template>
    <div class="profile">
        <router-link to="/EditProfile">
            <b-img center img-top src="https://picsum.photos/125/125/?image=58" alt="Center image" id="image"></b-img>
        </router-link>
        <hr>
        <router-link to="/EditProfile">
                <p id="username"> {{ name }} </p>
        </router-link>
                <div> Birthdate: {{birthdate}} </div>
        <hr>
        <p>
            “The Pessimist Sees Difficulty In Every Opportunity. The Optimist Sees Opportunity In Every Difficulty.” – Winston Churchill
        </p>
    </div>
</template>

<script>
export default {
name: 'profile',
  props: {
    name: String,
    birthdate: '',
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

