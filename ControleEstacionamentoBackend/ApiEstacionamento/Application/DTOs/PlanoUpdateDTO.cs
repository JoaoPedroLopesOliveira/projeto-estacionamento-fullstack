using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.DTOs
{
    public class PlanoUpdateDTO
    {
        public string Nome;

        //tipo: mensal/semanal
        public string Tipo;

        public decimal Preco;

        //quantidade
        public int QuantidadeVeiculosPermitidos;

        public string Description;

        //null para ser valido em todos os estacionamentos
        public EstacionamentoConfig? estacionamentoConfig;
        
    }
}