using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Dto
{
    public class ViewCreateBook
    {
        public IEnumerable<SelectListItemDto>? TheLoai { get; set; }
        public IEnumerable<SelectListItemDto>? NhaXuatBan { get; set; }
        public IEnumerable<SelectListItemDto>? TacGia { get; set; }
    }
    public class SelectListItemDto
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
    }
}