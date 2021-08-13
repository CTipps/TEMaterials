<template>
  <b-container class="mt-3">
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope ="col">ID</th>
          <th scope="col">Name</th>
          <th scope="col">City/State</th>
          <th scope="col">Lat/Long</th>
          <th scope="col">Pets</th>
          <th scope="col">Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(agency) in agencies" v-bind:key="agency.agencyId">
          <td>{{ agency.agencyId }}</td>
          <td>{{ agency.name }}</td>
          <td>{{ agency.city }}, {{agency.state}}</td>
          <td> {{agency.lat}} {{agency.lon}}</td>
          <td>
            <router-link :to="{name: 'agency-pet-list', params: {id: agency.agencyId}}">
              <button class="btn btn-success" >Pets</button>
            </router-link></td>
          <td>
            <router-link :to="{name: 'edit-agency', params: {id: agency.agencyId}}">
              <button class="btn btn-warning" >Edit</button>
            </router-link>
            <button class="btn btn-danger" v-on:click="deleteAgency(agency.agencyId)" >Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
    <add-agency />
  </b-container>
</template>

<script>
import AgencyService from "@/services/AgencyService.js";
import AddAgency from './AddAgency.vue';

export default {
  name: "agency-list",
  components: { AddAgency },
  computed: {
    agencies() {
      return this.$store.state.agencies;
    },
  },
  created() {
    AgencyService.getAllAgencies().then((response) => {
      this.$store.commit("SET_AGENCIES", response.data);
    });
  },
  methods: {
    deleteAgency(agencyId){
      if(confirm(`Are you sure you want to delete this? This will remove all pets associated as well.`))
      {AgencyService.deleteAgency(agencyId)
      .then(() => this.$store.commit("DELETE_AGENCY", agencyId))
      this.$router.go('agency-list')
    }
    }
  }
};
</script>

<style>
</style>