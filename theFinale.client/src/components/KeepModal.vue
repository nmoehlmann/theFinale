<template>
    <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
            <main class="container-fluid">
                <section class="row" v-if="keep">
                    <div class="col-lg-6">
                        <div class="keep-img">
                            <!-- img -->
                            <div class="dropdown options-container" v-if="keep?.creatorId == account?.id">
                                <button class="btn btn-dark m-1 dropdown-toggle" type="button" data-bs-toggle="dropdown">
                                    Options
                                </button>
                                <ul class="dropdown-menu">
                                    <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#keepEditor">Edit</a></li>
                                    <li><a class="dropdown-item" href="#" @click.prevent="deleteKeep(keep.id)">Delete</a>
                                    </li>
                                </ul>
                            </div>
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
                        <section class="row mb-2" v-if="keep.creatorId && !keep.vaultKeepId">
                            <form @submit.prevent="createVaultKeep(keep.id)">
                                <div class="d-flex justify-content-between">
                                    <div class="d-flex mx-2">
                                        <select class="vault-options mx-2" v-model="editable.vaultId" required>
                                            <option disabled selected value="">Choose Vault</option>
                                            <option v-for="v in vaults" :key="v.id" :value="v.id">{{ v.name }}</option>
                                        </select>
                                        <button class="btn btn-dark" data-bs-dismiss="modal">Save</button>
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
                        <section class="row mb-2" v-if="keep.creatorId && keep.vaultKeepId">
                            <form @submit.prevent="deleteVaultKeep(keep.vaultKeepId)">
                                <div class="d-flex justify-content-between align-items-center">
                                    <div class="remove-button-container">
                                        <button class="remove-button" type="submit" data-bs-dismiss="modal"><i
                                                class="mdi mdi-cancel"></i>
                                            Remove</button>
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
import { vaultKeepsService } from "../services/VaultKeepsServices.js";
import { keepsService } from "../services/KeepsService.js";
import { Modal } from "bootstrap";

export default {
    setup() {
        const editable = ref({ vaultId: '' })

        return {
            editable,
            keep: computed(() => AppState.activeKeep),
            keepImg: computed(() => `url(${AppState.activeKeep.img})`),
            vaults: computed(() => AppState.myVaults),
            account: computed(() => AppState?.account),

            async createVaultKeep(keepId) {
                try {
                    editable.value.keepId = keepId
                    await vaultKeepsService.createVaultKeep(editable.value)
                    editable.value = { vaultId: '' }
                } catch (error) {
                    Pop.error('error creating vaultKeep')
                    logger.log(error)
                }
            },

            async deleteVaultKeep(vkId) {
                try {
                    await vaultKeepsService.deleteVaultKeep(vkId)
                } catch (error) {
                    Pop.error('error deleting keep in vault')
                    logger.log(error)
                }
            },

            async deleteKeep(keepId) {
                try {
                    if (await Pop.confirm('Are you sure you want to permanently delete your keep!')) {
                        await keepsService.deleteKeep(keepId)
                        Modal.getOrCreateInstance('#keepModal').hide()
                        Pop.success("Keep has been deleted")
                    }
                } catch (error) {
                    Pop.error('error deleting keep')
                    logger.log(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.delete-button {
    position: relative;
    left: 2.5rem;
}

.options-container {
    color: red;
}

.remove-button-container {
    border-bottom: black solid;
    opacity: .8;
}

.remove-button {
    all: unset;
    font-size: 1.4rem;
    cursor: pointer;
}

.remove-button:hover,
.remove-button-container:hover {
    transition-timing-function: ease-in-out;
    transition: 10ms;
    color: red;
    border-bottom: red solid;
}

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