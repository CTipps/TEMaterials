<template>
  <div class="container">
      <b-form @submit.prevent="onSubmit" @reset="onReset">

        <b-form-group id="species" label="Species:" label-for="input-species">
          <b-form-select
            id="input-species"
            v-model="filter.speciesId"
            :options="species"
            value-field="speciesId"
            text-field="name"
          >
            <template #first>
              <b-form-select-option :value="0" 
                >Select an option</b-form-select-option
              >
            </template>
          </b-form-select>
        </b-form-group>

        <b-form-group id="breed" label="Breed:" label-for="input-breeds">
          <b-form-select
            id="input-breeds"
            v-model="filter.breedIds"
            :options="speciesBreeds"
            value-field="breedId"
            text-field="name"
            multiple
          >
            <template #first>
              <b-form-select-option :value="0" disabled
                >Select an option</b-form-select-option
              >
            </template>
          </b-form-select>
        </b-form-group>

        <b-form-group
          id="agencies"
          label="Agencies:"
          label-for="input-agencies"
        >
          <b-form-select
            id="input-agencies"
            v-model="filter.agencyIds"
            :options="agencies"
            value-field="agencyId"
            text-field="name"
            multiple
          >
            <template #first>
              <b-form-select-option :value="0" disabled
                >Select an option</b-form-select-option
              >
            </template>
          </b-form-select>
        </b-form-group>

        <b-form-group id="sex" label="Sex:" label-for="input-sex">
          <b-form-radio-group
            id="input-sex"
            v-model="filter.sex"
            :options="sexOptions"
          ></b-form-radio-group>
        </b-form-group>

        <b-form-group
          id="age-groups"
          label="Age Groups:"
          label-for="input-age-groups"
        >
          <b-form-checkbox-group
            id="input-age-groups"
            v-model="filter.ageGroups"
            :options="ageGroupOptions"
            name="age-group-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <b-form-group
          id="activity-levels"
          label="Activity Levels:"
          label-for="input-activity-levels"
        >
          <b-form-checkbox-group
            id="input-activity-levels"
            v-model="filter.activityLevels"
            :options="activityLevelOptions"
            name="activity-level-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <b-form-group
          id="exercise-needs"
          label="Exercise Needs:"
          label-for="input-exercise-needs"
        >
          <b-form-checkbox-group
            id="input-exercise-needs"
            v-model="filter.allExerciseNeeds"
            :options="exerciseNeedsOptions"
            name="exercise-needs-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <b-form-group
          id="owner-experience"
          label="Owner Experience Required:"
          label-for="input-owner-experience"
        >
          <b-form-checkbox-group
            id="input-owner-experience"
            v-model="filter.ownerExperiences"
            :options="ownerExperienceOptions"
            name="owner-experience-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <b-form-group
          id="size-group"
          label="Size Group:"
          label-for="input-size-group"
        >
          <b-form-checkbox-group
            id="input-size-group"
            v-model="filter.sizeGroups"
            :options="sizeGroupOptions"
            name="size-group-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <b-form-group
          id="vocal-level"
          label="Vocal Level:"
          label-for="input-vocal-level"
        >
          <b-form-checkbox-group
            id="input-vocal-level"
            v-model="filter.vocalLevels"
            :options="vocalLevelOptions"
            name="vocal-level-checkbox"
          ></b-form-checkbox-group>
        </b-form-group>

        <div class="my-3">
        <b-button class="mx-1" type="submit" variant="primary" v-b-toggle.criteria >Submit</b-button>
        <b-button class="mx-1" type="reset" variant="secondary">Reset Choices</b-button>
        </div>
      </b-form>
  </div>
</template>

<script>
import PetService from "@/services/PetService.js";
import SpeciesService from "@/services/SpeciesService.js";
import BreedService from "@/services/BreedService.js";
import AgencyService from "@/services/AgencyService.js";

export default {
  name: "criteria-form",
  data() {
    return {
      sexOptions: ["Male", "Female"],
      ageGroupOptions: ["Baby", "Young", "Adult", "Senior"],
      activityLevelOptions: [
        "Not Active",
        "Slightly Active",
        "Moderately Active",
        "Highly Active",
      ],
      exerciseNeedsOptions: ["Not Required", "Low", "Moderate", "High"],
      ownerExperienceOptions: ["None", "Species", "Breed"],
      sizeGroupOptions: ["Small", "Medium", "Large", "X-Large"],
      vocalLevelOptions: ["Quiet", "Some", "Lots"],
      filter: {
        userId: 0,
        speciesId: 0,
        breedIds: [],
        agencyIds: [],
        sex: "",
        ageGroups: [],
        activityLevels: [],
        allExerciseNeeds: [],
        ownerExperiences: [],
        sizeGroups: [],
        vocalLevels: [],
      },
    };
  },
  computed: {
    speciesBreeds: function () {
      if (this.filter.speciesId !== 0) {
        return this.breeds.filter((breed) => {
          return breed.speciesId === this.filter.speciesId;
        });
      } else {
        return this.breeds;
      }
    },
    species: function () {
      return this.$store.state.species;
    },
    breeds: function () {
      return this.$store.state.breeds;
    },
    agencies: function () {
      return this.$store.state.agencies;
    },
  },
  methods: {
    onSubmit() {
      this.$store.commit("SET_SEARCH_CRITERIA", this.filter);
      console.log(this.$store.state.filter);

      PetService.getFilteredPets(this.filter).then((response) => {
        this.$store.commit("SET_PETS", response.data);
      });
    },
    onReset() {
      this.filter = {
        userId: 0,
        speciesId: 0,
        breedIds: [],
        agencyIds: [],
        sex: "",
        ageGroups: [],
        activityLevels: [],
        allExerciseNeeds: [],
        ownerExperiences: [],
        sizeGroups: [],
        vocalLevels: [],
      };
      this.$store.commit("SET_SEARCH_CRITERIA", this.filter);
      console.log(this.$store.state.filter);
            PetService.getFilteredPets(this.filter).then((response) => {
        this.$store.commit("SET_PETS", response.data);
      });
    },
  },
  created() {
    SpeciesService.getAllSpecies().then((response) => {
      this.$store.commit("SET_SPECIES", response.data);
    });
    BreedService.getAllBreeds().then((response) => {
      this.$store.commit("SET_BREEDS", response.data);
    });
    AgencyService.getAllAgencies().then((response) => {
      this.$store.commit("SET_AGENCIES", response.data);
    });
  },
};
</script>

<style>
</style>