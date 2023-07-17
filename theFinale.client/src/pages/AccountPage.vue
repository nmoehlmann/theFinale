<template>
  <header class="container">
    <UserHero :account="account" />
  </header>
  <main class="container">
    <section class="row">
      <h1>Vaults</h1>
      <div class="col-4" v-for="v in vaults" :key="v.id">
        <VaultCard :vault="v" />
      </div>
    </section>
    <section class="row">
      <h1>Keeps</h1>
      <div class="col-4" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </section>
    </main>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import { accountService } from '../services/AccountService';
export default {
  setup() {
    async function getMyVaults() {
      try {
        await vaultsService.getMyVaults()
      } catch (error) {
        logger.log('error getting my vaults', error)
      }
    }

    // async function getUserKeeps() {
    //   try {
    //     logger.log(AppState.account)
    //     // await keepsService.getUserKeeps()
    //   } catch (error) {
    //     Pop.error(error)
    //     logger.log('error getting my keeps', error)
    //   }
    // }

    onMounted(() => {
      getMyVaults()
      // getUserKeeps()
    })
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped>

</style>
