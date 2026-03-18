<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import axios from 'axios'

const dados = ref<any[]>([])
const carregando = ref(false)
const total = ref(0)
const erro = ref('')

// API
const carregarDados = async () => {
  try {
    carregando.value = true
    const response = await axios.get('/dados')
    dados.value = response.data

    // regra de negócio misturada
    total.value = dados.value.reduce(
      (acc, d) => acc + d.valor * 2,
      0
    )
  } catch (e) {
    erro.value = 'Erro ao carregar dados'
  } finally {
    carregando.value = false
  }
}

// lógica duplicada (mesma regra em outro lugar)
const totalFormatado = computed(() => {
  return `R$ ${total.value.toFixed(2)}`
})

// exportação
const exportarCsv = () => {
  const csv = dados.value.map(d => d.valor).join(',')
  console.log(csv)
}

// lógica UI + regra misturada
const temDados = computed(() => dados.value.length > 0)

onMounted(() => {
  carregarDados()
})
</script>

<template>
  <div>
    <h1>Relatório</h1>

    <p v-if="erro">{{ erro }}</p>
    <p v-if="carregando">Carregando...</p>

    <h2>Total: {{ totalFormatado }}</h2>

    <button @click="exportarCsv">Exportar</button>

    <ul v-if="temDados">
      <li v-for="(item, index) in dados" :key="index">
        {{ item.valor }}
      </li>
    </ul>
  </div>
</template>