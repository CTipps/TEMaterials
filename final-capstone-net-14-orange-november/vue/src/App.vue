<template>
  <div id="app">
    <the-navbar /> 
    <router-view />
    <bottom-footer />
  </div>
</template>

<script>
import TheNavbar from './components/TheNavbar.vue';
import BottomFooter from './components/BottomFooter.vue';

export default {
  name: "App",

  components: {
    TheNavbar,
    BottomFooter,
  },
};
 </script>