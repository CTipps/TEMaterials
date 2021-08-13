<template>
    <div>
        <router-link class="nav-link" v-bind:to="{ name: 'user-list' }">Users</router-link>
        <router-link class="nav-link" v-bind:to="{ name: 'agency-list' }">Agencies</router-link>
        <router-link class="nav-link" v-bind:to="{ name: 'pets-list' }">Pets</router-link>
    </div>
</template>

<script>
export default {
name: 'admin-navigation'
}
</script>

<style>

</style>