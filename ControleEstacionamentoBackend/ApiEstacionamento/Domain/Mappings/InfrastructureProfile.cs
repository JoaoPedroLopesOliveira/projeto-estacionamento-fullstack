using ApiEstacionamento.Entities;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;

namespace ApiEstacionamento.Domain.Mappings
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            
        CreateMap<Veiculo, VeiculoEntity>();
        CreateMap<VeiculoEntity, Veiculo>();
        // TODO
        //CreateMap<Cliente, ClienteEntity>();
        //CreateMap<ClienteEntity, Cliente>();
        //CreateMap<Plano, PlanoEntity>();
        //CreateMap<PlanoEntity, Plano>();
        //CreateMap<Administrador, AdministradorEntity>();
        //CreateMap<AdministradorEntity, Administrador>();
        //CreateMap<Ticket, TicketEntity>();
        //CreateMap<TicketEntity, Ticket>();
        }
    }
}