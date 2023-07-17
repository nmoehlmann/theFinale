<template>
    <main class="elevation-3 vault-img vault-container d-flex align-items-end justify-content-center">
        <div class="p-2 m-1 text-light title-card">
            <h1>{{ vault.name }}</h1>
        </div>
    </main>
</template>


<script>
import { computed } from 'vue';
import { Vault } from '../models/Vault';

export default {
    props: {
        vault: {type: Vault, required: true}
    },
    setup(props){
        return {
            vaultImg: computed(() => `url(${props.vault?.img})`)
        }
    }
}
</script>


<style lang="scss" scoped>
    .vault-img {
        background-image: v-bind(vaultImg);
        background-position: center;
        background-size: cover;
    }

    .vault-container {
        height: 15rem;
        margin-bottom: 1.5rem;
    }

    .title-card {
        background: rgba(0, 0, 0, 0.41);
        border-radius: 16px;
        box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
        backdrop-filter: blur(13.9px);
        -webkit-backdrop-filter: blur(13.9px);
    }
</style>