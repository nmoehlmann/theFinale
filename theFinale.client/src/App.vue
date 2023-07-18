<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

  <Modal id="keepModal" class="modal instant" tabindex="-1" role="dialog">
    <KeepModal />
  </Modal>

  <Modal id="keepForm" class="modal instant" tabindex="-1" role="dialog">
    <KeepFormModal />
  </Modal>

  <Modal id="vaultForm" class="modal instant" tabindex="-1" role="dialog">
    <VaultFormModal />
  </Modal>

  <section class="offcanvas offcanvas-start" data-bs-scroll="true" data-bs-backdrop="true" tabindex="-1"
    id="profileEditor">
    <ProfileEditor :account="account" />
  </section>
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
</style>
