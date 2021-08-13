<template>
  <b-card
    elevation="2"
    bg-variant="light"
    v-bind:title="pet.name"
    v-bind:img-src="pet.primaryImageUrl"
    img-alt="Image"
    tag="article"
    style="max-width: 20rem"
    class="mb-2"
    display="flex"
    v-if="
      (this.$store.state.matchedPets.includes(pet) === false &&
        this.$store.state.rejectedPets.includes(pet) === false) ||
      isMatchedPage === true
    "
    v-on:mouseover="setActivePet"
  >
    <b-collapse id="collapse-1">
      <b-card-text v-if="pet.ageString !== ''"
        >Age: {{ pet.ageString }}</b-card-text
      >
      <b-card-text v-else>Age: {{ pet.ageGroup }}</b-card-text>
      <b-card-text>Sex: {{ pet.sex }}</b-card-text>

      <b-card-text>Size: {{ pet.sizeGroup }}</b-card-text>
      <b-card-text>Breed: {{ pet.breed }}</b-card-text>

      <b-card-text v-if="pet.exerciseNeeds !== ''">Exercise Needs: {{ pet.exerciseNeeds }}</b-card-text>
      <b-card-text v-show="pet.vocalLevel !== ''"
        >Vocal Level: {{ pet.vocalLevel }}</b-card-text
      >
    </b-collapse>
    <b-button v-b-toggle.collapse-1 variant="primary" v-show="!isMatchedPage"
      >About {{ pet.name }}
    </b-button>
    <accept-reject-icons-bar v-show="!isMatchedPage" />
    <router-link
      v-show="isMatchedPage"
      :to="{ name: 'pet-details', params: { id: pet.petId } }"
    >
      <b-button variant="primary"> View Adoption Details </b-button>
    </router-link>
  </b-card>
</template>

<script>
import AcceptRejectIconsBar from "./AcceptRejectIconsBar.vue";

export default {
  components: { AcceptRejectIconsBar },
  name: "pet-card",
  props: {
    isMatchedPage: Boolean,
    pet: {
      type: Object,
    },
  },
  methods: {
    setActivePet() {
      this.$store.commit("SET_ACTIVE_PET", this.pet);
    },
  },
};
</script>

<style>
.mb-2 {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  margin: 100px;
  align-items: center;
  justify-content: center;
  margin: auto;
  display: flex;
}
.mb-2 img {
  max-height: 220px;
  pointer-events: none;
}
</style>