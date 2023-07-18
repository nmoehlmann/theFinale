<template>
    <header class="container">
        <UserHero :account="profile" />
    </header>
    <main class="container">
        <section class="row">
            <h1>Vaults</h1>
            <div class="col-4" v-for="v in vaults" :key="v.id">
                <VaultCard :vault="v" />
            </div>
        </section>
        <section class="">
            <h1>Keeps</h1>
            <div class="keep-container">
                <div class="" v-for="k in keeps" :key="k.id">
                    <KeepCard :keep="k" />
                </div>
            </div>
        </section>
    </main>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { profilesService } from '../services/ProfilesService'
import { computed, onMounted } from 'vue';
import { AppState } from "../AppState.js";
import { vaultsService } from "../services/VaultsService.js";
import { keepsService } from "../services/KeepsService.js";

export default {
    setup() {
        const route = useRoute()

        async function getProfile() {
            try {
                await profilesService.getProfileById(route.params.id)
            } catch (error) {
                Pop.error('error getting profile')
                logger.log(error)
            }
        }

        async function getUserVaults() {
            try {
                await vaultsService.getUserVaults(route.params.id)
            } catch (error) {
                Pop.error('couldnt get user vaults', error)
                logger.log(error)
            }
        }

        async function getUserKeeps() {
            try {
                AppState.page = "profile"
                await keepsService.getUserKeeps(route.params.id)
            } catch (error) {
                Pop.error('error getting user keeps')
                logger.log(error)
            }
        }

        // async function getUserKeeps() {
        //     try {

        //     } catch (error) {
        //         Pop.error(error)
        //         logger.log('error getting user keeps', error)
        //     }

        // }

        onMounted(() => {
            getProfile()
            getUserVaults()
            getUserKeeps()
        })
        return {
            profile: computed(() => AppState.profile),
            vaults: computed(() => AppState.vaults),
            keeps: computed(() => AppState.userKeeps)
        }
    }
}
</script>


<style lang="scss" scoped>
.keep-container {
    column-count: 4;
    // padding-left: 5rem;
    // padding-right: 5rem;
}

@media(max-width: 1000px) {
    .keep-container {
        column-count: 3;
        // padding-left: 2rem;
        // padding-right: 2rem;
    }
}

@media(max-width: 768px) {
    .keep-container {
        column-count: 2;
        // padding-left: 1rem;
        // padding-right: 1rem;
    }
}

@media(max-width: 420px) {
    .keep-container {
        column-count: 1;
        // padding-left: 1rem;
        // padding-right: 1rem;
    }
}
</style>