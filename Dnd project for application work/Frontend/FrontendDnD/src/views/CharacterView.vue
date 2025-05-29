<template>
    <v-container >
        <v-row cols="12">
            <v-col cols="1"></v-col>

            <v-col cols="8" class="bg-white">
                <h1>All Character</h1>
            </v-col>

            <v-col cols="2" class="bg-white">
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

            <v-col cols="10" class="bg-white">
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
                                    <!-- เมื่อกดปุ่มนี้ จะเด้ง edit model ขึ้นมา-->
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
        <!--Edit character-->
        <v-dialog v-model="dialogEdit" max-width="500">
            <v-card>
                <v-card-title>Edit Character</v-card-title>
                <v-card-text>
                    <v-form @submit.prevent="updateCharacter">
                        <v-row class="d-flex align-center">
                            <v-checkbox v-model="editFlags.characterName"
                                        class="mr-2" />
                            <v-text-field label="Character Name"
                                          v-model="editedCharacter.characterName"
                                          :disabled="!editFlags.characterName"
                                          dense outlined required />
                        </v-row>

                        <v-row class="d-flex align-center">
                            <v-checkbox v-model="editFlags.alignmentId"
                                        class="mr-2" />
                            <v-select label="Alignment"
                                      :items="alignments"
                                      item-title="alignmentName"
                                      item-value="alignmentId"
                                      v-model="editedCharacter.alignmentId"
                                      :disabled="!editFlags.alignmentId"
                                      dense outlined required />
                        </v-row>

                        <v-row class="d-flex align-center">
                            <v-checkbox v-model="editFlags.raceId"
                                        class="mr-2" />
                            <v-select label="Race"
                                      :items="races"
                                      item-title="raceName"
                                      item-value="raceId"
                                      v-model="editedCharacter.raceId"
                                      :disabled="!editFlags.raceId"
                                      dense outlined required />
                        </v-row>

                        <v-row class="d-flex align-center">
                            <v-checkbox v-model="editFlags.classId"
                                        class="mr-2" />
                            <v-select label="Class"
                                      :items="classes"
                                      item-title="className"
                                      item-value="classId"
                                      v-model="editedCharacter.classId"
                                      :disabled="!editFlags.classId"
                                      dense outlined required />
                        </v-row>

                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text @click="dialogEdit = false">Cancel</v-btn>
                            <v-btn color="primary" type="submit">Update</v-btn>
                        </v-card-actions>
                    </v-form>

                </v-card-text>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script setup>
    import { ref, onMounted } from "vue";
    import axios from "axios";
    import { useRouter } from "vue-router";

    const router = useRouter();

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

    const alignments = ref([]);
    const races = ref([]);
    const classes = ref([]);

    const fetchOptions = async () => {
        const [alignmentRes, raceRes, classRes] = await Promise.all([
            axios.get('http://localhost:5145/api/StaticData/Alignment'),
            axios.get('http://localhost:5145/api/StaticData/Race'),
            axios.get('http://localhost:5145/api/StaticData/Class'),
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

    const dialogEdit = ref(false);
    const editFlags = ref({
        characterName: false,
        alignmentId: false,
        raceId: false,
        classId: false,
    });

    const editedCharacter = ref({
        characterId: null,
        characterName: '',
        alignmentId: null,
        raceId: null,
        classId: null
    });

    const editCharacter = (item) => {
        editedCharacter.value = {
            characterId: item.characterId,
            characterName: item.characterName,
            alignmentId: item.alignmentId,
            raceId: item.raceId,
            classId: item.classId
        };
        dialogEdit.value = true;
    };

    const updateCharacter = async () => {
        try {
            const payload = { characterId: editedCharacter.value.characterId };
            if (editFlags.value.characterName) payload.characterName = editedCharacter.value.characterName;
            if (editFlags.value.alignmentId) payload.alignmentId = editedCharacter.value.alignmentId;
            if (editFlags.value.raceId) payload.raceId = editedCharacter.value.raceId;
            if (editFlags.value.classId) payload.classId = editedCharacter.value.classId;

            await axios.put(`http://localhost:5145/api/Character/${payload.characterId}`, payload);
            dialogEdit.value = false;
            await fetchCharacters();
        } catch (error) {
            console.error("Failed to update character:", error);
            alert("Failed to update character");
        }
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
