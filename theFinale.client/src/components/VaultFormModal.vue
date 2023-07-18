<template>
  <div class="modal-dialog modal-dialog-centered modal-md">
    <div class="modal-content">
      <main class="container-fluid p-4">
        <form @submit.prevent="createVault()">
          <section class="d-flex justify-content-between align-items-center mb-5">
            <h1>Add Your Vault</h1>
            <button class="cancel-button btn-close" type="button" data-bs-dismiss="modal"></button>
          </section>
          <section>
            <div class="input mb-5 d-flex">
              <input class="input-text" type="text" placeholder="Title..." v-model="editable.name" required minlength="2">
              <span class="required">*</span>
            </div>
            <div class="input mb-5 d-flex">
              <input class="input-text" type="text" placeholder="Image URL..." v-model="editable.img" required>
              <span class="required">*</span>
            </div>
            <div class="mb-3 d-flex flex-column align-items-center">
              <label for="description">
                <p class="fs-5">Vault Description</p>
              </label>
              <textarea name="description" class="description" cols="30" rows="3" v-model="editable.description" required
                minlength="2"></textarea>
            </div>
            <div class="col-6 offset-6 d-flex justify-content-end flex-column">
              <div class="">
                <p class="tiny-text">Private vaults can only be seen by you</p>
                <div class="d-flex justify-content-evenly mb-3">
                  <input @onchange="editable.isPrivate != editable.isPrivate" type="checkbox"
                    v-model="editable.isPrivate">
                  <p class="fw-bold">Make Vault Private?</p>
                </div>
              </div>
              <button type="submit" class="btn btn-dark">Create Vault</button>
            </div>
          </section>
        </form>
      </main>
    </div>
  </div>
</template>


<script>
import { ref } from 'vue';
import { logger } from '../utils/Logger';
import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService';
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async createVault() {
        try {
          const vaultData = editable.value
          await vaultsService.createVault(vaultData)
          editable.value = {}
          Modal.getOrCreateInstance('#vaultForm').hide()
          Pop.success("Created Vault")
        } catch (error) {
          logger.log('error creating vault', error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.tiny-text {
  font-size: .80rem;
}

.required {
  color: red;
}

p,
h1 {
  margin: 0;
}

.input {
  width: 100%;
  border-bottom: solid;
}

.input-text {
  all: unset;
  width: 100%
}

.description {
  width: 100%;
}
</style>