<template>
  <header class="d-flex justify-content-center py-2 my-2 title-card">
    <h1>Select a vault to save keep</h1>
  </header>
  <main class="selector-body">
    <section class="row">
      <div class="col-6 col-lg-3" v-for="v in myVaults" :key="v.id">
        <VaultSelectCard :vault="v" />
      </div>
    </section>
  </main>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {
    return {
      myVaults: computed(() => AppState.myVaults)
    }
  }
}
</script>


<style lang="scss" scoped>
.title-card {
  background-color: var(--light-brown);
  width: 100%;
}

.selector-body {
  // background-color: var(--light-purple)
}
</style>