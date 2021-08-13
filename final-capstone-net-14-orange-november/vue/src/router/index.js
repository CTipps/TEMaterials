import Vue from 'vue'
import Router from 'vue-router'
import store from '../store/index'

import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import PetDetails from '../views/PetDetails.vue'
import PetList from '@/components/PetList.vue'
import EditPet from '@/views/EditPet.vue'
import PetMatcher from '@/views/PetMatcher.vue'
import Admin from '@/views/Admin.vue'
import Restricted from '@/views/Restricted.vue'
import UserList from '@/components/UserList.vue'
import ChangeRole from '@/components/ChangeRole.vue'
import AgencyList from '@/components/AgencyList.vue'
import EditAgency from '@/views/EditAgency.vue'
import ForgotPassword from '@/views/ForgotPassword.vue'
import ResetPassword from '@/views/ResetPassword.vue'
import Matches from '@/views/Matches.vue'
import AgencyPetList from '@/components/AgencyPetList.vue'


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
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: '/restricted',
      name: 'restricted',
      component: Restricted,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: "/forgotpassword",
      name: 'forgot-password',
      component: ForgotPassword,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }
    },
    {
      path: "/resetpassword/:resetCode",
      name: "reset-password",
      component: ResetPassword,
      meta: {
        requiresAuth: false,
        requiresAdmin: false
      }

    },
    {
      path: "/pets/:id",
      name: "pet-details",
      component: PetDetails,
      meta: {
        requiresAuth: true,
        requiresAdmin: false
      }
    },
    {
      path: "/editpet/:id",
      name: "edit-pet",
      component: EditPet,
      meta: {
        requiresAuth: true,
        requiresAdmin: false
      }
    },
    {
      path: "/pets/",
      name: "pets-list",
      component: PetList,
      meta: {
        requiresAuth: true,
        requiresAdmin: false
      }
    },
    {
      path: "/pets/agency/:id",
      name: "agency-pet-list",
      component: AgencyPetList,
      meta: {
        requiresAuth: true,
        requiresAgency: true
      }
    },
    {
      path: '/petmatcher',
      name: 'pet-matcher',
      component: PetMatcher,
      meta: {
        requiresAuth: true,
        requiresAdmin: false
      }
    },
    {
    path: '/admin',
    name: 'admin',
    component: Admin,
    meta: {
      requiresAuth: true,
      requiresAdmin: true
    }
  },
  {
    path: '/admin/users',
    name: 'user-list',
    component: UserList,
    meta: {
      requiresAuth: true,
      requiresAdmin: true
    }
  },
  {
    path: '/changerole/:id',
    name: 'role-change',
    component: ChangeRole,
    meta: {
      requiresAuth: true,
      requiresAdmin: true
    }
  },
  {
  path: '/agency',
    name: 'agency-list',
    component: AgencyList,
    meta: {
      requiresAuth: true,
      requiresAgency: true
    }
  },
  {
    path: "/editagency/:id",
    name: "edit-agency",
    component: EditAgency,
    meta: {
      requiresAuth: true,
      requiresAdmin: true
    }
  },
  {
    path: "/mymatches/",
    name: "matches",
    component: Matches,
    meta: {
      requiresAuth: true,
    }
  }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const requiresAdmin = to.matched.some(x => x.meta.requiresAdmin);
  const requiresAgency = to.matched.some(x => x.meta.requiresAgency);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else if(store.state.user.role == 'admin') {
    next();
  }
   else if(requiresAdmin && store.state.user.role != 'admin') {
    next("/restricted");
  } else if(requiresAgency && store.state.user.role != 'agency') {
    next("/restricted");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
