using DN.AtualizacaoModelos.DTO;
using DN.AutoShopBrasil.Data.Context;
using DN.AutoShopBrasil.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace DN.AtualizacaoModelos
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeCarro = string.Empty; 
            Console.WriteLine("Iniciando JOB");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var _context = new AutoShopBrasilContext();
            try
            {
                //Atualizando marcas
                foreach (var marcaDto in ListarMarcasAsync())
                {
                    if (!_context.Marcas.AsNoTracking().Any(x => x.Nome == marcaDto.name))
                    {
                        var marca = new Marca { Nome = marcaDto.name, Principal = marcaDto.order == "2" ? true : false };
                        _context.Marcas.Add(marca);
                        _context.SaveChanges();
                    }
                }

                //Atualizando carros
                foreach (var marcaDto in ListarMarcasAsync())
                {
                    Guid marcaId = _context.Marcas.FirstOrDefault(x => x.Nome == marcaDto.name).MarcaId;

                    foreach (var carroDto in ListarCarrosPorMarcaAsync(marcaDto.id))
                    {
                        nomeCarro = $"{carroDto.name} - {carroDto.key}";

                        if (!_context.Modelos.AsNoTracking().Any(x => x.NomeCompleto == carroDto.name))
                        {
                            var carro = new Modelo { NomeCompleto = carroDto.name, NomeCompacto = FormatarNomeCompacto(carroDto.key), MarcaId = marcaId };
                            _context.Modelos.Add(carro);
                            _context.SaveChanges();
                        }

                        foreach (var modeloDto in ListarModelosPorMarcaCarroAsync(marcaDto.id, carroDto.id))
                        {
                            Guid carroId = _context.Modelos.FirstOrDefault(x => x.NomeCompleto == carroDto.name).ModeloId;
                            int numero = int.Parse(modeloDto.key.Split('-')[0]);
                            if (numero <= DateTime.Now.Year + 2)
                            {
                                if (!_context.AnoModelo.AsNoTracking().Any(x => x.Ano == numero && x.ModeloId == carroId))
                                {
                                    var anoModeloCarro = new AnoModelo { ModeloId = carroId, Ano = numero };
                                    _context.AnoModelo.Add(anoModeloCarro);
                                    _context.SaveChanges();
                                }
                            }


                        }
                    }
                }

                _context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine($"Operação finalizada em {stopwatch.Elapsed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro {ex.Message} ao buscar o carro: {nomeCarro}");
            }

            Console.WriteLine(Environment.NewLine + "Pressione para finalizar o processo");
            Console.ReadKey();
        }

        private static string FormatarNomeCompacto(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                string[] partes = key.Split('-');

                return key.Substring(0, ((key.Length - 1) - partes[partes.Length - 1].Length)).ToUpper();
            }
            return string.Empty;
        }

        private static IEnumerable<MarcaDTO> ListarMarcasAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://fipeapi.appspot.com/api/1/carros/marcas.json").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var marcas = JsonConvert.DeserializeObject<List<MarcaDTO>>(json);
                    return marcas;
                }
            }
            throw new Exception();
        }

        private static IEnumerable<CarroDTO> ListarCarrosPorMarcaAsync(string idMarca)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"http://fipeapi.appspot.com/api/1/carros/veiculos/{idMarca}.json").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var carros = JsonConvert.DeserializeObject<List<CarroDTO>>(json);
                    return carros;
                }
            }
            throw new Exception();
        }

        private static IEnumerable<ModeloDTO> ListarModelosPorMarcaCarroAsync(string idMarca, string idVeiculo)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"http://fipeapi.appspot.com/api/1/carros/veiculo/{idMarca}/{idVeiculo}.json").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(json);
                    return modelos;
                }
            }
            throw new Exception();
        }
    }
}
