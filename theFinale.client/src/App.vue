<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

  <Modal id="keepModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="keep enhanced view">
    <KeepModal />
  </Modal>

  <Modal id="keepForm" class="modal instant" tabindex="-1" role="dialog" aria-labelledby="create keep form">
    <KeepFormModal />
  </Modal>

  <Modal id="vaultForm" class="modal instant" tabindex="-1" role="dialog" aria-labelledby="create vault form">
    <VaultFormModal />
  </Modal>

  <section class="offcanvas offcanvas-start" data-bs-scroll="true" data-bs-backdrop="true" tabindex="-1"
    id="profileEditor" aria-labelledby="profile editor">
    <ProfileEditor :account="account" />
  </section>

  <Modal id="keepEditor" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="keep editor">
    <KeepEditor />
  </Modal>

  <Modal id="vaultEditor" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="vault editor">
    <VaultEditor />
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState),
      account: computed(() => AppState?.account)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

main {
  background-color: var(--light-white)
}

.modals {
  background-color: var(--light-white)
}
</style>
