using System.Collections.Generic;

namespace MaksimHladki.BusinessLayer.Model
{
    public sealed class DepotCalculateDrugTypeModel
    {
        public int DepotId { get; set; }
        public List<DepotCalculateDrugTypeItemModel> DrugTypes { get; set; }
    }

    public sealed class DepotCalculateDrugTypeItemModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}