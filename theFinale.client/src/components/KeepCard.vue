<template>
  <main class="elevation-3 selectable" data-bs-toggle="modal" data-bs-target="#keepModal"
    @click="getKeepById(keep.id, keep.vaultKeepId)" v-if="keep">
    <div class="keep-backgroundImg">
      <img class="keep-img img-fluid" :src="keep.img" alt="">
      <div class="keep-details p-2">
        <section class="d-flex flex-column align-items-start">
          <img :title="keep?.creator?.name" class="rounded-circle pfp" :src="keep?.creator?.picture" alt=""
            v-if="page == 'home'">
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
import { logger } from "../utils/Logger";
import { keepsService } from "../services/KeepsService";
import { AppState } from "../AppState.js";

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
      keepImg: computed(() => `url(${props.keep?.img})`),
      page: computed(() => AppState.page)
    }
  }
}
</script>


<style lang="scss" scoped>
main {
  border-radius: 5px;
}

.keep-backgroundImg {
  background-image: v-bind(keepImg);
  width: 100%;
  background-size: cover;
  background-repeat: no-repeat;
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
  aspect-ratio: 1/1;
  margin-bottom: 1rem;
  object-fit: contain;
  background: rgba($color: #000000, $alpha: .7)
}

.title-card {
  background: rgba(0, 0, 0, 0.41);
  border-radius: 16px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(13.9px);
  -webkit-backdrop-filter: blur(13.9px);
  padding: .25rem;
  font-family: 'Marko One', serif;
}

p,
h1 {
  margin: 0;
}
</style>