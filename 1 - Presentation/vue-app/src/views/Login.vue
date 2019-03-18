<template>
    <v-layout
      justify-center
      wrap
    >

          <v-flex
        xs12
        md4
      >
             <v-alert
        v-model="dadosDoCliente.erro"
        dismissible
        type="error"
      >
        {{dadosDoCliente.message}}
      </v-alert>
        <material-card
          color="green"
          title="Efetuar login"
        >
        <v-container py-0>
            <v-layout wrap>
                <v-flex
                xs12
                >
                <v-text-field
                    label="Usuario"
                    v-model="input.Usuario"
                    />
                </v-flex>
            </v-layout>
            <v-layout wrap>
                <v-flex
                xs12
                >
                <v-text-field
                    type="password"
                    label="Senha"
                    v-model="input.Senha"
                    />
                </v-flex>
            </v-layout>
          <div class="text-xs-right">

            <v-btn
                class="mx-0 font-weight-light"
                color="success"
                @click="login()"
                >
                Login
            </v-btn>
          </div>
        </v-container>
            </material-card>
            </v-flex>
            </v-layout>

</template>

<script>
import axios from 'axios'

    export default {
        name: 'Login',
        data() {
            return {
                input: {
                    Usuario: "",
                    Senha: ""
                },
                dadosDoCliente: [],
            }
        },
        methods: {
            login() {
                if(this.input.username != "" && this.input.senha != "") {
                    this.autenticar();
                }
            },
            autenticar(){
                axios
                    .post('https://localhost:44311/api/users/login', this.input)
                    .then(response => this.verificarDados(response.data));
            },
            verificarDados(result){
                this.dadosDoCliente = result;
                console.log(this.dadosDoCliente);
                if(this.dadosDoCliente.erro)
                {}
                else{
                    localStorage.authorization = `Bearer ${this.dadosDoCliente.token}`;
                    this.$emit("authenticated", true);     
                    this.$router.replace({ name: "User Profile" });
                }
            }
        }
    }
</script>

<style scoped>
    #login {
        width: 500px;
        border: 1px solid #CCCCCC;
        background-color: #FFFFFF;
        margin: auto;
        margin-top: 200px;
        padding: 20px;
    }
</style>