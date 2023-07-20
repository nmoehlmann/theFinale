<template>
  <header class="offcanvas-header justify-content-between">
    <h1>Profile</h1>
    <button class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </header>
  <form @submit.prevent="updateAccount()">
    <main class="offcanvas-body">
      <!-- SECTION name -->
      <section class="d-flex gap-3 justify-content-center mb-3">
        <label>Name</label>
        <input type="text" v-model="editable.name">
      </section>
      <section class="d-flex flex-column align-items-center mb-3">
        <label>Picture URL</label>
        <input class="input mb-3" type="text" v-model="editable.picture">
        <img class="pfp" :src="account.picture" alt="">
      </section>
      <section class="d-flex flex-column align-items-center">
        <label>Cover Image URL</label>
        <input class="input mb-3" type="text" v-model="editable.coverImg">
        <img class="coverImg img-fluid" :src="account.coverImg" alt="">
      </section>

    </main>
    <footer>
      <button class="btn btn-dark mb-5" type="submit">Save</button>
    </footer>
  </form>
</template>


<script>
import { ref, watchEffect } from "vue";
import { Account } from "../models/Account.js";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { accountService } from "../services/AccountService.js";

export default {
  props: {
    account: { type: Account, required: true }
  },
  setup() {
    const editable = ref({})

    watchEffect(() => {
      if (!AppState.account) {
        return
      }
      editable.value = { ...AppState.account }
    })
    return {
      editable,

      async updateAccount() {
        try {
          let accountId = AppState?.account?.id
          await accountService.updateAccount(editable.value, accountId)
        } catch (error) {
          Pop.error('error updating the account')
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.coverImg {
  object-fit: contain;
}

.pfp {
  object-fit: contain;
  height: 10rem;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.input {
  width: 80%;
}

.name-card {
  display: flex;
  justify-content: center;
  margin-top: 1rem;
}

footer {
  position: fixed;
  bottom: 0;
  left: 10rem;

}
</style>