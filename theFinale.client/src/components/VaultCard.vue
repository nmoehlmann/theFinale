<template>
    <main class="elevation-3 vault-img">
        
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
        height: 100px;
    }
</style>