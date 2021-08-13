<template>
  <b-container class="accept-reject-bar">
    <b-row>
      <b-col>
        <b-button variant="light">
          <b-icon
            icon="x-circle-fill"
            scale="2"
            variant="danger"
            class="skip-button"
            @click="addPetToRejected(pet)"
          ></b-icon>
        </b-button>
      </b-col>
      <b-col>
        <b-button variant="light">
          <b-icon
            icon="heart-fill"
            scale="2"
            class="heart-button"
            style="color: #ff69b4"
            @click="addPetToMatched(pet)"
          ></b-icon>
        </b-button>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  components: {},
  pet: {},
  methods: {
    addPetToMatched(pet) {
      this.$store.commit("ADD_PET_TO_MATCHED", pet);
      this.$store.commit("POP_PET_OFF_STATE");
    },
    addPetToRejected(pet) {
      this.$store.commit("ADD_PET_TO_REJECTED", pet);
      this.$store.commit("POP_PET_OFF_STATE");
    },
  },
  computed: {
      pet: function() {
       return this.$store.state.activePet;
      }
  }
};
</script>

<style>
.accept-reject-bar {
  justify-content: center;
  margin: 20px;
}
</style>