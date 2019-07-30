<template>
  <div id="dashboard">
    <div id="header">
    </div>
    <div id="body">
      <template v-if="$route.matched.length">
          <router-view></router-view>
          <h1> Available Agents </h1>
          <ul id="example-1">
            <li v-for="item in items" v-bind:key="item.id">
              {{ item }}
            </li>
          </ul>
      </template>
      <template v-else>
        <div>
          This is the dashboard homepage.
          <router-link v-if="loggedIn" to="/logout">Log out</router-link>

        </div>
      </template>
    </div>
    <div id="footer">
    </div>
  </div>
</template>

<script>

import auth from '../auth'
export default {
    data () {
      return {
        loggedIn: auth.loggedIn(),
        items: [
          {
            id: 1,
            value: 'a'
          },
          {
            id: 2,
            value: 'b'
          },
          {
            id: 3,
            value: 'c'
          }
          ]
      }
    },
    created () {
      auth.onChange = loggedIn => {
        this.loggedIn = loggedIn
      }
    }
  }
</script>
