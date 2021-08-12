<template>
  <table class="table table-bordered table-hover">
    <tbody>
      <tr>
        <td>Name</td>
        <td>{{ pet.name }}</td>
      </tr>

      <tr>
        <td>Age</td>
        <td>{{ pet.age }}</td>
      </tr>

      <tr>
        <td>Type</td>
        <td>{{ pet.type }}</td>
      </tr>

      <tr>
        <td>Breed</td>
        <td>{{ pet.breed }}</td>
      </tr>

      <tr>
        <td>Image</td>
        <td>
          <a v-bind:href="pet.image" target="blank">{{ pet.image }} </a>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "PetDetail",

  data: function () {
    return {
      pet: {},
    };
  },

  props: ["id"],

  created() {
    let pets = this.$store.state.pets;
    this.pet = pets.find((item) => {
      return item.id == this.id;
    });
  },
};
</script>

<style scoped>
table,
th,
td {
  border: 1px solid black;
}

table {
  width: 50%;
  margin: 20px;
}
</style>