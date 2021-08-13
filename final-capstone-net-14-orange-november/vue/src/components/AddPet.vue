<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Pet</a
    >

    <b-form @submit.prevent="onSubmit" v-if="isFormShown">
      <b-form-group id="agency" label="Agency:" label-for="agency">
        <b-form-select
        type="text"
          id="agency"
          v-model="newPet.agencyId"
          :options="agencies"
          value-field="agencyId"
          text-field="name"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="name" label="Name:" label-for="name">
        <b-form-input
          id="name"
          v-model="newPet.name"
          type="text"
          placeholder="Enter Animal Name"
          required
        />
      </b-form-group>

            <b-form-group id="sex" label="Sex:" label-for="sex">
        <b-form-select
          id="sex"
          v-model="newPet.sex"
          :options="sexOptions"
          value-field="sex"
          text-field="sex"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="species" label="Species:" label-for="species">
        <b-form-select
          id="species"
          v-model="newPet.speciesId"
          :options="species"
          value-field="speciesId"
          text-field="name"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="breed" label="Breed:" label-for="breeds">
        <b-form-select
          id="input-breeds"
          v-model="newPet.breedId"
          :options="speciesBreeds"
          value-field="breedId"
          text-field="name"
        >
          <template #first>
            <b-form-select-option :value="null" disabled
              >Select an option</b-form-select-option
            >
          </template>
        </b-form-select>
      </b-form-group>

      <b-form-group id="ageString" label="Age:" label-for="ageString">
        <b-form-input
          id="ageString"
          v-model="newPet.ageString"
          type="text"
          placeholder="Enter Animal's Age"
          description="Ex. 1 year 7 months"
        />
      </b-form-group>

      <b-form-group id="age-group" label="Age Group:" label-for="age-group">
        <b-form-select
          id="age-groups"
          v-model="newPet.ageGroup"
          :options="ageGroupOptions"
          name="age-group"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="activity-level"
        label="Activity Level:"
        label-for="activity-level"
      >
        <b-form-select
          id="activity-level"
          v-model="newPet.activityLevel"
          :options="activityLevelOptions"
          name="activity-level"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="exercise-needs"
        label="Exercise Needs:"
        label-for="exercise-needs"
      >
        <b-form-select
          id="input-exercise-needs"
          v-model="newPet.exerciseNeeds"
          :options="exerciseNeedsOptions"
          name="exercise-needs"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="owner-experience"
        label="Owner Experience Required:"
        label-for="owner-experience"
      >
        <b-form-select
          id="owner-experience"
          v-model="newPet.ownerExperience"
          :options="ownerExperienceOptions"
          name="owner-experience"
        ></b-form-select>
      </b-form-group>

      <b-form-group id="size-group" label="Size Group:" label-for="size-group">
        <b-form-select
          id="input-size-group"
          v-model="newPet.sizeGroup"
          :options="sizeGroupOptions"
          name="size-group"
        ></b-form-select>
      </b-form-group>

      <b-form-group
        id="vocal-level"
        label="Vocal Level:"
        label-for="vocal-level"
      >
        <b-form-select
          id="vocal-level"
          v-model="newPet.vocalLevel"
          :options="vocalLevelOptions"
          name="vocal-level"
        ></b-form-select>
      </b-form-group>

      <b-form-group id="description" label="Description:" label-for="description">
        <b-form-textarea
          id="description"
          v-model="newPet.descriptionText"
          required
        />
      </b-form-group>

      <b-form-group  id="imageUrl" label="Image URL:" label-for="imageUrl">
        <b-form-input
          class="required-field"
          id="imageUrl"
          v-model="newPet.primaryImageUrl"
          type="text"
          required
        />
      </b-form-group>

      <b-form-group id="thumbnailUrl" label="Thumbnail Url:" label-for="thumbnailUrl">
        <b-form-input
          id="thumbnailUrl"
          v-model="newPet.thumbnailUrl"
          type="text"
          description="Can be the same as primary image."
        />
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-secondary"
        value="Cancel"
      />
    </b-form>
  </div>
</template>

<script>
import PetService from "../services/PetService.js";
import SpeciesService from "@/services/SpeciesService.js";
import BreedService from "@/services/BreedService.js";
import AgencyService from "@/services/AgencyService.js";

export default {
  name: "PetAdd",
  data() {
    return {
      newPet: {
      },

      isFormShown: false,

 sexOptions: [
        "Male",
        "Female"
      ],
      ageGroupOptions: [
        "Baby",
        "Young",
        "Adult",
        "Senior"
      ],
      activityLevelOptions: [
        "Not Active",
        "Slightly Active",
        "Moderately Active",
        "Highly Active"
      ],
      exerciseNeedsOptions: [
        "Not Required",
        "Low",
        "Moderate",
        "High"
      ],
      ownerExperienceOptions: [
        "None",
        "Species",
        "Breed"
      ],
      sizeGroupOptions: [          
        "Small",
        "Medium",
        "Large",
        "X-Large"
      ],
      vocalLevelOptions: [
        "Quiet",
        "Some",
        "Lots"
      ],
    };
  },
   computed: {
   speciesBreeds: function () {
      if (this.newPet.speciesId !== 0) {
        return this.breeds.filter( (breed) => {          
          return breed.speciesId === this.newPet.speciesId;
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
    }
    },
  created() {
      SpeciesService.getAllSpecies().then((response) => {
        this.$store.commit("SET_SPECIES", response.data);
      });
      BreedService.getAllBreeds().then((response) => {
        this.$store.commit("SET_BREEDS", response.data) 
      });
      AgencyService.getAllAgencies().then((response) => {
        this.$store.commit("SET_AGENCIES", response.data) 
      });
    },
  methods: {
    async onSubmit() {
      await this.$store.commit("ADD_PET", this.newPet);

      PetService.addPet(this.newPet)
        .then((response) => {
          console.log("promise was success", response);
          // this.$router.push({ name: "pets-list" });
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });

      this.resetForm();
    },

    resetForm() {
      this.newPet = {};
      this.isFormShown = false;
      this.$router.go({ name: "agency-pet-list" });
    },
  },
};
</script>

<style>
.required-field::before {
  content: "*";
  color: red;
  margin-right: 2px;
}
</style>