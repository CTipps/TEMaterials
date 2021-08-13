<template>
  <b-container class="reset-password-form">
    <b-form @submit.prevent="onSubmit" v-if="showform">
      <b-form-group
        id="input-group-1"
        label="New Password:"
        label-for="input-1"
        description="Password Reset Form"
      >
        <b-form-input
          id="input-1"
          v-model="password"
          type="password"
          placeholder="Enter new password"
          required
        ></b-form-input>
        <b-form-input
          id="input-2"
          v-model="confirmPassword"
          type="password"
          placeholder="Confirm new password"
          required
        ></b-form-input>
        <b-button type="submit" variant="primary">Submit</b-button>
        <router-link :to="{ name: 'login' }">
          <b-button type="reset" variant="secondary">Cancel</b-button>
        </router-link>
      </b-form-group>
    </b-form>
    <div v-else>
      <p>Your password has been reset. Please login to continue.</p>
      <router-link :to="{ name: 'login' }">
          <b-button type="reset" variant="primary">Return to Login</b-button>
        </router-link>
        </div>
  </b-container>
</template>

<script>
import UserService from "@/services/UserService.js";
export default {
  name: "reset-password",
  data() {
    return {
      showform: true,
      password: "",
      confirmPassword: "",
    };
  },
  methods: {
    comparePasswords() {
      return (this.password === this.confirmPassword);
    },
    onSubmit() {
      if (this.comparePasswords()) {
        UserService.updateUserPassword(this.$route.params.resetCode, this.password)
          .then((response) => {
            if (response.status == 200) {
              console.log(response);
              this.showform = false;
            }
          })
          .catch((error) => {
            const response = error.response;

            if (response.status === 401) {
              this.invalidCredentials = true;
            }
          });
      }
    },
  },
};
</script>

<style>
</style>