<template>
    <!-- Top Bar -->
    <v-app-bar app color="primary" dark>
        <v-toolbar-title>DnD App</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn text :to="'/'" router> Main </v-btn>
        <v-btn text :to="'/characters'" router> Character </v-btn>
        <v-btn text :to="'/races'" router> Race </v-btn>
        <v-btn text :to="'/classes'" router> Class </v-btn>
    </v-app-bar>

    <v-app>
        <v-main>
            <router-view />
        </v-main>
    </v-app>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'App',

  data () {
    return {
      //
    }
  },
})
</script>
