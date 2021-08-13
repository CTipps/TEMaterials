<template>
  <b-container>
    <b-form class="contact-form" @submit.prevent="onSubmit" v-if="showForm">
      <h4>Send an email to {{ agency.name }} about {{ pet.name }}</h4>
      <label>Your Name</label>
      <b-form-input type="text" name="user_name" v-model="from_name" />
      <label>Email</label>
      <b-form-input type="email" name="user_email" v-model="userEmail" />
      <label>Your Message</label>
      <b-form-textarea name="message" v-model="message"></b-form-textarea>
      <b-button variant="primary" type="submit">Send</b-button>
    </b-form>
    <p class="text-center" v-else>
      Thank you. Your email has been sent to {{ toName }}.
    </p>
  </b-container>
</template>

<script>
import emailjs from "emailjs-com";

export default {
  name: "contact-agency-form",
  data() {
    return {
      userEmail: "",
      message: "",
      from_name: "",
      showForm: true,
      toEmail: "",
      toName: "",
      petName: "",
    };
  },
  props: {
      agency: Object,
      pet: Object,
  },
  created() {
    this.toEmail = this.agency.email;
    this.toName = this.agency.name;
    this.petName = this.pet.name;
  },
  methods: {
    onSubmit() {
      this.sendEmail(
        this.from_name,
        this.toName,
        this.message,
        this.toEmail,
        this.userEmail
      );
      this.showForm = false;
    },
    sendEmail(from_name, to_name, message, to_email, from_email) {
      emailjs.send(
        "service_ma4flzn",
        "template_20fs70n",
        {
          from_name: from_name,
          pet_name: this.petName,
          to_name: to_name,
          message: message,
          to_email: to_email,
          from_email: from_email,
          reply_to: from_email,
        },
        "user_zwKLQJuOYaw9GImXa9FKt"
      );
    },
  },
};
</script>

<style>
</style>