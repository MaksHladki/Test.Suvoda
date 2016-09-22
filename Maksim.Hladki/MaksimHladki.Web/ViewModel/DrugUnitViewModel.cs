namespace MaksimHladki.Web.ViewModel
{
    public class DrugUnitViewModel
    {
        public string Id { get; set; }
        public int PickNumber { get; set; }
        public int DrugTypeId { get; set; }
        public int? DepotId { get; set; }
        public DrugTypeViewModel DrugType { get; set; }
    }
}