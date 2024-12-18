
namespace Sales.web.Controllers
{
    [Authorize]
    public class ClientsController(ApplicationDbContext context, IMapper mapper) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public IActionResult Index()
        {
            return View("Form");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(" That is Invalid");

            var isFound = _context.Clients.Any(c => c.FullName == model.FullName);

            if (isFound)
                return BadRequest("يوجد عميل بنفس الاسم");

            var client = _mapper.Map<Client>(model);

            _context.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Create", "Orders");
        }

        public IActionResult ShowAllClients()
        {
            var clients = _context.Clients.ToList();
            var viewModel = _mapper.Map<IEnumerable<ClientFormViewModel>>(clients);

            return View("ShowClients", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var client = _context.Clients.Find(id);

            if (client is null)
                return NotFound();

            var viewModel = _mapper.Map<ClientFormViewModel>(client);

            return View("Create", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = _context.Clients.Find(viewModel.Id);

            if (client == null)
                return NotFound();

            var model = _mapper.Map(viewModel, client);
            _context.SaveChanges();

            return RedirectToAction("Create", "Orders");
        }

        [Authorize(Roles = "Admin,FirstManager")]
        public IActionResult CreateAccount()
        {
            return View("FormAccount");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,FirstManager")]
        public IActionResult CreateAccount(AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(" That is Invalid");

            var isFound = _context.Accounts.Any(c => c.Title == model.Title);

            if (isFound)
                return BadRequest("يوجد حساب بنفس الاسم");

            var account = _mapper.Map<Account>(model);

            _context.Add(account);
            _context.SaveChanges();

            return RedirectToAction("ShowAllAccounts", "Clients");
        }

        [Authorize(Roles = "Admin,FirstManager")]
        public IActionResult ShowAllAccounts()
        {
            var clients = _context.Accounts.ToList();
            var viewModel = _mapper.Map<IEnumerable<AccountViewModel>>(clients);

            return View("ShowAllAccounts", viewModel);
        }

        [Authorize(Roles = "Admin,FirstManager")]
        public IActionResult EditAccount(int id)
        {
            var account = _context.Accounts.Find(id);

            if (account is null)
                return NotFound();

            var viewModel = _mapper.Map<AccountViewModel>(account);

            return View("FormAccount", viewModel);
        }
        [Authorize(Roles = "Admin,FirstManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAccount(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var account = _context.Accounts.Find(viewModel.Id);

            if (account == null)
                return NotFound();

            viewModel.LastUpdatedOn = DateTime.Now;
            var model = _mapper.Map(viewModel, account);

            _context.SaveChanges();

            return RedirectToAction("ShowAllAccounts", "Clients");
        }

        public IActionResult AllowItem(ClientFormViewModel model)
        {
            var client = _context.Clients.SingleOrDefault(b => b.FullName == model.FullName);
            var isAllowed = client is null || client.Id.Equals(model.Id);

            return Json(isAllowed);
        }
    }
}
