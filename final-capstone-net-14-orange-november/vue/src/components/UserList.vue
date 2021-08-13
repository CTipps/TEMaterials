<template>
  <b-container class="mt-3">
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope ="col">ID</th>
          <th scope="col">Username</th>
          <th scope="col">Role</th>
          <th scope="col">Email</th>
          <th scope="col">RESET CODE</th>
          <th scope="col">Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(user) in users" v-bind:key="user.userId">
          <td>{{user.userId}}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.role }}</td>
          <td>{{user.email}}</td>
          <td>{{ user.passwordResetCode }}</td>
          <td>
             <router-link :to="{name: 'role-change', params: {id: user.userId}}">
              <button class="btn btn-warning" >Change Role</button>
             </router-link>
             <button class="btn btn-danger" v-on:click="deleteUser(user.userId)" v-if="$store.state.user.role == 'admin'" >Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </b-container>
</template>

<script>
import UserService from "@/services/UserService.js";

export default {
  name: "user-list",
  computed: {
    users() {
      return this.$store.state.users;
    },
  },
  created() {
    UserService.getAllUsers().then((response) => {
      this.$store.commit("SET_USERS", response.data);
    });
  },
  methods: {
    deleteUser(userId){
      console.log(userId)
      UserService.deleteUser(userId)
      .then(() => this.$store.commit("DELETE_USER", userId))
    }
  }
};
</script>

<style>
</style>