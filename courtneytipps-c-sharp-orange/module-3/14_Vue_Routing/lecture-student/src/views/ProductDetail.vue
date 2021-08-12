<template>
  <div>
      <h4>{{activeProductID}}</h4>
  </div>
</template>

<script>
export default {
    data() {
        return {
            activeProductId: 0
        }
    },
    created() {
      this.activeProductID = this.$route.params.id;
      console.log(this.activeProductId);
    }

}
</script>

<style>

</style>