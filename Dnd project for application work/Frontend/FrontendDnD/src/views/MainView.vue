<template>
    <v-container>
        <!-- ใช้ v-row แบบไม่มี padding -->
        <v-row no-gutters>
            <!-- card สีแดงสูง 5px เต็มแถว -->
            <v-col cols="12">
                <v-card height="5" color="red" flat></v-card>
            </v-col>
        </v-row>
        <v-row no-gutters>
            <!-- card สีแดงสูง 5px เต็มแถว -->
            <v-col cols="12">
                <v-card height="5" color="white" flat></v-card>
            </v-col>
        </v-row>
        <v-row no-gutters>
            <v-col cols="4">
                <v-card height="5" color="orange" flat></v-card>
            </v-col>
            <v-col cols="4">
                <v-card height="5" color="red" flat></v-card>
            </v-col>
            <v-col cols="4">
                <v-card height="5" color="orange" flat></v-card>
            </v-col>

        </v-row>

        <v-row no-gutters>
            <v-col>
                <v-card height="5" width="1168" color="green" flat></v-card>
            </v-col>
        </v-row>

        <v-row cals ="12" style="height: 300px;">
            <!-- Card 1 -->
            <v-col cols="4" class="d-flex justify-end">
                <v-card height="600"
                        width="380"
                        color="surface-variant"
                        :image="cards[0].image"
                        :title="cards[0].title"
                        :subtitle="cards[0].subtitle">
                </v-card>
                <!-- Left Button -->
                <div class="d-flex align-center justify-center" ml-5>
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
            <v-col cols="4" class="d-flex justify-start">
                <!-- Right Button -->
                <div class="d-flex align-center justify-center">
                    <v-btn icon color="white" @click="rotateRight">
                        <svg-icon type="mdi" :path="mdiChevronRightCircleOutline" />
                    </v-btn>
                </div>
                <v-card height="600"
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

    // cards ข้อมูล
    const cards = ref([
        {
            title: 'Evening sunset',
            subtitle: 'Take a walk down the beach',
            image: '/src/assets/Dwarf.png',
        },
        {
            title: 'Mountain Adventure',
            subtitle: 'Explore the heights',
            image: '/src/assets/Elf.png',
        },
        {
            title: 'City Lights',
            subtitle: 'Enjoy the nightlife',
            image: '/src/assets/Halfing.png',
        },
        {
            title: 'City Lights',
            subtitle: 'Enjoy the nightlife',
            image: '/src/assets/Human.png',
        },
    ])

    // เลื่อนซ้าย
    function rotateLeft() {
        cards.value.unshift(cards.value.pop())
    }

    // เลื่อนขวา
    function rotateRight() {
        cards.value.push(cards.value.shift())
    }
</script>
