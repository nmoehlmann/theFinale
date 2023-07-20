<template>
    <main class="row">
        <div class="col-12">
            <div class="d-flex edit-button">
                <button class="btn btn-dark" v-if="account.id == authAccount.id" data-bs-toggle="offcanvas"
                    data-bs-target="#profileEditor">
                    Profile Editor
                </button>
            </div>
            <div class="img-blur">
                <img class="coverImg img-fluid" :src="account.coverImg" alt="">
            </div>
            <div class="d-flex flex-column align-items-center pfp-container">
                <img class="pfp" :src="account?.picture" alt="">
                <h1>{{ account.name }}</h1>
                <p class="display-count"><span class="keep-count">{{ keeps.length }}</span> Keeps | <span
                        class="vault-count">{{ vaults.length }}</span> Vaults</p>
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
    setup(props) {

        return {
            keeps: computed(() => AppState.userKeeps),
            vaults: computed(() => AppState.vaults),
            authAccount: computed(() => AppState.account),
            backgroundImg: computed(() => `url(${props?.account?.coverImg})`)
        }
    }
}
</script>


<style lang="scss" scoped>
.img-blur {
    background-image: v-bind(backgroundImg);
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    border-radius: 5px;
}

.coverImg {
    object-fit: contain;
    object-position: center;
    width: 100%;
    margin: 0;
    height: 40rem;
    backdrop-filter: blur(4px);
    border-radius: 5px;
}

.edit-button {
    position: relative;
    top: 3rem;
    left: 1rem;
    z-index: 1;
}

.display-count {
    font-weight: 600;
    margin-top: .5rem;
    font-size: 1.5rem;
}

.keep-count,
.vault-count {
    color: var(--purple);
    background-color: var(--darker-dark);
    padding: .25rem;
    border-radius: 10px;
}

.pfp-container {
    position: relative;
    bottom: 8rem;
}

.pfp {
    background-color: black;
    object-fit: contain;
    outline: solid;
    border-radius: 50%;
    height: 15rem;
    aspect-ratio: 1/1;
}
</style>