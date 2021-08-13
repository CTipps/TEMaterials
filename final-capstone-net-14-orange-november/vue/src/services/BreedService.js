import axios from 'axios';

export default {
    getAllBreeds() {
        return axios.get('/breeds');
    },
    getBreed(breedId) {
        return axios.get(`/breeds/${breedId}`);
    }
}