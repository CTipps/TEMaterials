<template>
  <b-container >
    <div style="height: 500px; width: 100%"  class="activeAgencyMap">
      <l-map
        :zoom="zoom"
        :center="center"
        :options="mapOptions"
        style="height: 80%"
        ref="myMap"
        @ready="containerShown"
      >
        <l-tile-layer :url="url" :attribution="attribution" />
        <l-marker v-bind:lat-lng="center">
          <l-popup>
            {{ this.$store.state.activeAgency.name }}
          </l-popup>
        </l-marker>
      </l-map>
    </div>
  </b-container>
</template>

<script>
import 'leaflet/dist/leaflet.css';

export default {
  name: "single-instance-map",
  data() {
    return {
      zoom: 9,
      url: "https://api.mapbox.com/styles/v1/mapbox/light-v10/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw",
      attribution:
        '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors | Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      mapOptions: {
        zoomSnap: 0.5,
      },
      map: null
    };
  },
  computed: {
    center: function() {
      return [ this.$store.state.activeAgency.lat, this.$store.state.activeAgency.lon ];
    }
  },
  methods:{
    containerShown(){
      this.$nextTick(() => {
        console.log(this.$refs.myMap.mapObject);
        this.$refs.myMap.mapObject.invalidateSize();
      });
    }
  },
  mounted() {
      this.$nextTick(() => {
        this.map = this.$refs.myMap.mapObject;
      });
    },
};
</script>

<style lang="scss" scoped>
.activeAgencyMap {
  width: 100%;
    height: 400px;
}
</style>