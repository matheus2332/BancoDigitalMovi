<template>
  <v-container
    fill-height
    fluid
    grid-list-xl
  >
    <v-layout
      justify-center
      wrap
    >
      <v-flex
        md12
      >
        <material-card
          color="green"
          title="Meus emprestimos"
        >
          <v-data-table
            :headers="headers"
            :items="items"
            hide-actions
            no-data-text="Ainda não há emprestimos solicitados"
          >
            <template
              slot="headerCell"
              slot-scope="{ header }"
            >
              <span
                class="subheading font-weight-light text-success text--darken-3"
                v-text="header.text"
              />
            </template>
            <template
              slot="items"
              slot-scope="{ item }"
            >
              <td>{{ item.nomeDoCliente }}</td>
              <td>{{ item.data }}</td>
              <td>{{ item.valor }}</td>
            </template>
          </v-data-table>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  
  data: () => ({
    headers: [
      {
        sortable: false,
        text: 'Nome',
        value: 'nomeDoCliente'
      },
      {
        sortable: false,
        text: 'Data',
        value: 'data'
      },
      {
        sortable: false,
        text: 'Valor',
        value: 'valor'
      }
    ],
    items: []
  }),
  mounted() {
      axios
        .get('https://localhost:44311/api/cliente/meus-emprestimos',{
          headers: {
             Authorization: localStorage.authorization,
          }
        })
        .then(response => this.items = response.data);
  },
}
</script>
