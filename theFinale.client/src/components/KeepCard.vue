<template>
  <main class="elevation-3" data-bs-toggle="modal" data-bs-target="#keepModal" @click="getKeepById(keep.id)">
    <h1>{{ keep.name }}</h1>
    <img :src="keep.img" alt="">
    <p>{{ keep.description }}</p>
  </main>
</template>


<script>
import { computed } from "vue";
import { Keep } from "../models/Keep.js";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger";
import { keepsService } from "../services/KeepsService";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {
      async getKeepById(keepId) {
        try {
          logger.log('getting keep')
          await keepsService.getKeepById(keepId)
        } catch (error) {
          logger.log('getting keep by id', error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>