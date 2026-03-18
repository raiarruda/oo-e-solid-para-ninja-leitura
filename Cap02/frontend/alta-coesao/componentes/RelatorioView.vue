<script setup lang="ts">
import { onMounted } from 'vue'
import { useRelatorio } from '@/composables/useRelatorio'
import { formatarMoeda } from '@/utils/formatador'

const { dados, total, carregar, exportar } = useRelatorio()

onMounted(() => {
  carregar()
})
</script>

<template>
  <div>
    <h1>Total: {{ formatarMoeda(total) }}</h1>

    <button @click="exportar">Exportar CSV</button>

    <ul>
      <li v-for="(item, index) in dados" :key="index">
        {{ item.valor }}
      </li>
    </ul>
  </div>
</template>