<script setup>
    import TopBar from './components/TopBar.vue'
</script>

<template>
    <v-app class="app-root">
        <TopBar />
        <v-main class="main-background">
            <v-container fluid>
                <router-view />
            </v-container>
        </v-main>
    </v-app>
</template>

<style>

</style>
