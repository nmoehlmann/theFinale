<template>
    <header class="container">
        <h1>profile page</h1>
    </header>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import {profilesService} from '../services/ProfilesService'
import { onMounted } from 'vue';

export default {
    setup(){
        const route = useRoute()

        async function getProfile() {
            try {
                await profilesService.getProfileById(route.params.id)
            } catch (error) {
                Pop.error('error getting profile')
                logger.log(error)
            }
        }

        async function getUserKeeps() {
            try {
                
            } catch (error) {
                Pop.error(error)
                logger.log('error getting user keeps', error)
            }

        }

        onMounted(() => {
            getProfile()
        })
        return {}
    }
}
</script>


<style lang="scss" scoped>

</style>