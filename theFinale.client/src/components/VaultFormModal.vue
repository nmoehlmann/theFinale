<template>
  <div class="modal-dialog modal-dialog-centered modal-md">
    <div class="modal-content">
      <main class="container-fluid p-4">
        <form>
          <section class="d-flex justify-content-between align-items-center mb-5">
            <h1>Add Your Vault</h1>
            <button class="cancel-button btn-close" type="button" data-bs-dismiss="modal"></button>
          </section>
          <section>
            <div class="input mb-5 d-flex">
              <input class="input-text" type="text" placeholder="Title..." v-model="editable.name" required minlength="2">
              <span class="required">*</span>
            </div>
            <div class="input mb-5 d-flex">
              <input class="input-text" type="text" placeholder="Image URL..." v-model="editable.img" required>
              <span class="required">*</span>
            </div>
            <div class="col-6 offset-6 d-flex justify-content-end flex-column">
                <div class="">
                    <p class="tiny-text">Private vaults can only be seen by you</p>
                    <div class="d-flex justify-content-start gap-3 mb-3">
                        <input type="checkbox">
                        <p class="fw-bold">Make Vault Private?</p>
                    </div>
                </div>
                <button type="submit" class="btn btn-dark">Create Vault</button>
            </div>
          </section>
        </form>
      </main>
    </div>
  </div>
</template>


<script>
import { ref } from 'vue';

export default {
    setup(){
        const editable = ref({})
        return {
            editable
        }
    }
}
</script>


<style lang="scss" scoped>

    .tiny-text {
        font-size: .80rem;
    }
    .required {
    color: red;
}

  p, h1 {
    margin: 0;
  }

  .input {
    width: 100%;
    border-bottom: solid;
  }

  .input-text {
    all: unset;
    width: 100%
  }

  .description {
    width: 100%;
  }
</style>