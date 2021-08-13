<template>
  <div class="home">
    <b-container fluid="xl">
    <b-jumbotron
      header="WAYWARD WHISKERS"
      lead="Your premier solution for finding a new furry friend!"
      class="mt-3"
    >
      <b-img :src="require('../assets/home_alt.jpg')" fluid thumbnail />
    </b-jumbotron>
    <p class="lead">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Viverra vitae congue eu consequat. Facilisis mauris sit amet massa vitae tortor condimentum lacinia quis.</p>
    <p >Vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa. Est ullamcorper eget nulla facilisi etiam dignissim diam. Convallis convallis tellus id interdum velit laoreet id donec ultrices. Vitae justo eget magna fermentum. Hendrerit dolor magna eget est. Interdum velit euismod in pellentesque massa placerat duis. Fames ac turpis egestas sed tempus urna et pharetra pharetra. Vitae aliquet nec ullamcorper sit amet risus. Lectus sit amet est placerat in egestas erat imperdiet. Potenti nullam ac tortor vitae purus faucibus ornare. Ac ut consequat semper viverra nam. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing elit. Posuere sollicitudin aliquam ultrices sagittis orci. Tristique senectus et netus et. Leo duis ut diam quam. Auctor elit sed vulputate mi sit amet mauris commodo quis. Sit amet tellus cras adipiscing enim eu. Semper viverra nam libero justo laoreet sit. Tincidunt praesent semper feugiat nibh sed pulvinar.</p>
    <h2>Now supporting {{ numberOfAgencies }} organizations!</h2>
    <agency-map></agency-map>
    </b-container>
  </div>
</template>

<script>
import AgencyMap from "@/components/AgencyMap.vue";
import PetService from "@/services/PetService.js"
import AgencyService from "@/services/AgencyService.js"

export default {
  name: "home",
  components: { AgencyMap },
  data(){
    return {
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
    }
  },
  computed: {
    numberOfAgencies: function() {
      return this.$store.state.agencies.length;
    }
  },
  created(){
    this.$store.commit("SET_SEARCH_CRITERIA", this.filter);
      console.log(this.$store.state.filter);

      PetService.getFilteredPets(this.filter).then((response) => {
        this.$store.commit("SET_PETS", response.data);
      });
      AgencyService.getAllAgencies().then((response) => {
        this.$store.commit("SET_AGENCIES", response.data);
      });
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Oswald:wght@700&display=swap');
.display-3 {
  font-family: Oswald, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
}
</style>