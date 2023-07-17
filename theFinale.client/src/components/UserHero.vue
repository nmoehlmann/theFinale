<template>
    <main class="row">
        <div class="col-12">
            <img class="coverImg img-fluid" src="https://codetheweb.blog/assets/img/posts/css-advanced-background-images/cover.jpg" alt="">
            <div class="d-flex flex-column align-items-center pfp-container">
                <img class="pfp" :src="account.picture" alt="">
                <h1>{{ account.name }}</h1>
            </div>
        </div>
    </main>
</template>


<script>
import { Account } from '../models/Account';

export default {
    props: {
        account: {type: Account, required: true}
    },
    setup(){
        
        return {}
    }
}
</script>


<style lang="scss" scoped>

    .pfp-container {
        position: relative;
        bottom: 4rem;
    }

    .pfp {
        border-radius: 50%;
    }
    .coverImg {
        object-fit: cover;
        object-position: center;
        width: 100%;
        height: 30rem;
    }
</style>