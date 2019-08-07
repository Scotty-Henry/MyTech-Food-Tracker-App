import axios from 'axios';

const apiClient = axios.create({
    baseURL: (`${process.env.VUE_APP_USDA_BASE_URL}`),
    headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json'
    }
});


export default {

    // returns list of foods based on a search query
    getFoods(query) {
        return apiClient.get(`/search/?format=json&q=${query}&ds=Standard%20Reference&api_key=${process.env.VUE_APP_CURR_API_KEY}`).then(response => response.data);
    },
    // returns a single food by ndbno, with 'basic' attributes (cal, prot, fat, carb, sodium)
    getFood(id) {
        return apiClient.get(`/reports/?format=json&ndbno=${id}&type=b&api_key=${process.env.VUE_APP_CURR_API_KEY}`).then(response => response.data);
    },
    // getReview(id) {
    //     return apiClient.get('/' + id).then(response => response.data);
    // },
    // deleteReview(id) {
    //     return apiClient.delete('/' + id);
    // },
    // addNewReview(review) {
    //     return apiClient.post('', JSON.stringify(review));
    // },
    // updateReview(id, review) {
    //     return apiClient.put('/' + id, JSON.stringify(review));
    // }
    getProfileInfo(){
        const url = `${process.env.VUE_APP_REMOTE_API}/Account/dashboard`;
        return axios.get(url).then(response => response.data);
    }
}