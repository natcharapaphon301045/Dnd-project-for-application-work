<template>
    <v-container>
        <v-row cals="12" style="height: 300px;">
            <!-- Card 1 -->
            <v-col cols="4" class="d-flex justify-end mt-5">
                <v-card height="570"
                        width="380"
                        color="surface-variant"
                        :image="cards[0].image"
                        :title="cards[0].title"
                        :subtitle="cards[0].subtitle">
                </v-card>
                <!-- Left Button -->
                <div class="d-flex align-center justify-center ml-5">
                    <v-btn icon color="black" @click="rotateLeft">
                        <svg-icon type="mdi" :path="mdiChevronLeftCircleOutline" />
                    </v-btn>
                </div>
            </v-col>

            <!-- Card 2 -->
            <v-col cols="4">
                <v-card class="mx-auto"
                        height="600"
                        width="500"
                        color="surface-variant"
                        :image="cards[1].image"
                        :title="cards[1].title"
                        :subtitle="cards[1].subtitle">
                </v-card>
            </v-col>

            <!-- Card 3 -->
            <v-col cols="4" class="d-flex justify-start mt-5">
                <!-- Right Button -->
                <div class="d-flex align-center justify-center mr-2">
                    <v-btn icon color="black" @click="rotateRight">
                        <svg-icon type="mdi" :path="mdiChevronRightCircleOutline" />
                    </v-btn>
                </div>
                <v-card height="570 "
                        width="380"
                        color="surface-variant"
                        :image="cards[2].image"
                        :title="cards[2].title"
                        :subtitle="cards[2].subtitle">

                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script setup>
    import { ref } from 'vue'
    import SvgIcon from '@jamescoyle/vue-icon'
    import { mdiChevronLeftCircleOutline, mdiChevronRightCircleOutline } from '@mdi/js'

    const cards = ref([
        {
            title: '',
            subtitle: '',
            image: '/src/assets/Wizard.png',
        },
        {
            title: '',
            subtitle: '',
            image: '/src/assets/Bard.png',
        },
        {
            title: '',
            subtitle: '',
            image: '/src/assets/Cleric.png',
        },
        {
            title: '',
            subtitle: '',
            image: '/src/assets/Fighter.png',
        },
        {
            title: '',
            subtitle: '',
            image: '/src/assets/Rogue.png',
        },
    ])

    function rotateLeft() {
        cards.value.unshift(cards.value.pop())
    }

    function rotateRight() {
        cards.value.push(cards.value.shift())
    }

</script>

