<template>
  <main class="d-flex justify-content-center">
    <section class="row">
      <div class="keep-container">
        <div class="keep-card" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </section>
  </main>
</template>

<script>
import { computed, onMounted } from "vue";
import { keepsService } from "../services/KeepsService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";

export default {
  setup() {

    async function getAllKeeps() {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        logger.log(error)
        Pop.error(error)
      }
    }


    onMounted(() => {
      getAllKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">

.keep-container {
  column-count: 4;
  padding-left: 10rem;
  padding-right: 10rem;
}
</style>
