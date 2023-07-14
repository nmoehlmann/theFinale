<template>
  <main class="d-flex elevation-3 justify-content-center">
    <form @submit.prevent="createKeep()">
      <div>
        <label for="name">Name:</label>
        <input type="text" v-model="editable.name">
      </div>
      <div>
        <label for="img">Img:</label>
        <input type="text" v-model="editable.img">
      </div>
      <div>
        <label for="name">Description:</label>
        <input type="text" v-model="editable.description">
      </div>
      <div>
        <button type="submit">Submit</button>
      </div>
    </form>
  </main>
</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js"

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
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>