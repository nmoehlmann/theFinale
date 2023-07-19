<template>
    <div class="modal-dialog modal-dialog-centered modal-md">
        <div class="modal-content container">
            <section class="d-flex justify-content-between mb-1">
                <h1>Vault Editor</h1>
                <button class="btn btn-close mt-2" data-bs-dismiss="modal"></button>
            </section>
            <section class="row">
                <form action="" class="row" @submit.prevent="updateVault(vault.id)">
                    <div class="col-6">
                        <div
                            class="vault-img d-flex flex-column justify-content-end align-items-center title-text text-light">
                            <h1>{{ vault.name }}</h1>
                            <p>By: {{ vault?.creator?.name }}</p>
                        </div>
                    </div>
                    <div class="col-6 d-flex flex-column">
                        <div class="d-flex flex-column align-items-center mb-3">
                            <label>Title</label>
                            <input type="text" v-model="editable.name">
                        </div>
                        <div class="d-flex flex-column align-items-center mb-3">
                            <label>Image URL</label>
                            <input type="text" v-model="editable.img">
                        </div>
                        <div class="d-flex justify-content-center align-items-center gap-2 mb-5">
                            <label for="">Private:</label>
                            <input type="checkbox" :checked="editable.isPrivate" v-model="editable.isPrivate">
                        </div>
                        <div class="d-flex justify-content-center">
                            <button class="btn btn-dark" type="submit">Save</button>
                        </div>
                    </div>
                </form>
            </section>
        </div>
    </div>
</template>


<script>
import { computed, ref, watchEffect } from 'vue';
import { AppState } from '../AppState';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultsService } from "../services/VaultsService.js";

export default {
    setup() {
        const editable = ref({})

        watchEffect(() => {
            if (!AppState.activeVault) {
                return
            }
            editable.value = { ...AppState.activeVault }
        })
        return {
            editable,
            vault: computed(() => AppState.activeVault),
            vaultImg: computed(() => `url(${AppState?.activeVault?.img}`),

            async updateVault(vaultId) {
                try {
                    await vaultsService.updateVault(vaultId, editable.value)
                } catch (error) {
                    Pop.error("Error updating vault")
                    logger.log(error)
                }
            }
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