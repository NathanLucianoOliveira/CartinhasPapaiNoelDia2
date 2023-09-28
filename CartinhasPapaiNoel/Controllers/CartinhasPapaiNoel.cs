using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CartinhasDoPapaiNoel
{
    [ApiController]
    [Route("[controller]")]
    public class CartinhasPapaiNoelController: ControllerBase
    {


        private readonly string Cartinhas;

        public CartinhasPapaiNoelController()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Cartinhas = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Cartinhas.json");
        }
        private List<Carta> LerCartasDoArquivo()
        {
            if (!System.IO.File.Exists(Cartinhas))
            {
                return new List<Carta>();
            }

            string json = System.IO.File.ReadAllText(Cartinhas);
            return JsonConvert.DeserializeObject<List<Carta>>(json);
        }

        private void EscreverCartasNoArquivo(List<Carta> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(Cartinhas, json);
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(LerCartasDoArquivo());

        }

        [HttpPost]

        public IActionResult Post([FromBody] Carta newCarta)
        {

            List<Carta> cartas = LerCartasDoArquivo();

            Carta novaCarta = new Carta()
            {

                NomeCrianca = newCarta.NomeCrianca,
                Endereco = newCarta.Endereco,
                IdadeCrianca = newCarta.IdadeCrianca,
                TextoCarta = newCarta.TextoCarta
            };

            cartas.Add(novaCarta);
            EscreverCartasNoArquivo(cartas);

            return CreatedAtAction(nameof(Get), new { codigo = novaCarta.NomeCrianca }, novaCarta);
        }


    }
}
