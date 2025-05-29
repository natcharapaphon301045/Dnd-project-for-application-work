<template>
    <v-container>
        <v-row cols="12" style="height: 300px;">
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
                        :image="cards[1].image">
                    <v-card-title class="custom-title">
                        {{cards[1].title}}
                    </v-card-title>
                    <v-card-subtitle class="custom-subtitle">
                        {{cards[1].subtitle}}
                    </v-card-subtitle>
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
    import '../style.css';

    const cards = ref([
        {
            title: 'Dwarf',
            subtitle: 'Sturdy miners and warriors',
            image: '/src/assets/Dwarf.png',
        },
        {
            title: 'Elf',
            subtitle: 'Graceful and magical beings',
            image: '/src/assets/Elf.png',
        },
        {
            title: 'Halfing',
            subtitle: 'Small, nimble adventurers',
            image: '/src/assets/Halfing.png',
        },
        {
            title: 'Human',
            subtitle: 'Versatile and ambitious',
            image: '/src/assets/Human.png',
        },
    ])

    function rotateLeft() {
        cards.value.unshift(cards.value.pop())
    }

    function rotateRight() {
        cards.value.push(cards.value.shift())
    }

</script>

