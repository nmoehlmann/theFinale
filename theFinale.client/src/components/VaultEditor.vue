<template>
    <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content container">
            <section class="d-flex justify-content-end">
                <button class="btn btn-close" data-bs-dismiss="modal"></button>
            </section>
            <section class="row">
                <div class="col-6">
                    <div class="vault-img d-flex flex-column justify-content-end align-items-center title-text text-light">
                        <h1>{{ vault.name }}</h1>
                        <p>By: {{ vault?.creator?.name }}</p>
                    </div>
                </div>
                <div class="col-6">
                    <div class="d-flex flex-column align-items-center mb-3">
                        <label>Title</label>
                        <input type="text">
                    </div>
                    <div class="d-flex flex-column align-items-center mb-3">
                        <label>Image URL</label>
                        <input type="text">
                    </div>
                    <div class="d-flex justify-content-center align-items-center gap-2">
                        <label for="">Private:</label>
                        <input type="checkbox">
                    </div>
                </div>
            </section>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
    setup(){
        return {
            vault: computed(() => AppState.activeVault),
            vaultImg: computed(() => `url(${AppState?.activeVault?.img}`)
        }
    }
}
</script>


<style lang="scss" scoped>


.vault-img {
  background-image: v-bind(vaultImg);
  height: 20rem;
  background-size: fill;
  background-repeat: no-repeat;
  background-position: center;
  border-radius: 5px;
}

.title-text {
  text-shadow: black 2px 2px 5px;
  font-weight: 600;
}
</style>