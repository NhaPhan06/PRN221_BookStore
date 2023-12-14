using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Presentation.Pages {
    public class Cart : PageModel {
        public IList<Carts> Carts { get; set; } = default!;

        [BindProperty] public decimal total { get; set; }

        public void OnGet() {
            Carts = new List<Carts>();
            string? jsoncart = HttpContext.Session.GetString("cart");
            if (jsoncart != null) {
                Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
            }

            if (Carts.Count != 0) {
                foreach (Carts c in Carts) {
                    total += c.Price * c.StockQuantity;
                }
            } else {
                total = 0;
            }
        }
    }
}