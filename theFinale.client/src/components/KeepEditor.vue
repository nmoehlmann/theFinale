<template>
    <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content container">
            <section class="d-flex justify-content-start mb-3">
                <button class="btn btn-dark back-button" data-bs-toggle="modal" data-bs-target="#keepModal">
                    Back
                </button>
            </section>
            <section class="row">
                <form @submit.prevent="updateKeep(keep?.id)" class="row">
                    <div class="col-6 d-flex flex-column">
                        <div class="d-flex gap-3 mb-3 justify-content-center">
                            <label for="">Image URL</label>
                            <input type="text" v-model="editable.img">
                        </div>
                        <div class="img-container">
                            <img class="img-card elevation-3 m-3" :src="keep?.img" alt="">
                        </div>
                    </div>
                    <div class="col-6 d-flex flex-column justify-content-between">
                        <div class="d-flex gap-3 flex-column align-items-start">
                            <label for="">Title:</label>
                            <input type="text" v-model="editable.name">
                        </div>
                        <div class="d-flex flex-column gap-3 align-items-start my-5">
                            <label class="text-center" for="">Description:</label>
                            <textarea class="description" v-model="editable.description" cols="60" rows="4"></textarea>
                        </div>
                    </div>
                    <div class="d-flex justify-content-end">
                        <button type="submit" class="btn btn-dark m-1">Save</button>
                    </div>
                </form>
            </section>
        </div>
    </div>
</template>


<script>
import { computed, ref, watchEffect } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService';

export default {
    setup(){
        const editable = ref({})

        watchEffect(() => {
            if (!AppState.activeKeep) {
                return
            }
            editable.value = { ...AppState.activeKeep}
        })
        return {
            editable,
            keep: computed(() => AppState.activeKeep),

            async updateKeep(keepId) {
                try {
                    await keepsService.updateKeep(keepId, editable.value)
                } catch (error) {
                    Pop.error('error updating keep')
                    logger.log(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>

    .description {
        min-height: 10rem;
    }

    .back-button {
        margin: 0;
        position: relative;
        right: .8rem;
        border-radius: 0;
    }

    .img-container {
        display: flex;
        justify-content: center;
    }
    .img-card {
        object-fit: contain;
        height: 20rem;
        border-radius: 5px;
        padding: 1rem;
    }
</style>