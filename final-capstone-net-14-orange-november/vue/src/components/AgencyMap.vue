<template>
  <b-container>
    <div style="height: 500px; width: 100%">
      <l-map
        :zoom="zoom"
        :center="center"
        :options="mapOptions"
        style="height: 80%"
      >
        <l-tile-layer
          :url="url"
          :attribution="attribution"
        />
        <l-marker
          v-for="agency in agencies"
          :key="agency.agencyId"
          :lat-lng="[ agency.lat, agency.lon ]"
        >
          <l-popup>
            {{agency.name}}
          </l-popup>
        </l-marker>
      </l-map>
    </div>
  </b-container>
</template>

<script>
import AgencyService from "@/services/AgencyService.js";

export default {
  name: 'agency-map',
  data() {
    return {
      zoom: 4,
      center: { lat: 38.065392, lng: -94.262695 },
      url: 'https://api.mapbox.com/styles/v1/mapbox/light-v10/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw',
      attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors | Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      mapOptions: {
      zoomSnap: 0.5
      },
    }
  },
  computed: {
    agencies: function () {
      return this.$store.state.agencies;
    },
  },
  created() {
      AgencyService.getAllAgencies().then((response) => {
        this.$store.commit("SET_AGENCIES", response.data) 
      });
  } 

}


</script>

<style>

</style>