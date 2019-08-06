<template>
    <div class="profile">
        <h2>UserName</h2>
        <ul>
        <li>UserImage</li>
        <li>Stars</li>
        </ul>
        <router-link to="/CreateProfile">Edit Profile</router-link>
    </div>
</template>

<script>
export default {

}
</script>

<style>
.profile {
    display: flex;
    align-items: center;
    height: 80vh;
}    
</style>
