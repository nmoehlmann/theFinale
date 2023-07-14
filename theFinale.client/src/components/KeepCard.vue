<template>
  <main class="elevation-3">
    <h1>{{ keep.name }}</h1>
    <img :src="keep.img" alt="">
    <p>{{ keep.description }}</p>
  </main>
</template>


<script>
import { computed } from "vue";
import { Keep } from "../models/Keep.js";
import { AppState } from "../AppState.js";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {
    }
  }
}
</script>


<style lang="scss" scoped></style>