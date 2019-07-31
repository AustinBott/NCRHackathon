<template>
    <div>
        <p v-if="$route.query.redirect">
            You need to login first.
        </p>
        <form novalidate class="md-layout" @submit.prevent="login">
            <md-card class="md-layout-item md-size-50 md-small-size-100">

                <md-card-header>
                    <div class="md-title">Login</div>
                </md-card-header>

                <md-card-content>
                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <md-field>
                                <label for="email">E-Mail</label>
                                <md-input name="email" id="email" autocomplete="email" v-model="email" placeholder="email" />
                            </md-field>
                        </div>

                        <div class="md-layout-item md-small-size-100">
                            <md-field>
                                <label for="password">
                                    Password
                                    <md-input v-model="pass" placeholder="password" type="password" />
                                </label>
                            </md-field>
                        </div>

                        <md-card-actions>
                            <md-button type="submit">login</md-button>
                        </md-card-actions>

                    </div>
                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <p v-if="error" class="error">Invalid Login</p>
                        </div>
                    </div>
                </md-card-content>
            </md-card>
        </form>
    </div>
</template>

<script>
import auth from '../auth'

export default {
  data () {
    return {
      email: 'joe@example.com',
      pass: 'password1',
      error: false
    }
  },
  methods: {
    login () {
      auth.login(this.email, this.pass, loggedIn => {
        if (!loggedIn) {
          this.error = true
        } else {
          this.$router.replace({path: '/availableAgentList'})
        }
      })
    }
  }
}
</script>

<style>
    .md-card {
        margin: auto;
        margin-top: 5%;
    }

    .error {
        color: red;
        text-decoration: underline;
        text-decoration-color: red;
        text-align: center
    }
    
</style>
