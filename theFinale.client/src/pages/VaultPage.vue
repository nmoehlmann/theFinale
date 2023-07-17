<template>
  <header class="container" v-if="vault">
    <section class="row">
      <div
        class="col-6 offset-3 vault-img d-flex align-items-center justify-content-end text-light flex-column title-text">
        <h1>{{ vault?.name }}</h1>
        <p>By: {{ vault?.creator?.name }}</p>
      </div>
      <div class="d-flex justify-content-center mt-3 fw-medium fs-3">
        <p>{{ keeps.length }} Keeps</p>
      </div>
    </section>
  </header>
  <main class="container">
    <section class="row">
      <div class="col-4" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </section>
  </main>
</template>


<script>
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { computed, onMounted } from "vue";
import { vaultsService } from "../services/VaultsService.js";
import { AppState } from "../AppState.js";
import { vaultKeepsService } from "../services/VaultKeepsServices.js";

export default {
  setup() {
    const route = useRoute()

    async function getVaultById() {
      try {
        await vaultsService.getVaultById(route.params.id)
      } catch (error) {
        Pop.error('error getting vault')
        logger.log(error)
      }
    }

    async function getVaultKeeps() {
      try {
        await vaultKeepsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Pop.error('error getting keeps in vault')
        logger.log(error)
      }
    }

    onMounted(() => {
      getVaultById()
      getVaultKeeps()
    })
    return {
      vault: computed(() => AppState?.activeVault),
      vaultImg: computed(() => `url(${AppState?.activeVault?.img})`),
      keeps: computed(() => AppState.keepsInVault)
    }
  }
}
</script>


<style lang="scss" scoped>
.vault-img {
  background-image: v-bind(vaultImg);
  height: 20rem;
  background-size: fill;
  background-repeat: no-repeat;
  background-position: center;
  border-radius: 5px;
}

.title-text {
  text-shadow: black 2px 2px 5px;
  font-weight: 600;
}
</style>