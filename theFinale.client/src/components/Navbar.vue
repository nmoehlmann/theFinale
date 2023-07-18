<template>
  <nav class="container-fluid">
    <main class="row">

      <div class="col-4 d-flex gap-5 align-items-center">
        <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
          <div>
            <h1 class="fs-2 fw-medium">Home</h1>
          </div>
        </router-link>

        <div class="dropdown">
          <button class="btn dropdown-toggle create-button fs-2 fw-medium" type="button" data-bs-toggle="dropdown"
            aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#keepForm">new keep</a></li>
            <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#vaultForm">new vault</a></li>
          </ul>
        </div>
      </div>

      <div class="col-4">
        <div class="d-flex justify-content-center">
          <h1>The Keepr Co.</h1>
        </div>
      </div>

      <div class="col-4">
        <div class="d-flex justify-content-end">
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
      backButton: computed(() => AppState.backButtonActive)
    }
  },
  components: { Login }
}
</script>

<style scoped>
h1,
p {
  margin: 0;
}
</style>
