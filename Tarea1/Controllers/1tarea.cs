using Microsoft.AspNetCore.Mvc;

namespace Tarea1.Controllers
{
    public class _1tarea : Controller
    {
        #region 8. Diccionario Traducciones
        private static readonly Dictionary<string, string> traducciones = new()
        {
            { "dog", "perro" },
            { "cat", "gato" },
            { "house", "casa" },
            { "car", "auto" }
        };

        [HttpGet("traducir/{palabra}")]
        public IActionResult Traducir(string palabra)
        {
            if (traducciones.TryGetValue(palabra.ToLower(), out string? traduccion))
                return Ok(traduccion);
            else
                return NotFound("Palabra no encontrada");
        }
        #endregion

        // ===================================================
        // 9. Contador de Palabras
        // ===================================================
        #region 9. Contador Palabras
        [HttpPost("contar-palabras")]
        public IActionResult ContarPalabras([FromBody] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return BadRequest("El texto no puede estar vacío.");

            int cantidad = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            return Ok($"El texto tiene {cantidad} palabras.");
        }
        #endregion

        // ===================================================
        // 19. SortedList para Países
        // ===================================================
        #region 19. SortedList Países
        [HttpGet("paises")]
        public IActionResult ObtenerPaises()
        {
            var paises = new SortedList<int, string>
            {
                { 3, "Bolivia" },
                { 1, "Argentina" },
                { 2, "Chile" }
            };
            return Ok(paises);
        }
        #endregion

        // ===================================================
        // 21. Validar Edad
        // ===================================================
        #region 21. Validar Edad
        [HttpGet("validar-edad/{edad}")]
        public IActionResult ValidarEdad(int edad)
        {
            if (edad < 18)
                return BadRequest("Debes ser mayor de 18 años.");
            return Ok("Edad válida.");
        }
        #endregion

        // ===================================================
        // 22. Dividir con Try-Catch
        // ===================================================
        #region 22. Dividir
        [HttpGet("dividir/{a}/{b}")]
        public IActionResult Dividir(int a, int b)
        {
            try
            {
                int resultado = a / b;
                return Ok($"El resultado es {resultado}");
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Error: No se puede dividir entre cero.");
            }
        }
        #endregion

        // ===================================================
        // 23. Excepción Personalizada
        // ===================================================
        #region 23. Excepción Personalizada
        public class MiExcepcion : Exception
        {
            public MiExcepcion(string mensaje) : base(mensaje) { }
        }

        [HttpGet("lanzar-error")]
        public IActionResult LanzarError()
        {
            throw new MiExcepcion("Este es un error personalizado.");
        }
        #endregion

        // ===================================================
        // 28. Agrupar por Categoría
        // ===================================================
        #region 28. Agrupar por Categoría
        [HttpGet("productos/por-categoria")]
        public IActionResult AgruparProductos()
        {
            var productos = new List<(string Nombre, string Categoria)>
            {
                ("Manzana", "Fruta"),
                ("Banana", "Fruta"),
                ("Lechuga", "Verdura"),
                ("Tomate", "Verdura")
            };

            var agrupados = productos.GroupBy(p => p.Categoria)
                .Select(g => new { Categoria = g.Key, Productos = g.Select(p => p.Nombre).ToList() });

            return Ok(agrupados);
        }
        #endregion

        // ===================================================
        // 32. Delegado Func
        // ===================================================
        #region 32. Delegado Func
        [HttpGet("elevar/{numero}")]
        public IActionResult Elevar(int numero)
        {
            Func<int, int> cuadrado = x => x * x;
            return Ok($"El cuadrado de {numero} es {cuadrado(numero)}");
        }
        #endregion

        // ===================================================
        // 30. Any / All
        // ===================================================
        #region 30. Any / All
        [HttpPost("existen-pares")]
        public IActionResult ExistenPares([FromBody] List<int> numeros)
        {
            bool todosPares = numeros.All(n => n % 2 == 0);
            bool algunoPar = numeros.Any(n => n % 2 == 0);

            return Ok(new { TodosPares = todosPares, AlgunoPar = algunoPar });
        }
        #endregion

        // ===================================================
        // 34. Expresión Lambda Filtrar
        // ===================================================
        #region 34. Expresión Lambda
        [HttpPost("filtrar")]
        public IActionResult FiltrarNumeros([FromBody] List<int> numeros)
        {
            var mayores = numeros.Where(n => n > 10).ToList();
            return Ok(mayores);
        }
        #endregion
    }
}
