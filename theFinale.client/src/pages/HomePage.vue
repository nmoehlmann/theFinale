<template>
  <main>
    <section class="row">
      <div class="col-md-4" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
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
        await keepsService.getAllKeeps(AppState.account.id)
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

<style scoped lang="scss"></style>
