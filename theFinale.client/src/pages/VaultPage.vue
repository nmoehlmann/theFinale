<template>
  <header class="container" v-if="vault">
    <section class="row">
      <div
        class="col-6 offset-3 vault-img d-flex align-items-center justify-content-end text-light flex-column title-text">
        <h1>{{ vault?.name }}</h1>
        <p>By: {{ vault?.creator?.name }}</p>
      </div>
      <div class="d-flex justify-content-center mt-3 fw-medium fs-3">
        <p class="keep-count">{{ keeps.length }} Keeps</p>
        <div class="dropdown options">
          <button class="btn fs-2 fw-medium" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            ...
          </button>
          <ul class="dropdown-menu">
            <li><a @click.prevent="deleteVault()" class="dropdown-item" href="#">Delete Vault</a></li>
          </ul>
        </div>
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
import { router } from "../router.js";

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
      keeps: computed(() => AppState.keepsInVault),

      async deleteVault() {
        try {
          if (await Pop.confirm("Are you sure you want to delete this Vault?")) {
            await vaultsService.deleteVault(route.params.id)
            router.push({ name: 'Home' })
            Pop.success("Deleted Vault")
          }
        } catch (error) {
          Pop.error('error deleting vault')
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-count {
  position: relative;
  left: 2rem;
}

.options {
  position: relative;
  left: 11rem;
  bottom: .5rem;
}

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