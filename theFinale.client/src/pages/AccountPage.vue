<template>
  <header class="container">
    <UserHero :account="account" />
  </header>
  <main class="container">
    <h1>Vaults</h1>
    <div class="col-4" v-for="v in vaults" :key="v.id">
      <VaultCard :vault="v" />
    </div>
  </main>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import { vaultsService } from '../services/VaultsService';
export default {
  setup() {
    async function getMyVaults() {
      try {
        await vaultsService.getMyVaults()
      } catch (error) {
        logger.log('error getting my vaults', error)
      }
    }

    onMounted(() => {
      getMyVaults()
    })
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>

<style scoped>

</style>
