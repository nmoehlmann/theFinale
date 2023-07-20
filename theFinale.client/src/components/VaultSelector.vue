<template>
  <header class="d-flex justify-content-center my-2">
    <h1>Select Vault</h1>
  </header>
  <main>
    <section class="row">
      <div class="col-3" v-for="v in myVaults" :key="v.id">
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


<style lang="scss" scoped></style>