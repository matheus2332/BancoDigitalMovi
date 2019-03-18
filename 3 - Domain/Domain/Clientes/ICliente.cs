namespace Domain.Clientes
{
    public interface ICliente
    {
        string Cpf { get; }
        decimal LimiteDeEmprestimo { get; }
        string Nome { get; }
        string Senha { get; }
        string Usuario { get; }
    }
}