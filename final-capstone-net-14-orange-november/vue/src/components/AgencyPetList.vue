<template>
  <b-container>
    <table class="table table-bordered table-hover my-3">
      <thead>
        <tr>
          <th scope ="col">Thumbnail</th>
          <th scope="col">Name</th>
          <th scope="col">Age</th>
          <th scope="col">Species</th>
          <th scope="col">Breed</th>
          <th scope="col">Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pet) in agencyPets" v-bind:key="pet.petId">
          <td><img class="thumbnail" :src="pet.thumbnailUrl" alt="Img"></td>
          <td>{{ pet.name }}</td>
          <td>{{ pet.ageGroup }}</td>
          <td>{{ pet.species }}</td>
          <td>{{ pet.breed }}</td>
          <td>
            <router-link :to="{name: 'edit-pet', params: {id: pet.petId}}">
              <button class="btn btn-warning mb-1" >Edit</button>
            </router-link> 
            <button class="btn btn-danger mb-1" v-on:click="deletePet(pet.petId)" >Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
    <add-pet />
  </b-container>
</template>

<script>
import PetService from "@/services/PetService.js";
import AddPet from '../components/AddPet.vue';

export default {
  name: "agency-pet-list",
  components: { AddPet },
  computed: {
    agencyPets() {
      return this.$store.state.agencyPets;
    },
  },
  created() {
    PetService.getAgencyPets(this.$route.params.id).then((response) => {
      this.$store.commit("SET_AGENCY_PETS", response.data);
    });
  },
  methods: {
    deletePet(petId){
      if(confirm('Are you sure you want to DELETE this pet?')){
      PetService.deletePet(petId)
      .then(() => this.$store.commit("DELETE_PET", petId))
    } this.$router.go({name: 'agency-pet-list'})
    }
  }
};
</script>

<style>
.table {
  text-align: center;
}
.thumbnail {
  max-height: 100px;
  max-width: 100px
}
</style>