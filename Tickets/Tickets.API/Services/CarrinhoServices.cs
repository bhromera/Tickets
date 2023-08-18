using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.API.Contracts.v1.Carrinho;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Models;
using Tickets.Application.Data.Repositories.Interfaces;

namespace Tickets.Services
{
    public class CarrinhoServices : ICarrinhoServices
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IItensCarrinhoRepository _itensCarrinhoRepository;

        public CarrinhoServices(ICarrinhoRepository carrinhoRepository, IItensCarrinhoRepository itensCarrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _itensCarrinhoRepository = itensCarrinhoRepository;
        }

        public async Task<ActionResult> CreateAsync(PostCarrinhoRequest request)
        {
            var carrinho = new Application.Data.Models.Carrinho()
            {
                Id = request.Id,
                IdCliente = request.IdCliente,
                Data = DateTime.Now
            };

            var idCarrinho = _carrinhoRepository.InsertOrUpdate(carrinho);

            var itens = request.Itens.Select(x => new ItensCarrinho()
            {
                IdCarrinho = idCarrinho,
                IdIngresso = x.IdIngresso,
                Quantidade = x.Quantidade,
                Valor = x.Valor
            }).ToList();

            if (!_itensCarrinhoRepository.InsertOrUpdate(itens))
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = _carrinhoRepository.Delete(id);

            if (response == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var carrinhoResponse = new GetCarrinhoResponse();

            var carrinho = _carrinhoRepository.GetById(id);

            if (carrinho != null)
            {
                var itensCarrinho = _itensCarrinhoRepository.GetByCarrinho(carrinho.Id);

                carrinhoResponse.Carrinho = new API.Contracts.v1.Carrinho.Carrinho()
                {
                    Id = carrinho.Id,
                    Data = carrinho.Data,
                    IdCliente = carrinho.IdCliente,
                    ItensCarrinho = itensCarrinho
                };
            }

            if (carrinhoResponse == null)
                return new BadRequestResult();

            return new OkObjectResult(carrinhoResponse);
        }

        public async Task<ActionResult> GetByClienteAsync(int id)
        {
            try
            {
                var carrinhosResponse = new List<GetCarrinhoResponse>();

                var carrinhos = _carrinhoRepository.GetByClienteId(id);

                foreach (var carrinho in carrinhos)
                {
                    var itensCarrinho = _itensCarrinhoRepository.GetByCarrinho(carrinho.Id);

                    var item = new API.Contracts.v1.Carrinho.Carrinho()
                    {
                        Id = carrinho.Id,
                        Data = carrinho.Data,
                        IdCliente = carrinho.IdCliente,
                        ItensCarrinho = itensCarrinho
                    };

                    carrinhosResponse.Add(new GetCarrinhoResponse() { Carrinho = item });
                }

                if (carrinhosResponse == null)
                    return new BadRequestResult();

                return new OkObjectResult(carrinhosResponse);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
