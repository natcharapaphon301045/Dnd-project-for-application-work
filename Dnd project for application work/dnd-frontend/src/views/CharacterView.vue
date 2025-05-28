<template>
    <div>
        <h1>Character Page</h1>
        <v-table>
            <thead>
                <tr>
                    <th>Character Name</th>
                    <th>Alignment</th>
                    <th>Race</th>
                    <th>Class</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="character in characters" :key="character.id">
                    <td>{{ character.characterName }}</td>
                    <td>{{ character.alignmentName }}</td>
                    <td>{{ character.raceName }}</td>
                    <td>{{ character.className }}</td>
                    <td>
                        <v-btn small color="primary" @click="editCharacter(character.id)">Edit</v-btn>
                        <v-btn small color="error" @click="deleteCharacter(character.id)">Delete</v-btn>
                    </td>
                </tr>
            </tbody>
        </v-table>
    </div>
</template>

<script lang="ts">
    import axios from 'axios'
    import { defineComponent, onMounted, ref } from 'vue'

    export default defineComponent({
        name: 'CharacterView',
        setup() {
            const characters = ref([])

            const fetchCharacters = async () => {
                try {
                    const response = await axios.get('http://localhost:5000/api/character')
                    characters.value = response.data
                } catch (error) {
                    console.error('Error fetching characters:', error)
                }
            }

            const editCharacter = (id: number) => {
                // นำไปหน้าแก้ไข หรือเปิด dialog
                console.log('Edit character with id:', id)
            }

            const deleteCharacter = async (id: number) => {
                try {
                    await axios.delete(`http://localhost:5000/api/character/${id}`)
                    characters.value = characters.value.filter(c => c.id !== id)
                } catch (error) {
                    console.error('Error deleting character:', error)
                }
            }

            onMounted(fetchCharacters)

            return { characters, editCharacter, deleteCharacter }
        },
    })
</script>
