import axios from 'axios';


export default {
    getAllPets() {
        console.log("Reached Get All Pets in PetService");
        return axios.get('/pets');
    },
    getAgencyPets(agencyId) {
        console.log("Reached Get Agency Pets in PetService");
        return axios.get(`/agency/${agencyId}/pets`);
    },
    getPet(petId) {
        return axios.get(`/pets/${petId}`);
    },
    getPetPictures(petId) {
        return axios.get(`/pets/${petId}/pictures`);
    },
    addPet(pet) {
        console.log(pet);
        return axios.post('/pets', pet);
    },
    updatePet(pet) {
        console.log(pet);
        return axios.put('/pets', pet)
    },
    deletePet(petId) {
        console.log("Reached DeletePet in PetServices");
        console.log(petId);
        return axios.delete(`/pets/${petId}`)
    },
    addPetToPetMatches(petId){
        let userId = this.$store.state.user.userId;
        console.log(userId, petId);
        return axios.post(`/matchpet/${petId}`)
    },
    getFilteredPets(searchCriteria){
        console.log(searchCriteria);
        console.log("Reached getFilteredPets");
        return axios.post('/user/pets/filter/', searchCriteria)
    }
}