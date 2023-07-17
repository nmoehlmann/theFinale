<template>
    <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
            <main class="container-fluid">
                <section class="row" v-if="keep">
                    <div class="col-lg-6">
                        <div class="keep-img">
                            <!-- img -->
                        </div>
                    </div>
                    <div class="col-lg-6 d-flex flex-column justify-content-between">
                        <section class="row mb-3">
                            <div class="d-flex justify-content-center gap-3">
                                <p><i class="mdi mdi-eye"></i>views {{ keep.views }}</p>
                                <p>kept {{ keep.kept }}</p>
                            </div>
                        </section>
                        <section class="row mb-5">
                            <div class="d-flex flex-column align-items-center">
                                <h1>{{ keep.name }}</h1>
                                <p>{{ keep.description }}</p>
                            </div>
                        </section>
                        <section class="row mb-2" v-if="keep.creatorId">
                            <form @submit.prevent="createVaultKeep()">
                                <div class="d-flex justify-content-between">
                                    <div class="d-flex mx-2">
                                        <select class="vault-options mx-2" v-model="editable.vaultId" required>
                                            <option disabled selected value="">Choose Vault</option>
                                            <option v-for="v in vaults" :key="v.id" value="v.id">{{ v.name }}</option>
                                        </select>
                                        <button class="btn btn-dark">Save</button>
                                    </div>
                                    <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
                                        <div class="d-flex gap-2" data-bs-dismiss="modal">
                                            <img class="creator-img rounded-circle" :src="keep.creator?.picture" alt="">
                                            <p>{{ keep?.creator?.name }}</p>
                                        </div>
                                    </router-link>
                                </div>
                            </form>
                        </section>
                    </div>
                </section>
            </main>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultKeeps } from "../services/VaultKeepsServices.js"

export default {
    setup() {
        const editable = ref({ vaultId: '' })

        return {
            editable,
            keep: computed(() => AppState.activeKeep),
            keepImg: computed(() => `url(${AppState.activeKeep.img})`),
            vaults: computed(() => AppState.vaults),

            async createVaultKeep() {
                try {
                    await vaultKeeps.createVaultKeep(editable.value)
                    editable.value = { vaultId: '' }
                } catch (error) {
                    Pop.error('error creating vaultKeep')
                    logger.log(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.vault-options {
    outline: none;
    border: none;

}

.creator-img {
    height: 2rem;
    aspect-ratio: 1/1;
}

.keep-img {
    background-image: v-bind(keepImg);
    height: 30rem;
    background-position: center;
    background-size: contain;
    background-repeat: no-repeat;
}

p {
    margin: 0;
}
</style>