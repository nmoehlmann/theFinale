<template>
    <main class="row">
        <div class="col-12">
            <div class="d-flex edit-button">
                <button class="btn btn-dark" v-if="account.id == authAccount.id" data-bs-toggle="offcanvas"
                    data-bs-target="#profileEditor">
                    Profile Editor
                </button>
            </div>
            <img class="coverImg img-fluid" :src="account.coverImg" alt="">
            <div class="d-flex flex-column align-items-center pfp-container">
                <img class="pfp" :src="account?.picture" alt="">
                <h1>{{ account.name }}</h1>
                <p class="display-count">{{ keeps.length }} Keeps | {{ vaults.length }} Vaults</p>
            </div>
        </div>
    </main>
</template>

<!-- <button class="btn btn-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasScrolling" aria-controls="offcanvasScrolling">Enable body scrolling</button>

<div class="offcanvas offcanvas-start" data-bs-scroll="true" data-bs-backdrop="false" tabindex="-1" id="offcanvasScrolling" aria-labelledby="offcanvasScrollingLabel">
  <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasScrollingLabel">Offcanvas with body scrolling</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </div>
<div class="offcanvas-body">
    <p>Try scrolling the rest of the page to see this option in action.</p>
  </div>
</div> -->


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { Account } from '../models/Account';

export default {
    props: {
        account: { type: Account, required: true }
    },
    setup() {

        return {
            keeps: computed(() => AppState.userKeeps),
            vaults: computed(() => AppState.vaults),
            authAccount: computed(() => AppState.account)
        }
    }
}
</script>


<style lang="scss" scoped>
.edit-button {
    position: relative;
    top: 3rem;
    left: 1rem;
}

.display-count {
    font-weight: 600;
    margin-top: .5rem;
}

.pfp-container {
    position: relative;
    bottom: 4rem;
}

.pfp {
    border-radius: 50%;
    height: 15rem;
    aspect-ratio: 1/1;
}

.coverImg {
    object-fit: cover;
    object-position: center;
    width: 100%;
    height: 30rem;
    margin: 0;
}
</style>