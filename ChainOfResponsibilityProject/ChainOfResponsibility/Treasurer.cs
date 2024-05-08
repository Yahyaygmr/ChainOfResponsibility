using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        private readonly Context _context;

        public Treasurer(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    Description = "istenen tutar müşteriye ödendi",
                    EmployeeName = "Batuhan Zanlıer"
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    EmployeeName = "Batuhan Zanlıer",
                    Description = "Ödeme veznadar tarafından yapılamadı. Şube müdür yardımcısına yönlendirildi.",
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }

        }
    }
}
