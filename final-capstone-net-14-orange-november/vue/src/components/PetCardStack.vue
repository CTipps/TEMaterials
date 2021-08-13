<template>
  <div id="card-stack">
    <vue-swing
      @throwin="throwin"
      :config="config"
      v-for="(pet, index) in pets"
      @throwoutright="throwoutMatch(pet)"
      @throwoutleft="throwoutReject(pet)"
      :key="pet.petId"
      v-show="index === pets.length - 1"
    >
      <pet-card :pet="pet" :isMatchedPage="false" class="card" />
    </vue-swing>
  </div>
</template>

<script>
import PetCard from "./PetCard.vue";
import VueSwing from "vue-swing";
import UserService from "@/services/UserService.js";

export default {
  name: "pet-card-stack",
  components: { PetCard },
  computed: {
    pets() {
      return this.$store.state.pets;
    },
    filter() {
      return this.$store.state.filter;
    },
  },
  created() {
    console.log("Created PetCardStack component");
    console.log(this.pets);
  },
  beforeDestroy() {
    console.log("Reached beforeDestroy lifecycle hook");
    UserService.likePets(this.$store.state.matchedPets);
  },
  data() {
    return {
      config: {
        /**
         * Invoked in the event of dragmove.
         * Returns a value between 0 and 1 indicating the completeness of the throw out condition.
         * Ration of the absolute distance from the original card position and element width.
         *
         * @param {number} xOffset Distance from the dragStart.
         * @param {number} yOffset Distance from the dragStart.
         * @param {HTMLElement} element Element.
         * @returns {number}
         */
        throwOutConfidence: (xOffset, yOffset, element) => {
          const xConfidence = Math.min(
            Math.abs(xOffset) / element.offsetWidth,
            1
          );
          const yConfidence = Math.min(
            Math.abs(yOffset) / element.offsetHeight,
            1
          );

          return Math.max(xConfidence, yConfidence);
        },
        allowedDirections: [VueSwing.Direction.LEFT, VueSwing.Direction.RIGHT],
      },
    };
  },
  methods: {
    throwin() {},
    throwoutMatch(pet) {
      this.$store.commit("ADD_PET_TO_MATCHED", pet);
      this.pets.pop();
    },
    throwoutReject(pet) {
      this.$store.commit("ADD_PET_TO_REJECTED", pet);
      this.pets.pop();
    },
  },
};
</script>

<style scoped>
</style>