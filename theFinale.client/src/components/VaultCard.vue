<template>
    <router-link :to="{ name: 'Vault', params: { id: vault.id } }">
        <main class="elevation-3 vault-img vault-container d-flex flex-column justify-content-between">
            <div>
                <i title="Private Vault" class="mdi mdi-lock locked" v-if="checkPrivate(vault.id)"></i>
            </div>
            <div class="p-2 m-1 text-light title-card">
                <h1>{{ vault.name }}</h1>
            </div>
        </main>
    </router-link>
</template>


<script>
import { computed } from 'vue';
import { Vault } from '../models/Vault';
import { AppState } from "../AppState.js";

export default {
    props: {
        vault: { type: Vault, required: true }
    },
    setup(props) {
        return {
            vaultImg: computed(() => `url(${props.vault?.img})`),
            vaults: computed(() => AppState.vaults),

            checkPrivate(vaultId) {
                let vault = AppState.vaults.find(v => v.id == vaultId)
                if (vault.isPrivate == true) {
                    return true
                } else {
                    return false
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.locked {
    color: red;
    font-size: 2rem;
}

.vault-img {
    background-image: v-bind(vaultImg);
    background-position: center;
    background-size: cover;
}

.vault-container {
    height: 15rem;
    margin-bottom: 1.5rem;
    border-radius: 5px;
}

.title-card {
    background: rgba(0, 0, 0, 0.41);
    border-radius: 16px;
    box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
    backdrop-filter: blur(13.9px);
    -webkit-backdrop-filter: blur(13.9px);
}
</style>