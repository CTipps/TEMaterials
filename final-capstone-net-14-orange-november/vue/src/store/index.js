import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'))


if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    pets: [],
    users: [],
    agencies: [],
    activeAgency: {},
    activePet: {},
    matchedPets: [],
    rejectedPets: [],
    filter: {},
    species: [],
    breeds: [],
    agencyPets: []
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    SET_USERS(state, users) {
      state.users = users;
    },
    DELETE_USER(state, userId) {
      state.users = this.state.users.filter(user => user.id != userId);
    },
    UPDATE_USER_ROLE(state, editedUser) {
      state.users = this.state.users.filter(user => user.userId != editedUser.userId);
      state.users = state.users.push(editedUser);
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_ACTIVE_PET(state, pet) {
      state.activePet = pet;
    },
    SET_PETS(state, pets) {
      state.pets = pets;
    },
    SET_AGENCY_PETS(state, pets) {
      state.agencyPets = pets;
    },
    ADD_PET(state, pet) {
      state.pets.push(pet)
    },
    UPDATE_PET(state, editedPet) {
      state.pets = this.state.pets.filter(pet => pet.petId != editedPet.petId);
      state.pets = state.pets.push(editedPet);
    },
    DELETE_PET(state, petId) {
      state.pets = this.state.pets.filter(pet => pet.petId != petId);
    },
    SET_ACTIVE_AGENCY(state, agency) {
      state.activeAgency = agency;
    },
    SET_AGENCIES(state, agencies) {
      state.agencies = agencies;
    },
    ADD_AGENCY(state, agency) {
      state.pets.push(agency)
    },
    UPDATE_AGENCY(state, editedAgency) {
      state.agencies = this.state.agencies.filter(agency => agency.id != editedAgency.id);
      state.agencies = state.agencies.push(editedAgency);
    },
    DELETE_AGENCY(state, agencyId) {
      state.agencies = this.state.agencies.filter(agency => agency.id != agencyId);
    },
    ADD_PET_TO_MATCHED(state, pet) {
      state.matchedPets.push(pet);
      console.log(state.matchedPets);
    },
    SET_MATCHED_PETS(state, matchedPets) {
      state.matchedPets = matchedPets;
    },
    ADD_PET_TO_REJECTED(state, petId) {
      state.rejectedPets.push(petId);
      console.log(state.rejectedPets);
    },
    SET_SEARCH_CRITERIA(state, filter) {
      state.filter = filter;
    },
    UPDATE_USER_PASSWORD(state, editedUser) {
      state.users = this.state.users.filter(user => user.userId != editedUser.userId);
      state.users = state.users.push(editedUser);
    },
    SET_BREEDS(state, breeds) {
      console.log("reached SET_BREEDS mutation");
      state.breeds = breeds;
      console.log(state.breeds);
    },
    SET_SPECIES(state, species) {
      console.log("reached SET_SPECIES mutation");
      state.species = species;
      console.log(state.species);
    },
    POP_PET_OFF_STATE(state){
      state.pets.pop();
    }
  }
})
