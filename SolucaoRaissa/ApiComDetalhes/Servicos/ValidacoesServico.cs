namespace ApiComDetalhes.Servicos;

public class ValidacoesServico
{
    public bool ValidarPalidromo(string palavra)
    {
        // try
        // {
            if (string.IsNullOrEmpty(palavra))
            {
                throw new ArgumentException("A palavra de entrada não pode ser vazia.");
            }

            var invertida = new string(palavra.Reverse().ToArray());

            return (palavra == invertida);
        // }
        // catch (ArgumentException ex)
        // {
        //     Console.WriteLine("Palavra invalida", ex.Message);
        //     return false;
        // }
    }
}