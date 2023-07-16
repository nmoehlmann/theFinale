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
                        <section class="row mb-2">
                            <div class="d-flex justify-content-between">
                                <!-- TODO add vaults option input -->
                                <button class="btn btn-dark">Save</button>
                                <div class="d-flex gap-2">
                                    <img class="creator-img rounded-circle" :src="keep?.creator?.picture" alt="">
                                    <p>{{ keep?.creator?.name }}</p>
                                </div>
                            </div>
                        </section>
                    </div>
                </section>
            </main>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
    setup(){
        return {
            keep: computed(() => AppState.activeKeep),
            keepImg: computed(() => `url(${AppState.activeKeep.img})`)
        }
    }
}
</script>


<style lang="scss" scoped>

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