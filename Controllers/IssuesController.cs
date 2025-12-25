using Microsoft.AspNetCore.Mvc; // MVC controller için
using CommonIssues.Models; // Model ve DbContext için
using System.Linq; // LINQ sorguları için

namespace CommonIssues.Controllers // Controller namespace
{
    public class IssuesController : Controller
    {
        private readonly CommonIssuesContext _context; // DbContext değişkeni burada

        public IssuesController(CommonIssuesContext context)
        {
            _context = context; // Constructor ile context alır
        }

        public IActionResult Index(string search)
{
    var issues = _context.Issues.AsQueryable(); // Sorguyu başlatır

    if (!string.IsNullOrEmpty(search)) // Arama varsa şartı koyuyorum
    {
        issues = issues.Where(i => i.Title.Contains(search)); // Başlığa göre filtre
    }

    return View(issues.ToList()); // Listeyi View’a gönderme
}

        public IActionResult Create()
{
            return View(); // Boş formu gösterir
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Issue issue)
        {
            if (ModelState.IsValid) // Model doğrulaması
            {
                issue.CreatedDate = DateTime.Now; // Oluşturulma tarihi
                _context.Issues.Add(issue);       // Veriyi ekle
                _context.SaveChanges();            // DB’ye yaz
                return RedirectToAction(nameof(Index)); // Listeye dön
            }

            return View(issue); // Hata varsa formu tekrar göster
        }
            // GET: Issues/Edit/5
          public IActionResult Edit(int id)
{
    var issue = _context.Issues.Find(id);
    return View(issue);
}


            // POST: Issues/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Issue issue)
{
    if (ModelState.IsValid)
    {
        _context.Issues.Update(issue);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(issue);
}





          // GET: Issues/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var issue = _context.Issues.FirstOrDefault(i => i.Id == id);

            if (issue == null)
                return NotFound();

            return View(issue);
        }
            // POST: Issues/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                var issue = _context.Issues.Find(id);

                if (issue != null)
                {
                    _context.Issues.Remove(issue);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

    }
}
