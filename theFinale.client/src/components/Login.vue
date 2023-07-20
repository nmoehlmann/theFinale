<template>
  <span class="navbar-text">
    <button class="btn selectable lighten-30 text-uppercase my-2 my-lg-0 login-button mdi mdi-login" @click="login"
      v-if="!user.isAuthenticated">
      Login
    </button>
    <div v-else class="d-flex p-2">
      <div class="dropdown my-lg-0">
        <div type="button"
          class="border-0 selectable no-select pfp-container d-flex justify-content-center align-items-center"
          data-bs-toggle="dropdown">
          <div v-if="account.picture || user.picture" class="">
            <img :src="account.picture || user.picture" alt="account photo" height="40"
              class="pfp img-fluid rounded-circle" />
          </div>
        </div>
        <div class="dropdown-menu dropdown-menu-lg-end dropdown-menu-start p-0" aria-labelledby="authDropdown">
          <div class="list-group">
            <router-link :to="{ name: 'Account' }">
              <div class="list-group-item dropdown-item list-group-item-action">
                Manage Account
              </div>
            </router-link>
            <div class="list-group-item dropdown-item list-group-item-action text-danger selectable" @click="logout">
              <i class="mdi mdi-logout"></i>
              logout
            </div>
          </div>
        </div>
      </div>
    </div>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.login-button {
  font-size: 1.5rem;
}

.pfp {
  height: 4rem;
  object-fit: contain;
}

.pfp-container {
  background: rgba($color: #000000, $alpha: .5);
  border-radius: 50%;
  height: 4.5rem;
  aspect-ratio: 1/1;
}</style>
