<template>
  <main class="">
    <section class="">
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
        AppState.page = "home"
        logger.log(AppState.page)
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
  padding-left: 5rem;
  padding-right: 5rem;
}

@media(max-width: 1000px) {
  .keep-container {
    column-count: 3;
    padding-left: 2rem;
    padding-right: 2rem;
  }
}

@media(max-width: 768px) {
  .keep-container {
    column-count: 2;
    padding-left: 1rem;
    padding-right: 1rem;
  }
}

@media(max-width: 420px) {
  .keep-container {
    column-count: 1;
    padding-left: 1rem;
    padding-right: 1rem;
  }
}
</style>
