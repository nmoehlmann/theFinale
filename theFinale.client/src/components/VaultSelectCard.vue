<template>
  <main class="vault-img-background d-flex flex-column selectable" @click="createVaultKeep(vault.id)">
    <div>
      <i class="mdi mdi-lock" v-if="vault.isPrivate"></i>
    </div>
    <div class="title-card d-flex flex-column align-items-center">
      <h1 class="fs-2">{{ vault.name }}</h1>
      <p>By: {{ vault.creator.name }}</p>
    </div>
  </main>
</template>


<script>
import { computed, ref } from "vue";
import { Vault } from "../models/Vault.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultKeepsService } from "../services/VaultKeepsServices.js";
import { AppState } from "../AppState.js";

export default {
  props: {
    vault: { type: Vault, required: true }
  },
  setup(props) {
    const editable = ref({})
    return {
      editable,
      vaultImg: computed(() => `url(${props.vault.img})`),

      async createVaultKeep(vaultId) {
        try {
          editable.value.vaultId = vaultId
          editable.value.keepId = AppState.activeKeep.id
          await vaultKeepsService.createVaultKeep(editable.value)
          AppState.vaultSelector = false
          Pop.success('Added keep to vault')
        } catch (error) {
          Pop.error('error adding keep to vault')
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
i {
  color: red;
  font-size: 2rem;
}

.title-card {
  background: rgba($color: #000000, $alpha: .7);
  color: white;
  padding: .5rem;
  border-radius: 15px;
}

.vault-img {
  background-image: v-bind(vaultImg);
  background-size: contain;
  background-repeat: no-repeat;
  height: 15rem;
  backdrop-filter: blur(8px);

  display: flex;
  justify-content: center;
  align-items: center;

  // height: 100%;
  // width: 100%;
}

.vault-img-background {
  background-image: v-bind(vaultImg);
  background-size: cover;
  background-repeat: no-repeat;
  height: 15rem;

  display: flex;
  justify-content: center;
  align-items: center;

  margin-bottom: 1.5rem;
  border-radius: 8px;
}

p,
h2,
h1 {
  margin: 0;
}
</style>