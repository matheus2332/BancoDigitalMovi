<template>
  <v-container
    fill-height
    fluid
    grid-list-xl>
    <v-layout
      justify-center
      wrap
    >
      <v-flex
        xs12
        md8
      >
      <v-alert
        v-model="mensagemDeSucesso"
        dismissible
        type="success"
      >
        Emprestimo realizado com sucesso
      </v-alert>

        <material-card
          color="green"
          title="Solicitar emprestimo"
          :text="'Seu limite atual é ' + this.dadosDoCliente.limiteDisponivel"
        >
        <v-form>
            <v-container py-0>
              <v-layout wrap>
                <v-flex
                  xs12
                  md6
                >
                  <v-text-field
                    label="Nome"
                    v-model="dadosDoCliente.nomeDoCliente"
                    disabled/>
                </v-flex>
                <v-flex
                  xs12
                  md6
                >
                  <v-text-field
                    class="purple-input"
                    label="Data"
                    v-model="dadosDoCliente.data"
                    disabled
                  />
                </v-flex>
                <v-flex
                  xs12
                  md6>
                  <v-text-field
                    class="purple-input"
                    label="Valor do emprestimo"
                    v-model="valorDoEmprestimo"
                    :error-messages="erros"
                    type="number"/>
                </v-flex>
                <v-flex
                  xs12
                  text-xs-right
                >
                  <v-btn
                    class="mx-0 font-weight-light"
                    color="success"
                    @click="solicitar()"
                  >
                    Solicitar
                  </v-btn>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
        </material-card>
      </v-flex>
      <v-flex
        xs12
        md4
      >
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  //
  data: function () {
    return {
      valorDoEmprestimo: "",
      erros: '',
      mensagemDeSucesso: false,
      possuiErros: false,
      dadosDoCliente: []
    }
  },
  mounted() {
      axios
        .get('https://localhost:44311/api/cliente/dados',{
          headers: {
             Authorization: localStorage.authorization,
          }})
        .then(response => this.dadosDoCliente = response.data);
  },
  methods: {
    solicitar () {
      var obj = {
          valorDoEmprestimo: this.valorDoEmprestimo == undefined || this.valorDoEmprestimo == '' ? 0 : this.valorDoEmprestimo
      };
      axios
        .post('https://localhost:44311/api/emprestimo',obj, {
          headers: {
             Authorization: localStorage.authorization,
          },
        })
        .then(response => this.tratarSolicitacaoDeEmprestimo(response.data))
    },
    tratarSolicitacaoDeEmprestimo(result){
        if(this.haErros(result)){
          this.erros = result.errorMessages[0];
        }
        else{ 
          this.mensagemDeSucesso = "emprestimo realizado com sucesso!!!" 
          this.$router.replace({ name: "Table List" });
        }
    },
    haErros(result){
      this.possuiErros = result.errorMessages.length > 0;
      return this.possuiErros;
    },
    getTexto(){
      return "Seu limite atual é " + this.dadosDoCliente.limiteDisponivel;
    }
  }
}
</script>
