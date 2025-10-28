using System;
using TesteTecnico.Modelos;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Dados.Banco;
using TesteTecnico.API.Request;
using TesteTecnico.API.Response;
using Microsoft.EntityFrameworkCore;

namespace TesteTecnico.API.EndPoints
{
    public static class EmpresasExtension
    {
        public static void AddEndPointsEmpresas(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("empresas").WithTags("Empresas");

            //LISTAR
            groupBuilder.MapGet("", async ([FromServices] DAL<Empresa> dal) =>
            {
                var listaEmpresas = await dal.ListarAsync();

                if (listaEmpresas is null)
                {
                    return Results.NotFound();
                }

                var listaDeArtistaResponse = EntityListToResponseList(listaEmpresas);
                return Results.Ok(listaDeArtistaResponse);
            });

            //OBTER POR NOME
            groupBuilder.MapGet("nome/{nome}", async ([FromServices] DAL<Empresa> dal, string nome) =>
            {
                var empresas = await dal.RecuperarListaPorAsync(x => EF.Functions.Like(x.Nome, $"{nome}%"));
                
                if (empresas is null)
                {
                    return Results.NotFound();
                
                }
                return Results.Ok(EntityListToResponseList(empresas));
            });

            //OBTER POR ID
            groupBuilder.MapGet("{id}", async ([FromServices] DAL<Empresa> dal, int id) =>
            {
                var empresa = await dal.RecuperarItemPorAsync(x => x.Id == id);

                if (empresa is null)
                {
                    return Results.NotFound();

                }
                return Results.Ok(EntityToResponse(empresa));
            });

            //CADASTRAR
            groupBuilder.MapPost("", async ([FromServices] DAL<Empresa> dal, [FromBody] EmpresaRequest empresaRequest) =>
            {
                var empresa = new Empresa(empresaRequest.Nome, empresaRequest.Cnpj, empresaRequest.Email, empresaRequest.Telefone, empresaRequest.Endereco);

                await dal.AdicionarAsync(empresa);

                return Results.Ok();
            });

            //DELETAR
            groupBuilder.MapDelete("{id}", async ([FromServices] DAL<Empresa> dal, int id) => {
                var empresa = await dal.RecuperarItemPorAsync(x => x.Id == id);

                if (empresa is null)
                {
                    return Results.NotFound();
                }

                await dal.ExcluirAsync(empresa);
                return Results.NoContent();
            });

            //ATUALIZAR
            groupBuilder.MapPut("", async ([FromServices] DAL<Empresa> dal, [FromBody] EmpresaRequestEdit empresaRequestEdit) => {
                var empresaAtualizar = await dal.RecuperarItemPorAsync(x => x.Id == empresaRequestEdit.Id);

                if (empresaAtualizar is null)
                {
                    return Results.NotFound();
                }

                empresaAtualizar.Nome = empresaRequestEdit.Nome;
                empresaAtualizar.Cnpj = empresaRequestEdit.Cnpj;
                empresaAtualizar.Email = empresaRequestEdit.Email;
                empresaAtualizar.Telefone = empresaRequestEdit.Telefone;
                empresaAtualizar.Endereco = empresaRequestEdit.Endereco;

                await dal.AtualizarAsync(empresaAtualizar);
                return Results.Ok();
            });
        }

        private static ICollection<EmpresaResponse> EntityListToResponseList(IEnumerable<Empresa> listaEmpresas)
        {
            return listaEmpresas.Select(x => EntityToResponse(x)).ToList();
        }

        private static EmpresaResponse EntityToResponse(Empresa empresa)
        {
            return new EmpresaResponse(empresa.Id, empresa.Nome, empresa.Cnpj, empresa.Email, empresa.Telefone, empresa.Endereco);
        }
    }
}