using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sales.web.Controllers
{
    [Authorize]
    public class OrdersController(ApplicationDbContext context, IMapper mapper) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin,FirstManager,FirstSales")]
        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.Client).Include(o => o.DetailsOfItem).ToList();
            var viewModel = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,FirstSales")]
        public IActionResult Create()
        {
            var clients = _context.Clients.OrderBy(x => x.FullName).ToList();
            var items = _context.Items.OrderBy(x => x.Title).ToList();

            var viewModel = new OrderFormViewModel();

            viewModel.Items = _mapper.Map<IEnumerable<SelectListItem>>(items);
            viewModel.Clients = _mapper.Map<IEnumerable<SelectListItem>>(clients);

            return View("Form", viewModel);
        }


        [Authorize(Roles = "Admin,FirstSales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderFormViewModel newOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Console.Write("good");

            var selectedItems = _context.Items        //sort      
                .Where(c => newOrder.SelectedItems.Contains(c.Id))
                .ToList();

            var toStore = -1;
            if (newOrder.ToStore)
                toStore = 1;

            int count = 0, conNum = 1, conSort = 1;
            double? sum = 0;
            var test = new List<int>();
            var model = _mapper.Map<Order>(newOrder);

            foreach (var item in selectedItems)
            {
                //if(newOrder.SortOfNum[conNum + 2] is not null)
                var sourcePrice = (newOrder.SortOfNum[conNum + 2] == null || newOrder.SortOfNum[conNum + 2] <= 0) ? item.TheSourcePrice : newOrder.SortOfNum[conNum + 2];

                var numStore = newOrder.SortOfNum[conNum + 3];
                if (newOrder.Title[conSort] == item.SortOfQuantity1)
                {

                    var storeThis = toStore * (newOrder.SortOfNum[conNum] / item.NumQuantity1InQuantity2 / item.NumQuantity2InQuantity3);
                    //(numStore == 2) ? item.Store2 += storeThis : (numStore == 3) ? item.Store3 += storeThis : item.Store1 += storeThis;
                    if (numStore == 2)
                    {
                        if (item.Store2 < -storeThis || (item.Store2 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن1");
                        item.Store2 += storeThis;
                    }
                    else if (numStore == 3)
                    {
                        if (item.Store3 < -storeThis || (item.Store3 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن2");
                        item.Store3 += storeThis;
                    }
                    else
                    {
                        if (item.Store1 < -storeThis || (item.Store1 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى صاله العرض");
                        item.Store1 += storeThis;
                    }
                    sum = item.Store1;
                    item.TheSourcePrice = sourcePrice ?? item.TheSourcePrice;
                }
                else if (newOrder.Title[conSort] == item.SortOfQuantity2)
                {
                    var storeThis = toStore * (newOrder.SortOfNum[conNum] / item.NumQuantity2InQuantity3);
                    item.TheSourcePrice = sourcePrice ?? item.TheSourcePrice;
                    sum = item.Store1;
                    if (numStore == 2)
                    {
                        if (item.Store2 < -storeThis || (item.Store2 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن1");
                        item.Store2 += storeThis;
                    }
                    else if (numStore == 3)
                    {
                        if (item.Store3 < -storeThis || (item.Store3 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن2");
                        item.Store3 += storeThis;
                    }
                    else
                    {
                        if (item.Store1 < -storeThis || (item.Store1 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى صاله العرض");
                        item.Store1 += storeThis;
                    }
                }
                else
                {
                    var storeThis = toStore * newOrder.SortOfNum[conNum];
                    item.TheSourcePrice = sourcePrice ?? item.TheSourcePrice;
                    sum = item.Store1;
                    if (numStore == 2)
                    {
                        if (item.Store2 < -storeThis || (item.Store2 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن1");
                        item.Store2 += storeThis;
                    }
                    else if (numStore == 3)
                    {
                        if (item.Store3 < -storeThis || (item.Store3 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى مخزن2");
                        item.Store3 += storeThis;
                    }
                    else
                    {
                        if (item.Store1 < -storeThis || (item.Store1 == null && storeThis < 0))
                            return BadRequest($"{newOrder.Title[conSort - 1]} مش موجوده فى صاله العرض");
                        item.Store1 += storeThis;
                    }
                }
                if (item.Store1 < 0 || item.Store3 < 0 || item.Store2 < 0)
                    return BadRequest($"{newOrder.Title[conSort - 1]} مش موجود");

                //_context.UpdateRange(item);

                var itemDetails = new ItemDetails()
                {
                    //OrderId = model.Id,
                    Orders = model,
                    Title = newOrder.Title[conSort - 1],
                    SortOfQuantity = newOrder.Title[conSort],
                    NumberOfQuantity = newOrder.SortOfNum[conNum],
                    PriceOfItem = newOrder.SortOfNum[conNum - 1],
                    TotalOfPrice = newOrder.SortOfNum[conNum + 1]
                };
                _context.ItemsDetails.Add(itemDetails);


                if (newOrder.ClientId >= 0)
                {
                    var client = _context.Clients.Find(newOrder.ClientId);//
                                                                          //.SingleOrDefault(i => i.Id == model.ClientId);
                    client.Account += newOrder.TheRest;
                }

                count++; conSort += 2; conNum += 5;
                test.Add(item.Id);
            };

            _context.Orders.Add(model);
            _context.SaveChanges();

            //return Ok(newOrder);
            return RedirectToAction("Create", "Orders");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult GetQualityPrices(int id)
        {
            var item = _context.Items.Find(id);
            //return Ok(item);
            //return View();
            item.Store1 = item.Store1 ?? 0;
            item.Store2 = item.Store2 ?? 0;
            item.Store3 = item.Store3 ?? 0;
            var itemStore1 = Math.Round((double)item.Store1, 2);
            var itemStore2 = Math.Round((double)item.Store2, 2);
            var itemStore3 = Math.Round((double)item.Store3, 2);
            return Ok(new
            {
                q1 = item.Quantity1,
                q2 = item.Quantity2,
                q3 = item.Quantity3,
                title = item.Title
                ,
                srtQuality1 = item.SortOfQuantity1,
                srtQuality2 = item.SortOfQuantity2,
                srtQuality3 = item.SortOfQuantity3
                ,
                srcPrice = item.TheSourcePrice,
                stor1 = itemStore1,
                stor2 = itemStore2,
                stor3 = itemStore3
            });
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult GetTheRestOfClient(int id)
        {
            var client = _context.Clients.Find(id);

            if (client is null)
                return NotFound("مش موجود");

            return Ok(new { act = client.Account, srt = client.SortOfQuality, teleph = client.PhoneNumber, city = client.Email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetItemDetails(AddItemViewModel model)
        {
            return PartialView("_RowItem", model);
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateItem(ItemFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is InValid");

            var isFound = _context.Items.Any(c => c.Title == model.Title);

            if (isFound)
                return BadRequest("يوجد صنف بنفس الاسم");


            var item = _mapper.Map<Item>(model);

            _context.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Create", "Orders");
        }

        public IActionResult EditItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item is null)
                return NotFound();

            var model = _mapper.Map<ItemFormViewModel>(item);

            return View("CreateItem", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemFormViewModel? model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = _context.Items.Find(model?.Id);

            if (item is null)
                return NotFound();

            var viewModel = _mapper.Map(model, item);
            _context.SaveChanges();

            return RedirectToAction("Create", "Orders");
        }

        public IActionResult ShowItems()
        {
            var items = _context.Items.OrderBy(i => i.Store1 + i.Store2 + i.Store3).ToList();
            var viewModels = _mapper.Map<IEnumerable<ItemFormViewModel>>(items);
            return View(viewModels);
        }
        public IActionResult ShowItemsInStore1()
        {
            var items = _context.Items.Where(i => i.Store1 > 0).ToList();
            var viewModels = _mapper.Map<IEnumerable<ItemFormViewModel>>(items);
            return View("ShowItems", viewModels);
        }

        public IActionResult ShowItemsInStore2()
        {
            var items = _context.Items.Where(i => i.Store2 > 0).ToList();
            var viewModels = _mapper.Map<IEnumerable<ItemFormViewModel>>(items);
            return View("ShowItems", viewModels);
        }

        public IActionResult ShowItemsInStore3()
        {
            var items = _context.Items.Where(i => i.Store3 > 0).ToList();
            var viewModels = _mapper.Map<IEnumerable<ItemFormViewModel>>(items);
            return View("ShowItems", viewModels);
        }

        public IActionResult AllowItem(ItemFormViewModel model)
        {
            var item = _context.Items.SingleOrDefault(b => b.Title == model.Title);
            var isAllowed = item is null || item.Id.Equals(model.Id);

            return Json(isAllowed);
        }
    }
}
