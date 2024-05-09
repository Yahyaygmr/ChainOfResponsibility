using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        private readonly Context _context;

        public ManagerAsistant(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    EmployeeName = "Elif Çalış",
                    Description = "İstenen turar şube müdür yardımcısı tarafından ödendi."
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
                    EmployeeName = "Elif Çalış",
                    Description = "Ödeme yapılamadı, İşlem şube müdürüne yönlendirildi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }
    }
}
