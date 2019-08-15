import axios from 'axios';
import auth from '@/auth';

const apiClient = axios.create({
    baseURL: (`${process.env.VUE_APP_USDA_BASE_URL}`),
    headers: {
        //Authorization: 'Bearer ' + auth.getToken(),
        'Content-Type': 'application/json',
        Accept: 'application/json'
    }
});
const apiLocal = axios.create({
    baseURL: (`${process.env.VUE_APP_REMOTE_API}`),
    headers: {
        //Authorization: 'Bearer ' + auth.getToken(),
        'Content-Type': 'application/json',
        Accept: 'application/json'
    }
});
function addAuthorization() {
    apiLocal.defaults.headers.Authorization = 'Bearer ' + auth.getToken();
}

export default {

    // returns list of foods based on a search query
    getFoods(query) {
        return apiClient.get(`/search/?format=json&q=${query}&ds=Standard%20Reference&api_key=${process.env.VUE_APP_CURR_API_KEY}`).then(response => response.data);
    },
    // returns a single food by ndbno, with 'basic' attributes (cal, prot, fat, carb, sodium)
    getFood(id) {
        return apiClient.get(`/reports/?format=json&ndbno=${id}&type=b&api_key=${process.env.VUE_APP_CURR_API_KEY}`).then(response => response.data);
    },
    getProfileInfo(){
        const url = `${process.env.VUE_APP_REMOTE_API}/Account/dashboard`;
        addAuthorization();
        return apiLocal.get(url)
        .then(response => response.data);
    },
    getMealbyUser(){
        const url = `${process.env.VUE_APP_REMOTE_API}/Account/getMealbyUser`;
        addAuthorization();
        return apiLocal.get(url).then(response => response.data);
    },
    submitMeal(){
        const url = `${process.env.VUE_APP_REMOTE_API}/Account/addMeal`;
        addAuthorization();
        return apiLocal.post(url).then(response => response.data);
    },
    getNutritionbyMealandDate(){
        const url = `${process.env.VUE_APP_REMOTE_API}/Account/getNutritionbyMealandDate`;
        return apiLocal.get(url).then(response => response.data);
    },
    findNutrient(nameNutrient, myArray){
        for (var i=0; i < myArray.length; i++) {
            if (myArray[i].name === nameNutrient) {
                return myArray[i].value;
            }
        }
    },
    stringtoDate(datestring){
        let stringConverted2Date = new Date(datestring);
        stringConverted2Date = stringConverted2Date.toLocaleDateString('en-US')
        return stringConverted2Date
      },

}