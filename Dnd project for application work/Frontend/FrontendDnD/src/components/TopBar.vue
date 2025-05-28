<template>
    <v-card>
        <v-toolbar class="text-white" d-flex align-center px-4 
                   image="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
            <div class="d-flex align-center">
                <span class="text-h6 mr-10 ml-15">Dnd Webapp</span>

                <v-tabs background-color="transparent"
                        height="60">
                    <div class="ml-10"></div>
                    <v-tab :to="{ name: 'MainView' }">MAIN</v-tab>
                    <v-tab :to="{ name: 'Character' }">Character</v-tab>
                    <v-tab :to="{ name: 'Race' }">Race</v-tab>
                    <v-tab :to="{ name: 'Class' }">Class</v-tab>
                </v-tabs>
            </div>
        </v-toolbar>
    </v-card>
</template>

<script setup>
    import { ref, watch } from 'vue'
    import { useRoute } from 'vue-router'

    const route = useRoute()
    const currentTab = ref(route.fullpath)

    watch(() => route.fullpath, (newPath) => {
        currentTab.value = newPath
    })
</script>