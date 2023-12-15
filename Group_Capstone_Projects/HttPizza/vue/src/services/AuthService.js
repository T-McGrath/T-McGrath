import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  }

}
