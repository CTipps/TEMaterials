<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Agency</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
     <div class="form-group">
        <label for="name">Agency Name </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newAgency.name"
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
          v-model="newAgency.street"
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
          v-model.number="newAgency.city"
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
          v-model="newAgency.state"
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
          v-model="newAgency.postalCode"
        />
      </div>
      <div class="form-group">
        <label for="email">Email </label>
        <input
          type="text"
          id="email"
          name="email"
          class="form-control"
          v-model="newAgency.email"
        />
      </div>
      <div class="form-group">
        <label for="phone">Phone Number </label>
        <input
          type="text"
          id="phone"
          name="phone"
          class="form-control"
          v-model="newAgency.phone"
        />
      </div>
      <div class="form-group">
        <label for="about">About</label>
        <textarea
          id="about"
          name="about"
          class="form-control"
          v-model.number="newAgency.about"
        />
      </div>
      <div class="form-group">
        <label for="url">Website URL</label>
        <input
          type="text"
          id="url"
          name="url"
          class="form-control"
          v-model.number="newAgency.url"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-secondary"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import AgencyService from "../services/AgencyService.js";


export default {
  name: "agency-add",
  data() {
    return {
      newAgency: {
        lat: 0,
        lon: 0
      },
      isFormShown: false,
    };
  },

  methods: {
    async onSubmit() {
        await AgencyService.getAgencyCoords(`${this.newAgency.street} ${this.newAgency.city} ${this.newAgency.state} ${this.newAgency.postalCode}`)
        .then((response) => {
          console.log("promise was success", response.data['features'][0]['center']);
          this.newAgency.lon = response.data['features'][0]['center'][0];
          this.newAgency.lat = response.data['features'][0]['center'][1];
        })
        .catch((error) => {
         
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        })
        
      AgencyService.addAgency(this.newAgency)
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

          this.$store.commit("ADD_AGENCY", this.newAgency);
          this.resetForm();
        },

    resetForm() {
      this.newAgency = {};
      this.isFormShown = false;
    },
  },
};
</script>
<style>

</style>