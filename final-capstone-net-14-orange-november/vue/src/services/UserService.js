import axios from 'axios';

export default {
    getAllUsers() {
        console.log("Reached Get All Users in UserService")
        return axios.get('/admin');
    },
    getUser(userID) {
        return axios.get(`/admin/${userID}`)
    },
    updateUserRole(user) {
        console.log(user);
        return axios.put(`/admin/users/${user.userId}`, user)
    },
    deleteUser(userId) {
        console.log("Reached Delete User in UserService");
        console.log(userId);
        return axios.delete(`/admin/${userId}`)
    },
    updateUserPassword(resetCode, newPassword){
        return axios.put(`/resetpassword/`, {resetCode: resetCode, newPassword: newPassword})
    },
    getUserCoordinates(postalCode) {
        return axios.get(`https://api.mapbox.com/geocoding/v5/mapbox.places/${postalCode}.json?limit=1&access_token=pk.eyJ1Ijoid2F5d2FyZHdoaXNrZXJzIiwiYSI6ImNrczZ2cmRqeDA1eGkzMnBjZG56ZTNjd20ifQ.gEc2Jf8bIdDFzmmcrdZ4nw`)
    },
    getUserFromPWResetCode(resetCode){
        return axios.get(`/resetpassword/${resetCode}`)
    },
    getUserResetCodeFromEmailAddress(emailAddress){
        console.log(emailAddress);
        return axios.get(`/forgotpassword/${emailAddress}`)
    },
    likePets(likedPets) {
        return axios.post(`/user/pets/liked`, likedPets)
    },
    unlikePet(unlikedPet) {
        return axios.delete(`/user/pets/liked`, unlikedPet)
    },
    getLikedPets() {
        return axios.get(`/user/pets/liked`)
    }
    
}