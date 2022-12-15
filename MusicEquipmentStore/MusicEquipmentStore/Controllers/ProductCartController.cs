using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.Context;
using MusicEquipmentStore.Models.ViewModel;
using MusicEquipmentStore.Models;
using System.Security.Policy;

namespace MusicEquipmentStore.Controllers
{
    public class ProductCartController : Controller
    {
        protected MusicEquipmentStoreContext _dbContext;
        string username = "";

        public ProductCartController(MusicEquipmentStoreContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            username = (string)TempData["Username"];
            TempData["username"] = username;
            ProductViewModel productViewMode = new ProductViewModel();
            //productViewModel.Products = await _context.Products.Where(x => x.Id == id).Include(y=>y.CategoryId).FirstOrDefaultAsync();
            productViewMode.Products = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();



            List<Cart> oldCart = _dbContext.Carts.Where(x => x.ProductId == id).ToList();
            UpdateCart updateCart = new UpdateCart();
            int prodQuantity = 0;
            if (oldCart.Count == 0)
            {
                prodQuantity = 1;
                Cart cart = new Cart()
                {
                    ProductId = (int)productViewMode.Products.Id,
                    ProductName = productViewMode.Products.Name,
                    ProductPrice = (prodQuantity * productViewMode.Products.Price).ToString(),
                    ProductQuantity = prodQuantity.ToString(),
                    UserName = username,
                    UserAddress = null
                };



                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5088/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Cart>("cart/AddToCart", cart);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                prodQuantity = oldCart.Count + 1;
                updateCart = new UpdateCart()
                {
                    ProductQuantity = prodQuantity.ToString(),
                    ProductPrice = ((decimal)productViewMode.Products.Price * prodQuantity).ToString(),
                    UserName = username,
                    UpdateStatus = true,
                    ProductName = oldCart[0].ProductName,
                    ProductId = oldCart[0].ProductId
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5088/api/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<UpdateCart>("cart/Update", updateCart);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Add(long id)
        {
            string baseUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";

            username = (string)TempData["Username"];
            TempData["username"] = username;


            bool updatesttaus = true;
            Product product = _dbContext.Products.Find(id);
            //List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();
            Cart cartItem = _dbContext.Carts.Where(c => c.ProductId == id).FirstOrDefault();
            UpdateCart updateCart = new UpdateCart();

            if (cartItem == null)
            {
                updateCart = new UpdateCart()
                {
                    ProductName = product.Name,
                    ProductQuantity = "1",
                    ProductPrice = product.Price.ToString(),
                    UserName = username,
                    UpdateStatus = updatesttaus,
                    ProductId = cartItem.ProductId

                };
            }
            else
            {
                int totalproductquantity = Convert.ToInt32(cartItem.ProductQuantity) + 1;
                updateCart = new UpdateCart()
                {
                    ProductQuantity = totalproductquantity.ToString(),
                    ProductPrice = ((decimal)product.Price * totalproductquantity).ToString(),
                    UserName = username,
                    UpdateStatus = updatesttaus,
                    ProductName = cartItem.ProductName,
                    ProductId = cartItem.ProductId
                };
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP PUT
                var putTask = client.PutAsJsonAsync<UpdateCart>("cart/Update", updateCart);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            };

            return RedirectToAction("Index");

        }

    }
}
