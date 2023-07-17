<template>
  <div class="modal-dialog modal-dialog-centered modal-md">
    <div class="modal-content">
      <main class="container-fluid p-4">
        <form @submit.prevent="createKeep()">
          <section class="d-flex justify-content-between align-items-center mb-5">
            <h1>Add Your Keep</h1>
            <button class="cancel-button btn-close" type="button" data-bs-dismiss="modal"></button>
          </section>
          <section>
            <div class="input mb-5 d-flex">
              <input type="text" placeholder="Title..." v-model="editable.name" required minlength="2">
              <span class="required">*</span>
            </div>
            <div class="input mb-5 d-flex">
              <input type="text" placeholder="Image URL..." v-model="editable.img" required>
              <span class="required">*</span>
            </div>
            <div class="mb-3 d-flex flex-column align-items-center">
              <label for="description">
                <p class="fs-5">Keep Description</p>
              </label>
              <textarea name="description" class="description" cols="30" rows="10" v-model="editable.description" required
                minlength="2"></textarea>
            </div>
            <div class="d-flex justify-content-end">
              <button type="submit" class="btn btn-dark">Create</button>
            </div>
          </section>
        </form>
      </main>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js"
import { Modal } from "bootstrap";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async createKeep() {
        try {
          logger.log('creating keep')
          const keepData = editable.value
          await keepsService.createKeep(keepData)
          editable.value = {}
          Modal.getOrCreateInstance('#keepForm').hide()
          Pop.success('Created Keep')
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
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

input {
  all: unset;
  width: 100%
}

.description {
  width: 100%;
}</style>