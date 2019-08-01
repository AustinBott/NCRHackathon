import Vue from 'vue'
import VueRouter from 'vue-router'
import { MdButton, MdContent, MdTabs, MdCard, MdField, MdBottomBar, MD} from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

Vue.use(MdContent)
Vue.use(MdTabs)
Vue.use(VueRouter)
Vue.use(MdCard)
Vue.use(MdField)
Vue.use(MdButton)
Vue.use(MdBottomBar)

Vue.config.productionTip = false

import auth from './auth'
import App from './components/App.vue'
import AvailableAgentList from './components/AvailableAgentList.vue'
import AgentDashboard from './components/AgentDashboard.vue'
import ChecksList from './components/ChecksList.vue'
import EditCheck from './components/EditCheck.vue'
import AddCheck from './components/AddCheck.vue'

import Login from './components/Login.vue'

function requireAuth (to, from, next) {
  if (!auth.loggedIn()) {
    next({
      path: '/login',
      query: { redirect: to.fullPath }
    })
  } else {
    next()
  }
}

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/availableAgentList', component: AvailableAgentList, beforeEnter: requireAuth },
    { path: '/agent/dashboard/:agentId', component: AgentDashboard, beforeEnter: requireAuth, props: true },
    { path: '/checkslist/', component: ChecksList, beforeEnter: requireAuth, props: true },
    { path: '/checkslist/editcheck/:checkName', component: EditCheck, beforeEnter: requireAuth, props: true },
    { path: '/checkslist/addcheck', component: AddCheck, beforeEnter: requireAuth, props: true },
    { path: '/checkslist/:agentId', component: ChecksList, beforeEnter: requireAuth, props: true },
    { path: '/login', component: Login },
    { path: '/', component: AvailableAgentList, beforeEnter: requireAuth },
    { path: '/logout',
      beforeEnter (to, from, next) {
        auth.logout()
        console.log("logging user out");
        next('/login')
      }
    }
  ]
})

new Vue({
  el: '#app',
  router,
  // replace the content of <div id="app"></div> with App
  render: h => h(App)
})
