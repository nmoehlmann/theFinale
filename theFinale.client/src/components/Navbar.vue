<template>
  <nav class="container-fluid nav">
    <main class="row">

      <div class="col-4 d-flex gap-3 align-items-center">
        <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
          <div class="home-button">
            <h1 class="fs-2 fw-medium">Home</h1>
          </div>
        </router-link>

        <div class="dropdown" v-if="account.id">
          <button class="btn dropdown-toggle create-button fs-2 fw-medium" type="button" data-bs-toggle="dropdown"
            aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#keepForm"
                @click="autoFocus('keepForm')">new keep</a></li>
            <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#vaultForm"
                @click="autoFocus('vaultForm')">new vault</a></li>
          </ul>
        </div>
      </div>

      <div class="col-4 d-flex justify-content-center align-items-center">
        <div>
          <img class="keepr-img my-3" src="/Keepr-logo.png" alt="">
        </div>
      </div>

      <div class="col-4 d-flex justify-content-end align-items-center">
        <div class="pfp">
          <Login />
        </div>
      </div>

    </main>
  </nav>
</template>

<script>
import { computed } from "vue";
import Login from './Login.vue';
import { AppState } from "../AppState.js";
export default {
  setup() {
    return {
      backButton: computed(() => AppState.backButtonActive),
      account: computed(() => AppState.account),

      autoFocus(modalName) {
        if (modalName == 'keepForm') {
          const modal = document.getElementById('keepForm')
          const input = document.getElementById('title-input')
          modal.addEventListener('shown.bs.modal', () => {
            input.focus()
          })
        }
        if (modalName == 'vaultForm') {
          const modal = document.getElementById('vaultForm')
          const input = document.getElementById('input-vault')
          modal.addEventListener('shown.bs.modal', () => {
            input.focus()
          })
        }
      }
    }
  },
  components: { Login }
}
</script>

<style scoped lang="scss">
.pfp {
  border-radius: 50%;
}

.keepr-img {
  height: 4rem;
}

.home-button {
  background-color: var(--purple);
  border-radius: 15%;
  padding: .25rem;
  margin-left: 2rem;
  transition: 300ms;
}

.home-button:hover {
  background-color: var(--light-purple);
}

.nav {
  border-bottom: solid;
  border-color: var(--purple);
  box-shadow: 2px 4px black;
}

h1,
p {
  margin: 0;
}

@media(max-width: 625px) {
  .keepr-img {
    display: none;
  }
}
</style>
