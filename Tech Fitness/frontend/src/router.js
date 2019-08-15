import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import CreateProfile from './views/CreateProfile.vue'
import EditProfile from './views/EditProfile.vue'
import SearchFood from './views/SearchFood.vue'
import HistoryView from './views/HistoryView.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (!user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (!user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/CreateProfile",
      name: "CreateProfile",
      component: CreateProfile,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/EditProfile",
      name: "EditProfile",
      component: EditProfile,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/search-food",
      name: "search-food",
      component: SearchFood,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: "/history-view",
      name: "HistoryView",
      component: HistoryView,
      beforeEnter: (to, from, next) => {
        const user = auth.getUser();
        if (user) {
          next();
        } else {
          next('/login');
        }
      }
    },
    {
      path: '*',
      redirect: '/'
    }
  ],
  linkActiveClass: 'active',
})

export default router;
