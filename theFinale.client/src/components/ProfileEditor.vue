<template>
  <header class="offcanvas-header justify-content-end">
    <button class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </header>
  <main class="offcanvas-body">

  </main>
</template>


<script>
import { Account } from "../models/Account.js";

export default {
  props: {
    account: { type: Account, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>