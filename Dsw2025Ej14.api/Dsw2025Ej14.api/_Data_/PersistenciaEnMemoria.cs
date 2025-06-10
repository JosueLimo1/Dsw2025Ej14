using System.Text.Json;
using Dsw2025Ej14.api._Domain_;

namespace Dsw2025Ej14.api._Data_
{
    public class PersistenciaEnMemoria
    {
        private readonly List<product> _product = new();

        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        /*private void LoadProducts()
        {
            var json = File.ReadAllText("Data\\products.json" "")
        }
        */

        private void LoadProducts()
        {
           
            if (!File.Exists("products.json")) return;

            
            var json = File.ReadAllText("products.json");

          
            var products = JsonSerializer.Deserialize<List<product>>(json);

           
            if (products != null)
                _product.AddRange(products);
        }

        // Método para obtener todos los productos
        public List<product> GetAll()
        {
            return _product;
        }

        // Método para buscar un producto por su SKU
        public product? GetBySku(string sku)
        {
            return _product.FirstOrDefault(p => p.sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
        }
    }
}

    

