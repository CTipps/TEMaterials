<template>
  <b-container>
  <div class="form-group">
    <form v-on:submit.prevent="onSubmit" >
        <h3>Please Select A Role For "{{editedUser.username}}"</h3>
  <select class="form-control" @change="changeSelectedRole($event)">
    <option value="" selected disabled>Choose</option>
    <option v-for="role in roles" :value="role.id" :key="role.id">{{ role.name }}</option>
  </select>
  <br><br>
  <p><span>Selected role: {{ selectedRole  }}</span></p>
  <br />
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click="returnToUsers"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
  </b-container>
</template>

<script>
import UserService from '@/services/UserService.js'
export default {
name: 'role-change',
data() {
    return {
      editedUser: {},
      roles: [
        {name: "user", id: 1},
        {name: "agency",  id: 2},
        {name: "admin", id: 3}
      ],
      selectedRole: null
    };
  },

  
  created(){
    this.editedUser = this.$store.state.users.find(user => user.userId === this.$route.params.id);
  },

  methods: {
    changeSelectedRole(event) {
      this.selectedRole = event.target.options[event.target.options.selectedIndex].text
    },
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedUser.role = this.selectedRole;
      this.$store.commit("UPDATE_USER_ROLE", this.editedUser);

      UserService.updateUserRole(this.editedUser)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.go({ name: "user-list" });
        })
        .catch((error) => {
         
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });

      this.resetForm();
      this.returnToUsers();
    },

    resetForm() {
      this.editedUser = {};
    },

    returnToUsers() {
      this.$router.push({name: "user-list" });
    }
  },
}
</script>

<style>

</style>