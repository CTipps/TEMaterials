<template>
  <b-container class="forgot-email-form">
    <b-form @submit.prevent="onSubmit" @reset="onReset" v-if="showForm">
      <b-form-group
        id="input-group-1"
        label="Email address:"
        label-for="input-1"
        description="We'll never share your email with anyone else."
      >
        <b-form-input
          id="input-1"
          v-model="email"
          type="email"
          placeholder="Enter email"
          required
        ></b-form-input>
        <b-button type="submit" variant="primary">Submit</b-button>
        <router-link :to="{ name: 'login' }">
          <b-button type="reset" variant="secondary">Cancel</b-button>
        </router-link>
      </b-form-group>
    </b-form>
    <p class="text-center" v-else>
      Thank you. An email has been sent with further instructions on resetting
      your password.
    </p>
  </b-container>
</template>

<script>
import emailjs from "emailjs-com";
import UserService from "@/services/UserService.js";
export default {
  name: "forgot-password",
  data() {
    return {
      email: "",
      message: "http://localhost:8080/resetpassword/",
      from_name: "Wayward Whiskers",
      showForm: true,
      resetCode: "",
    };
  },
  methods: {
    onSubmit() {
      UserService.getUserResetCodeFromEmailAddress(this.email).then(
        (response) => {
          if (response.status == 200) {
            console.log(response);
            this.sendEmail(this.message, response.data, this.email);
          }
        }
      );

      this.showForm = false;
      
    },
    sendEmail(message, resetCode, emailAddress) {
      let newURL = message + resetCode;
      emailjs.send(
        "service_ma4flzn",
        "template_4pvo5su",
        {
          from_name: this.from_name,
          message: newURL,
          email: emailAddress,
        },
        "user_zwKLQJuOYaw9GImXa9FKt"
      );
    },
    onReset() {},
  },
};
</script>

<style>
</style>