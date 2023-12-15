import { createStore as _createStore } from 'vuex';
import axios from 'axios';

export function createStore(currentToken, currentUser) {
  let store = _createStore({
    state: {
      token: currentToken || '',
      user: currentUser || {},
      selectedIngs: [],
      selectedSpecialtyRecipe: {}
    },
    mutations: {
      SET_AUTH_TOKEN(state, token) {
        state.token = token;
        localStorage.setItem('token', token);
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
      },
      SET_USER(state, user) {
        state.user = user;
        localStorage.setItem('user', JSON.stringify(user));
      },
      LOGOUT(state) {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        state.token = '';
        state.user = {};
        axios.defaults.headers.common = {};
      },
      ADD_ING(state, ingredients) {
        ingredients.array.forEach(element => {
          return state.selectedIngs.push(element);
        });
      }, 
      CLEAR_INGS(state) {
        state.selectedIngs = [];
      },
      ADD_RECIPE(state, recipe) {
        state.selectedSpecialtyRecipe = recipe;
      },
      CLEAR_RECIPE(state) {
        state.selectedSpecialtyRecipe = {};
      }
    }
  });
  return store;
}
