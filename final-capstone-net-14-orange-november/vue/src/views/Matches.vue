<template>
  <b-container>
    <b-card-group deck class="mt-4">
    <div v-for="(pet, index) of pets" v-bind:key="index">
      <pet-card :pet="pet" :isMatchedPage="isMatchedPage" class="card" />
    </div>
    </b-card-group>
  </b-container>
</template>

<script>
import PetCard from "@/components/PetCard.vue";
import UserService from "@/services/UserService.js";

export default {
  name: "matches",
  components: { PetCard },
  computed: {
      pets() {
          return this.$store.state.matchedPets;
    },
  },
  data() {
      return {
        matchedPets: [],
        isMatchedPage: true,
    };
  },
  created() {
    UserService.getLikedPets().then((response) => {
      this.$store.commit("SET_MATCHED_PETS", response.data);
    });
    console.log(this.matchedPets);
  },
};
</script>

<style>
</style>