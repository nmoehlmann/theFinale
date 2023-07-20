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
    <section class="">
      <h1>Keeps</h1>
      <div class="keep-container">
        <div class="" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
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

    async function getUserKeeps() {
      try {
        AppState.page = "account"
        logger.log(AppState.page)
        logger.log(AppState.account)
        await accountService.getAccount()
        await keepsService.getUserKeeps(AppState.account.id)
      } catch (error) {
        Pop.error(error)
        logger.log('error getting my keeps', error)
      }
    }

    onMounted(() => {
      getMyVaults()
      getUserKeeps()
    })
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.userKeeps)
    }
  }
}
</script>

<style scoped lang="scss">
.keep-container {
  column-count: 4;
  // padding-left: 5rem;
  // padding-right: 5rem;
}

@media(max-width: 1000px) {
  .keep-container {
    column-count: 3;
    // padding-left: 2rem;
    // padding-right: 2rem;
  }
}

@media(max-width: 768px) {
  .keep-container {
    column-count: 2;
    // padding-left: 1rem;
    // padding-right: 1rem;
  }
}

// @media(max-width: 420px) {
//   .keep-container {
//     column-count: 1;
//     // padding-left: 1rem;
//     // padding-right: 1rem;
//   }
// }
</style>
