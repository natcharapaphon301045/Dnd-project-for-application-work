<template>
    <v-container>
        <v-row cols="12">
            <v-col cols="1"></v-col>

            <v-col cols="9">
                <h1>All Character</h1>
            </v-col>

            <v-col cols="2">
                <v-btn color="primary" class="mb-4 mt-5" @click="openDialog">
                    Create Character
                </v-btn>
            </v-col>
        </v-row>
        <!-- Modal Create Character -->
        <v-dialog v-model="dialog" max-width="500">
            <v-card>
                <v-card-title>Create New Character</v-card-title>
                <v-card-text>
                    <v-form @submit.prevent="createCharacter">
                        <v-text-field label="Character Name"
                                      v-model="newCharacter.characterName"
                                      dense
                                      outlined
                                      required />

                        <v-select label="Alignment"
                                  :items="alignments"
                                  item-title="alignmentName"
                                  item-value="alignmentId"
                                  v-model="newCharacter.alignmentId"
                                  dense
                                  outlined
                                  required />

                        <v-select label="Race"
                                  :items="races"
                                  item-title="raceName"
                                  item-value="raceId"
                                  v-model="newCharacter.raceId"
                                  dense
                                  outlined
                                  required />

                        <v-select label="Class"
                                  :items="classes"
                                  item-title="className"
                                  item-value="classId"
                                  v-model="newCharacter.classId"
                                  dense
                                  outlined
                                  required />

                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text @click="dialog = false">Cancel</v-btn>
                            <v-btn color="primary" type="submit">Create</v-btn>
                        </v-card-actions>
                    </v-form>
                </v-card-text>
            </v-card>
        </v-dialog>
        <!-- Table part -->
        <v-row cols="12">
            <v-col cols="1"></v-col>

            <v-col cols="10">
                <table class="v-data-table elevation-1" style="width: 100%; border-collapse: collapse;">
                    <thead>
                        <tr>
                            <th style="padding: 8px;"></th>
                            <th style="text-align:left; padding: 8px; border-bottom: 1px solid #ddd;">Character Name</th>
                            <th style="text-align:left; padding: 8px; border-bottom: 1px solid #ddd;">Alignment</th>
                            <th style="text-align:left; padding: 8px; border-bottom: 1px solid #ddd;">Race</th>
                            <th style="text-align:left; padding: 8px; border-bottom: 1px solid #ddd;">Class</th>
                            <th style="text-align:left; padding: 8px; border-bottom: 1px solid #ddd;">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in characters" :key="item.characterId">
                            <td style="padding: 20px;"></td>
                            <td style="padding: 8px;">{{ item.characterName }}</td>
                            <td style="padding: 8px;">{{ item.alignmentName }}</td>
                            <td style="padding: 8px;">{{ item.raceName }}</td>
                            <td style="padding: 8px;">{{ item.className }}</td>
                            <td style="padding: 8px;">
                                <v-btn icon @click="editCharacter(item)">
                                    <v-icon>mdi-pencil</v-icon>
                                </v-btn>
                                <v-btn icon @click="deleteCharacter(item.characterId)">
                                    <v-icon color="red">mdi-delete</v-icon>
                                </v-btn>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </v-col>

            <v-col cols="1"></v-col>
        </v-row>
    </v-container>
</template>

<script setup>
    import { ref, onMounted } from "vue";
    import axios from "axios";
    import { useRouter } from "vue-router";

    const router = useRouter();

    // Modal
    const dialog = ref(false);

    const newCharacter = ref({
        characterName: '',
        alignmentId: null,
        raceId: null,
        classId: null,
    });

    const openDialog = () => {
        console.log("Open dialog triggered")
        newCharacter.value = { characterName: '', alignmentId: null, raceId: null, classId: null };
        dialog.value = true;
    };

    // Dropdown data
    const alignments = ref([]);
    const races = ref([]);
    const classes = ref([]);

    const fetchOptions = async () => {
        const [alignmentRes, raceRes, classRes] = await Promise.all([
            axios.get('http://localhost:5145/api/Alignment'),
            axios.get('http://localhost:5145/api/Race'),
            axios.get('http://localhost:5145/api/Class'),
        ]);
        alignments.value = alignmentRes.data.data;
        races.value = raceRes.data.data;
        classes.value = classRes.data.data;
    };

    const createCharacter = async () => {
        try {
            await axios.post('http://localhost:5145/api/Character', newCharacter.value);
            dialog.value = false;
            await fetchCharacters();
        } catch (error) {
            console.error('Failed to create character:', error);
            alert('Failed to create character');
        }
    };

    // Table
    const characters = ref([]);

    const fetchCharacters = async () => {
        try {
            const response = await axios.get('http://localhost:5145/api/Character');
            characters.value = response.data.data;
        } catch (error) {
            console.error('Error fetching characters:', error);
        }
    };

    const editCharacter = (item) => {
        router.push({ name: "EditCharacter", params: { id: item.characterId } });
    };

    const deleteCharacter = async (id) => {
        if (confirm("Are you sure you want to delete this character?")) {
            await axios.delete(`http://localhost:5145/api/Character/${id}`);
            await fetchCharacters();
        }
    };

    onMounted(() => {
        fetchCharacters();
        fetchOptions();
    });
</script>
