using System.Collections.Generic;
using System.Web.Mvc;

namespace MaksimHladki.Web.Infrastructure
{
    public static class SelectListItemExt
    {
        public static List<SelectListItem> SelectValue(this List<SelectListItem> list, string value)
        {
            foreach (var selectListItem in list)
            {
                selectListItem.Selected = selectListItem.Value == value;
            }

            return list;
        }
    }
}