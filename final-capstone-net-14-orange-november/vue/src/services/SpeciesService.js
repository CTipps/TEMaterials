import axios from 'axios';

export default {
    getAllSpecies() {
        return axios.get('/species');
    },
    getSpecies(speciesId) {
        return axios.get(`/species/${speciesId}`);
    },
    getSpeciesBreeds(speciesId) { 
        return axios.get(`/species/${speciesId}/breeds`);
    }
}