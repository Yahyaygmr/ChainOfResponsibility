using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        private readonly Context _context;

        public AreaDirector(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    EmployeeName = "Ersen Kaçar",
                    Description = "İstenen turar bölge yöneticisi tarafından ödendi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    EmployeeName = "Ersen Kaçar",
                    Description = "Tutar günlük ödeme limitinin üzerinde olduğundan ödeme yapılamadı. Müşteriye bilgi verildi"
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }

    }
}
