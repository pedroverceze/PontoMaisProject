namespace PontoMaisDomain.Companies.Dto
{
    public class AddCompanyRequestDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Sector { get; set; }
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
    }
}
