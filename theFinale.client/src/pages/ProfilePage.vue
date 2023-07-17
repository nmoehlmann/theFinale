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
        })
        return {
            profile: computed(() => AppState.profile),
            vaults: computed(() => AppState.vaults)
        }
    }
}
</script>


<style lang="scss" scoped></style>