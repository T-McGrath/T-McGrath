import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import ProductsView from "../views/ProductsView.vue";
import ProductDetailView from "../views/ProductDetailView.vue";

const routes = [
  {
    path: "/",
    name: "products",
    component: ProductsView
  },
  {
    path: "/products/:id",
    name: "product-details",
    component: ProductDetailView
  }
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
