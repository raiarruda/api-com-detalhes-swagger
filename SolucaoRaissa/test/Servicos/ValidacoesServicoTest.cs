
using ApiComDetalhes.Servicos;

namespace tests.Servicos;

public class ValidacoesServicoTest
{
    [Fact(DisplayName ="Verificar palidromo valido")]
    [Trait("Categoria", "Unidade")]
      public void PalindromoValido_Sucesso()
    {
        //arrange
        var validacaoService = new ValidacoesServico();
        var palavra = "arara";

        //act
        var validaPalidromo = validacaoService.ValidarPalidromo(palavra);

        //assert
        Assert.True(validaPalidromo);

    }
    [Fact(DisplayName ="Verificar palidromo invalido")]
    public void PalindromoInvalido_Sucesso()
    {
        //arrange
        var validacaoService = new ValidacoesServico();
        var palavra = "araras";

        //act
        var validaPalidromo = validacaoService.ValidarPalidromo(palavra);

        //assert
        Assert.False(validaPalidromo);

    }
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void PalindromoValidoParametroVazio_Falha(string p)
    {
        //arrange
        var validacaoService = new ValidacoesServico();
        var palavra = p;

        //act
        var excecao = Assert.Throws<ArgumentException>(() => validacaoService.ValidarPalidromo(palavra));

       //assert
        Assert.Equal("A palavra de entrada não pode ser vazia.", excecao.Message);


    }

}
