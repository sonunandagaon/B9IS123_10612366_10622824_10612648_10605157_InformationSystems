using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.Context;
using MusicEquipmentStore.Models.ViewModel;
using MusicEquipmentStore.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult Index()
        {
            string baseUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";
            username = (string)TempData["Username"];
            TempData["username"] = username;
            // string username = (string)TempData["Username"];
            IEnumerable<Cart> cartitems = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                //HTTP GET
                var responseTask = client.GetAsync("cart/GetCartItems/" + username);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Cart>>();
                    readTask.Wait();
                    cartitems = readTask.Result;
                }
                else
                {
                    cartitems = Enumerable.Empty<Cart>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(cartitems);
        }


        public ActionResult Create(int id)
        {
            string baseUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";

            username = (string)TempData["Username"];
            TempData["username"] = username;
            ProductViewModel productViewMode = new ProductViewModel();
            //productViewModel.Products = await _context.Products.Where(x => x.Id == id).Include(y=>y.CategoryId).FirstOrDefaultAsync();
            productViewMode.Products = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();

            var _data = _dbContext.Carts.Where(x => x.ProductId == id).FirstOrDefault();
                      
            UpdateCart updateCart = new UpdateCart();
            int prodQuantity = 0;
            if (_data == null)
            {
                prodQuantity = 1;
                Cart cart = new Cart()
                {
                    ProductId = (int)productViewMode.Products.Id,
                    ProductName = productViewMode.Products.Name,
                    ProductPrice = (prodQuantity * productViewMode.Products.Price).ToString(),
                    ProductQuantity = prodQuantity.ToString(),
                    UserName = username
                    //UserAddress = null
                };


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);

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
               List<Cart> oldCart = _dbContext.Carts.Where(x => x.ProductId == id).ToList();
                
                prodQuantity = Convert.ToInt32(oldCart[0].ProductQuantity) + 1;
                updateCart = new UpdateCart()
                {
                    ProductQuantity = prodQuantity.ToString(),
                    ProductPrice = ((decimal)productViewMode.Products.Price * prodQuantity).ToString(),
                    UserName = username,
                    UpdateStatus = true,
                    ProductName = oldCart[0].ProductName,
                    ProductId = oldCart[0].ProductId
                    //Id = 2,
                    //UserAddress = null
                };
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

        public async Task<IActionResult> Decrease(long id)
        {
            string baseUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";

            username = (string)TempData["Username"];
            TempData["username"] = username;

            bool updatesttaus = false;
            Product product = _dbContext.Products.Find(id);
            //List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();
            List<Cart> cartItem = _dbContext.Carts.Where(c => c.ProductId == id).ToList();

            UpdateCart updatecart = new UpdateCart()
            {
                ProductId = cartItem[0].ProductId,
                ProductName = cartItem[0].ProductName,
                ProductPrice = cartItem[0].ProductPrice,
                UpdateStatus = updatesttaus,
                UserName = username
            };

            if (Convert.ToInt32(cartItem[0].ProductQuantity) > 1)
            {
                int totalproductquantity = Convert.ToInt32(cartItem[0].ProductQuantity) - 1;
                updatecart.ProductQuantity = totalproductquantity.ToString();
                updatecart.ProductPrice = (Convert.ToDecimal(product.Price) * totalproductquantity).ToString();
            }

            if (Convert.ToInt32(cartItem[0].ProductQuantity) == 1)
            {
                updatecart.ProductQuantity = "0";
                updatecart.ProductPrice = "0";
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);


                //HTTP DELETE
                var putTask = client.PutAsJsonAsync<UpdateCart>("cart/Update", updatecart);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            string baseUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";

            username = (string)TempData["Username"];
            TempData["username"] = username;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("cart/DeleteCart/" + username);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
