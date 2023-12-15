import { createRouter as createRouter, createWebHistory } from 'vue-router'
import { useStore } from 'vuex'

// Import components
import HomeView from '../views/HomeView.vue';
import LoginView from '../views/LoginView.vue';
import LogoutView from '../views/LogoutView.vue';
import RegisterView from '../views/RegisterView.vue';
import CreateYourOwnView from '../views/CreateYourOwnView.vue';
import SpecialtyView from '../views/SpecialtyView.vue';
import OrderHistoryView from '../views/OrderHistoryView.vue';
import OrderDetailsView from '../views/OrderDetailsView.vue';
//import CustomerInfoView from '../views/CustomerInfoView.vue';
import CartView from "../views/CartView.vue";
import CheckoutView from "../views/CheckoutView.vue";
import AdminPending from '../views/AdminPendingView.vue';
import AdminRecipe from '../views/AdminRecipeView.vue';
import AdminStock from '../views/AdminStockView.vue';
import CustomerInfoView from '../views/CustomerInfoView.vue'
import NewPizza from '../views/AdminNewPizzaView.vue'
import AdminNewPizzaViewVue from '../views/AdminNewPizzaView.vue';
import OrderCompleted from '../views/OrderCompleted.vue'

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */
const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/logout",
    name: "logout",
    component: LogoutView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/register",
    name: "register",
    component: RegisterView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/customizePizza",
    name: "createYourOwn",
    component: CreateYourOwnView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/cart",
    name: "cart",
    component: CartView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/checkout",
    name: "checkout",
    component: CheckoutView,
    meta: {
      requiresAuth: false
    }
  },
  // {
  //   path: "/customerInfo/:customerId",
  //   name: "customerInfo",
  //   component: CustomerInfoView,
  //   meta: {
  //     requiresAuth: false
  //   }
  // },
  // {
  //   path: "/orderHistory/:customerId",
  //   name: "orderHistory",
  //   component: OrderHistoryView,
  //   meta: {
  //     requiresAuth: false
  //   }
  // },
  {
    path: "/orderDetails/:orderId",
    name: "orderDetails",
    component: OrderDetailsView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/specialtyPizzas",
    name: "specialty",
    component: SpecialtyView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/AdminStock",
    name: "stock",
    component: AdminStock,
    meta: {
      requiresAuth: false
    }
  },

  {
    path: "/AdminPending",
    name: "AdminPending",
    component: AdminPending,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/adminRecipe",
    name: "AdminRecipe",
    component: AdminRecipe,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/newCustomerInfo",
    name: "NewCustomerInfo",
    component: CustomerInfoView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/NewPizza",
    name: "newPizza",
    component: AdminNewPizzaViewVue,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/orderCompleted",
    name: "orderCompleted",
    component: OrderCompleted,
    meta: {
      requiresAuth: false
    }
  }


];

// Create the router
const router = createRouter({
  history: createWebHistory(),
  routes: routes
});

router.beforeEach((to) => {

  // Get the Vuex store
  const store = useStore();

  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    return {name: "login"};
  }
  // Otherwise, do nothing and they'll go to their next destination
});

export default router;
