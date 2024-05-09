using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class Manager : Employee
    {
        private readonly Context _context;

        public Manager(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess()
                {
                    Amount = model.Amount,
                    Name = model.Name,
                    EmployeeName = "Ömer Faruk Gözegir",
                    Description = "İstenen turar şube müdürü tarafından ödendi."
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
                    EmployeeName = "Ömer Faruk Gözegir",
                    Description = "Ödeme yapılamadı, İşlem bölge müdürüne yönlendirildi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }

    }
}
