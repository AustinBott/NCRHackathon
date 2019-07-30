import Vue from 'vue'
import VueRouter from 'vue-router'
import { MdButton, MdContent, MdTabs, MdCard, MdField} from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

Vue.use(MdContent)
Vue.use(MdTabs)
Vue.use(VueRouter)
Vue.use(MdCard)
Vue.use(MdField)
Vue.use(MdButton)

Vue.config.productionTip = false

import auth from './auth'
import App from './components/App.vue'
import AvailableAgentList from './components/AvailableAgentList.vue'
import AgentDashboard from './components/AgentDashboard.vue'
import ChecksList from './components/ChecksList.vue'

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
    { path: '/agent/:agentId', component: AgentDashboard, beforeEnter: requireAuth },
    { path: '/agent/checks/:agentId', component: ChecksList, beforeEnter: requireAuth },
    { path: '/login', component: Login },
    { path: '/logout',
      beforeEnter (to, from, next) {
        auth.logout()
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
