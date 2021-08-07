using ThomasGreg.Domain;
using Xunit;

namespace ThomasGreg.Tests
{
    public class DomainTests
    {
        private readonly Cliente _cliente;
        public DomainTests()
        {
            _cliente = new Cliente("João", "joao.rubens@hotmail.com", "Logotipo A");

        }

        [Fact]
        public void Adicionar_Logradouro_ObterLogradouroAdicionadoNaLista()
        {
            _cliente.AdicionarLogradouro("Avenida Paulista");

            Assert.NotNull(_cliente.Logradouro);
        }

        [Fact]
        public void Atualizar_LogradouroEmListaVazia_ObterLogradouroAdicionado()
        {
            _cliente.AtualizarLogradouro("Praça das Aves", "Avenida Paulista");

            Assert.NotNull(_cliente.Logradouro);
        }

        [Fact]

        public void Atualizar_Logradouro_ObterLogradouroAtualizado()
        {
            Cliente cliente = new Cliente("Jamile", "jamile.alves@hotmail.com", "Logotipo B", "Avenida Duque de Caxias");

            cliente.AdicionarLogradouro("Avenida Paulista");

            cliente.AtualizarLogradouro("Avenida Paulista", "Rua Ribeiro");

            Assert.Equal("Rua Ribeiro", cliente.Logradouro.Find(x => x.Contains("Rua Ribeiro")));
        }

        [Fact]
        public void Remover_Logradouro_RemovidoDaLista()
        {
            Cliente cliente = new Cliente("Jamile", "jamile.alves@hotmail.com", "Logotipo B", "Avenida Duque de Caxias");

            cliente.RemoverLogradouro("Avenida Duque de Caxias");

            Assert.Empty(cliente.Logradouro);
        }
    }
}
