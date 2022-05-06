using System;


namespace WebGym.Domain.ViewModels
{
    public class AbstractAccountModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    }
}
