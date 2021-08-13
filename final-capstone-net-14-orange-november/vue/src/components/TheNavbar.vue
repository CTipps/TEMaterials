<template>
  <div id="navbar">
    <b-navbar toggleable="md" type="light" variant="light">
      <b-navbar-brand>
        <router-link class="navbar-brand" v-bind:to="{ name: 'home' }"
          ><img class="logo" :src="require('../assets/TransparentLogo3.png')" /></router-link
        >
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item v-if="$store.state.token != ''">
            <router-link class="nav-link" v-bind:to="{ name: 'pet-matcher' }"
              >Pet Matcher</router-link
            >
          </b-nav-item>
          <b-nav-item v-if="$store.state.token != ''">
            <router-link class="nav-link" v-bind:to="{ name: 'matches' }"
              >My Matches</router-link
            >
          </b-nav-item>
          <b-nav-item>
          <b-nav-item-dropdown v-if="$store.state.user.role == 'admin'" text="Admin">
            <b-dropdown-item >
              <router-link class="nav-link" v-bind:to="{ name: 'user-list' }">Users</router-link>
            </b-dropdown-item>
            <b-dropdown-item>
              <router-link class="nav-link" v-bind:to="{ name: 'agency-list' }">Agencies</router-link>
            </b-dropdown-item>
            <b-dropdown-item>
              <router-link class="nav-link" v-bind:to="{ name: 'pets-list' }">Pets</router-link>
            </b-dropdown-item>
          </b-nav-item-dropdown>
          </b-nav-item>

          <b-nav-item v-if="$store.state.user.role == 'agency'">
            <router-link class="nav-link" v-bind:to="{ name: 'agency' }"
              >Agency</router-link
            >
          </b-nav-item>
          <b-nav-item>
            <router-link
              class="nav-link"
              v-bind:to="{ name: 'logout' }"
              v-if="$store.state.token != ''"
              >Logout</router-link
            >
            <router-link class="nav-link" v-bind:to="{ name: 'login' }" v-else
              >Login</router-link
            >
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
export default {
  name: "the-navbar",
};
</script>

<style>
.logo {
  height: 75px;


}
</style>
