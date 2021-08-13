<template>
  <div class="container">
    <form v-on:submit.prevent="onSubmit">
      <div class="form-group">
        <label for="name">Agency Name </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="editedAgency.name"
        />
      </div>
      <div class="form-group">
        <label for="street">Street Address </label>
        <input
          required
          type="text"
          id="street"
          name="street"
          class="form-control"
          v-model="editedAgency.street"
        />
      </div>

      <div class="form-group">
        <label for="city">City </label>
        <input
          required
          type="text"
          id="city"
          name="city"
          class="form-control"
          v-model.number="editedAgency.city"
        />
      </div>

      <div class="form-group">
        <label for="state">State </label>
        <input
          required
          type="text"
          id="state"
          name="state"
          class="form-control"
          v-model="editedAgency.state"
        />
      </div>
      <div class="form-group">
        <label for="postal_code">Postal Code </label>
        <input
          required
          type="number"
          id="postal-code"
          name="postal-code"
          class="form-control"
          v-model.number="editedAgency.postalCode"
        />
      </div>
      <div class="form-group">
        <label for="email">Email </label>
        <input
          type="text"
          id="email"
          name="email"
          class="form-control"
          v-model="editedAgency.email"
        />
      </div>
      <div class="form-group">
        <label for="phone">Phone Number </label>
        <input
          type="text"
          id="phone"
          name="phone"
          class="form-control"
          v-model="editedAgency.phone"
        />
      </div>
      <div class="form-group">
        <label for="about">About</label>
        <input
          type="text"
          id="about"
          name="about"
          class="form-control"
          v-model.number="editedAgency.about"
        />
      </div>
      <div class="form-group">
        <label for="url">Website URL</label>
        <input
          type="text"
          id="url"
          name="url"
          class="form-control"
          v-model.number="editedAgency.url"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click="returnToAgency"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import AgencyService from "../services/AgencyService.js";

export default {
  name: "edit-agency",
  data() {
    return {
      editedAgency: {},
    };
  },

  created() {
    console.log("reached created method");
    this.editedAgency = this.$store.state.agencies.find(
      (agency) => agency.agencyId === this.$route.params.id
    );
    console.log(this.editedAgency);
  },

  methods: {
    onSubmit() {
      console.log("reached onSubmit method");
      this.editedAgency.AgencyId = this.$route.params.id;
      this.$store.commit("UPDATE_AGENCY", this.editedAgency);

      AgencyService.updateAgency(this.editedAgency)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.go({ name: "agency-list" });
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
      this.returnToAgency();
    },

    returnToAgency() {
      this.$router.push({ name: "agency-list" });
    },
  },
};
</script>

<style>
</style>