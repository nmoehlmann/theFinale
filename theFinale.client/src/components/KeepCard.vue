<template>
  <!-- <main class="d-flex flex-column justify-content-between elevation-3 keep-img p-2" data-bs-toggle="modal"
    data-bs-target="#keepModal" @click="getKeepById(keep.id, keep.vaultKeepId)" v-if="keep">
    <div class="d-flex justify-content-end">
      <img class="rounded-circle pfp" :src="keep?.creator?.picture" alt="">
    </div>
    <div class="d-flex justify-content-start title-card text-light p-2 mx-2">
      <h1>{{ keep.name }}</h1>
    </div>
  </main> -->
  <main class="shadow" data-bs-toggle="modal" data-bs-target="#keepModal" @click="getKeepById(keep.id, keep.vaultKeepId)"
    v-if="keep">
    <div class="keep-backgroundImg">
      <img class="keep-img img-fluid" :src="keep.img" alt="">
      <div class="keep-details p-2">
        <section class="d-flex flex-column align-items-start">
          <img class="rounded-circle pfp" :src="keep?.creator?.picture" alt="">
          <div class="title-card text-light">
            <h1>{{ keep.name }}</h1>
          </div>
        </section>
      </div>
    </div>
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
  setup(props) {
    return {
      async getKeepById(keepId, vkId) {
        try {
          logger.log('getting keep')
          await keepsService.getKeepById(keepId, vkId)
        } catch (error) {
          logger.log('getting keep by id', error)
        }
      },
      keepImg: computed(() => `url(${props.keep?.img})`)
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-backgroundImg {
  background-image: v-bind(keepImg);
  width: 100%;
  background-size: cover;
  margin-bottom: 1rem;
  border-radius: 5px;
}

.keep-details {
  display: inline-block;
}

.keep-img {
  visibility: hidden;
  border-radius: 5px;
}

.pfp {
  height: 2.5rem;
  margin-bottom: 1rem;
}

.title-card {
  background: rgba(0, 0, 0, 0.41);
  border-radius: 16px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(13.9px);
  -webkit-backdrop-filter: blur(13.9px);
  padding: .25rem;
}

p,
h1 {
  margin: 0;
}
</style>